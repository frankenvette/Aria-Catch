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

namespace UserModule_GP_BSS_GAIN_N_INPUT_ENGINE_R0_3
{
    public class UserModuleClass_GP_BSS_GAIN_N_INPUT_ENGINE_R0_3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput OBJECT_ID;
        Crestron.Logos.SplusObjects.AnalogInput MASTER_VOL;
        Crestron.Logos.SplusObjects.AnalogInput MASTER_MUTE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> CHAN_VOL;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> CHAN_POLARITY;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> CHAN_MUTE;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput OBJECT_ID_FB;
        Crestron.Logos.SplusObjects.AnalogOutput MASTER_VOL_FB;
        Crestron.Logos.SplusObjects.AnalogOutput MASTER_MUTE_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CHAN_VOL_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CHAN_POLARITY_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CHAN_MUTE_FB;
        CrestronString G_SOBJECT_ID;
        ushort G_INUM_CHAN_USED = 0;
        ushort G_IMASTER_VOL = 0;
        ushort [] G_ICHAN_VOL;
        ushort G_IRX_OK = 0;
        CrestronString G_SREPLY;
        ushort G_IREPLY_SV = 0;
        StringParameter DEFAULT_OBJECT_ID;
        private ushort FVOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort IRETURN = 0;
            
            
            __context__.SourceCodeLine = 150;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.BoolToInt (Functions.Mid( STR , (int)( 3 ) , (int)( 1 ) ) == "\u0000") ))  ) ) 
                { 
                __context__.SourceCodeLine = 152;
                IRETURN = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 2) + 1) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 156;
                IRETURN = (ushort) ( (Byte( STR , (int)( 2 ) ) * 2) ) ; 
                } 
            
            __context__.SourceCodeLine = 158;
            return (ushort)( IRETURN) ; 
            
            }
            
        private void FSET_VOLUMEPERCENT (  SplusExecutionContext __context__, ushort SV , ushort VOL_DATA ) 
            { 
            CrestronString SVOL;
            SVOL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 165;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( VOL_DATA , 2 ) == 0))  ) ) 
                {
                __context__.SourceCodeLine = 165;
                SVOL  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (VOL_DATA / 2) ) ) + "\u0000\u0000"  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 166;
                SVOL  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (VOL_DATA / 2) ) ) + "\u0080\u0000"  ) ; 
                }
            
            __context__.SourceCodeLine = 168;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) SV ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) SV ) ) ) , SVOL ) ; 
            
            }
            
        private void FSET_BOOLEAN (  SplusExecutionContext __context__, ushort SV , CrestronString BOOLEAN ) 
            { 
            
            __context__.SourceCodeLine = 173;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000{3}\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) SV ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) SV ) ) ) , BOOLEAN ) ; 
            __context__.SourceCodeLine = 175;
            if ( Functions.TestForTrue  ( ( SUBSCRIBE  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 176;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) SV ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) SV ) ) ) ) ; 
                }
            
            
            }
            
        private void FSUBSCRIBE (  SplusExecutionContext __context__, ushort DO_WHAT ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 183;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (DO_WHAT == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (DO_WHAT == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 185;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(G_INUM_CHAN_USED - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 187;
                    MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) I ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) I ) ) ) ) ; 
                    __context__.SourceCodeLine = 188;
                    MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) (I + 32) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) (I + 32) ) ) ) ) ; 
                    __context__.SourceCodeLine = 189;
                    MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) (I + 64) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) (I + 64) ) ) ) ) ; 
                    __context__.SourceCodeLine = 185;
                    } 
                
                __context__.SourceCodeLine = 191;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) 97 ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) 97 ) ) ) ) ; 
                __context__.SourceCodeLine = 192;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) 96 ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) 96 ) ) ) ) ; 
                } 
            
            __context__.SourceCodeLine = 195;
            Functions.Delay (  (int) ( 20 ) ) ; 
            __context__.SourceCodeLine = 197;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (DO_WHAT == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (DO_WHAT == 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 199;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 0 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)(G_INUM_CHAN_USED - 1); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 201;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) I ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) I ) ) ) ) ; 
                    __context__.SourceCodeLine = 202;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) (I + 32) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) (I + 32) ) ) ) ) ; 
                    __context__.SourceCodeLine = 203;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) (I + 64) ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) (I + 64) ) ) ) ) ; 
                    __context__.SourceCodeLine = 199;
                    } 
                
                __context__.SourceCodeLine = 205;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) 97 ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) 97 ) ) ) ) ; 
                __context__.SourceCodeLine = 206;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( Functions.High( (ushort) 96 ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) 96 ) ) ) ) ; 
                } 
            
            
            }
            
        private void FRESUBSCRIBE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 212;
            CreateWait ( "WRESUBSCRIBE" , 100 , WRESUBSCRIBE_Callback ) ;
            
            }
            
        public void WRESUBSCRIBE_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 214;
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
            
            __context__.SourceCodeLine = 221;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( OBJECT_ID ) == 3))  ) ) 
                {
                __context__.SourceCodeLine = 221;
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
        
        __context__.SourceCodeLine = 226;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( OBJECT_ID ) == 3))  ) ) 
            {
            __context__.SourceCodeLine = 226;
            FSUBSCRIBE (  __context__ , (ushort)( 0 )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MASTER_VOL_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 233;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_IMASTER_VOL != MASTER_VOL  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 235;
            G_IMASTER_VOL = (ushort) ( MASTER_VOL  .UshortValue ) ; 
            __context__.SourceCodeLine = 237;
            MASTER_VOL_FB  .Value = (ushort) ( G_IMASTER_VOL ) ; 
            __context__.SourceCodeLine = 239;
            FSET_VOLUMEPERCENT (  __context__ , (ushort)( 96 ), (ushort)( G_IMASTER_VOL )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN_VOL_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ISV = 0;
        
        
        __context__.SourceCodeLine = 246;
        ISV = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 248;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_ICHAN_VOL[ ISV ] != CHAN_VOL[ ISV ] .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 250;
            G_ICHAN_VOL [ ISV] = (ushort) ( CHAN_VOL[ ISV ] .UshortValue ) ; 
            __context__.SourceCodeLine = 252;
            CHAN_VOL_FB [ ISV]  .Value = (ushort) ( G_ICHAN_VOL[ ISV ] ) ; 
            __context__.SourceCodeLine = 254;
            FSET_VOLUMEPERCENT (  __context__ , (ushort)( (ISV - 1) ), (ushort)( G_ICHAN_VOL[ ISV ] )) ; 
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
        ushort ISV = 0;
        ushort ICH = 0;
        
        
        __context__.SourceCodeLine = 262;
        ICH = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 263;
        ISV = (ushort) ( ((ICH - 1) + 64) ) ; 
        __context__.SourceCodeLine = 265;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHAN_POLARITY[ ICH ] .UshortValue == 1))  ) ) 
            {
            __context__.SourceCodeLine = 265;
            FSET_BOOLEAN (  __context__ , (ushort)( ISV ), "\u0001") ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 266;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHAN_POLARITY[ ICH ] .UshortValue == 2))  ) ) 
                {
                __context__.SourceCodeLine = 266;
                FSET_BOOLEAN (  __context__ , (ushort)( ISV ), "\u0000") ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MASTER_MUTE_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 271;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MASTER_MUTE  .UshortValue == 1))  ) ) 
            {
            __context__.SourceCodeLine = 271;
            FSET_BOOLEAN (  __context__ , (ushort)( 97 ), "\u0001") ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 272;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MASTER_MUTE  .UshortValue == 2))  ) ) 
                {
                __context__.SourceCodeLine = 272;
                FSET_BOOLEAN (  __context__ , (ushort)( 97 ), "\u0000") ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN_MUTE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ISV = 0;
        ushort ICH = 0;
        
        
        __context__.SourceCodeLine = 279;
        ICH = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 280;
        ISV = (ushort) ( ((ICH - 1) + 32) ) ; 
        __context__.SourceCodeLine = 282;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHAN_MUTE[ ICH ] .UshortValue == 1))  ) ) 
            {
            __context__.SourceCodeLine = 282;
            FSET_BOOLEAN (  __context__ , (ushort)( ISV ), "\u0001") ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 283;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHAN_MUTE[ ICH ] .UshortValue == 2))  ) ) 
                {
                __context__.SourceCodeLine = 283;
                FSET_BOOLEAN (  __context__ , (ushort)( ISV ), "\u0000") ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 288;
        if ( Functions.TestForTrue  ( ( G_IRX_OK)  ) ) 
            { 
            __context__.SourceCodeLine = 290;
            G_IRX_OK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 291;
            while ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 293;
                G_SREPLY  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 295;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Length( RX__DOLLAR__ ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 1 ) ) == 3) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 297;
                    G_SREPLY  .UpdateValue ( G_SREPLY + Functions.Remove ( 1, RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 295;
                    } 
                
                __context__.SourceCodeLine = 300;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( G_SREPLY , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( G_SREPLY , (int)( 6 ) , (int)( 3 ) ) == G_SOBJECT_ID) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 302;
                    G_IREPLY_SV = (ushort) ( ((Byte( G_SREPLY , (int)( 9 ) ) * 256) + Byte( G_SREPLY , (int)( 10 ) )) ) ; 
                    __context__.SourceCodeLine = 304;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IREPLY_SV < 32 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 306;
                        G_ICHAN_VOL [ (G_IREPLY_SV + 1)] = (ushort) ( FVOLUMEPERCENTTOI( __context__ , Functions.Mid( G_SREPLY , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                        __context__.SourceCodeLine = 307;
                        CHAN_VOL_FB [ (G_IREPLY_SV + 1)]  .Value = (ushort) ( G_ICHAN_VOL[ (G_IREPLY_SV + 1) ] ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 309;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IREPLY_SV < 64 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 309;
                            CHAN_MUTE_FB [ (G_IREPLY_SV - 31)]  .Value = (ushort) ( Byte( G_SREPLY , (int)( 14 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 310;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IREPLY_SV < 96 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 310;
                                CHAN_POLARITY_FB [ (G_IREPLY_SV - 63)]  .Value = (ushort) ( Byte( G_SREPLY , (int)( 14 ) ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 311;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_IREPLY_SV == 96))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 313;
                                    G_IMASTER_VOL = (ushort) ( FVOLUMEPERCENTTOI( __context__ , Functions.Mid( G_SREPLY , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                    __context__.SourceCodeLine = 314;
                                    MASTER_VOL_FB  .Value = (ushort) ( G_IMASTER_VOL ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 316;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_IREPLY_SV == 97))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 316;
                                        MASTER_MUTE_FB  .Value = (ushort) ( Byte( G_SREPLY , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 291;
                } 
            
            __context__.SourceCodeLine = 321;
            G_IRX_OK = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OBJECT_ID_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 327;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( OBJECT_ID ) == 3))  ) ) 
            { 
            __context__.SourceCodeLine = 329;
            G_SOBJECT_ID  .UpdateValue ( OBJECT_ID  ) ; 
            __context__.SourceCodeLine = 330;
            OBJECT_ID_FB  .UpdateValue ( G_SOBJECT_ID  ) ; 
            __context__.SourceCodeLine = 332;
            if ( Functions.TestForTrue  ( ( SUBSCRIBE  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 334;
                CancelWait ( "WRESUBSCRIBE" ) ; 
                __context__.SourceCodeLine = 335;
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
        
        __context__.SourceCodeLine = 343;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 32 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( G_INUM_CHAN_USED  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (G_INUM_CHAN_USED  >= __FN_FORSTART_VAL__1) && (G_INUM_CHAN_USED  <= __FN_FOREND_VAL__1) ) : ( (G_INUM_CHAN_USED  <= __FN_FORSTART_VAL__1) && (G_INUM_CHAN_USED  >= __FN_FOREND_VAL__1) ) ; G_INUM_CHAN_USED  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 345;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( CHAN_MUTE[ G_INUM_CHAN_USED ] ))  ) ) 
                {
                __context__.SourceCodeLine = 345;
                break ; 
                }
            
            __context__.SourceCodeLine = 343;
            } 
        
        __context__.SourceCodeLine = 347;
        G_SOBJECT_ID  .UpdateValue ( DEFAULT_OBJECT_ID  ) ; 
        __context__.SourceCodeLine = 348;
        OBJECT_ID_FB  .UpdateValue ( G_SOBJECT_ID  ) ; 
        __context__.SourceCodeLine = 350;
        G_IRX_OK = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_ICHAN_VOL  = new ushort[ 33 ];
    G_SOBJECT_ID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    G_SREPLY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    
    SUBSCRIBE = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DigitalInput__, SUBSCRIBE );
    
    MASTER_VOL = new Crestron.Logos.SplusObjects.AnalogInput( MASTER_VOL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MASTER_VOL__AnalogSerialInput__, MASTER_VOL );
    
    MASTER_MUTE = new Crestron.Logos.SplusObjects.AnalogInput( MASTER_MUTE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MASTER_MUTE__AnalogSerialInput__, MASTER_MUTE );
    
    CHAN_VOL = new InOutArray<AnalogInput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        CHAN_VOL[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( CHAN_VOL__AnalogSerialInput__ + i, CHAN_VOL__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CHAN_VOL__AnalogSerialInput__ + i, CHAN_VOL[i+1] );
    }
    
    CHAN_POLARITY = new InOutArray<AnalogInput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        CHAN_POLARITY[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( CHAN_POLARITY__AnalogSerialInput__ + i, CHAN_POLARITY__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CHAN_POLARITY__AnalogSerialInput__ + i, CHAN_POLARITY[i+1] );
    }
    
    CHAN_MUTE = new InOutArray<AnalogInput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        CHAN_MUTE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( CHAN_MUTE__AnalogSerialInput__ + i, CHAN_MUTE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CHAN_MUTE__AnalogSerialInput__ + i, CHAN_MUTE[i+1] );
    }
    
    MASTER_VOL_FB = new Crestron.Logos.SplusObjects.AnalogOutput( MASTER_VOL_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( MASTER_VOL_FB__AnalogSerialOutput__, MASTER_VOL_FB );
    
    MASTER_MUTE_FB = new Crestron.Logos.SplusObjects.AnalogOutput( MASTER_MUTE_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( MASTER_MUTE_FB__AnalogSerialOutput__, MASTER_MUTE_FB );
    
    CHAN_VOL_FB = new InOutArray<AnalogOutput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        CHAN_VOL_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN_VOL_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CHAN_VOL_FB__AnalogSerialOutput__ + i, CHAN_VOL_FB[i+1] );
    }
    
    CHAN_POLARITY_FB = new InOutArray<AnalogOutput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        CHAN_POLARITY_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN_POLARITY_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CHAN_POLARITY_FB__AnalogSerialOutput__ + i, CHAN_POLARITY_FB[i+1] );
    }
    
    CHAN_MUTE_FB = new InOutArray<AnalogOutput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        CHAN_MUTE_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN_MUTE_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CHAN_MUTE_FB__AnalogSerialOutput__ + i, CHAN_MUTE_FB[i+1] );
    }
    
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
    MASTER_VOL.OnAnalogChange.Add( new InputChangeHandlerWrapper( MASTER_VOL_OnChange_2, false ) );
    for( uint i = 0; i < 32; i++ )
        CHAN_VOL[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN_VOL_OnChange_3, false ) );
        
    for( uint i = 0; i < 32; i++ )
        CHAN_POLARITY[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN_POLARITY_OnChange_4, false ) );
        
    MASTER_MUTE.OnAnalogChange.Add( new InputChangeHandlerWrapper( MASTER_MUTE_OnChange_5, false ) );
    for( uint i = 0; i < 32; i++ )
        CHAN_MUTE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN_MUTE_OnChange_6, false ) );
        
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_7, false ) );
    OBJECT_ID.OnSerialChange.Add( new InputChangeHandlerWrapper( OBJECT_ID_OnChange_8, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_BSS_GAIN_N_INPUT_ENGINE_R0_3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WRESUBSCRIBE_Callback;


const uint SUBSCRIBE__DigitalInput__ = 0;
const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint OBJECT_ID__AnalogSerialInput__ = 1;
const uint MASTER_VOL__AnalogSerialInput__ = 2;
const uint MASTER_MUTE__AnalogSerialInput__ = 3;
const uint CHAN_VOL__AnalogSerialInput__ = 4;
const uint CHAN_POLARITY__AnalogSerialInput__ = 36;
const uint CHAN_MUTE__AnalogSerialInput__ = 68;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint OBJECT_ID_FB__AnalogSerialOutput__ = 1;
const uint MASTER_VOL_FB__AnalogSerialOutput__ = 2;
const uint MASTER_MUTE_FB__AnalogSerialOutput__ = 3;
const uint CHAN_VOL_FB__AnalogSerialOutput__ = 4;
const uint CHAN_POLARITY_FB__AnalogSerialOutput__ = 36;
const uint CHAN_MUTE_FB__AnalogSerialOutput__ = 68;
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
