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

namespace UserModule_TOUCH_PANEL_PIN_CLIENT_V0_1
{
    public class UserModuleClass_TOUCH_PANEL_PIN_CLIENT_V0_1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput LOGOUT;
        Crestron.Logos.SplusObjects.StringInput PIN_ENTRY;
        Crestron.Logos.SplusObjects.BufferInput PIN_CONFIG_IMPORT;
        Crestron.Logos.SplusObjects.AnalogInput FORCE_LOGIN_LEVEL;
        Crestron.Logos.SplusObjects.DigitalOutput PIN_SECURITY_ENABLE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput PIN_VALID_PULSE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput PIN_INVALID_PULSE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput PIN_LEVEL_LOGGED_IN_FB;
        Crestron.Logos.SplusObjects.StringOutput PIN_ENTRY_FB;
        Crestron.Logos.SplusObjects.StringOutput ERROR_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CONFIGURED_PIN_LEVEL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> CONFIGURED_PIN_PIN;
        StringParameter HARD_CODED_PIN;
        STRUCTUREPIN [] G_STRUCTPIN_CONFIG;
        ushort G_INUMBER_OF_PINS = 0;
        CrestronString G_SPIN_CONFIG_IMPORT;
        CrestronString G_SSINGLE_PIN_DATA;
        private CrestronString FXML_PCDATA (  SplusExecutionContext __context__, CrestronString DATA , CrestronString TAG ) 
            { 
            CrestronString SSTART;
            CrestronString SEND;
            SSTART  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
            SEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            CrestronString SRETURN;
            SRETURN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            ushort ISTART = 0;
            ushort IEND = 0;
            
            
            __context__.SourceCodeLine = 94;
            if ( Functions.TestForTrue  ( ( Functions.Find( TAG , DATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 96;
                SSTART  .UpdateValue ( "<" + TAG  ) ; 
                __context__.SourceCodeLine = 97;
                SEND  .UpdateValue ( "</" + TAG + ">"  ) ; 
                __context__.SourceCodeLine = 99;
                ISTART = (ushort) ( Functions.Find( SSTART , DATA ) ) ; 
                __context__.SourceCodeLine = 100;
                if ( Functions.TestForTrue  ( ( ISTART)  ) ) 
                    { 
                    __context__.SourceCodeLine = 102;
                    ISTART = (ushort) ( (Functions.Find( ">" , DATA , ISTART ) + 1) ) ; 
                    __context__.SourceCodeLine = 103;
                    if ( Functions.TestForTrue  ( ( ISTART)  ) ) 
                        { 
                        __context__.SourceCodeLine = 105;
                        IEND = (ushort) ( Functions.Find( SEND , DATA ) ) ; 
                        __context__.SourceCodeLine = 106;
                        if ( Functions.TestForTrue  ( ( IEND)  ) ) 
                            { 
                            __context__.SourceCodeLine = 108;
                            SRETURN  .UpdateValue ( Functions.Mid ( DATA ,  (int) ( ISTART ) ,  (int) ( (IEND - ISTART) ) )  ) ; 
                            __context__.SourceCodeLine = 109;
                            return ( SRETURN ) ; 
                            } 
                        
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 114;
            return ( "" ) ; 
            
            }
            
        private CrestronString FXML_ATTRIBUTE (  SplusExecutionContext __context__, CrestronString DATA , CrestronString TAG , CrestronString ATTRIBUTE ) 
            { 
            ushort ISTART = 0;
            ushort ICOUNT = 0;
            
            CrestronString SRETURN;
            SRETURN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            CrestronString SATTRIBUTE;
            SATTRIBUTE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            CrestronString STAG;
            STAG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            
            __context__.SourceCodeLine = 124;
            STAG  .UpdateValue ( "<" + TAG  ) ; 
            __context__.SourceCodeLine = 126;
            if ( Functions.TestForTrue  ( ( Functions.Find( STAG , DATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 128;
                ISTART = (ushort) ( (Functions.Find( STAG , DATA ) + Functions.Length( STAG )) ) ; 
                __context__.SourceCodeLine = 129;
                SATTRIBUTE  .UpdateValue ( ATTRIBUTE + "=\u0022"  ) ; 
                __context__.SourceCodeLine = 131;
                if ( Functions.TestForTrue  ( ( Functions.Find( SATTRIBUTE , DATA , ISTART ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 133;
                    ISTART = (ushort) ( (Functions.Find( SATTRIBUTE , DATA , ISTART ) + Functions.Length( SATTRIBUTE )) ) ; 
                    __context__.SourceCodeLine = 134;
                    ICOUNT = (ushort) ( Functions.Find( "\u0022" , DATA , ISTART ) ) ; 
                    __context__.SourceCodeLine = 135;
                    ICOUNT = (ushort) ( (ICOUNT - ISTART) ) ; 
                    __context__.SourceCodeLine = 136;
                    SRETURN  .UpdateValue ( Functions.Mid ( DATA ,  (int) ( ISTART ) ,  (int) ( ICOUNT ) )  ) ; 
                    __context__.SourceCodeLine = 138;
                    return ( SRETURN ) ; 
                    } 
                
                __context__.SourceCodeLine = 140;
                return ( "" ) ; 
                } 
            
            __context__.SourceCodeLine = 142;
            return ( "" ) ; 
            
            }
            
        private ushort FPIN_CONFIG_COUNT (  SplusExecutionContext __context__, CrestronString SDATA ) 
            { 
            ushort ICOUNT = 0;
            
            ushort IFIND_POSITION = 0;
            
            
            __context__.SourceCodeLine = 150;
            ICOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 151;
            IFIND_POSITION = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 153;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "</pin>" , SDATA , IFIND_POSITION ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 155;
                ICOUNT = (ushort) ( (ICOUNT + 1) ) ; 
                __context__.SourceCodeLine = 156;
                IFIND_POSITION = (ushort) ( (Functions.Find( "</pin>" , SDATA , IFIND_POSITION ) + 1) ) ; 
                __context__.SourceCodeLine = 153;
                } 
            
            __context__.SourceCodeLine = 159;
            return (ushort)( ICOUNT) ; 
            
            }
            
        private void FPIN_VALID (  SplusExecutionContext __context__, ushort I ) 
            { 
            
            __context__.SourceCodeLine = 164;
            PIN_ENTRY_FB  .UpdateValue ( "Valid"  ) ; 
            __context__.SourceCodeLine = 165;
            PIN_LEVEL_LOGGED_IN_FB  .Value = (ushort) ( G_STRUCTPIN_CONFIG[ I ].ILEVEL ) ; 
            __context__.SourceCodeLine = 166;
            Functions.Delay (  (int) ( 150 ) ) ; 
            __context__.SourceCodeLine = 167;
            Functions.Pulse ( 1, PIN_VALID_PULSE_FB ) ; 
            __context__.SourceCodeLine = 169;
            PIN_ENTRY_FB  .UpdateValue ( ""  ) ; 
            
            }
            
        private void FPIN_INVALID (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 174;
            PIN_ENTRY_FB  .UpdateValue ( "Invalid"  ) ; 
            __context__.SourceCodeLine = 175;
            Functions.Delay (  (int) ( 150 ) ) ; 
            __context__.SourceCodeLine = 176;
            Functions.Pulse ( 1, PIN_INVALID_PULSE_FB ) ; 
            __context__.SourceCodeLine = 177;
            PIN_ENTRY_FB  .UpdateValue ( ""  ) ; 
            
            }
            
        private CrestronString FMASK (  SplusExecutionContext __context__, CrestronString SDATA ) 
            { 
            ushort I = 0;
            
            CrestronString SMASK;
            SMASK  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            
            __context__.SourceCodeLine = 185;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( Functions.Length( SDATA ) ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)1; 
            int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 187;
                SMASK  .UpdateValue ( SMASK + "*"  ) ; 
                __context__.SourceCodeLine = 185;
                } 
            
            __context__.SourceCodeLine = 190;
            return ( SMASK ) ; 
            
            }
            
        private void FPIN_CHECK (  SplusExecutionContext __context__, CrestronString SDATA ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 197;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SDATA ) == 5))  ) ) 
                { 
                __context__.SourceCodeLine = 199;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_INUMBER_OF_PINS > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 201;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)G_INUMBER_OF_PINS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 203;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SDATA == G_STRUCTPIN_CONFIG[ I ].SPIN))  ) ) 
                            { 
                            __context__.SourceCodeLine = 205;
                            FPIN_VALID (  __context__ , (ushort)( I )) ; 
                            __context__.SourceCodeLine = 206;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 201;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 210;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SDATA == G_STRUCTPIN_CONFIG[ 0 ].SPIN))  ) ) 
                    { 
                    __context__.SourceCodeLine = 212;
                    I = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 213;
                    FPIN_VALID (  __context__ , (ushort)( 0 )) ; 
                    } 
                
                __context__.SourceCodeLine = 215;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > G_INUMBER_OF_PINS ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 217;
                    FPIN_INVALID (  __context__  ) ; 
                    } 
                
                } 
            
            
            }
            
        private void FLOGOUT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 223;
            PIN_LEVEL_LOGGED_IN_FB  .Value = (ushort) ( 0 ) ; 
            
            }
            
        object LOGOUT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 229;
                FLOGOUT (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object PIN_ENTRY_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 233;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PIN_ENTRY ) < 5 ))  ) ) 
                { 
                __context__.SourceCodeLine = 235;
                PIN_ENTRY_FB  .UpdateValue ( FMASK (  __context__ , PIN_ENTRY)  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 237;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( PIN_ENTRY ) == 5))  ) ) 
                    { 
                    __context__.SourceCodeLine = 239;
                    PIN_ENTRY_FB  .UpdateValue ( FMASK (  __context__ , PIN_ENTRY)  ) ; 
                    __context__.SourceCodeLine = 240;
                    FPIN_CHECK (  __context__ , PIN_ENTRY) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 244;
                    PIN_ENTRY_FB  .UpdateValue ( ""  ) ; 
                    } 
                
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object FORCE_LOGIN_LEVEL_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 249;
        if ( Functions.TestForTrue  ( ( FORCE_LOGIN_LEVEL  .UshortValue)  ) ) 
            { 
            __context__.SourceCodeLine = 251;
            PIN_LEVEL_LOGGED_IN_FB  .Value = (ushort) ( FORCE_LOGIN_LEVEL  .UshortValue ) ; 
            __context__.SourceCodeLine = 252;
            Functions.Pulse ( 1, PIN_VALID_PULSE_FB ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 256;
            FLOGOUT (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PIN_CONFIG_IMPORT_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        short SIRETURN = 0;
        
        
        __context__.SourceCodeLine = 265;
        try 
            { 
            __context__.SourceCodeLine = 267;
            G_SPIN_CONFIG_IMPORT  .UpdateValue ( Functions.Gather ( "</tp>" , PIN_CONFIG_IMPORT )  ) ; 
            __context__.SourceCodeLine = 269;
            if ( Functions.TestForTrue  ( ( Functions.Find( "</tp>" , G_SPIN_CONFIG_IMPORT ))  ) ) 
                { 
                __context__.SourceCodeLine = 271;
                PIN_SECURITY_ENABLE_FB  .Value = (ushort) ( Functions.Atoi( FXML_PCDATA( __context__ , G_SPIN_CONFIG_IMPORT , "enable" ) ) ) ; 
                __context__.SourceCodeLine = 273;
                G_INUMBER_OF_PINS = (ushort) ( FPIN_CONFIG_COUNT( __context__ , G_SPIN_CONFIG_IMPORT ) ) ; 
                __context__.SourceCodeLine = 275;
                if ( Functions.TestForTrue  ( ( G_INUMBER_OF_PINS)  ) ) 
                    { 
                    __context__.SourceCodeLine = 277;
                    SIRETURN = (short) ( Functions.ResizeArray( ref G_STRUCTPIN_CONFIG , (int)G_INUMBER_OF_PINS , null ) ) ; 
                    __context__.SourceCodeLine = 278;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIRETURN == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 280;
                        I = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 281;
                        while ( Functions.TestForTrue  ( ( Functions.Find( "</pin>" , G_SPIN_CONFIG_IMPORT ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 283;
                            I = (ushort) ( (I + 1) ) ; 
                            __context__.SourceCodeLine = 285;
                            G_SSINGLE_PIN_DATA  .UpdateValue ( Functions.Remove ( "</pin>" , G_SPIN_CONFIG_IMPORT )  ) ; 
                            __context__.SourceCodeLine = 287;
                            G_STRUCTPIN_CONFIG [ I] . ILEVEL = (ushort) ( Functions.Atoi( FXML_ATTRIBUTE( __context__ , G_SSINGLE_PIN_DATA , "pin" , "lev" ) ) ) ; 
                            __context__.SourceCodeLine = 289;
                            G_STRUCTPIN_CONFIG [ I] . SPIN  .UpdateValue ( FXML_PCDATA (  __context__ , G_SSINGLE_PIN_DATA, "pin")  ) ; 
                            __context__.SourceCodeLine = 291;
                            if ( Functions.TestForTrue  ( ( IsSignalDefined( CONFIGURED_PIN_PIN[ I ] ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 293;
                                CONFIGURED_PIN_PIN [ I]  .UpdateValue ( G_STRUCTPIN_CONFIG [ I] . SPIN  ) ; 
                                __context__.SourceCodeLine = 294;
                                CONFIGURED_PIN_LEVEL [ I]  .Value = (ushort) ( G_STRUCTPIN_CONFIG[ I ].ILEVEL ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 281;
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 300;
                        __context__.SourceCodeLine = 301;
                        MakeString ( ERROR_FB , "Resize Structure Error = 0x{0:X}", SIRETURN) ; 
                        
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 307;
                    __context__.SourceCodeLine = 308;
                    MakeString ( ERROR_FB , "No pin element found") ; 
                    
                    } 
                
                __context__.SourceCodeLine = 311;
                G_STRUCTPIN_CONFIG [ 0] . ILEVEL = (ushort) ( 65535 ) ; 
                __context__.SourceCodeLine = 312;
                G_STRUCTPIN_CONFIG [ 0] . SPIN  .UpdateValue ( HARD_CODED_PIN  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 316;
                __context__.SourceCodeLine = 317;
                MakeString ( ERROR_FB , "No cDelim") ; 
                
                } 
            
            } 
        
        catch (Exception __splus_exception__)
            { 
            SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
            
            __context__.SourceCodeLine = 323;
            __context__.SourceCodeLine = 324;
            MakeString ( ERROR_FB , "{0}", Functions.GetExceptionMessage (  __splus_exceptionobj__ ) ) ; 
            
            
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
        
        __context__.SourceCodeLine = 334;
        G_INUMBER_OF_PINS = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 335;
        G_STRUCTPIN_CONFIG [ 0] . ILEVEL = (ushort) ( 65535 ) ; 
        __context__.SourceCodeLine = 336;
        G_STRUCTPIN_CONFIG [ 0] . SPIN  .UpdateValue ( HARD_CODED_PIN  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SPIN_CONFIG_IMPORT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
    G_SSINGLE_PIN_DATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    G_STRUCTPIN_CONFIG  = new STRUCTUREPIN[ 2 ];
    for( uint i = 0; i < 2; i++ )
    {
        G_STRUCTPIN_CONFIG [i] = new STRUCTUREPIN( this, true );
        G_STRUCTPIN_CONFIG [i].PopulateCustomAttributeList( false );
        
    }
    
    LOGOUT = new Crestron.Logos.SplusObjects.DigitalInput( LOGOUT__DigitalInput__, this );
    m_DigitalInputList.Add( LOGOUT__DigitalInput__, LOGOUT );
    
    PIN_SECURITY_ENABLE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( PIN_SECURITY_ENABLE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( PIN_SECURITY_ENABLE_FB__DigitalOutput__, PIN_SECURITY_ENABLE_FB );
    
    PIN_VALID_PULSE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( PIN_VALID_PULSE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( PIN_VALID_PULSE_FB__DigitalOutput__, PIN_VALID_PULSE_FB );
    
    PIN_INVALID_PULSE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( PIN_INVALID_PULSE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( PIN_INVALID_PULSE_FB__DigitalOutput__, PIN_INVALID_PULSE_FB );
    
    FORCE_LOGIN_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( FORCE_LOGIN_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( FORCE_LOGIN_LEVEL__AnalogSerialInput__, FORCE_LOGIN_LEVEL );
    
    PIN_LEVEL_LOGGED_IN_FB = new Crestron.Logos.SplusObjects.AnalogOutput( PIN_LEVEL_LOGGED_IN_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( PIN_LEVEL_LOGGED_IN_FB__AnalogSerialOutput__, PIN_LEVEL_LOGGED_IN_FB );
    
    CONFIGURED_PIN_LEVEL = new InOutArray<AnalogOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        CONFIGURED_PIN_LEVEL[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CONFIGURED_PIN_LEVEL__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CONFIGURED_PIN_LEVEL__AnalogSerialOutput__ + i, CONFIGURED_PIN_LEVEL[i+1] );
    }
    
    PIN_ENTRY = new Crestron.Logos.SplusObjects.StringInput( PIN_ENTRY__AnalogSerialInput__, 10, this );
    m_StringInputList.Add( PIN_ENTRY__AnalogSerialInput__, PIN_ENTRY );
    
    PIN_ENTRY_FB = new Crestron.Logos.SplusObjects.StringOutput( PIN_ENTRY_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PIN_ENTRY_FB__AnalogSerialOutput__, PIN_ENTRY_FB );
    
    ERROR_FB = new Crestron.Logos.SplusObjects.StringOutput( ERROR_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ERROR_FB__AnalogSerialOutput__, ERROR_FB );
    
    CONFIGURED_PIN_PIN = new InOutArray<StringOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        CONFIGURED_PIN_PIN[i+1] = new Crestron.Logos.SplusObjects.StringOutput( CONFIGURED_PIN_PIN__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( CONFIGURED_PIN_PIN__AnalogSerialOutput__ + i, CONFIGURED_PIN_PIN[i+1] );
    }
    
    PIN_CONFIG_IMPORT = new Crestron.Logos.SplusObjects.BufferInput( PIN_CONFIG_IMPORT__AnalogSerialInput__, 512, this );
    m_StringInputList.Add( PIN_CONFIG_IMPORT__AnalogSerialInput__, PIN_CONFIG_IMPORT );
    
    HARD_CODED_PIN = new StringParameter( HARD_CODED_PIN__Parameter__, this );
    m_ParameterList.Add( HARD_CODED_PIN__Parameter__, HARD_CODED_PIN );
    
    
    LOGOUT.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOGOUT_OnPush_0, false ) );
    PIN_ENTRY.OnSerialChange.Add( new InputChangeHandlerWrapper( PIN_ENTRY_OnChange_1, false ) );
    FORCE_LOGIN_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( FORCE_LOGIN_LEVEL_OnChange_2, false ) );
    PIN_CONFIG_IMPORT.OnSerialChange.Add( new InputChangeHandlerWrapper( PIN_CONFIG_IMPORT_OnChange_3, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TOUCH_PANEL_PIN_CLIENT_V0_1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint LOGOUT__DigitalInput__ = 0;
const uint PIN_ENTRY__AnalogSerialInput__ = 0;
const uint PIN_CONFIG_IMPORT__AnalogSerialInput__ = 1;
const uint FORCE_LOGIN_LEVEL__AnalogSerialInput__ = 2;
const uint PIN_SECURITY_ENABLE_FB__DigitalOutput__ = 0;
const uint PIN_VALID_PULSE_FB__DigitalOutput__ = 1;
const uint PIN_INVALID_PULSE_FB__DigitalOutput__ = 2;
const uint PIN_LEVEL_LOGGED_IN_FB__AnalogSerialOutput__ = 0;
const uint PIN_ENTRY_FB__AnalogSerialOutput__ = 1;
const uint ERROR_FB__AnalogSerialOutput__ = 2;
const uint CONFIGURED_PIN_LEVEL__AnalogSerialOutput__ = 3;
const uint CONFIGURED_PIN_PIN__AnalogSerialOutput__ = 11;
const uint HARD_CODED_PIN__Parameter__ = 10;

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
public class STRUCTUREPIN : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  SPIN;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  ILEVEL = 0;
    
    
    public STRUCTUREPIN( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SPIN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, Owner );
        
        
    }
    
}

}
