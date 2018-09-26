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

namespace UserModule_GP_BSS_GAIN_MONO_ENGINE_R0_2
{
    public class UserModuleClass_GP_BSS_GAIN_MONO_ENGINE_R0_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput OBJECT_ID;
        Crestron.Logos.SplusObjects.AnalogInput CHAN_VOL;
        Crestron.Logos.SplusObjects.AnalogInput CHAN_POLARITY;
        Crestron.Logos.SplusObjects.AnalogInput CHAN_MUTE;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput OBJECT_ID_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN_VOL_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN_POLARITY_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN_MUTE_FB;
        CrestronString G_SOBJECT_ID;
        ushort G_INUM_CHAN_USED = 0;
        ushort G_ICHAN_VOL = 0;
        ushort G_IRX_OK = 0;
        CrestronString G_SREPLY;
        StringParameter DEFAULT_OBJECT_ID;
        private ushort FVOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort IRETURN = 0;
            
            
            __context__.SourceCodeLine = 93;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.BoolToInt (Functions.Mid( STR , (int)( 3 ) , (int)( 1 ) ) == "\u0000") ))  ) ) 
                { 
                __context__.SourceCodeLine = 95;
                IRETURN = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 2) + 1) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 99;
                IRETURN = (ushort) ( (Byte( STR , (int)( 2 ) ) * 2) ) ; 
                } 
            
            __context__.SourceCodeLine = 101;
            return (ushort)( IRETURN) ; 
            
            }
            
        private void FSET_VOLUMEPERCENT (  SplusExecutionContext __context__, ushort SV , ushort VOL_DATA ) 
            { 
            CrestronString SVOL;
            SVOL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 107;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( VOL_DATA , 2 ) == 0))  ) ) 
                {
                __context__.SourceCodeLine = 107;
                SVOL  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (VOL_DATA / 2) ) ) + "\u0000\u0000"  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 108;
                SVOL  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (VOL_DATA / 2) ) ) + "\u0080\u0000"  ) ; 
                }
            
            __context__.SourceCodeLine = 110;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) SV ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) SV ) ) ) , SVOL ) ; 
            
            }
            
        private void FSET_BOOLEAN (  SplusExecutionContext __context__, ushort SV , CrestronString BOOLEAN ) 
            { 
            
            __context__.SourceCodeLine = 115;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000{3}\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) SV ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) SV ) ) ) , BOOLEAN ) ; 
            __context__.SourceCodeLine = 117;
            if ( Functions.TestForTrue  ( ( SUBSCRIBE  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 118;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) SV ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) SV ) ) ) ) ; 
                }
            
            
            }
            
        private void FSUBSCRIBE (  SplusExecutionContext __context__, ushort DO_WHAT ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 125;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (DO_WHAT == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (DO_WHAT == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 127;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(G_INUM_CHAN_USED - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 129;
                    MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) I ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) I ) ) ) ) ; 
                    __context__.SourceCodeLine = 130;
                    MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) (I + 1) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) (I + 1) ) ) ) ) ; 
                    __context__.SourceCodeLine = 131;
                    MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) (I + 2) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) (I + 2) ) ) ) ) ; 
                    __context__.SourceCodeLine = 127;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 135;
            Functions.Delay (  (int) ( 20 ) ) ; 
            __context__.SourceCodeLine = 137;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (DO_WHAT == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (DO_WHAT == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 139;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 0 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)(G_INUM_CHAN_USED - 1); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 141;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) I ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) I ) ) ) ) ; 
                    __context__.SourceCodeLine = 142;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) (I + 1) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) (I + 1) ) ) ) ) ; 
                    __context__.SourceCodeLine = 143;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) (I + 2) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) (I + 2) ) ) ) ) ; 
                    __context__.SourceCodeLine = 139;
                    } 
                
                } 
            
            
            }
            
        private void FRESUBSCRIBE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 150;
            CreateWait ( "WRESUBSCRIBE" , 100 , WRESUBSCRIBE_Callback ) ;
            
            }
            
        public void WRESUBSCRIBE_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 152;
            FSUBSCRIBE (  __context__ , (ushort)( 2 )) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    object SUBSCRIBE_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 160;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( OBJECT_ID ) == 3))  ) ) 
                {
                __context__.SourceCodeLine = 160;
                FSUBSCRIBE (  __context__ , (ushort)( 1 )) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SUBSCRIBE_OnRelease_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 165;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( OBJECT_ID ) == 3))  ) ) 
            {
            __context__.SourceCodeLine = 165;
            FSUBSCRIBE (  __context__ , (ushort)( 0 )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN_VOL_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 171;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_ICHAN_VOL != CHAN_VOL  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 173;
            G_ICHAN_VOL = (ushort) ( CHAN_VOL  .UshortValue ) ; 
            __context__.SourceCodeLine = 175;
            CHAN_VOL_FB  .Value = (ushort) ( G_ICHAN_VOL ) ; 
            __context__.SourceCodeLine = 177;
            FSET_VOLUMEPERCENT (  __context__ , (ushort)( 0 ), (ushort)( G_ICHAN_VOL )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN_MUTE_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 183;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHAN_MUTE  .UshortValue == 1))  ) ) 
            {
            __context__.SourceCodeLine = 183;
            FSET_BOOLEAN (  __context__ , (ushort)( 1 ), "\u0001") ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 184;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHAN_MUTE  .UshortValue == 2))  ) ) 
                {
                __context__.SourceCodeLine = 184;
                FSET_BOOLEAN (  __context__ , (ushort)( 1 ), "\u0000") ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN_POLARITY_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 189;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHAN_POLARITY  .UshortValue == 1))  ) ) 
            {
            __context__.SourceCodeLine = 189;
            FSET_BOOLEAN (  __context__ , (ushort)( 2 ), "\u0001") ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 190;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHAN_POLARITY  .UshortValue == 2))  ) ) 
                {
                __context__.SourceCodeLine = 190;
                FSET_BOOLEAN (  __context__ , (ushort)( 2 ), "\u0000") ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 195;
        if ( Functions.TestForTrue  ( ( G_IRX_OK)  ) ) 
            { 
            __context__.SourceCodeLine = 197;
            G_IRX_OK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 198;
            while ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 200;
                G_SREPLY  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 202;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Length( RX__DOLLAR__ ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 1 ) ) == 3) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 204;
                    G_SREPLY  .UpdateValue ( G_SREPLY + Functions.Remove ( 1, RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 202;
                    } 
                
                __context__.SourceCodeLine = 207;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( G_SREPLY , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( G_SREPLY , (int)( 6 ) , (int)( 3 ) ) == G_SOBJECT_ID) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 209;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_1__ = ((int)Byte( G_SREPLY , (int)( 10 ) ));
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 213;
                                G_ICHAN_VOL = (ushort) ( FVOLUMEPERCENTTOI( __context__ , Functions.Mid( G_SREPLY , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 214;
                                CHAN_VOL_FB  .Value = (ushort) ( G_ICHAN_VOL ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 216;
                                CHAN_MUTE_FB  .Value = (ushort) ( Byte( G_SREPLY , (int)( 14 ) ) ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 217;
                                CHAN_POLARITY_FB  .Value = (ushort) ( Byte( G_SREPLY , (int)( 14 ) ) ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                __context__.SourceCodeLine = 198;
                } 
            
            __context__.SourceCodeLine = 221;
            G_IRX_OK = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OBJECT_ID_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 227;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( OBJECT_ID ) == 3))  ) ) 
            { 
            __context__.SourceCodeLine = 229;
            G_SOBJECT_ID  .UpdateValue ( OBJECT_ID  ) ; 
            __context__.SourceCodeLine = 230;
            OBJECT_ID_FB  .UpdateValue ( G_SOBJECT_ID  ) ; 
            __context__.SourceCodeLine = 232;
            if ( Functions.TestForTrue  ( ( SUBSCRIBE  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 234;
                CancelWait ( "WRESUBSCRIBE" ) ; 
                __context__.SourceCodeLine = 235;
                FRESUBSCRIBE (  __context__  ) ; 
                } 
            
            } 
        
        
        
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
        
        __context__.SourceCodeLine = 243;
        G_SOBJECT_ID  .UpdateValue ( DEFAULT_OBJECT_ID  ) ; 
        __context__.SourceCodeLine = 244;
        OBJECT_ID_FB  .UpdateValue ( G_SOBJECT_ID  ) ; 
        __context__.SourceCodeLine = 246;
        G_INUM_CHAN_USED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 248;
        G_IRX_OK = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SOBJECT_ID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    G_SREPLY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    
    SUBSCRIBE = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DigitalInput__, SUBSCRIBE );
    
    CHAN_VOL = new Crestron.Logos.SplusObjects.AnalogInput( CHAN_VOL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN_VOL__AnalogSerialInput__, CHAN_VOL );
    
    CHAN_POLARITY = new Crestron.Logos.SplusObjects.AnalogInput( CHAN_POLARITY__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN_POLARITY__AnalogSerialInput__, CHAN_POLARITY );
    
    CHAN_MUTE = new Crestron.Logos.SplusObjects.AnalogInput( CHAN_MUTE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN_MUTE__AnalogSerialInput__, CHAN_MUTE );
    
    CHAN_VOL_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN_VOL_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN_VOL_FB__AnalogSerialOutput__, CHAN_VOL_FB );
    
    CHAN_POLARITY_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN_POLARITY_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN_POLARITY_FB__AnalogSerialOutput__, CHAN_POLARITY_FB );
    
    CHAN_MUTE_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN_MUTE_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN_MUTE_FB__AnalogSerialOutput__, CHAN_MUTE_FB );
    
    OBJECT_ID = new Crestron.Logos.SplusObjects.StringInput( OBJECT_ID__AnalogSerialInput__, 3, this );
    m_StringInputList.Add( OBJECT_ID__AnalogSerialInput__, OBJECT_ID );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    OBJECT_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( OBJECT_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( OBJECT_ID_FB__AnalogSerialOutput__, OBJECT_ID_FB );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    DEFAULT_OBJECT_ID = new StringParameter( DEFAULT_OBJECT_ID__Parameter__, this );
    m_ParameterList.Add( DEFAULT_OBJECT_ID__Parameter__, DEFAULT_OBJECT_ID );
    
    WRESUBSCRIBE_Callback = new WaitFunction( WRESUBSCRIBE_CallbackFn );
    
    SUBSCRIBE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE_OnPush_0, false ) );
    SUBSCRIBE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SUBSCRIBE_OnRelease_1, false ) );
    CHAN_VOL.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN_VOL_OnChange_2, false ) );
    CHAN_MUTE.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN_MUTE_OnChange_3, false ) );
    CHAN_POLARITY.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN_POLARITY_OnChange_4, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_5, false ) );
    OBJECT_ID.OnSerialChange.Add( new InputChangeHandlerWrapper( OBJECT_ID_OnChange_6, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_BSS_GAIN_MONO_ENGINE_R0_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WRESUBSCRIBE_Callback;


const uint SUBSCRIBE__DigitalInput__ = 0;
const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint OBJECT_ID__AnalogSerialInput__ = 1;
const uint CHAN_VOL__AnalogSerialInput__ = 2;
const uint CHAN_POLARITY__AnalogSerialInput__ = 3;
const uint CHAN_MUTE__AnalogSerialInput__ = 4;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint OBJECT_ID_FB__AnalogSerialOutput__ = 1;
const uint CHAN_VOL_FB__AnalogSerialOutput__ = 2;
const uint CHAN_POLARITY_FB__AnalogSerialOutput__ = 3;
const uint CHAN_MUTE_FB__AnalogSerialOutput__ = 4;
const uint DEFAULT_OBJECT_ID__Parameter__ = 10;

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
