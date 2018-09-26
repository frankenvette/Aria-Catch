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
using stadiumVision;

namespace UserModule_STADIUMVISION_DMPENGINE_V0_2_POWER_FAKE
{
    public class UserModuleClass_STADIUMVISION_DMPENGINE_V0_2_POWER_FAKE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.StringInput COMMAND;
        Crestron.Logos.SplusObjects.StringInput DMP_ID;
        Crestron.Logos.SplusObjects.StringInput PIN_F;
        Crestron.Logos.SplusObjects.StringInput CHANNEL_TUNE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_TUNE;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME;
        Crestron.Logos.SplusObjects.StringInput INPUT_BY_NAME;
        Crestron.Logos.SplusObjects.StringOutput DEBUG_FB;
        Crestron.Logos.SplusObjects.StringOutput MESSAGE_FB;
        Crestron.Logos.SplusObjects.StringOutput DMP_ID_FB;
        Crestron.Logos.SplusObjects.StringOutput GROUP_ID_FB;
        Crestron.Logos.SplusObjects.StringOutput GROUP_NAME_FB;
        Crestron.Logos.SplusObjects.StringOutput GROUP_EXTERNAL_ID_FB;
        Crestron.Logos.SplusObjects.StringOutput PIN_F_FB;
        Crestron.Logos.SplusObjects.AnalogOutput ACK_NCK_FB;
        Crestron.Logos.SplusObjects.AnalogOutput POWER_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_TUNE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_FB;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_MUTE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput INPUT_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CC_FB;
        Crestron.Logos.SplusObjects.StringOutput CC_OPTION_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_OF_LAST_DIRECT_TUNE_FB;
        StringParameter DEFAULT_PIN_FIXED;
        StringParameter DEFAULT_DMP_ID;
        StringParameter DEFAULT_INFO_BANNER_DURATION;
        stadiumVision.dmp THIS;
        ushort G_ICHANNEL_OF_LAST_DIRECT_TUNE = 0;
        ushort ICURRENTCHAN = 0;
        public void CBF_DEBUG_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 107;
                DEBUG_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_MESSAGE_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 108;
                MESSAGE_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_DMP_ID_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 110;
                DMP_ID_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_GROUP_ID_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 112;
                GROUP_ID_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_GROUP_NAME_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 113;
                GROUP_NAME_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_GROUP_EXTERNAL_ID_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 114;
                GROUP_EXTERNAL_ID_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_PIN_F_FB ( SimplSharpString P ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 116;
                PIN_F_FB  .UpdateValue ( P  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_POWER_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_CHANNEL_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 120;
                ICURRENTCHAN = (ushort) ( S ) ; 
                __context__.SourceCodeLine = 121;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POWER_FB  .Value == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 122;
                    CHANNEL_TUNE_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 123;
                    CHANNEL_TUNE_FB  .Value = (ushort) ( ICURRENTCHAN ) ; 
                    } 
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_VOLUME_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 125;
                VOLUME_FB  .Value = (ushort) ( S ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_VOLUME_MUTE_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 126;
                VOLUME_MUTE_FB  .Value = (ushort) ( S ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_INPUT_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 127;
                INPUT_FB  .Value = (ushort) ( S ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_CC_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 128;
                CC_FB  .Value = (ushort) ( S ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_CC_OPTION_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 129;
                CC_OPTION_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_ACK_NAK_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 133;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_ICHANNEL_OF_LAST_DIRECT_TUNE < 65535 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 135;
                    CHANNEL_OF_LAST_DIRECT_TUNE_FB  .Value = (ushort) ( G_ICHANNEL_OF_LAST_DIRECT_TUNE ) ; 
                    } 
                
                __context__.SourceCodeLine = 137;
                ACK_NCK_FB  .Value = (ushort) ( S ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        private void FCHECK_POWER_ON (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 143;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POWER_FB  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 145;
                Functions.Delay (  (int) ( 20 ) ) ; 
                __context__.SourceCodeLine = 146;
                THIS . send ( "control/player/power/on") ; 
                __context__.SourceCodeLine = 147;
                POWER_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 148;
                Functions.Delay (  (int) ( 20 ) ) ; 
                __context__.SourceCodeLine = 149;
                THIS . send ( "control/player/power/on") ; 
                } 
            
            
            }
            
        private void FPOWER_OFF (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 154;
            G_ICHANNEL_OF_LAST_DIRECT_TUNE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 155;
            THIS . send ( "control/player/power/off") ; 
            __context__.SourceCodeLine = 156;
            POWER_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 157;
            CHANNEL_TUNE_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 158;
            Functions.Delay (  (int) ( 20 ) ) ; 
            __context__.SourceCodeLine = 159;
            THIS . send ( "control/player/power/off") ; 
            
            }
            
        private void FTUNE_SEND (  SplusExecutionContext __context__ ) 
            { 
            CrestronString S;
            S  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            
            __context__.SourceCodeLine = 164;
            S  .UpdateValue ( "control/player/channel/" + Functions.ItoA (  (int) ( G_ICHANNEL_OF_LAST_DIRECT_TUNE ) )  ) ; 
            __context__.SourceCodeLine = 165;
            THIS . send ( S .ToString()) ; 
            
            }
            
        object COMMAND_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 170;
                G_ICHANNEL_OF_LAST_DIRECT_TUNE = (ushort) ( 65535 ) ; 
                __context__.SourceCodeLine = 171;
                THIS . send ( COMMAND .ToString()) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CHANNEL_TUNE__DOLLAR___OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 176;
            if ( Functions.TestForTrue  ( ( Functions.Length( CHANNEL_TUNE__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 178;
                G_ICHANNEL_OF_LAST_DIRECT_TUNE = (ushort) ( Functions.Atoi( CHANNEL_TUNE__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 180;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_ICHANNEL_OF_LAST_DIRECT_TUNE > 1 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 182;
                    FTUNE_SEND (  __context__  ) ; 
                    __context__.SourceCodeLine = 183;
                    FCHECK_POWER_ON (  __context__  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 185;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( CHANNEL_TUNE__DOLLAR__ ) == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 187;
                        FPOWER_OFF (  __context__  ) ; 
                        } 
                    
                    }
                
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object CHANNEL_TUNE_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 195;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( CHANNEL_TUNE  .UshortValue > 1 ))  ) ) 
            { 
            __context__.SourceCodeLine = 197;
            G_ICHANNEL_OF_LAST_DIRECT_TUNE = (ushort) ( CHANNEL_TUNE  .UshortValue ) ; 
            __context__.SourceCodeLine = 198;
            FTUNE_SEND (  __context__  ) ; 
            __context__.SourceCodeLine = 199;
            FCHECK_POWER_ON (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 201;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_TUNE  .UshortValue == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 203;
                FPOWER_OFF (  __context__  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString S;
        S  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
        
        
        __context__.SourceCodeLine = 210;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( VOLUME  .UshortValue < 101 ))  ) ) 
            { 
            __context__.SourceCodeLine = 212;
            G_ICHANNEL_OF_LAST_DIRECT_TUNE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 213;
            S  .UpdateValue ( "control/player/volume/" + Functions.ItoA (  (int) ( VOLUME  .UshortValue ) )  ) ; 
            __context__.SourceCodeLine = 214;
            THIS . send ( S .ToString()) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 218;
            MakeString ( MESSAGE_FB , "Ignored Volume: {0:d}, Out of Range 0-100", (ushort)VOLUME  .UshortValue) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUT_BY_NAME_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 223;
        if ( Functions.TestForTrue  ( ( Functions.Length( INPUT_BY_NAME ))  ) ) 
            { 
            __context__.SourceCodeLine = 225;
            THIS . send_input ( INPUT_BY_NAME .ToString()) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DMP_ID_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 228;
        THIS . dmp_id  =  ( DMP_ID  )  .ToString() ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PIN_F_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 229;
        THIS . pin_F  =  ( PIN_F  )  .ToString() ; 
        
        
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
        
        __context__.SourceCodeLine = 234;
        POWER_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 237;
        THIS . dmp_id  =  ( DEFAULT_DMP_ID  )  .ToString() ; 
        __context__.SourceCodeLine = 238;
        THIS . pin_F  =  ( DEFAULT_PIN_FIXED  )  .ToString() ; 
        __context__.SourceCodeLine = 239;
        // RegisterDelegate( THIS , MESSAGE_ , CBF_MESSAGE_FB ) 
        THIS .Message_  = CBF_MESSAGE_FB; ; 
        __context__.SourceCodeLine = 240;
        // RegisterDelegate( THIS , DEBUG_ , CBF_DEBUG_FB ) 
        THIS .Debug_  = CBF_DEBUG_FB; ; 
        __context__.SourceCodeLine = 242;
        // RegisterDelegate( THIS , DMP_ID_ , CBF_DMP_ID_FB ) 
        THIS .Dmp_Id_  = CBF_DMP_ID_FB; ; 
        __context__.SourceCodeLine = 244;
        // RegisterDelegate( THIS , GROUP_ID_ , CBF_GROUP_ID_FB ) 
        THIS .Group_Id_  = CBF_GROUP_ID_FB; ; 
        __context__.SourceCodeLine = 245;
        // RegisterDelegate( THIS , GROUP_NAME_ , CBF_GROUP_NAME_FB ) 
        THIS .Group_Name_  = CBF_GROUP_NAME_FB; ; 
        __context__.SourceCodeLine = 246;
        // RegisterDelegate( THIS , GROUP_EXTERNAL_ID_ , CBF_GROUP_EXTERNAL_ID_FB ) 
        THIS .Group_External_Id_  = CBF_GROUP_EXTERNAL_ID_FB; ; 
        __context__.SourceCodeLine = 248;
        // RegisterDelegate( THIS , PIN_F_ , CBF_PIN_F_FB ) 
        THIS .Pin_F_  = CBF_PIN_F_FB; ; 
        __context__.SourceCodeLine = 250;
        // RegisterDelegate( THIS , POWER_ , CBF_POWER_FB ) 
        THIS .Power_  = CBF_POWER_FB; ; 
        __context__.SourceCodeLine = 251;
        // RegisterDelegate( THIS , CHANNEL_ , CBF_CHANNEL_FB ) 
        THIS .Channel_  = CBF_CHANNEL_FB; ; 
        __context__.SourceCodeLine = 252;
        // RegisterDelegate( THIS , VOLUME_ , CBF_VOLUME_FB ) 
        THIS .Volume_  = CBF_VOLUME_FB; ; 
        __context__.SourceCodeLine = 253;
        // RegisterDelegate( THIS , VOLUME_MUTE_ , CBF_VOLUME_MUTE_FB ) 
        THIS .Volume_Mute_  = CBF_VOLUME_MUTE_FB; ; 
        __context__.SourceCodeLine = 254;
        // RegisterDelegate( THIS , INPUT_ , CBF_INPUT_FB ) 
        THIS .Input_  = CBF_INPUT_FB; ; 
        __context__.SourceCodeLine = 255;
        // RegisterDelegate( THIS , CC_ , CBF_CC_FB ) 
        THIS .CC_  = CBF_CC_FB; ; 
        __context__.SourceCodeLine = 256;
        // RegisterDelegate( THIS , CC_OPTION_ , CBF_CC_OPTION_FB ) 
        THIS .CC_Option_  = CBF_CC_OPTION_FB; ; 
        __context__.SourceCodeLine = 258;
        // RegisterDelegate( THIS , ACK_NAK_ , CBF_ACK_NAK_FB ) 
        THIS .Ack_Nak_  = CBF_ACK_NAK_FB; ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    CHANNEL_TUNE = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_TUNE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_TUNE__AnalogSerialInput__, CHANNEL_TUNE );
    
    VOLUME = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOLUME__AnalogSerialInput__, VOLUME );
    
    ACK_NCK_FB = new Crestron.Logos.SplusObjects.AnalogOutput( ACK_NCK_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ACK_NCK_FB__AnalogSerialOutput__, ACK_NCK_FB );
    
    POWER_FB = new Crestron.Logos.SplusObjects.AnalogOutput( POWER_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( POWER_FB__AnalogSerialOutput__, POWER_FB );
    
    CHANNEL_TUNE_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_TUNE_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_TUNE_FB__AnalogSerialOutput__, CHANNEL_TUNE_FB );
    
    VOLUME_FB = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VOLUME_FB__AnalogSerialOutput__, VOLUME_FB );
    
    VOLUME_MUTE_FB = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_MUTE_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VOLUME_MUTE_FB__AnalogSerialOutput__, VOLUME_MUTE_FB );
    
    INPUT_FB = new Crestron.Logos.SplusObjects.AnalogOutput( INPUT_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( INPUT_FB__AnalogSerialOutput__, INPUT_FB );
    
    CC_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CC_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CC_FB__AnalogSerialOutput__, CC_FB );
    
    CHANNEL_OF_LAST_DIRECT_TUNE_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_OF_LAST_DIRECT_TUNE_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_OF_LAST_DIRECT_TUNE_FB__AnalogSerialOutput__, CHANNEL_OF_LAST_DIRECT_TUNE_FB );
    
    COMMAND = new Crestron.Logos.SplusObjects.StringInput( COMMAND__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( COMMAND__AnalogSerialInput__, COMMAND );
    
    DMP_ID = new Crestron.Logos.SplusObjects.StringInput( DMP_ID__AnalogSerialInput__, 16, this );
    m_StringInputList.Add( DMP_ID__AnalogSerialInput__, DMP_ID );
    
    PIN_F = new Crestron.Logos.SplusObjects.StringInput( PIN_F__AnalogSerialInput__, 32, this );
    m_StringInputList.Add( PIN_F__AnalogSerialInput__, PIN_F );
    
    CHANNEL_TUNE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( CHANNEL_TUNE__DOLLAR____AnalogSerialInput__, 16, this );
    m_StringInputList.Add( CHANNEL_TUNE__DOLLAR____AnalogSerialInput__, CHANNEL_TUNE__DOLLAR__ );
    
    INPUT_BY_NAME = new Crestron.Logos.SplusObjects.StringInput( INPUT_BY_NAME__AnalogSerialInput__, 12, this );
    m_StringInputList.Add( INPUT_BY_NAME__AnalogSerialInput__, INPUT_BY_NAME );
    
    DEBUG_FB = new Crestron.Logos.SplusObjects.StringOutput( DEBUG_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( DEBUG_FB__AnalogSerialOutput__, DEBUG_FB );
    
    MESSAGE_FB = new Crestron.Logos.SplusObjects.StringOutput( MESSAGE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( MESSAGE_FB__AnalogSerialOutput__, MESSAGE_FB );
    
    DMP_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( DMP_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( DMP_ID_FB__AnalogSerialOutput__, DMP_ID_FB );
    
    GROUP_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( GROUP_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( GROUP_ID_FB__AnalogSerialOutput__, GROUP_ID_FB );
    
    GROUP_NAME_FB = new Crestron.Logos.SplusObjects.StringOutput( GROUP_NAME_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( GROUP_NAME_FB__AnalogSerialOutput__, GROUP_NAME_FB );
    
    GROUP_EXTERNAL_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( GROUP_EXTERNAL_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( GROUP_EXTERNAL_ID_FB__AnalogSerialOutput__, GROUP_EXTERNAL_ID_FB );
    
    PIN_F_FB = new Crestron.Logos.SplusObjects.StringOutput( PIN_F_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PIN_F_FB__AnalogSerialOutput__, PIN_F_FB );
    
    CC_OPTION_FB = new Crestron.Logos.SplusObjects.StringOutput( CC_OPTION_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CC_OPTION_FB__AnalogSerialOutput__, CC_OPTION_FB );
    
    DEFAULT_PIN_FIXED = new StringParameter( DEFAULT_PIN_FIXED__Parameter__, this );
    m_ParameterList.Add( DEFAULT_PIN_FIXED__Parameter__, DEFAULT_PIN_FIXED );
    
    DEFAULT_DMP_ID = new StringParameter( DEFAULT_DMP_ID__Parameter__, this );
    m_ParameterList.Add( DEFAULT_DMP_ID__Parameter__, DEFAULT_DMP_ID );
    
    DEFAULT_INFO_BANNER_DURATION = new StringParameter( DEFAULT_INFO_BANNER_DURATION__Parameter__, this );
    m_ParameterList.Add( DEFAULT_INFO_BANNER_DURATION__Parameter__, DEFAULT_INFO_BANNER_DURATION );
    
    
    COMMAND.OnSerialChange.Add( new InputChangeHandlerWrapper( COMMAND_OnChange_0, false ) );
    CHANNEL_TUNE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( CHANNEL_TUNE__DOLLAR___OnChange_1, false ) );
    CHANNEL_TUNE.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_TUNE_OnChange_2, false ) );
    VOLUME.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_OnChange_3, false ) );
    INPUT_BY_NAME.OnSerialChange.Add( new InputChangeHandlerWrapper( INPUT_BY_NAME_OnChange_4, false ) );
    DMP_ID.OnSerialChange.Add( new InputChangeHandlerWrapper( DMP_ID_OnChange_5, false ) );
    PIN_F.OnSerialChange.Add( new InputChangeHandlerWrapper( PIN_F_OnChange_6, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    THIS  = new stadiumVision.dmp();
    
    
}

public UserModuleClass_STADIUMVISION_DMPENGINE_V0_2_POWER_FAKE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint COMMAND__AnalogSerialInput__ = 0;
const uint DMP_ID__AnalogSerialInput__ = 1;
const uint PIN_F__AnalogSerialInput__ = 2;
const uint CHANNEL_TUNE__DOLLAR____AnalogSerialInput__ = 3;
const uint CHANNEL_TUNE__AnalogSerialInput__ = 4;
const uint VOLUME__AnalogSerialInput__ = 5;
const uint INPUT_BY_NAME__AnalogSerialInput__ = 6;
const uint DEBUG_FB__AnalogSerialOutput__ = 0;
const uint MESSAGE_FB__AnalogSerialOutput__ = 1;
const uint DMP_ID_FB__AnalogSerialOutput__ = 2;
const uint GROUP_ID_FB__AnalogSerialOutput__ = 3;
const uint GROUP_NAME_FB__AnalogSerialOutput__ = 4;
const uint GROUP_EXTERNAL_ID_FB__AnalogSerialOutput__ = 5;
const uint PIN_F_FB__AnalogSerialOutput__ = 6;
const uint ACK_NCK_FB__AnalogSerialOutput__ = 7;
const uint POWER_FB__AnalogSerialOutput__ = 8;
const uint CHANNEL_TUNE_FB__AnalogSerialOutput__ = 9;
const uint VOLUME_FB__AnalogSerialOutput__ = 10;
const uint VOLUME_MUTE_FB__AnalogSerialOutput__ = 11;
const uint INPUT_FB__AnalogSerialOutput__ = 12;
const uint CC_FB__AnalogSerialOutput__ = 13;
const uint CC_OPTION_FB__AnalogSerialOutput__ = 14;
const uint CHANNEL_OF_LAST_DIRECT_TUNE_FB__AnalogSerialOutput__ = 15;
const uint DEFAULT_PIN_FIXED__Parameter__ = 10;
const uint DEFAULT_DMP_ID__Parameter__ = 11;
const uint DEFAULT_INFO_BANNER_DURATION__Parameter__ = 12;

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
