using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using mediaTune;

namespace UserModule_GP_MEDIATUNE_REMOTE_CHANNEL_V0_4
{
    public class UserModuleClass_GP_MEDIATUNE_REMOTE_CHANNEL_V0_4 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput HTML_CONFIG_SET;
        Crestron.Logos.SplusObjects.AnalogInput INDEX;
        Crestron.Logos.SplusObjects.StringInput HTML_CHANNEL_FONT_SIZE;
        Crestron.Logos.SplusObjects.StringInput HTML_CHANNEL_FONT_FACE;
        Crestron.Logos.SplusObjects.StringInput HTML_CHANNEL_FONT_COLOR;
        Crestron.Logos.SplusObjects.StringInput HTML_CONTENT_FONT_SIZE;
        Crestron.Logos.SplusObjects.StringInput HTML_CONTENT_FONT_FACE;
        Crestron.Logos.SplusObjects.StringInput HTML_CONTENT_FONT_COLOR;
        Crestron.Logos.SplusObjects.StringOutput MESSAGE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput INDEX_FB;
        Crestron.Logos.SplusObjects.AnalogOutput ICONINDEX_FB;
        Crestron.Logos.SplusObjects.StringOutput HTML_CHANNEL_FONT_SIZE_FB;
        Crestron.Logos.SplusObjects.StringOutput HTML_CHANNEL_FONT_FACE_FB;
        Crestron.Logos.SplusObjects.StringOutput HTML_CHANNEL_FONT_COLOR_FB;
        Crestron.Logos.SplusObjects.StringOutput HTML_CONTENT_FONT_SIZE_FB;
        Crestron.Logos.SplusObjects.StringOutput HTML_CONTENT_FONT_FACE_FB;
        Crestron.Logos.SplusObjects.StringOutput HTML_CONTENT_FONT_COLOR_FB;
        Crestron.Logos.SplusObjects.StringOutput HTML_FORMAT_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> CHANNEL_DATA_FB;
        ushort G_IMYINDEX = 0;
        CrestronString _CHANNELSIZE_;
        CrestronString _CHANNELFACE_;
        CrestronString _CHANNELCOLOR_;
        CrestronString _CONTENTSIZE_;
        CrestronString _CONTENTFACE_;
        CrestronString _CONTENTCOLOR_;
        CrestronString HTML_CHANNEL_CONFIG;
        CrestronString HTML_CONTENT_CONFIG;
        private void FGET_CHANNEL_DATA (  SplusExecutionContext __context__ ) 
            { 
            ushort IDATAINDEX = 0;
            
            CrestronString [] SCHANNEL_DATA;
            SCHANNEL_DATA  = new CrestronString[ 13 ];
            for( uint i = 0; i < 13; i++ )
                SCHANNEL_DATA [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            CrestronString SHTML;
            SHTML  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
            
            
            __context__.SourceCodeLine = 110;
            try 
                { 
                __context__.SourceCodeLine = 112;
                if ( Functions.TestForTrue  ( ( G_IMYINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 114;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)(12 - 1); 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IDATAINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDATAINDEX  >= __FN_FORSTART_VAL__1) && (IDATAINDEX  <= __FN_FOREND_VAL__1) ) : ( (IDATAINDEX  <= __FN_FORSTART_VAL__1) && (IDATAINDEX  >= __FN_FOREND_VAL__1) ) ; IDATAINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 116;
                        SCHANNEL_DATA [ IDATAINDEX ]  .UpdateValue ( RemoteCore . getChannelData ( (ushort)( G_IMYINDEX ), (ushort)( (IDATAINDEX - 1) ))  ) ; 
                        __context__.SourceCodeLine = 117;
                        CHANNEL_DATA_FB [ IDATAINDEX]  .UpdateValue ( SCHANNEL_DATA [ IDATAINDEX ]  ) ; 
                        __context__.SourceCodeLine = 114;
                        } 
                    
                    __context__.SourceCodeLine = 120;
                    ICONINDEX_FB  .Value = (ushort) ( Functions.Atoi( SCHANNEL_DATA[ 10 ] ) ) ; 
                    __context__.SourceCodeLine = 122;
                    SHTML  .UpdateValue ( "<P>"  ) ; 
                    __context__.SourceCodeLine = 123;
                    SHTML  .UpdateValue ( SHTML + HTML_CHANNEL_CONFIG + SCHANNEL_DATA [ 1 ] + " - " + SCHANNEL_DATA [ 3 ] + "</FONT><BR>"  ) ; 
                    __context__.SourceCodeLine = 124;
                    SHTML  .UpdateValue ( SHTML + HTML_CONTENT_CONFIG + "Now:  " + SCHANNEL_DATA [ 6 ] + "<BR>Next:  " + SCHANNEL_DATA [ 7 ] + "</FONT>"  ) ; 
                    __context__.SourceCodeLine = 125;
                    SHTML  .UpdateValue ( SHTML + "</P>"  ) ; 
                    __context__.SourceCodeLine = 126;
                    HTML_FORMAT_FB  .UpdateValue ( SHTML  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 130;
                    MakeString ( MESSAGE_FB , "Function fget_Channel_Data Ignored: g_iMyIndex Zero.") ; 
                    } 
                
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 135;
                MakeString ( MESSAGE_FB , "Function fget_Channel_Data Exception: {0}", Functions.GetExceptionMessage (  __splus_exceptionobj__ ) ) ; 
                
                }
                
                
                }
                
