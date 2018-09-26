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

namespace UserModule_TOUCH_PANEL_PIN_SERVER_V0_2
{
    public class UserModuleClass_TOUCH_PANEL_PIN_SERVER_V0_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput REFRESH;
        Crestron.Logos.SplusObjects.DigitalInput READ;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_SAVE;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_SAVE_TO_ALL;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_CANCEL;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_TOUCH_PANEL_INDEX;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_TOUCH_PANEL_SECURITY;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_PIN_INDEX;
        Crestron.Logos.SplusObjects.StringInput EDIT_PIN_PIN;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_PIN_LEVEL;
        Crestron.Logos.SplusObjects.StringInput PATHFILEEXT;
        Crestron.Logos.SplusObjects.DigitalOutput FILE_OPS_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SAVE_DONE_PULSE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput EDIT_SECURITY_DIFFERENT_THAN_FILE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput EDIT_PIN_DIFFERENT_THAN_FILE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput EDIT_LEVEL_DIFFERENT_THAN_FILE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_TOUCH_PANEL_INDEX_FB;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_PIN_INDEX_FB;
        Crestron.Logos.SplusObjects.StringOutput EDIT_PIN_SELECTED_PIN_FB;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_PIN_SELECTED_LEVEL_FB;
        Crestron.Logos.SplusObjects.StringOutput MESSAGE_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TOUCH_PANEL_PIN_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> TOUCH_PANEL_PIN_LEVEL_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TOUCH_PANEL_EXPORT;
        StringParameter FILE_NAME;
        STRUCTUREPIN [] G_STRUCTPIN_CONFIG;
        CrestronString G_SPATHFILEEXT;
        short G_SIFIND = 0;
        short G_SIHANDLE = 0;
        int G_SLIBYTES = 0;
        FILE_INFO G_FILEINFO;
        CrestronString G_SFILECONTENTS;
        ushort G_IEDIT_DIFFERENT_THAN_FILE = 0;
        ushort G_IEDIT_PIN_DIFFERENT = 0;
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
            
            
            __context__.SourceCodeLine = 132;
            if ( Functions.TestForTrue  ( ( Functions.Find( TAG , DATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 134;
                SSTART  .UpdateValue ( "<" + TAG  ) ; 
                __context__.SourceCodeLine = 135;
                SEND  .UpdateValue ( "</" + TAG + ">"  ) ; 
                __context__.SourceCodeLine = 137;
                ISTART = (ushort) ( Functions.Find( SSTART , DATA ) ) ; 
                __context__.SourceCodeLine = 138;
                if ( Functions.TestForTrue  ( ( ISTART)  ) ) 
                    { 
                    __context__.SourceCodeLine = 140;
                    ISTART = (ushort) ( (Functions.Find( ">" , DATA , ISTART ) + 1) ) ; 
                    __context__.SourceCodeLine = 141;
                    if ( Functions.TestForTrue  ( ( ISTART)  ) ) 
                        { 
                        __context__.SourceCodeLine = 143;
                        IEND = (ushort) ( Functions.Find( SEND , DATA ) ) ; 
                        __context__.SourceCodeLine = 144;
                        if ( Functions.TestForTrue  ( ( IEND)  ) ) 
                            { 
                            __context__.SourceCodeLine = 146;
                            SRETURN  .UpdateValue ( Functions.Mid ( DATA ,  (int) ( ISTART ) ,  (int) ( (IEND - ISTART) ) )  ) ; 
                            __context__.SourceCodeLine = 147;
                            return ( SRETURN ) ; 
                            } 
                        
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 152;
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
            
            
            __context__.SourceCodeLine = 162;
            STAG  .UpdateValue ( "<" + TAG  ) ; 
            __context__.SourceCodeLine = 164;
            if ( Functions.TestForTrue  ( ( Functions.Find( STAG , DATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 166;
                ISTART = (ushort) ( (Functions.Find( STAG , DATA ) + Functions.Length( STAG )) ) ; 
                __context__.SourceCodeLine = 167;
                SATTRIBUTE  .UpdateValue ( ATTRIBUTE + "=\u0022"  ) ; 
                __context__.SourceCodeLine = 169;
                if ( Functions.TestForTrue  ( ( Functions.Find( SATTRIBUTE , DATA , ISTART ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 171;
                    ISTART = (ushort) ( (Functions.Find( SATTRIBUTE , DATA , ISTART ) + Functions.Length( SATTRIBUTE )) ) ; 
                    __context__.SourceCodeLine = 172;
                    ICOUNT = (ushort) ( Functions.Find( "\u0022" , DATA , ISTART ) ) ; 
                    __context__.SourceCodeLine = 173;
                    ICOUNT = (ushort) ( (ICOUNT - ISTART) ) ; 
                    __context__.SourceCodeLine = 174;
                    SRETURN  .UpdateValue ( Functions.Mid ( DATA ,  (int) ( ISTART ) ,  (int) ( ICOUNT ) )  ) ; 
                    __context__.SourceCodeLine = 176;
                    return ( SRETURN ) ; 
                    } 
                
                __context__.SourceCodeLine = 178;
                return ( "" ) ; 
                } 
            
            __context__.SourceCodeLine = 180;
            return ( "" ) ; 
            
            }
            
        private void FEDIT_OUTPUTS_CLEAR (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 184;
            EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB  .Value = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 185;
            Functions.SetArray ( TOUCH_PANEL_PIN_FB , "" ) ; 
            __context__.SourceCodeLine = 186;
            Functions.SetArray ( TOUCH_PANEL_PIN_LEVEL_FB , (ushort)65535) ; 
            __context__.SourceCodeLine = 188;
            EDIT_PIN_SELECTED_PIN_FB  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 189;
            EDIT_PIN_SELECTED_LEVEL_FB  .Value = (ushort) ( 65535 ) ; 
            
            }
            
        private void FUPDATE_EDIT_OUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 195;
            if ( Functions.TestForTrue  ( ( EDIT_TOUCH_PANEL_INDEX_FB  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 197;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_TOUCH_PANEL_INDEX_FB  .Value <= 25 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 200;
                    EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB  .Value = (ushort) ( G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].IENABLE ) ; 
                    __context__.SourceCodeLine = 202;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)3; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 204;
                        MakeString ( TOUCH_PANEL_PIN_FB [ I] , "{0:d5}", (uint)G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].LIPIN[ I ]) ; 
                        __context__.SourceCodeLine = 205;
                        TOUCH_PANEL_PIN_LEVEL_FB [ I]  .Value = (ushort) ( G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].ILEVEL[ I ] ) ; 
                        __context__.SourceCodeLine = 202;
                        } 
                    
                    __context__.SourceCodeLine = 207;
                    if ( Functions.TestForTrue  ( ( EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB  .Value)  ) ) 
                        { 
                        __context__.SourceCodeLine = 209;
                        if ( Functions.TestForTrue  ( ( EDIT_PIN_INDEX_FB  .Value)  ) ) 
                            { 
                            __context__.SourceCodeLine = 211;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_PIN_INDEX  .UshortValue <= 3 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 213;
                                MakeString ( EDIT_PIN_SELECTED_PIN_FB , "{0:d5}", (uint)G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].LIPIN[ EDIT_PIN_INDEX_FB  .Value ]) ; 
                                __context__.SourceCodeLine = 214;
                                EDIT_PIN_SELECTED_LEVEL_FB  .Value = (ushort) ( G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].ILEVEL[ EDIT_PIN_INDEX_FB  .Value ] ) ; 
                                } 
                            
                            } 
                        
                        } 
                    
                    } 
                
                } 
            
            
            }
            
        private void FPARSE_EXPORT (  SplusExecutionContext __context__, ushort IEXPORT ) 
            { 
            ushort IINDEX = 0;
            ushort IPINCOUNT = 0;
            
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32768, this );
            
            CrestronString STP;
            STP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
            
            CrestronString SPIN;
            SPIN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 229;
            SDATA  .UpdateValue ( G_SFILECONTENTS  ) ; 
            __context__.SourceCodeLine = 230;
            STP  .UpdateValue ( Functions.Remove ( "<root>" , SDATA )  ) ; 
            __context__.SourceCodeLine = 231;
            while ( Functions.TestForTrue  ( ( Functions.Find( "</tp>" , SDATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 233;
                STP  .UpdateValue ( Functions.Remove ( "</tp>" , SDATA )  ) ; 
                __context__.SourceCodeLine = 234;
                IINDEX = (ushort) ( Functions.Atoi( FXML_ATTRIBUTE( __context__ , STP , "tp" , "i" ) ) ) ; 
                __context__.SourceCodeLine = 235;
                if ( Functions.TestForTrue  ( ( IINDEX)  ) ) 
                    { 
                    __context__.SourceCodeLine = 237;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINDEX <= 25 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 239;
                        G_STRUCTPIN_CONFIG [ IINDEX] . IENABLE = (ushort) ( Functions.Atoi( FXML_PCDATA( __context__ , STP , "enable" ) ) ) ; 
                        __context__.SourceCodeLine = 240;
                        IPINCOUNT = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 241;
                        while ( Functions.TestForTrue  ( ( Functions.Find( "</pin>" , STP ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 243;
                            IPINCOUNT = (ushort) ( (IPINCOUNT + 1) ) ; 
                            __context__.SourceCodeLine = 244;
                            SPIN  .UpdateValue ( Functions.Remove ( "</pin>" , STP )  ) ; 
                            __context__.SourceCodeLine = 246;
                            if ( Functions.TestForTrue  ( ( IEXPORT)  ) ) 
                                { 
                                __context__.SourceCodeLine = 248;
                                TOUCH_PANEL_EXPORT [ IINDEX]  .UpdateValue ( SPIN  ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 250;
                            G_STRUCTPIN_CONFIG [ IINDEX] . ILEVEL [ IPINCOUNT] = (ushort) ( Functions.Atoi( FXML_ATTRIBUTE( __context__ , SPIN , "pin" , "lev" ) ) ) ; 
                            __context__.SourceCodeLine = 251;
                            G_STRUCTPIN_CONFIG [ IINDEX] . LIPIN [ IPINCOUNT] = (uint) ( Functions.Atol( FXML_PCDATA( __context__ , SPIN , "pin" ) ) ) ; 
                            __context__.SourceCodeLine = 241;
                            } 
                        
                        __context__.SourceCodeLine = 253;
                        if ( Functions.TestForTrue  ( ( IEXPORT)  ) ) 
                            { 
                            __context__.SourceCodeLine = 255;
                            TOUCH_PANEL_EXPORT [ IINDEX]  .UpdateValue ( STP  ) ; 
                            __context__.SourceCodeLine = 256;
                            Functions.ProcessLogic ( ) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        } 
                    
                    } 
                
                else 
                    { 
                    } 
                
                __context__.SourceCodeLine = 231;
                } 
            
            __context__.SourceCodeLine = 269;
            FUPDATE_EDIT_OUTPUTS (  __context__  ) ; 
            
            }
            
        private void FREAD (  SplusExecutionContext __context__, ushort IEXPORT ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 276;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 278;
            G_SIFIND = (short) ( FindFirst( G_SPATHFILEEXT , ref G_FILEINFO ) ) ; 
            __context__.SourceCodeLine = 279;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 281;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SIFIND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 283;
                G_SIHANDLE = (short) ( FileOpen( G_SPATHFILEEXT ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 285;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_SIHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 287;
                    G_SLIBYTES = (int) ( FileRead( (short)( G_SIHANDLE ) , G_SFILECONTENTS , (ushort)( FileLength( (short)( G_SIHANDLE ) ) ) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 291;
                    G_SLIBYTES = (int) ( G_SIHANDLE ) ; 
                    __context__.SourceCodeLine = 292;
                    MakeString ( MESSAGE_FB , "Error Read Open Err: {0:d}.", (int)G_SLIBYTES) ; 
                    __context__.SourceCodeLine = 293;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SLIBYTES == Functions.ToSignedLongInteger( -( 3018 ) )))  ) ) 
                        {
                        __context__.SourceCodeLine = 294;
                        MakeString ( MESSAGE_FB , "Error Read Open Loc: {0}.", G_SPATHFILEEXT ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 296;
                FileClose (  (short) ( G_SIHANDLE ) ) ; 
                __context__.SourceCodeLine = 297;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 299;
                if ( Functions.TestForTrue  ( ( G_SLIBYTES)  ) ) 
                    { 
                    __context__.SourceCodeLine = 301;
                    FPARSE_EXPORT (  __context__ , (ushort)( IEXPORT )) ; 
                    __context__.SourceCodeLine = 302;
                    EDIT_SECURITY_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 303;
                    EDIT_PIN_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 304;
                    EDIT_LEVEL_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 305;
                    MESSAGE_FB  .UpdateValue ( Functions.FileDate ( G_FILEINFO ,  (ushort) ( 1 ) ) + "  " + Functions.FileTime ( G_FILEINFO )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 310;
                    MakeString ( MESSAGE_FB , "Error Read: {0:d}.", (int)G_SLIBYTES) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 315;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 317;
                MakeString ( MESSAGE_FB , "File Not Found: {0}.", G_SPATHFILEEXT ) ; 
                } 
            
            
            }
            
        private void FWRITE (  SplusExecutionContext __context__ ) 
            { 
            ushort ITPINDEX = 0;
            ushort IPININDEX = 0;
            
            
            __context__.SourceCodeLine = 325;
            G_SFILECONTENTS  .UpdateValue ( "<?xml version=\u00221.0\u0022 ?>\r<root>\r"  ) ; 
            __context__.SourceCodeLine = 327;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)25; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( ITPINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ITPINDEX  >= __FN_FORSTART_VAL__1) && (ITPINDEX  <= __FN_FOREND_VAL__1) ) : ( (ITPINDEX  <= __FN_FORSTART_VAL__1) && (ITPINDEX  >= __FN_FOREND_VAL__1) ) ; ITPINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 329;
                G_SFILECONTENTS  .UpdateValue ( G_SFILECONTENTS + "\t<tp i=\u0022" + Functions.ItoA (  (int) ( ITPINDEX ) ) + "\u0022>\r\t"  ) ; 
                __context__.SourceCodeLine = 330;
                G_SFILECONTENTS  .UpdateValue ( G_SFILECONTENTS + "\t<enable>" + Functions.ItoA (  (int) ( G_STRUCTPIN_CONFIG[ ITPINDEX ].IENABLE ) ) + "</enable>\r\t"  ) ; 
                __context__.SourceCodeLine = 332;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)3; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( IPININDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (IPININDEX  >= __FN_FORSTART_VAL__2) && (IPININDEX  <= __FN_FOREND_VAL__2) ) : ( (IPININDEX  <= __FN_FORSTART_VAL__2) && (IPININDEX  >= __FN_FOREND_VAL__2) ) ; IPININDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 334;
                    MakeString ( G_SFILECONTENTS , "{0}\t<pin lev=\u0022{1:d}\u0022>{2:d5}</pin>\r\t", G_SFILECONTENTS , (ushort)G_STRUCTPIN_CONFIG[ ITPINDEX ].ILEVEL[ IPININDEX ], (uint)G_STRUCTPIN_CONFIG[ ITPINDEX ].LIPIN[ IPININDEX ]) ; 
                    __context__.SourceCodeLine = 332;
                    } 
                
                __context__.SourceCodeLine = 336;
                G_SFILECONTENTS  .UpdateValue ( G_SFILECONTENTS + "</tp>\r"  ) ; 
                __context__.SourceCodeLine = 327;
                } 
            
            __context__.SourceCodeLine = 338;
            G_SFILECONTENTS  .UpdateValue ( G_SFILECONTENTS + "</root>"  ) ; 
            __context__.SourceCodeLine = 340;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 341;
            G_SIHANDLE = (short) ( FileOpen( G_SPATHFILEEXT ,(ushort) (((256 | 1) | 512) | 16384) ) ) ; 
            __context__.SourceCodeLine = 343;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_SIHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 345;
                G_SLIBYTES = (int) ( FileWrite( (short)( G_SIHANDLE ) , G_SFILECONTENTS , (ushort)( Functions.Length( G_SFILECONTENTS ) ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 349;
                G_SLIBYTES = (int) ( G_SIHANDLE ) ; 
                } 
            
            __context__.SourceCodeLine = 351;
            FileClose (  (short) ( G_SIHANDLE ) ) ; 
            __context__.SourceCodeLine = 352;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 355;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_SLIBYTES < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 357;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SLIBYTES == Functions.ToSignedLongInteger( -( 3018 ) )))  ) ) 
                    { 
                    __context__.SourceCodeLine = 359;
                    MakeString ( MESSAGE_FB , "Error Write Err Loc: {0}.", G_SPATHFILEEXT ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 363;
                    MakeString ( MESSAGE_FB , "Error Write Err: {0:d}.", (int)G_SLIBYTES) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 368;
                Functions.Pulse ( 1, SAVE_DONE_PULSE_FB ) ; 
                } 
            
            
            }
            
        private ushort FCHECK_EDIT_PARAMETERS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 374;
            if ( Functions.TestForTrue  ( ( Functions.Not( FILE_OPS_FB  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 376;
                if ( Functions.TestForTrue  ( ( EDIT_TOUCH_PANEL_INDEX_FB  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 378;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_TOUCH_PANEL_INDEX_FB  .Value <= 25 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 380;
                        if ( Functions.TestForTrue  ( ( EDIT_PIN_INDEX  .UshortValue)  ) ) 
                            { 
                            __context__.SourceCodeLine = 382;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_PIN_INDEX  .UshortValue <= 3 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 384;
                                return (ushort)( 1) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 388;
                                MakeString ( MESSAGE_FB , "Edit Pin Index {0:d} out of range, max index={1:d}.", (ushort)EDIT_PIN_INDEX  .UshortValue, (ushort)3) ; 
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 393;
                            MakeString ( MESSAGE_FB , "Edit Pin Index Zero not valid.") ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 398;
                        MakeString ( MESSAGE_FB , "Edit Touchpanel Index {0:d} out of range, max index={1:d}.", (ushort)EDIT_TOUCH_PANEL_INDEX  .UshortValue, (ushort)25) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 403;
                    MakeString ( MESSAGE_FB , "Edit Touchpanel Index Zero not valid.") ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 408;
                MakeString ( MESSAGE_FB , "Edit Parameter event ignored, File Ops are busy.") ; 
                } 
            
            __context__.SourceCodeLine = 410;
            return (ushort)( 0) ; 
            
            }
            
        object READ_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 416;
                if ( Functions.TestForTrue  ( ( Functions.Not( FILE_OPS_FB  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 418;
                    FILE_OPS_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 419;
                    FREAD (  __context__ , (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 420;
                    FILE_OPS_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 424;
                    MakeString ( MESSAGE_FB , "Read File ignored, File Ops busy.") ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object EDIT_TOUCH_PANEL_INDEX_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 432;
            if ( Functions.TestForTrue  ( ( Functions.Not( FILE_OPS_FB  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 434;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_TOUCH_PANEL_INDEX  .UshortValue <= 25 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 436;
                    if ( Functions.TestForTrue  ( ( EDIT_TOUCH_PANEL_INDEX  .UshortValue)  ) ) 
                        { 
                        __context__.SourceCodeLine = 438;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( EDIT_SECURITY_DIFFERENT_THAN_FILE_FB  .Value ) || Functions.TestForTrue ( EDIT_PIN_DIFFERENT_THAN_FILE_FB  .Value )) ) ) || Functions.TestForTrue ( EDIT_LEVEL_DIFFERENT_THAN_FILE_FB  .Value )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 440;
                            FILE_OPS_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 441;
                            FREAD (  __context__ , (ushort)( 0 )) ; 
                            __context__.SourceCodeLine = 442;
                            FILE_OPS_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 447;
                        EDIT_TOUCH_PANEL_INDEX_FB  .Value = (ushort) ( EDIT_TOUCH_PANEL_INDEX  .UshortValue ) ; 
                        __context__.SourceCodeLine = 448;
                        FUPDATE_EDIT_OUTPUTS (  __context__  ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 452;
                        FEDIT_OUTPUTS_CLEAR (  __context__  ) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 457;
                    MakeString ( MESSAGE_FB , "Edit Touchpanel Index {0:d} out of range, max index={1:d}.", (ushort)EDIT_TOUCH_PANEL_INDEX  .UshortValue, (ushort)25) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 462;
                MakeString ( MESSAGE_FB , "Edit Touchpanel Index change event ignored, File Ops busy.") ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object EDIT_PIN_INDEX_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 468;
        if ( Functions.TestForTrue  ( ( FCHECK_EDIT_PARAMETERS( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 470;
            EDIT_PIN_INDEX_FB  .Value = (ushort) ( EDIT_PIN_INDEX  .UshortValue ) ; 
            __context__.SourceCodeLine = 471;
            MakeString ( EDIT_PIN_SELECTED_PIN_FB , "{0:d5}", (uint)G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].LIPIN[ EDIT_PIN_INDEX_FB  .Value ]) ; 
            __context__.SourceCodeLine = 472;
            EDIT_PIN_SELECTED_LEVEL_FB  .Value = (ushort) ( G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].ILEVEL[ EDIT_PIN_INDEX_FB  .Value ] ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_TOUCH_PANEL_SECURITY_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 478;
        if ( Functions.TestForTrue  ( ( Functions.Not( FILE_OPS_FB  .Value ))  ) ) 
            { 
            __context__.SourceCodeLine = 480;
            if ( Functions.TestForTrue  ( ( EDIT_TOUCH_PANEL_INDEX_FB  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 482;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_TOUCH_PANEL_INDEX_FB  .Value <= 25 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 484;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EDIT_TOUCH_PANEL_SECURITY  .UshortValue == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 486;
                        EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 487;
                        EDIT_PIN_SELECTED_PIN_FB  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 488;
                        EDIT_PIN_SELECTED_LEVEL_FB  .Value = (ushort) ( 65535 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 492;
                        EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 494;
                        if ( Functions.TestForTrue  ( ( FCHECK_EDIT_PARAMETERS( __context__ ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 496;
                            MakeString ( EDIT_PIN_SELECTED_PIN_FB , "{0:d5}", (uint)G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].LIPIN[ EDIT_PIN_INDEX_FB  .Value ]) ; 
                            __context__.SourceCodeLine = 497;
                            EDIT_PIN_SELECTED_LEVEL_FB  .Value = (ushort) ( G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].ILEVEL[ EDIT_PIN_INDEX_FB  .Value ] ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 500;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EDIT_TOUCH_PANEL_SECURITY  .UshortValue != G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].IENABLE))  ) ) 
                        { 
                        __context__.SourceCodeLine = 502;
                        EDIT_SECURITY_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 506;
                        EDIT_SECURITY_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    } 
                
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_PIN_PIN_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 516;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( EDIT_PIN_PIN ) == 5))  ) ) 
            { 
            __context__.SourceCodeLine = 518;
            if ( Functions.TestForTrue  ( ( FCHECK_EDIT_PARAMETERS( __context__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 520;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atol( EDIT_PIN_PIN ) != G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].LIPIN[ EDIT_PIN_INDEX_FB  .Value ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 522;
                    EDIT_PIN_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 526;
                    EDIT_PIN_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 531;
                MakeString ( MESSAGE_FB , "Edit Pin Pin change event ignored. Parameters.") ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 536;
            MakeString ( MESSAGE_FB , "Edit Pin Pin change event ignored. Length.") ; 
            __context__.SourceCodeLine = 537;
            EDIT_PIN_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_PIN_LEVEL_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 543;
        if ( Functions.TestForTrue  ( ( EDIT_PIN_LEVEL  .UshortValue)  ) ) 
            { 
            __context__.SourceCodeLine = 545;
            if ( Functions.TestForTrue  ( ( FCHECK_EDIT_PARAMETERS( __context__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 547;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_PIN_LEVEL  .UshortValue <= 3 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 549;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EDIT_PIN_LEVEL  .UshortValue != G_STRUCTPIN_CONFIG[ EDIT_TOUCH_PANEL_INDEX_FB  .Value ].ILEVEL[ EDIT_PIN_INDEX_FB  .Value ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 551;
                        EDIT_LEVEL_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 555;
                        EDIT_LEVEL_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 560;
                    EDIT_LEVEL_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 561;
                    MakeString ( MESSAGE_FB , "Edit Pin Level {0:d} out of range, Level range 1~{1:d}.", (ushort)EDIT_PIN_LEVEL  .UshortValue, (ushort)3) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 566;
                MakeString ( MESSAGE_FB , "Edit Pin Level change ignored. Parameters.") ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 571;
            EDIT_LEVEL_DIFFERENT_THAN_FILE_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 572;
            MakeString ( MESSAGE_FB , "Edit Pin Level {0:d} out of range, Level range 1~{1:d}.", (ushort)EDIT_PIN_LEVEL  .UshortValue, (ushort)3) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_SAVE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ISAVE = 0;
        
        
        __context__.SourceCodeLine = 580;
        if ( Functions.TestForTrue  ( ( FCHECK_EDIT_PARAMETERS( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 582;
            ISAVE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 583;
            if ( Functions.TestForTrue  ( ( EDIT_SECURITY_DIFFERENT_THAN_FILE_FB  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 585;
                if ( Functions.TestForTrue  ( ( EDIT_SAVE_TO_ALL  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 587;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)25; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( ISAVE  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ISAVE  >= __FN_FORSTART_VAL__1) && (ISAVE  <= __FN_FOREND_VAL__1) ) : ( (ISAVE  <= __FN_FORSTART_VAL__1) && (ISAVE  >= __FN_FOREND_VAL__1) ) ; ISAVE  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 589;
                        G_STRUCTPIN_CONFIG [ ISAVE] . IENABLE = (ushort) ( EDIT_TOUCH_PANEL_SECURITY  .UshortValue ) ; 
                        __context__.SourceCodeLine = 587;
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 594;
                    G_STRUCTPIN_CONFIG [ EDIT_TOUCH_PANEL_INDEX_FB  .Value] . IENABLE = (ushort) ( EDIT_TOUCH_PANEL_SECURITY  .UshortValue ) ; 
                    } 
                
                __context__.SourceCodeLine = 596;
                ISAVE = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 598;
            if ( Functions.TestForTrue  ( ( EDIT_PIN_DIFFERENT_THAN_FILE_FB  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 600;
                if ( Functions.TestForTrue  ( ( EDIT_SAVE_TO_ALL  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 602;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)25; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( ISAVE  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (ISAVE  >= __FN_FORSTART_VAL__2) && (ISAVE  <= __FN_FOREND_VAL__2) ) : ( (ISAVE  <= __FN_FORSTART_VAL__2) && (ISAVE  >= __FN_FOREND_VAL__2) ) ; ISAVE  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 604;
                        G_STRUCTPIN_CONFIG [ ISAVE] . LIPIN [ EDIT_PIN_INDEX_FB  .Value] = (uint) ( Functions.Atol( EDIT_PIN_PIN ) ) ; 
                        __context__.SourceCodeLine = 602;
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 609;
                    G_STRUCTPIN_CONFIG [ EDIT_TOUCH_PANEL_INDEX_FB  .Value] . LIPIN [ EDIT_PIN_INDEX_FB  .Value] = (uint) ( Functions.Atol( EDIT_PIN_PIN ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 611;
                ISAVE = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 613;
            if ( Functions.TestForTrue  ( ( EDIT_LEVEL_DIFFERENT_THAN_FILE_FB  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 615;
                if ( Functions.TestForTrue  ( ( EDIT_SAVE_TO_ALL  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 617;
                    ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__3 = (ushort)25; 
                    int __FN_FORSTEP_VAL__3 = (int)1; 
                    for ( ISAVE  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (ISAVE  >= __FN_FORSTART_VAL__3) && (ISAVE  <= __FN_FOREND_VAL__3) ) : ( (ISAVE  <= __FN_FORSTART_VAL__3) && (ISAVE  >= __FN_FOREND_VAL__3) ) ; ISAVE  += (ushort)__FN_FORSTEP_VAL__3) 
                        { 
                        __context__.SourceCodeLine = 619;
                        G_STRUCTPIN_CONFIG [ ISAVE] . ILEVEL [ EDIT_PIN_INDEX_FB  .Value] = (ushort) ( EDIT_PIN_LEVEL  .UshortValue ) ; 
                        __context__.SourceCodeLine = 617;
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 624;
                    G_STRUCTPIN_CONFIG [ EDIT_TOUCH_PANEL_INDEX_FB  .Value] . ILEVEL [ EDIT_PIN_INDEX_FB  .Value] = (ushort) ( EDIT_PIN_LEVEL  .UshortValue ) ; 
                    } 
                
                __context__.SourceCodeLine = 626;
                ISAVE = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 628;
            if ( Functions.TestForTrue  ( ( ISAVE)  ) ) 
                { 
                __context__.SourceCodeLine = 630;
                FILE_OPS_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 631;
                FWRITE (  __context__  ) ; 
                __context__.SourceCodeLine = 632;
                FREAD (  __context__ , (ushort)( 1 )) ; 
                __context__.SourceCodeLine = 633;
                FILE_OPS_FB  .Value = (ushort) ( 0 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 637;
                MakeString ( MESSAGE_FB , "Edit Save event ignored. Nothing new to save.") ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 642;
            MakeString ( MESSAGE_FB , "Edit Save event ignored. Parameters.") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_CANCEL_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 649;
        if ( Functions.TestForTrue  ( ( Functions.Not( FILE_OPS_FB  .Value ))  ) ) 
            { 
            __context__.SourceCodeLine = 651;
            FILE_OPS_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 652;
            FREAD (  __context__ , (ushort)( 0 )) ; 
            __context__.SourceCodeLine = 653;
            FUPDATE_EDIT_OUTPUTS (  __context__  ) ; 
            __context__.SourceCodeLine = 654;
            FILE_OPS_FB  .Value = (ushort) ( 0 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 658;
            MakeString ( MESSAGE_FB , "Edit Cancel event ignored, File Ops busy.") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PATHFILEEXT_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 664;
        if ( Functions.TestForTrue  ( ( Functions.Length( PATHFILEEXT ))  ) ) 
            { 
            __context__.SourceCodeLine = 666;
            G_SPATHFILEEXT  .UpdateValue ( PATHFILEEXT  ) ; 
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
        
        __context__.SourceCodeLine = 675;
        G_SPATHFILEEXT  .UpdateValue ( FILE_NAME  ) ; 
        __context__.SourceCodeLine = 676;
        EDIT_PIN_INDEX_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 677;
        EDIT_TOUCH_PANEL_INDEX_FB  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SPATHFILEEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
    G_SFILECONTENTS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32768, this );
    G_FILEINFO  = new FILE_INFO();
    G_FILEINFO .PopulateDefaults();
    G_STRUCTPIN_CONFIG  = new STRUCTUREPIN[ 26 ];
    for( uint i = 0; i < 26; i++ )
    {
        G_STRUCTPIN_CONFIG [i] = new STRUCTUREPIN( this, true );
        G_STRUCTPIN_CONFIG [i].PopulateCustomAttributeList( false );
        
    }
    
    REFRESH = new Crestron.Logos.SplusObjects.DigitalInput( REFRESH__DigitalInput__, this );
    m_DigitalInputList.Add( REFRESH__DigitalInput__, REFRESH );
    
    READ = new Crestron.Logos.SplusObjects.DigitalInput( READ__DigitalInput__, this );
    m_DigitalInputList.Add( READ__DigitalInput__, READ );
    
    EDIT_SAVE = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_SAVE__DigitalInput__, EDIT_SAVE );
    
    EDIT_SAVE_TO_ALL = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_SAVE_TO_ALL__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_SAVE_TO_ALL__DigitalInput__, EDIT_SAVE_TO_ALL );
    
    EDIT_CANCEL = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_CANCEL__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_CANCEL__DigitalInput__, EDIT_CANCEL );
    
    FILE_OPS_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FILE_OPS_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILE_OPS_FB__DigitalOutput__, FILE_OPS_FB );
    
    SAVE_DONE_PULSE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SAVE_DONE_PULSE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SAVE_DONE_PULSE_FB__DigitalOutput__, SAVE_DONE_PULSE_FB );
    
    EDIT_SECURITY_DIFFERENT_THAN_FILE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( EDIT_SECURITY_DIFFERENT_THAN_FILE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( EDIT_SECURITY_DIFFERENT_THAN_FILE_FB__DigitalOutput__, EDIT_SECURITY_DIFFERENT_THAN_FILE_FB );
    
    EDIT_PIN_DIFFERENT_THAN_FILE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( EDIT_PIN_DIFFERENT_THAN_FILE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( EDIT_PIN_DIFFERENT_THAN_FILE_FB__DigitalOutput__, EDIT_PIN_DIFFERENT_THAN_FILE_FB );
    
    EDIT_LEVEL_DIFFERENT_THAN_FILE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( EDIT_LEVEL_DIFFERENT_THAN_FILE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( EDIT_LEVEL_DIFFERENT_THAN_FILE_FB__DigitalOutput__, EDIT_LEVEL_DIFFERENT_THAN_FILE_FB );
    
    EDIT_TOUCH_PANEL_INDEX = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_TOUCH_PANEL_INDEX__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_TOUCH_PANEL_INDEX__AnalogSerialInput__, EDIT_TOUCH_PANEL_INDEX );
    
    EDIT_TOUCH_PANEL_SECURITY = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_TOUCH_PANEL_SECURITY__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_TOUCH_PANEL_SECURITY__AnalogSerialInput__, EDIT_TOUCH_PANEL_SECURITY );
    
    EDIT_PIN_INDEX = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_PIN_INDEX__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_PIN_INDEX__AnalogSerialInput__, EDIT_PIN_INDEX );
    
    EDIT_PIN_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_PIN_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_PIN_LEVEL__AnalogSerialInput__, EDIT_PIN_LEVEL );
    
    EDIT_TOUCH_PANEL_INDEX_FB = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_TOUCH_PANEL_INDEX_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_TOUCH_PANEL_INDEX_FB__AnalogSerialOutput__, EDIT_TOUCH_PANEL_INDEX_FB );
    
    EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB__AnalogSerialOutput__, EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB );
    
    EDIT_PIN_INDEX_FB = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_PIN_INDEX_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_PIN_INDEX_FB__AnalogSerialOutput__, EDIT_PIN_INDEX_FB );
    
    EDIT_PIN_SELECTED_LEVEL_FB = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_PIN_SELECTED_LEVEL_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_PIN_SELECTED_LEVEL_FB__AnalogSerialOutput__, EDIT_PIN_SELECTED_LEVEL_FB );
    
    TOUCH_PANEL_PIN_LEVEL_FB = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        TOUCH_PANEL_PIN_LEVEL_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( TOUCH_PANEL_PIN_LEVEL_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( TOUCH_PANEL_PIN_LEVEL_FB__AnalogSerialOutput__ + i, TOUCH_PANEL_PIN_LEVEL_FB[i+1] );
    }
    
    EDIT_PIN_PIN = new Crestron.Logos.SplusObjects.StringInput( EDIT_PIN_PIN__AnalogSerialInput__, 12, this );
    m_StringInputList.Add( EDIT_PIN_PIN__AnalogSerialInput__, EDIT_PIN_PIN );
    
    PATHFILEEXT = new Crestron.Logos.SplusObjects.StringInput( PATHFILEEXT__AnalogSerialInput__, 64, this );
    m_StringInputList.Add( PATHFILEEXT__AnalogSerialInput__, PATHFILEEXT );
    
    EDIT_PIN_SELECTED_PIN_FB = new Crestron.Logos.SplusObjects.StringOutput( EDIT_PIN_SELECTED_PIN_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_PIN_SELECTED_PIN_FB__AnalogSerialOutput__, EDIT_PIN_SELECTED_PIN_FB );
    
    MESSAGE_FB = new Crestron.Logos.SplusObjects.StringOutput( MESSAGE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( MESSAGE_FB__AnalogSerialOutput__, MESSAGE_FB );
    
    TOUCH_PANEL_PIN_FB = new InOutArray<StringOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        TOUCH_PANEL_PIN_FB[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TOUCH_PANEL_PIN_FB__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TOUCH_PANEL_PIN_FB__AnalogSerialOutput__ + i, TOUCH_PANEL_PIN_FB[i+1] );
    }
    
    TOUCH_PANEL_EXPORT = new InOutArray<StringOutput>( 25, this );
    for( uint i = 0; i < 25; i++ )
    {
        TOUCH_PANEL_EXPORT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TOUCH_PANEL_EXPORT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TOUCH_PANEL_EXPORT__AnalogSerialOutput__ + i, TOUCH_PANEL_EXPORT[i+1] );
    }
    
    FILE_NAME = new StringParameter( FILE_NAME__Parameter__, this );
    m_ParameterList.Add( FILE_NAME__Parameter__, FILE_NAME );
    
    
    READ.OnDigitalPush.Add( new InputChangeHandlerWrapper( READ_OnPush_0, false ) );
    REFRESH.OnDigitalPush.Add( new InputChangeHandlerWrapper( READ_OnPush_0, false ) );
    EDIT_TOUCH_PANEL_INDEX.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_TOUCH_PANEL_INDEX_OnChange_1, false ) );
    EDIT_PIN_INDEX.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_PIN_INDEX_OnChange_2, false ) );
    EDIT_TOUCH_PANEL_SECURITY.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_TOUCH_PANEL_SECURITY_OnChange_3, false ) );
    EDIT_PIN_PIN.OnSerialChange.Add( new InputChangeHandlerWrapper( EDIT_PIN_PIN_OnChange_4, false ) );
    EDIT_PIN_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_PIN_LEVEL_OnChange_5, false ) );
    EDIT_SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_SAVE_OnPush_6, false ) );
    EDIT_SAVE_TO_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_SAVE_OnPush_6, false ) );
    EDIT_CANCEL.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_CANCEL_OnPush_7, false ) );
    PATHFILEEXT.OnSerialChange.Add( new InputChangeHandlerWrapper( PATHFILEEXT_OnChange_8, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TOUCH_PANEL_PIN_SERVER_V0_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint REFRESH__DigitalInput__ = 0;
const uint READ__DigitalInput__ = 1;
const uint EDIT_SAVE__DigitalInput__ = 2;
const uint EDIT_SAVE_TO_ALL__DigitalInput__ = 3;
const uint EDIT_CANCEL__DigitalInput__ = 4;
const uint EDIT_TOUCH_PANEL_INDEX__AnalogSerialInput__ = 0;
const uint EDIT_TOUCH_PANEL_SECURITY__AnalogSerialInput__ = 1;
const uint EDIT_PIN_INDEX__AnalogSerialInput__ = 2;
const uint EDIT_PIN_PIN__AnalogSerialInput__ = 3;
const uint EDIT_PIN_LEVEL__AnalogSerialInput__ = 4;
const uint PATHFILEEXT__AnalogSerialInput__ = 5;
const uint FILE_OPS_FB__DigitalOutput__ = 0;
const uint SAVE_DONE_PULSE_FB__DigitalOutput__ = 1;
const uint EDIT_SECURITY_DIFFERENT_THAN_FILE_FB__DigitalOutput__ = 2;
const uint EDIT_PIN_DIFFERENT_THAN_FILE_FB__DigitalOutput__ = 3;
const uint EDIT_LEVEL_DIFFERENT_THAN_FILE_FB__DigitalOutput__ = 4;
const uint EDIT_TOUCH_PANEL_INDEX_FB__AnalogSerialOutput__ = 0;
const uint EDIT_TOUCH_PANEL_SELECTED_SECURITY_FB__AnalogSerialOutput__ = 1;
const uint EDIT_PIN_INDEX_FB__AnalogSerialOutput__ = 2;
const uint EDIT_PIN_SELECTED_PIN_FB__AnalogSerialOutput__ = 3;
const uint EDIT_PIN_SELECTED_LEVEL_FB__AnalogSerialOutput__ = 4;
const uint MESSAGE_FB__AnalogSerialOutput__ = 5;
const uint TOUCH_PANEL_PIN_FB__AnalogSerialOutput__ = 6;
const uint TOUCH_PANEL_PIN_LEVEL_FB__AnalogSerialOutput__ = 9;
const uint TOUCH_PANEL_EXPORT__AnalogSerialOutput__ = 12;
const uint FILE_NAME__Parameter__ = 10;

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
    public ushort  IENABLE = 0;
    
    [SplusStructAttribute(1, false, false)]
    public uint  [] LIPIN;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  [] ILEVEL;
    
    
    public STRUCTUREPIN( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        ILEVEL  = new ushort[ 4 ];
        LIPIN  = new uint[ 4 ];
        
        
    }
    
}

}
