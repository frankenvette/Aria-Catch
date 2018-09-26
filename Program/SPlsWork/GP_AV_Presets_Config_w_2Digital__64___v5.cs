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

namespace UserModule_GP_AV_PRESETS_CONFIG_W_2DIGITAL__64___V5
{
    public class UserModuleClass_GP_AV_PRESETS_CONFIG_W_2DIGITAL__64___V5 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.AnalogInput RECALL;
        Crestron.Logos.SplusObjects.AnalogInput VIEW;
        Crestron.Logos.SplusObjects.DigitalInput SAVE;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> AUDIO_ZONE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> VIDEO_ZONE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> AUDIO_VOLUME;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> VIDEO_CHANNEL;
        Crestron.Logos.SplusObjects.DigitalInput AUDIOSELECT;
        Crestron.Logos.SplusObjects.DigitalInput VIDEOSELECT;
        Crestron.Logos.SplusObjects.DigitalInput AUDIOVOLSELECT;
        Crestron.Logos.SplusObjects.DigitalInput VIDEOCHANSELECT;
        Crestron.Logos.SplusObjects.DigitalInput DIGITALSELECT;
        Crestron.Logos.SplusObjects.DigitalInput DIGITALSELECT2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AUDIOINCLUDEZ;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VIDEOINCLUDEZ;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DIGITALINCLUDEZ;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DIGITALINCLUDEZ2;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SAVE_DONE;
        Crestron.Logos.SplusObjects.DigitalOutput AUDIOSELECTED;
        Crestron.Logos.SplusObjects.DigitalOutput VIDEOSELECTED;
        Crestron.Logos.SplusObjects.DigitalOutput AUDIOVOLSELECTED;
        Crestron.Logos.SplusObjects.DigitalOutput VIDEOCHANSELECTED;
        Crestron.Logos.SplusObjects.DigitalOutput DIGITALSELECTED;
        Crestron.Logos.SplusObjects.DigitalOutput DIGITALSELECTED2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AUDIOINCLUDEDZ;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> VIDEOINCLUDEDZ;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DIGITALINCLUDEDZ;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DIGITALINCLUDEDZ2;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> AUDIO_OUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> AUDIO_OUT_SAVED;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VIDEO_OUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VIDEO_OUT_SAVED;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VOLUME_OUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VOLUME_OUT_SAVED;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CHANNEL_OUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CHANNEL_OUT_SAVED;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DIGITAL_OUT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DIGITAL_OUT2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PRESET_FB;
        StringParameter PATHFILEEXT;
        G_PRESET [] PRESET;
        private void FVIEWDATA (  SplusExecutionContext __context__ ) 
            { 
            short IHANDLE = 0;
            short IBYTES = 0;
            
            ushort I = 0;
            
            CrestronString PATH;
            PATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
            
            
            __context__.SourceCodeLine = 111;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( BUSY_FB  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VIEW  .UshortValue <= 64 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (VIEW  .UshortValue != 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 113;
                BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 115;
                StartFileOperations ( ) ; 
                __context__.SourceCodeLine = 116;
                PATH  .UpdateValue ( PATHFILEEXT + Functions.ItoA (  (int) ( VIEW  .UshortValue ) ) + ".dat"  ) ; 
                __context__.SourceCodeLine = 117;
                IHANDLE = (short) ( FileOpen( PATH ,(ushort) (0 | 32768) ) ) ; 
                __context__.SourceCodeLine = 118;
                ReadStructure (  (short) ( IHANDLE ) , PRESET [ VIEW  .UshortValue] ,  ref IBYTES ) ; 
                __context__.SourceCodeLine = 119;
                /* Trace( " {0:d} Bytes read", (short)IBYTES) */ ; 
                __context__.SourceCodeLine = 120;
                FileClose (  (short) ( IHANDLE ) ) ; 
                __context__.SourceCodeLine = 121;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 123;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)99; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 127;
                    AUDIOINCLUDEDZ [ I]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 135;
                    VIDEOINCLUDEDZ [ I]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 141;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ VIEW  .UshortValue ].G_IDIGITALZONE[ I ] == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 143;
                        DIGITALINCLUDEDZ [ I]  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 147;
                        DIGITALINCLUDEDZ [ I]  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 149;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ VIEW  .UshortValue ].G_IDIGITALZONE2[ I ] == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 151;
                        DIGITALINCLUDEDZ2 [ I]  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 155;
                        DIGITALINCLUDEDZ2 [ I]  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 161;
                    AUDIO_OUT_SAVED [ I]  .Value = (ushort) ( PRESET[ VIEW  .UshortValue ].G_IAUDIO[ I ] ) ; 
                    __context__.SourceCodeLine = 162;
                    VIDEO_OUT_SAVED [ I]  .Value = (ushort) ( PRESET[ VIEW  .UshortValue ].G_IVIDEO[ I ] ) ; 
                    __context__.SourceCodeLine = 163;
                    VOLUME_OUT_SAVED [ I]  .Value = (ushort) ( PRESET[ VIEW  .UshortValue ].G_IVOLUME[ I ] ) ; 
                    __context__.SourceCodeLine = 164;
                    CHANNEL_OUT_SAVED [ I]  .Value = (ushort) ( PRESET[ VIEW  .UshortValue ].G_ICHANNEL[ I ] ) ; 
                    __context__.SourceCodeLine = 123;
                    } 
                
                __context__.SourceCodeLine = 167;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ VIEW  .UshortValue ].G_ATT[ 1 ] == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 169;
                    AUDIOSELECTED  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 173;
                    AUDIOSELECTED  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 175;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ VIEW  .UshortValue ].G_ATT[ 2 ] == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 177;
                    VIDEOSELECTED  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 181;
                    VIDEOSELECTED  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 183;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ VIEW  .UshortValue ].G_ATT[ 3 ] == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 185;
                    AUDIOVOLSELECTED  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 189;
                    AUDIOVOLSELECTED  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 191;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ VIEW  .UshortValue ].G_ATT[ 4 ] == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 193;
                    VIDEOCHANSELECTED  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 197;
                    VIDEOCHANSELECTED  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 199;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ VIEW  .UshortValue ].G_ATT[ 5 ] == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 201;
                    DIGITALSELECTED  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 205;
                    DIGITALSELECTED  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 207;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ VIEW  .UshortValue ].G_ATT[ 6 ] == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 209;
                    DIGITALSELECTED2  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 213;
                    DIGITALSELECTED2  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 216;
                BUSY_FB  .Value = (ushort) ( 0 ) ; 
                } 
            
            
            }
            
        object RECALL_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                short IHANDLE = 0;
                short IBYTES = 0;
                
                ushort I = 0;
                ushort J = 0;
                
                CrestronString PATH;
                PATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
                
                
                __context__.SourceCodeLine = 229;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( BUSY_FB  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( RECALL  .UshortValue <= 64 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (RECALL  .UshortValue != 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 231;
                    BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 233;
                    StartFileOperations ( ) ; 
                    __context__.SourceCodeLine = 235;
                    PATH  .UpdateValue ( PATHFILEEXT + Functions.ItoA (  (int) ( RECALL  .UshortValue ) ) + ".dat"  ) ; 
                    __context__.SourceCodeLine = 236;
                    IHANDLE = (short) ( FileOpen( PATH ,(ushort) (0 | 32768) ) ) ; 
                    __context__.SourceCodeLine = 237;
                    ReadStructure (  (short) ( IHANDLE ) , PRESET [ RECALL  .UshortValue] ,  ref IBYTES ) ; 
                    __context__.SourceCodeLine = 238;
                    /* Trace( " {0:d} Bytes read", (short)IBYTES) */ ; 
                    __context__.SourceCodeLine = 239;
                    FileClose (  (short) ( IHANDLE ) ) ; 
                    __context__.SourceCodeLine = 241;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 243;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBYTES > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 245;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_ATT[ 1 ] == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 247;
                            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__1 = (ushort)99; 
                            int __FN_FORSTEP_VAL__1 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                { 
                                __context__.SourceCodeLine = 249;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_IAUDIOZONE[ I ] == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 251;
                                    AUDIO_OUT [ I]  .Value = (ushort) ( PRESET[ RECALL  .UshortValue ].G_IAUDIO[ I ] ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 247;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 255;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_ATT[ 2 ] == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 257;
                            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__2 = (ushort)99; 
                            int __FN_FORSTEP_VAL__2 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                { 
                                __context__.SourceCodeLine = 259;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_IVIDEOZONE[ I ] == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 261;
                                    VIDEO_OUT [ I]  .Value = (ushort) ( PRESET[ RECALL  .UshortValue ].G_IVIDEO[ I ] ) ; 
                                    __context__.SourceCodeLine = 262;
                                    Functions.Delay (  (int) ( 20 ) ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 257;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 266;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_ATT[ 3 ] == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 268;
                            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__3 = (ushort)99; 
                            int __FN_FORSTEP_VAL__3 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                                { 
                                __context__.SourceCodeLine = 270;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_IAUDIOZONE[ I ] == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 272;
                                    VOLUME_OUT [ I]  .Value = (ushort) ( PRESET[ RECALL  .UshortValue ].G_IVOLUME[ I ] ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 268;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 276;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_ATT[ 4 ] == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 278;
                            ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__4 = (ushort)99; 
                            int __FN_FORSTEP_VAL__4 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                                { 
                                __context__.SourceCodeLine = 280;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_IVIDEOZONE[ I ] == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 282;
                                    CHANNEL_OUT [ I]  .Value = (ushort) ( PRESET[ RECALL  .UshortValue ].G_ICHANNEL[ I ] ) ; 
                                    __context__.SourceCodeLine = 283;
                                    Functions.Delay (  (int) ( 20 ) ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 278;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 287;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_ATT[ 5 ] == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 289;
                            ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__5 = (ushort)99; 
                            int __FN_FORSTEP_VAL__5 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                                { 
                                __context__.SourceCodeLine = 291;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_IDIGITALZONE[ I ] == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 293;
                                    Functions.Pulse ( 50, DIGITAL_OUT [ I] ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 289;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 297;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_ATT[ 6 ] == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 299;
                            ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__6 = (ushort)99; 
                            int __FN_FORSTEP_VAL__6 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                                { 
                                __context__.SourceCodeLine = 301;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESET[ RECALL  .UshortValue ].G_IDIGITALZONE2[ I ] == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 303;
                                    Functions.Pulse ( 50, DIGITAL_OUT2 [ I] ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 299;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 309;
                        ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__7 = (ushort)64; 
                        int __FN_FORSTEP_VAL__7 = (int)1; 
                        for ( J  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (J  >= __FN_FORSTART_VAL__7) && (J  <= __FN_FOREND_VAL__7) ) : ( (J  <= __FN_FORSTART_VAL__7) && (J  >= __FN_FOREND_VAL__7) ) ; J  += (ushort)__FN_FORSTEP_VAL__7) 
                            { 
                            __context__.SourceCodeLine = 311;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RECALL  .UshortValue == J))  ) ) 
                                { 
                                __context__.SourceCodeLine = 313;
                                PRESET_FB [ RECALL  .UshortValue]  .Value = (ushort) ( 1 ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 317;
                                PRESET_FB [ RECALL  .UshortValue]  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 309;
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 322;
                    BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object VIEW_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 329;
            FVIEWDATA (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SAVE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short IHANDLE = 0;
        short IBYTES = 0;
        
        ushort I = 0;
        
        CrestronString PATH;
        PATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        
        __context__.SourceCodeLine = 339;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( BUSY_FB  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VIEW  .UshortValue <= 64 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (VIEW  .UshortValue != 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 341;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 343;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)99; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 345;
                PRESET [ VIEW  .UshortValue] . G_IAUDIO [ I] = (ushort) ( AUDIO_ZONE[ I ] .UshortValue ) ; 
                __context__.SourceCodeLine = 346;
                PRESET [ VIEW  .UshortValue] . G_IVIDEO [ I] = (ushort) ( VIDEO_ZONE[ I ] .UshortValue ) ; 
                __context__.SourceCodeLine = 347;
                PRESET [ VIEW  .UshortValue] . G_IVOLUME [ I] = (ushort) ( AUDIO_VOLUME[ I ] .UshortValue ) ; 
                __context__.SourceCodeLine = 348;
                PRESET [ VIEW  .UshortValue] . G_ICHANNEL [ I] = (ushort) ( VIDEO_CHANNEL[ I ] .UshortValue ) ; 
                __context__.SourceCodeLine = 349;
                if ( Functions.TestForTrue  ( ( AUDIOINCLUDEDZ[ I ] .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 351;
                    PRESET [ VIEW  .UshortValue] . G_IAUDIOZONE [ I] = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 355;
                    PRESET [ VIEW  .UshortValue] . G_IAUDIOZONE [ I] = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 357;
                if ( Functions.TestForTrue  ( ( VIDEOINCLUDEDZ[ I ] .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 359;
                    PRESET [ VIEW  .UshortValue] . G_IVIDEOZONE [ I] = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 363;
                    PRESET [ VIEW  .UshortValue] . G_IVIDEOZONE [ I] = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 365;
                if ( Functions.TestForTrue  ( ( DIGITALINCLUDEDZ[ I ] .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 367;
                    PRESET [ VIEW  .UshortValue] . G_IDIGITALZONE [ I] = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 371;
                    PRESET [ VIEW  .UshortValue] . G_IDIGITALZONE [ I] = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 374;
                if ( Functions.TestForTrue  ( ( DIGITALINCLUDEDZ2[ I ] .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 376;
                    PRESET [ VIEW  .UshortValue] . G_IDIGITALZONE2 [ I] = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 380;
                    PRESET [ VIEW  .UshortValue] . G_IDIGITALZONE2 [ I] = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 343;
                } 
            
            __context__.SourceCodeLine = 383;
            if ( Functions.TestForTrue  ( ( AUDIOSELECTED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 385;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 1] = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 389;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 1] = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 391;
            if ( Functions.TestForTrue  ( ( VIDEOSELECTED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 393;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 2] = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 397;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 2] = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 399;
            if ( Functions.TestForTrue  ( ( AUDIOVOLSELECTED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 401;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 3] = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 405;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 3] = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 407;
            if ( Functions.TestForTrue  ( ( VIDEOCHANSELECTED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 409;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 4] = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 413;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 4] = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 415;
            if ( Functions.TestForTrue  ( ( DIGITALSELECTED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 417;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 5] = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 421;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 5] = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 423;
            if ( Functions.TestForTrue  ( ( DIGITALSELECTED2  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 425;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 6] = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 429;
                PRESET [ VIEW  .UshortValue] . G_ATT [ 6] = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 433;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 436;
            PATH  .UpdateValue ( PATHFILEEXT + Functions.ItoA (  (int) ( VIEW  .UshortValue ) ) + ".dat"  ) ; 
            __context__.SourceCodeLine = 437;
            IHANDLE = (short) ( FileOpen( PATH ,(ushort) (((256 | 512) | 2) | 32768) ) ) ; 
            __context__.SourceCodeLine = 438;
            WriteStructure (  (short) ( IHANDLE ) , PRESET [ VIEW  .UshortValue] ,  ref IBYTES ) ; 
            __context__.SourceCodeLine = 439;
            /* Trace( " {0:d} Bytes Written", (short)IBYTES) */ ; 
            __context__.SourceCodeLine = 440;
            FileClose (  (short) ( IHANDLE ) ) ; 
            __context__.SourceCodeLine = 442;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 444;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBYTES > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 446;
                Functions.Pulse ( 50, SAVE_DONE ) ; 
                __context__.SourceCodeLine = 447;
                /* Trace( "Saved Preset:{0:d}", (short)VIEW  .UshortValue) */ ; 
                } 
            
            __context__.SourceCodeLine = 450;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 453;
        FVIEWDATA (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUDIOSELECT_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 458;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AUDIOSELECTED  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 458;
            AUDIOSELECTED  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 459;
            AUDIOSELECTED  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VIDEOSELECT_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 463;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VIDEOSELECTED  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 463;
            VIDEOSELECTED  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 464;
            VIDEOSELECTED  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUDIOVOLSELECT_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 468;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AUDIOVOLSELECTED  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 468;
            AUDIOVOLSELECTED  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 469;
            AUDIOVOLSELECTED  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VIDEOCHANSELECT_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 473;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VIDEOCHANSELECTED  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 473;
            VIDEOCHANSELECTED  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 474;
            VIDEOCHANSELECTED  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGITALSELECT_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 478;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIGITALSELECTED  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 478;
            DIGITALSELECTED  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 479;
            DIGITALSELECTED  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGITALSELECT2_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 483;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIGITALSELECTED2  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 483;
            DIGITALSELECTED2  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 484;
            DIGITALSELECTED2  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUDIOINCLUDEZ_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 489;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 490;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AUDIOINCLUDEDZ[ I ] .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 490;
            AUDIOINCLUDEDZ [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 491;
            AUDIOINCLUDEDZ [ I]  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VIDEOINCLUDEZ_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 496;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 497;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VIDEOINCLUDEDZ[ I ] .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 497;
            VIDEOINCLUDEDZ [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 498;
            VIDEOINCLUDEDZ [ I]  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGITALINCLUDEZ_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 503;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 504;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIGITALINCLUDEDZ[ I ] .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 504;
            DIGITALINCLUDEDZ [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 505;
            DIGITALINCLUDEDZ [ I]  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGITALINCLUDEZ2_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 510;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 511;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIGITALINCLUDEDZ2[ I ] .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 511;
            DIGITALINCLUDEDZ2 [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 512;
            DIGITALINCLUDEDZ2 [ I]  .Value = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLEAR_FB_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 519;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)99; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 521;
            PRESET_FB [ I]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 519;
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
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    PRESET  = new G_PRESET[ 65 ];
    for( uint i = 0; i < 65; i++ )
    {
        PRESET [i] = new G_PRESET( this, true );
        PRESET [i].PopulateCustomAttributeList( false );
        
    }
    
    SAVE = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE__DigitalInput__, SAVE );
    
    CLEAR_FB = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR_FB__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR_FB__DigitalInput__, CLEAR_FB );
    
    AUDIOSELECT = new Crestron.Logos.SplusObjects.DigitalInput( AUDIOSELECT__DigitalInput__, this );
    m_DigitalInputList.Add( AUDIOSELECT__DigitalInput__, AUDIOSELECT );
    
    VIDEOSELECT = new Crestron.Logos.SplusObjects.DigitalInput( VIDEOSELECT__DigitalInput__, this );
    m_DigitalInputList.Add( VIDEOSELECT__DigitalInput__, VIDEOSELECT );
    
    AUDIOVOLSELECT = new Crestron.Logos.SplusObjects.DigitalInput( AUDIOVOLSELECT__DigitalInput__, this );
    m_DigitalInputList.Add( AUDIOVOLSELECT__DigitalInput__, AUDIOVOLSELECT );
    
    VIDEOCHANSELECT = new Crestron.Logos.SplusObjects.DigitalInput( VIDEOCHANSELECT__DigitalInput__, this );
    m_DigitalInputList.Add( VIDEOCHANSELECT__DigitalInput__, VIDEOCHANSELECT );
    
    DIGITALSELECT = new Crestron.Logos.SplusObjects.DigitalInput( DIGITALSELECT__DigitalInput__, this );
    m_DigitalInputList.Add( DIGITALSELECT__DigitalInput__, DIGITALSELECT );
    
    DIGITALSELECT2 = new Crestron.Logos.SplusObjects.DigitalInput( DIGITALSELECT2__DigitalInput__, this );
    m_DigitalInputList.Add( DIGITALSELECT2__DigitalInput__, DIGITALSELECT2 );
    
    AUDIOINCLUDEZ = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        AUDIOINCLUDEZ[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AUDIOINCLUDEZ__DigitalInput__ + i, AUDIOINCLUDEZ__DigitalInput__, this );
        m_DigitalInputList.Add( AUDIOINCLUDEZ__DigitalInput__ + i, AUDIOINCLUDEZ[i+1] );
    }
    
    VIDEOINCLUDEZ = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        VIDEOINCLUDEZ[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VIDEOINCLUDEZ__DigitalInput__ + i, VIDEOINCLUDEZ__DigitalInput__, this );
        m_DigitalInputList.Add( VIDEOINCLUDEZ__DigitalInput__ + i, VIDEOINCLUDEZ[i+1] );
    }
    
    DIGITALINCLUDEZ = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DIGITALINCLUDEZ[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DIGITALINCLUDEZ__DigitalInput__ + i, DIGITALINCLUDEZ__DigitalInput__, this );
        m_DigitalInputList.Add( DIGITALINCLUDEZ__DigitalInput__ + i, DIGITALINCLUDEZ[i+1] );
    }
    
    DIGITALINCLUDEZ2 = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DIGITALINCLUDEZ2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DIGITALINCLUDEZ2__DigitalInput__ + i, DIGITALINCLUDEZ2__DigitalInput__, this );
        m_DigitalInputList.Add( DIGITALINCLUDEZ2__DigitalInput__ + i, DIGITALINCLUDEZ2[i+1] );
    }
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    SAVE_DONE = new Crestron.Logos.SplusObjects.DigitalOutput( SAVE_DONE__DigitalOutput__, this );
    m_DigitalOutputList.Add( SAVE_DONE__DigitalOutput__, SAVE_DONE );
    
    AUDIOSELECTED = new Crestron.Logos.SplusObjects.DigitalOutput( AUDIOSELECTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( AUDIOSELECTED__DigitalOutput__, AUDIOSELECTED );
    
    VIDEOSELECTED = new Crestron.Logos.SplusObjects.DigitalOutput( VIDEOSELECTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( VIDEOSELECTED__DigitalOutput__, VIDEOSELECTED );
    
    AUDIOVOLSELECTED = new Crestron.Logos.SplusObjects.DigitalOutput( AUDIOVOLSELECTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( AUDIOVOLSELECTED__DigitalOutput__, AUDIOVOLSELECTED );
    
    VIDEOCHANSELECTED = new Crestron.Logos.SplusObjects.DigitalOutput( VIDEOCHANSELECTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( VIDEOCHANSELECTED__DigitalOutput__, VIDEOCHANSELECTED );
    
    DIGITALSELECTED = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITALSELECTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( DIGITALSELECTED__DigitalOutput__, DIGITALSELECTED );
    
    DIGITALSELECTED2 = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITALSELECTED2__DigitalOutput__, this );
    m_DigitalOutputList.Add( DIGITALSELECTED2__DigitalOutput__, DIGITALSELECTED2 );
    
    AUDIOINCLUDEDZ = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        AUDIOINCLUDEDZ[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AUDIOINCLUDEDZ__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AUDIOINCLUDEDZ__DigitalOutput__ + i, AUDIOINCLUDEDZ[i+1] );
    }
    
    VIDEOINCLUDEDZ = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        VIDEOINCLUDEDZ[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( VIDEOINCLUDEDZ__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( VIDEOINCLUDEDZ__DigitalOutput__ + i, VIDEOINCLUDEDZ[i+1] );
    }
    
    DIGITALINCLUDEDZ = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DIGITALINCLUDEDZ[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITALINCLUDEDZ__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DIGITALINCLUDEDZ__DigitalOutput__ + i, DIGITALINCLUDEDZ[i+1] );
    }
    
    DIGITALINCLUDEDZ2 = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DIGITALINCLUDEDZ2[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITALINCLUDEDZ2__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DIGITALINCLUDEDZ2__DigitalOutput__ + i, DIGITALINCLUDEDZ2[i+1] );
    }
    
    DIGITAL_OUT = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DIGITAL_OUT[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITAL_OUT__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DIGITAL_OUT__DigitalOutput__ + i, DIGITAL_OUT[i+1] );
    }
    
    DIGITAL_OUT2 = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DIGITAL_OUT2[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITAL_OUT2__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DIGITAL_OUT2__DigitalOutput__ + i, DIGITAL_OUT2[i+1] );
    }
    
    PRESET_FB = new InOutArray<DigitalOutput>( 64, this );
    for( uint i = 0; i < 64; i++ )
    {
        PRESET_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PRESET_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PRESET_FB__DigitalOutput__ + i, PRESET_FB[i+1] );
    }
    
    RECALL = new Crestron.Logos.SplusObjects.AnalogInput( RECALL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RECALL__AnalogSerialInput__, RECALL );
    
    VIEW = new Crestron.Logos.SplusObjects.AnalogInput( VIEW__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VIEW__AnalogSerialInput__, VIEW );
    
    AUDIO_ZONE = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        AUDIO_ZONE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( AUDIO_ZONE__AnalogSerialInput__ + i, AUDIO_ZONE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( AUDIO_ZONE__AnalogSerialInput__ + i, AUDIO_ZONE[i+1] );
    }
    
    VIDEO_ZONE = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        VIDEO_ZONE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( VIDEO_ZONE__AnalogSerialInput__ + i, VIDEO_ZONE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( VIDEO_ZONE__AnalogSerialInput__ + i, VIDEO_ZONE[i+1] );
    }
    
    AUDIO_VOLUME = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        AUDIO_VOLUME[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( AUDIO_VOLUME__AnalogSerialInput__ + i, AUDIO_VOLUME__AnalogSerialInput__, this );
        m_AnalogInputList.Add( AUDIO_VOLUME__AnalogSerialInput__ + i, AUDIO_VOLUME[i+1] );
    }
    
    VIDEO_CHANNEL = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        VIDEO_CHANNEL[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( VIDEO_CHANNEL__AnalogSerialInput__ + i, VIDEO_CHANNEL__AnalogSerialInput__, this );
        m_AnalogInputList.Add( VIDEO_CHANNEL__AnalogSerialInput__ + i, VIDEO_CHANNEL[i+1] );
    }
    
    AUDIO_OUT = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        AUDIO_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( AUDIO_OUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( AUDIO_OUT__AnalogSerialOutput__ + i, AUDIO_OUT[i+1] );
    }
    
    AUDIO_OUT_SAVED = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        AUDIO_OUT_SAVED[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( AUDIO_OUT_SAVED__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( AUDIO_OUT_SAVED__AnalogSerialOutput__ + i, AUDIO_OUT_SAVED[i+1] );
    }
    
    VIDEO_OUT = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        VIDEO_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VIDEO_OUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( VIDEO_OUT__AnalogSerialOutput__ + i, VIDEO_OUT[i+1] );
    }
    
    VIDEO_OUT_SAVED = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        VIDEO_OUT_SAVED[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VIDEO_OUT_SAVED__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( VIDEO_OUT_SAVED__AnalogSerialOutput__ + i, VIDEO_OUT_SAVED[i+1] );
    }
    
    VOLUME_OUT = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        VOLUME_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_OUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( VOLUME_OUT__AnalogSerialOutput__ + i, VOLUME_OUT[i+1] );
    }
    
    VOLUME_OUT_SAVED = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        VOLUME_OUT_SAVED[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_OUT_SAVED__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( VOLUME_OUT_SAVED__AnalogSerialOutput__ + i, VOLUME_OUT_SAVED[i+1] );
    }
    
    CHANNEL_OUT = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        CHANNEL_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_OUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CHANNEL_OUT__AnalogSerialOutput__ + i, CHANNEL_OUT[i+1] );
    }
    
    CHANNEL_OUT_SAVED = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        CHANNEL_OUT_SAVED[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_OUT_SAVED__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CHANNEL_OUT_SAVED__AnalogSerialOutput__ + i, CHANNEL_OUT_SAVED[i+1] );
    }
    
    PATHFILEEXT = new StringParameter( PATHFILEEXT__Parameter__, this );
    m_ParameterList.Add( PATHFILEEXT__Parameter__, PATHFILEEXT );
    
    
    RECALL.OnAnalogChange.Add( new InputChangeHandlerWrapper( RECALL_OnChange_0, false ) );
    VIEW.OnAnalogChange.Add( new InputChangeHandlerWrapper( VIEW_OnChange_1, false ) );
    SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_2, false ) );
    AUDIOSELECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUDIOSELECT_OnPush_3, false ) );
    VIDEOSELECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( VIDEOSELECT_OnPush_4, false ) );
    AUDIOVOLSELECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUDIOVOLSELECT_OnPush_5, false ) );
    VIDEOCHANSELECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( VIDEOCHANSELECT_OnPush_6, false ) );
    DIGITALSELECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGITALSELECT_OnPush_7, false ) );
    DIGITALSELECT2.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGITALSELECT2_OnPush_8, false ) );
    for( uint i = 0; i < 99; i++ )
        AUDIOINCLUDEZ[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( AUDIOINCLUDEZ_OnPush_9, false ) );
        
    for( uint i = 0; i < 99; i++ )
        VIDEOINCLUDEZ[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( VIDEOINCLUDEZ_OnPush_10, false ) );
        
    for( uint i = 0; i < 99; i++ )
        DIGITALINCLUDEZ[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGITALINCLUDEZ_OnPush_11, false ) );
        
    for( uint i = 0; i < 99; i++ )
        DIGITALINCLUDEZ2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGITALINCLUDEZ2_OnPush_12, false ) );
        
    CLEAR_FB.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_FB_OnPush_13, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_AV_PRESETS_CONFIG_W_2DIGITAL__64___V5 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RECALL__AnalogSerialInput__ = 0;
const uint VIEW__AnalogSerialInput__ = 1;
const uint SAVE__DigitalInput__ = 0;
const uint CLEAR_FB__DigitalInput__ = 1;
const uint AUDIO_ZONE__AnalogSerialInput__ = 2;
const uint VIDEO_ZONE__AnalogSerialInput__ = 101;
const uint AUDIO_VOLUME__AnalogSerialInput__ = 200;
const uint VIDEO_CHANNEL__AnalogSerialInput__ = 299;
const uint AUDIOSELECT__DigitalInput__ = 2;
const uint VIDEOSELECT__DigitalInput__ = 3;
const uint AUDIOVOLSELECT__DigitalInput__ = 4;
const uint VIDEOCHANSELECT__DigitalInput__ = 5;
const uint DIGITALSELECT__DigitalInput__ = 6;
const uint DIGITALSELECT2__DigitalInput__ = 7;
const uint AUDIOINCLUDEZ__DigitalInput__ = 8;
const uint VIDEOINCLUDEZ__DigitalInput__ = 107;
const uint DIGITALINCLUDEZ__DigitalInput__ = 206;
const uint DIGITALINCLUDEZ2__DigitalInput__ = 305;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint SAVE_DONE__DigitalOutput__ = 1;
const uint AUDIOSELECTED__DigitalOutput__ = 2;
const uint VIDEOSELECTED__DigitalOutput__ = 3;
const uint AUDIOVOLSELECTED__DigitalOutput__ = 4;
const uint VIDEOCHANSELECTED__DigitalOutput__ = 5;
const uint DIGITALSELECTED__DigitalOutput__ = 6;
const uint DIGITALSELECTED2__DigitalOutput__ = 7;
const uint AUDIOINCLUDEDZ__DigitalOutput__ = 8;
const uint VIDEOINCLUDEDZ__DigitalOutput__ = 107;
const uint DIGITALINCLUDEDZ__DigitalOutput__ = 206;
const uint DIGITALINCLUDEDZ2__DigitalOutput__ = 305;
const uint AUDIO_OUT__AnalogSerialOutput__ = 0;
const uint AUDIO_OUT_SAVED__AnalogSerialOutput__ = 99;
const uint VIDEO_OUT__AnalogSerialOutput__ = 198;
const uint VIDEO_OUT_SAVED__AnalogSerialOutput__ = 297;
const uint VOLUME_OUT__AnalogSerialOutput__ = 396;
const uint VOLUME_OUT_SAVED__AnalogSerialOutput__ = 495;
const uint CHANNEL_OUT__AnalogSerialOutput__ = 594;
const uint CHANNEL_OUT_SAVED__AnalogSerialOutput__ = 693;
const uint DIGITAL_OUT__DigitalOutput__ = 404;
const uint DIGITAL_OUT2__DigitalOutput__ = 503;
const uint PRESET_FB__DigitalOutput__ = 602;
const uint PATHFILEEXT__Parameter__ = 10;

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

[SplusStructAttribute(-1, true, false)]
public class G_PRESET : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  [] G_IAUDIO;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  [] G_IVIDEO;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  [] G_IVOLUME;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  [] G_ICHANNEL;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  [] G_IAUDIOZONE;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  [] G_IVIDEOZONE;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  [] G_IDIGITALZONE;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  [] G_IDIGITALZONE2;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  [] G_ATT;
    
    
    public G_PRESET( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        G_IAUDIO  = new ushort[ 100 ];
        G_IVIDEO  = new ushort[ 100 ];
        G_IVOLUME  = new ushort[ 100 ];
        G_ICHANNEL  = new ushort[ 100 ];
        G_IAUDIOZONE  = new ushort[ 100 ];
        G_IVIDEOZONE  = new ushort[ 100 ];
        G_IDIGITALZONE  = new ushort[ 100 ];
        G_IDIGITALZONE2  = new ushort[ 100 ];
        G_ATT  = new ushort[ 7 ];
        
        
    }
    
}

}