            private void FCHANNELSIZE (  SplusExecutionContext __context__, CrestronString S ) 
                { 
                
                __context__.SourceCodeLine = 142;
                if ( Functions.TestForTrue  ( ( Functions.Length( S ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 144;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atoi( S ) > 5 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 146;
                        _CHANNELSIZE_  .UpdateValue ( S  ) ; 
                        __context__.SourceCodeLine = 147;
                        HTML_CHANNEL_FONT_SIZE_FB  .UpdateValue ( _CHANNELSIZE_  ) ; 
                        __context__.SourceCodeLine = 148;
                        return ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 151;
                MakeString ( MESSAGE_FB , "Err setting HTML Channel font Size.") ; 
                
                }
                
            private void FCHANNELFACE (  SplusExecutionContext __context__, CrestronString S ) 
                { 
                
                __context__.SourceCodeLine = 156;
                if ( Functions.TestForTrue  ( ( Functions.Length( S ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 158;
                    _CHANNELFACE_  .UpdateValue ( S  ) ; 
                    __context__.SourceCodeLine = 159;
                    HTML_CHANNEL_FONT_FACE_FB  .UpdateValue ( _CHANNELFACE_  ) ; 
                    __context__.SourceCodeLine = 160;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 162;
                MakeString ( MESSAGE_FB , "Err setting HTML Channel font Face.") ; 
                
                }
                
            private void FCHANNELCOLOR (  SplusExecutionContext __context__, CrestronString S ) 
                { 
                
                __context__.SourceCodeLine = 167;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( S ) == 6))  ) ) 
                    { 
                    __context__.SourceCodeLine = 169;
                    _CHANNELCOLOR_  .UpdateValue ( S  ) ; 
                    __context__.SourceCodeLine = 170;
                    HTML_CHANNEL_FONT_COLOR_FB  .UpdateValue ( _CHANNELCOLOR_  ) ; 
                    __context__.SourceCodeLine = 171;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 173;
                MakeString ( MESSAGE_FB , "Err setting HTML Channel fron Color.") ; 
                
                }
                
            private void FCONTENTSIZE (  SplusExecutionContext __context__, CrestronString S ) 
                { 
                
                __context__.SourceCodeLine = 178;
                if ( Functions.TestForTrue  ( ( Functions.Length( S ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 180;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atoi( S ) > 5 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 182;
                        _CONTENTSIZE_  .UpdateValue ( S  ) ; 
                        __context__.SourceCodeLine = 183;
                        HTML_CONTENT_FONT_SIZE_FB  .UpdateValue ( _CONTENTSIZE_  ) ; 
                        __context__.SourceCodeLine = 184;
                        return ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 187;
                MakeString ( MESSAGE_FB , "Err setting HTML Content font Size.") ; 
                
                }
                
            private void FCONTENTFACE (  SplusExecutionContext __context__, CrestronString S ) 
                { 
                
                __context__.SourceCodeLine = 192;
                if ( Functions.TestForTrue  ( ( Functions.Length( S ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 194;
                    _CONTENTFACE_  .UpdateValue ( S  ) ; 
                    __context__.SourceCodeLine = 195;
                    HTML_CONTENT_FONT_FACE_FB  .UpdateValue ( _CONTENTFACE_  ) ; 
                    __context__.SourceCodeLine = 196;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 198;
                MakeString ( MESSAGE_FB , "Err setting HTML Content font Face.") ; 
                
                }
                
            private void FCONTENTCOLOR (  SplusExecutionContext __context__, CrestronString S ) 
                { 
                
                __context__.SourceCodeLine = 203;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( S ) == 6))  ) ) 
                    { 
                    __context__.SourceCodeLine = 205;
                    _CONTENTCOLOR_  .UpdateValue ( S  ) ; 
                    __context__.SourceCodeLine = 206;
                    HTML_CONTENT_FONT_COLOR_FB  .UpdateValue ( _CONTENTCOLOR_  ) ; 
                    __context__.SourceCodeLine = 207;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 209;
                MakeString ( MESSAGE_FB , "Err setting HTML Content fron Color.") ; 
                
                }
                
            private void FHTML_CONFIG_SET (  SplusExecutionContext __context__ ) 
                { 
                
                __context__.SourceCodeLine = 214;
                MakeString ( HTML_CHANNEL_CONFIG , "<Font size=\u0022{0}\u0022 face=\u0022{1}\u0022 color=\u0022#{2}\u0022>", _CHANNELSIZE_ , _CHANNELFACE_ , _CHANNELCOLOR_ ) ; 
                __context__.SourceCodeLine = 215;
                MakeString ( HTML_CONTENT_CONFIG , "<Font size=\u0022{0}\u0022 face=\u0022{1}\u0022 color=\u0022#{2}\u0022>", _CONTENTSIZE_ , _CONTENTFACE_ , _CONTENTCOLOR_ ) ; 
                
                }
                
            public void ECHANNEL_INDEX ( object __sender__ /*mediaTune.ChannelIndexEventArgs E */) 
                { 
                ChannelIndexEventArgs  E  = (ChannelIndexEventArgs )__sender__;
                try
                {
                    SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                    
                    __context__.SourceCodeLine = 221;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (E.Channel_Index == G_IMYINDEX))  ) ) 
                        { 
                        __context__.SourceCodeLine = 223;
                        FGET_CHANNEL_DATA (  __context__  ) ; 
                        } 
                    
                    
                    
                }
                finally { ObjectFinallyHandler(); }
                }
                
            object INDEX_OnChange_0 ( Object __EventInfo__ )
            
                { 
                Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
                try
                {
                    SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                    
                    __context__.SourceCodeLine = 230;
                    if ( Functions.TestForTrue  ( ( INDEX  .UshortValue)  ) ) 
                        { 
                        __context__.SourceCodeLine = 232;
                        G_IMYINDEX = (ushort) ( INDEX  .UshortValue ) ; 
                        __context__.SourceCodeLine = 233;
                        INDEX_FB  .Value = (ushort) ( G_IMYINDEX ) ; 
                        __context__.SourceCodeLine = 234;
                        try 
                            { 
                            __context__.SourceCodeLine = 236;
                            if ( Functions.TestForTrue  ( ( ChannelCount_Remote.ChannelCount)  ) ) 
                                { 
                                __context__.SourceCodeLine = 238;
                                FGET_CHANNEL_DATA (  __context__  ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 242;
                                MakeString ( MESSAGE_FB , "Change Index Event : Channel Count = Zero (Not initialized?).") ; 
                                } 
                            
                            } 
                        
                        catch (Exception __splus_exception__)
                            { 
                            SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                            
                            __context__.SourceCodeLine = 247;
                            MakeString ( MESSAGE_FB , "Change Index Event Exception: {0}", Functions.GetExceptionMessage (  __splus_exceptionobj__ ) ) ; 
                            
                            }
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 252;
                            MakeString ( MESSAGE_FB , "Change Index Event: Ignored Index Zero Value.") ; 
                            } 
                        
                        
                        
                    }
                    catch(Exception e) { ObjectCatchHandler(e); }
                    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                    return this;
                    
                }
                
            object HTML_CONFIG_SET_OnPush_1 ( Object __EventInfo__ )
            
                { 
                Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
                try
                {
                    SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                    
                    __context__.SourceCodeLine = 256;
                    FHTML_CONFIG_SET (  __context__  ) ; 
                    
                    
                }
                catch(Exception e) { ObjectCatchHandler(e); }
                finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                return this;
                
            }
            
        object HTML_CHANNEL_FONT_SIZE_OnChange_2 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 257;
                FCHANNELSIZE (  __context__ , HTML_CHANNEL_FONT_SIZE) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object HTML_CHANNEL_FONT_FACE_OnChange_3 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 258;
            FCHANNELFACE (  __context__ , HTML_CHANNEL_FONT_FACE) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object HTML_CHANNEL_FONT_COLOR_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 259;
        FCHANNELCOLOR (  __context__ , HTML_CHANNEL_FONT_COLOR) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HTML_CONTENT_FONT_SIZE_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 260;
        FCONTENTSIZE (  __context__ , HTML_CONTENT_FONT_SIZE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HTML_CONTENT_FONT_FACE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 261;
        FCONTENTFACE (  __context__ , HTML_CONTENT_FONT_FACE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HTML_CONTENT_FONT_COLOR_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 262;
        FCONTENTCOLOR (  __context__ , HTML_CONTENT_FONT_COLOR) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 266;
        FCHANNELSIZE (  __context__ , "12") ; 
        __context__.SourceCodeLine = 267;
        FCHANNELFACE (  __context__ , "Arial") ; 
        __context__.SourceCodeLine = 268;
        FCHANNELCOLOR (  __context__ , "FFFFFF") ; 
        __context__.SourceCodeLine = 269;
        FCONTENTSIZE (  __context__ , "12") ; 
        __context__.SourceCodeLine = 270;
        FCONTENTFACE (  __context__ , "Arial") ; 
        __context__.SourceCodeLine = 271;
        FCONTENTCOLOR (  __context__ , "FFFFFF") ; 
        __context__.SourceCodeLine = 273;
        FHTML_CONFIG_SET (  __context__  ) ; 
        __context__.SourceCodeLine = 275;
        // RegisterEvent( ChannelIndex , ONCHANNELINDEX_DATA_CHANGE , ECHANNEL_INDEX ) 
        try { g_criticalSection.Enter(); ChannelIndex .onChannelIndex_Data_Change  += ECHANNEL_INDEX; } finally { g_criticalSection.Leave(); }
        ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    _CHANNELSIZE_  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    _CHANNELFACE_  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
    _CHANNELCOLOR_  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
    _CONTENTSIZE_  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    _CONTENTFACE_  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
    _CONTENTCOLOR_  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
    HTML_CHANNEL_CONFIG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    HTML_CONTENT_CONFIG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 384, this );
    
    HTML_CONFIG_SET = new Crestron.Logos.SplusObjects.DigitalInput( HTML_CONFIG_SET__DigitalInput__, this );
    m_DigitalInputList.Add( HTML_CONFIG_SET__DigitalInput__, HTML_CONFIG_SET );
    
    INDEX = new Crestron.Logos.SplusObjects.AnalogInput( INDEX__AnalogSerialInput__, this );
    m_AnalogInputList.Add( INDEX__AnalogSerialInput__, INDEX );
    
    INDEX_FB = new Crestron.Logos.SplusObjects.AnalogOutput( INDEX_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( INDEX_FB__AnalogSerialOutput__, INDEX_FB );
    
    ICONINDEX_FB = new Crestron.Logos.SplusObjects.AnalogOutput( ICONINDEX_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ICONINDEX_FB__AnalogSerialOutput__, ICONINDEX_FB );
    
    HTML_CHANNEL_FONT_SIZE = new Crestron.Logos.SplusObjects.StringInput( HTML_CHANNEL_FONT_SIZE__AnalogSerialInput__, 3, this );
    m_StringInputList.Add( HTML_CHANNEL_FONT_SIZE__AnalogSerialInput__, HTML_CHANNEL_FONT_SIZE );
    
    HTML_CHANNEL_FONT_FACE = new Crestron.Logos.SplusObjects.StringInput( HTML_CHANNEL_FONT_FACE__AnalogSerialInput__, 32, this );
    m_StringInputList.Add( HTML_CHANNEL_FONT_FACE__AnalogSerialInput__, HTML_CHANNEL_FONT_FACE );
    
    HTML_CHANNEL_FONT_COLOR = new Crestron.Logos.SplusObjects.StringInput( HTML_CHANNEL_FONT_COLOR__AnalogSerialInput__, 6, this );
    m_StringInputList.Add( HTML_CHANNEL_FONT_COLOR__AnalogSerialInput__, HTML_CHANNEL_FONT_COLOR );
    
    HTML_CONTENT_FONT_SIZE = new Crestron.Logos.SplusObjects.StringInput( HTML_CONTENT_FONT_SIZE__AnalogSerialInput__, 3, this );
    m_StringInputList.Add( HTML_CONTENT_FONT_SIZE__AnalogSerialInput__, HTML_CONTENT_FONT_SIZE );
    
    HTML_CONTENT_FONT_FACE = new Crestron.Logos.SplusObjects.StringInput( HTML_CONTENT_FONT_FACE__AnalogSerialInput__, 32, this );
    m_StringInputList.Add( HTML_CONTENT_FONT_FACE__AnalogSerialInput__, HTML_CONTENT_FONT_FACE );
    
    HTML_CONTENT_FONT_COLOR = new Crestron.Logos.SplusObjects.StringInput( HTML_CONTENT_FONT_COLOR__AnalogSerialInput__, 6, this );
    m_StringInputList.Add( HTML_CONTENT_FONT_COLOR__AnalogSerialInput__, HTML_CONTENT_FONT_COLOR );
    
    MESSAGE_FB = new Crestron.Logos.SplusObjects.StringOutput( MESSAGE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( MESSAGE_FB__AnalogSerialOutput__, MESSAGE_FB );
    
    HTML_CHANNEL_FONT_SIZE_FB = new Crestron.Logos.SplusObjects.StringOutput( HTML_CHANNEL_FONT_SIZE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HTML_CHANNEL_FONT_SIZE_FB__AnalogSerialOutput__, HTML_CHANNEL_FONT_SIZE_FB );
    
    HTML_CHANNEL_FONT_FACE_FB = new Crestron.Logos.SplusObjects.StringOutput( HTML_CHANNEL_FONT_FACE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HTML_CHANNEL_FONT_FACE_FB__AnalogSerialOutput__, HTML_CHANNEL_FONT_FACE_FB );
    
    HTML_CHANNEL_FONT_COLOR_FB = new Crestron.Logos.SplusObjects.StringOutput( HTML_CHANNEL_FONT_COLOR_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HTML_CHANNEL_FONT_COLOR_FB__AnalogSerialOutput__, HTML_CHANNEL_FONT_COLOR_FB );
    
    HTML_CONTENT_FONT_SIZE_FB = new Crestron.Logos.SplusObjects.StringOutput( HTML_CONTENT_FONT_SIZE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HTML_CONTENT_FONT_SIZE_FB__AnalogSerialOutput__, HTML_CONTENT_FONT_SIZE_FB );
    
    HTML_CONTENT_FONT_FACE_FB = new Crestron.Logos.SplusObjects.StringOutput( HTML_CONTENT_FONT_FACE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HTML_CONTENT_FONT_FACE_FB__AnalogSerialOutput__, HTML_CONTENT_FONT_FACE_FB );
    
    HTML_CONTENT_FONT_COLOR_FB = new Crestron.Logos.SplusObjects.StringOutput( HTML_CONTENT_FONT_COLOR_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HTML_CONTENT_FONT_COLOR_FB__AnalogSerialOutput__, HTML_CONTENT_FONT_COLOR_FB );
    
    HTML_FORMAT_FB = new Crestron.Logos.SplusObjects.StringOutput( HTML_FORMAT_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HTML_FORMAT_FB__AnalogSerialOutput__, HTML_FORMAT_FB );
    
    CHANNEL_DATA_FB = new InOutArray<StringOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        CHANNEL_DATA_FB[i+1] = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_DATA_FB__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( CHANNEL_DATA_FB__AnalogSerialOutput__ + i, CHANNEL_DATA_FB[i+1] );
    }
    
    
    INDEX.OnAnalogChange.Add( new InputChangeHandlerWrapper( INDEX_OnChange_0, false ) );
    HTML_CONFIG_SET.OnDigitalPush.Add( new InputChangeHandlerWrapper( HTML_CONFIG_SET_OnPush_1, false ) );
    HTML_CHANNEL_FONT_SIZE.OnSerialChange.Add( new InputChangeHandlerWrapper( HTML_CHANNEL_FONT_SIZE_OnChange_2, false ) );
    HTML_CHANNEL_FONT_FACE.OnSerialChange.Add( new InputChangeHandlerWrapper( HTML_CHANNEL_FONT_FACE_OnChange_3, false ) );
    HTML_CHANNEL_FONT_COLOR.OnSerialChange.Add( new InputChangeHandlerWrapper( HTML_CHANNEL_FONT_COLOR_OnChange_4, false ) );
    HTML_CONTENT_FONT_SIZE.OnSerialChange.Add( new InputChangeHandlerWrapper( HTML_CONTENT_FONT_SIZE_OnChange_5, false ) );
    HTML_CONTENT_FONT_FACE.OnSerialChange.Add( new InputChangeHandlerWrapper( HTML_CONTENT_FONT_FACE_OnChange_6, false ) );
    HTML_CONTENT_FONT_COLOR.OnSerialChange.Add( new InputChangeHandlerWrapper( HTML_CONTENT_FONT_COLOR_OnChange_7, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_MEDIATUNE_REMOTE_CHANNEL_V0_4 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint HTML_CONFIG_SET__DigitalInput__ = 0;
const uint INDEX__AnalogSerialInput__ = 0;
const uint HTML_CHANNEL_FONT_SIZE__AnalogSerialInput__ = 1;
const uint HTML_CHANNEL_FONT_FACE__AnalogSerialInput__ = 2;
const uint HTML_CHANNEL_FONT_COLOR__AnalogSerialInput__ = 3;
const uint HTML_CONTENT_FONT_SIZE__AnalogSerialInput__ = 4;
const uint HTML_CONTENT_FONT_FACE__AnalogSerialInput__ = 5;
const uint HTML_CONTENT_FONT_COLOR__AnalogSerialInput__ = 6;
const uint MESSAGE_FB__AnalogSerialOutput__ = 0;
const uint INDEX_FB__AnalogSerialOutput__ = 1;
const uint ICONINDEX_FB__AnalogSerialOutput__ = 2;
const uint HTML_CHANNEL_FONT_SIZE_FB__AnalogSerialOutput__ = 3;
const uint HTML_CHANNEL_FONT_FACE_FB__AnalogSerialOutput__ = 4;
const uint HTML_CHANNEL_FONT_COLOR_FB__AnalogSerialOutput__ = 5;
const uint HTML_CONTENT_FONT_SIZE_FB__AnalogSerialOutput__ = 6;
const uint HTML_CONTENT_FONT_FACE_FB__AnalogSerialOutput__ = 7;
const uint HTML_CONTENT_FONT_COLOR_FB__AnalogSerialOutput__ = 8;
const uint HTML_FORMAT_FB__AnalogSerialOutput__ = 9;
const uint CHANNEL_DATA_FB__AnalogSerialOutput__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
