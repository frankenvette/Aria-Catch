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

namespace UserModule_GP_SMART_TEXT_PROCESSOR_V1_0_5
{
    public class UserModuleClass_GP_SMART_TEXT_PROCESSOR_V1_0_5 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput READ_DRIVER;
        Crestron.Logos.SplusObjects.StringInput IN;
        Crestron.Logos.SplusObjects.DigitalOutput READ_BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput OUT;
        Crestron.Logos.SplusObjects.StringOutput AUTO_CORRECTION_FILE;
        Crestron.Logos.SplusObjects.StringOutput AUTO_CORRECTION_FILE_DATE;
        Crestron.Logos.SplusObjects.StringOutput AUTO_CORRECTION_FILE_TIME;
        Crestron.Logos.SplusObjects.StringOutput AUTO_CORRECTION_FILE_SIZE;
        ushort [,] G_IPOSITION;
        CrestronString G_SLASTTEXT;
        ushort G_IITEMCOUNT = 0;
        STRCCORRECT [] CORRECT;
        StringParameter DIRECTORY;
        private CrestronString FCORRECT (  SplusExecutionContext __context__, CrestronString SDATA ) 
            { 
            ushort O = 0;
            ushort I = 0;
            ushort IPOSITION = 0;
            ushort ILENGTH = 0;
            ushort ICORRECTION = 0;
            
            CrestronString SNEWTEXT;
            SNEWTEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 254, this );
            
            
            __context__.SourceCodeLine = 183;
            SNEWTEXT  .UpdateValue ( SDATA  ) ; 
            __context__.SourceCodeLine = 184;
            IPOSITION = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 185;
            ICORRECTION = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 186;
            ILENGTH = (ushort) ( Functions.Length( SNEWTEXT ) ) ; 
            __context__.SourceCodeLine = 188;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_IITEMCOUNT; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( O  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (O  >= __FN_FORSTART_VAL__1) && (O  <= __FN_FOREND_VAL__1) ) : ( (O  <= __FN_FORSTART_VAL__1) && (O  >= __FN_FOREND_VAL__1) ) ; O  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 190;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)ILENGTH; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 192;
                    if ( Functions.TestForTrue  ( ( CORRECT[ O ].SENSITIVE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 194;
                        if ( Functions.TestForTrue  ( ( Functions.Find( CORRECT[ O ].SEARCHSTRING , SNEWTEXT , I ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 196;
                            IPOSITION = (ushort) ( Functions.Find( CORRECT[ O ].SEARCHSTRING , SNEWTEXT , I ) ) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 201;
                        if ( Functions.TestForTrue  ( ( Functions.Find( Functions.Upper( CORRECT[ O ].SEARCHSTRING ) , Functions.Upper( SNEWTEXT ) , I ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 203;
                            IPOSITION = (ushort) ( Functions.Find( Functions.Upper( CORRECT[ O ].SEARCHSTRING ) , Functions.Upper( SNEWTEXT ) , I ) ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 206;
                    if ( Functions.TestForTrue  ( ( IPOSITION)  ) ) 
                        { 
                        __context__.SourceCodeLine = 208;
                        Trace( "--->Correct Function Found Correction") ; 
                        __context__.SourceCodeLine = 209;
                        ICORRECTION = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 210;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CORRECT[ O ].ACTION == "Replace"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 212;
                            Trace( "--->Correct Function Replace, iPosition={0:d}", (short)IPOSITION) ; 
                            __context__.SourceCodeLine = 213;
                            SetString ( CORRECT [ O] . CORRECTION , (int)((IPOSITION - 1) + CORRECT[ O ].ACTIONPOSITION), SNEWTEXT ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 215;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CORRECT[ O ].ACTION == "Insert"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 217;
                                Trace( "--->Correct Function Insert, iPosition={0:d}", (short)IPOSITION) ; 
                                __context__.SourceCodeLine = 218;
                                SNEWTEXT  .UpdateValue ( Functions.Left ( SNEWTEXT ,  (int) ( ((IPOSITION + CORRECT[ O ].ACTIONPOSITION) - 1) ) ) + CORRECT [ O] . CORRECTION + Functions.Right ( SNEWTEXT ,  (int) ( (Functions.Length( SNEWTEXT ) - ((IPOSITION + CORRECT[ O ].ACTIONPOSITION) - 1)) ) )  ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 221;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CORRECT[ O ].ACTION == "Prefix"))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 223;
                                    Trace( "--->Correct Function Prefix, iPosition={0:d}", (short)IPOSITION) ; 
                                    __context__.SourceCodeLine = 224;
                                    SNEWTEXT  .UpdateValue ( Functions.Left ( SNEWTEXT ,  (int) ( (IPOSITION - 1) ) ) + CORRECT [ O] . CORRECTION + Functions.Right ( SNEWTEXT ,  (int) ( (Functions.Length( SNEWTEXT ) - (IPOSITION - 1)) ) )  ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 226;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CORRECT[ O ].ACTION == "Suffix"))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 228;
                                        Trace( "--->Correct Function Suffix, iPosition={0:d}", (short)IPOSITION) ; 
                                        __context__.SourceCodeLine = 229;
                                        SNEWTEXT  .UpdateValue ( Functions.Left ( SNEWTEXT ,  (int) ( ((IPOSITION - 1) + Functions.Length( CORRECT[ O ].SEARCHSTRING )) ) ) + CORRECT [ O] . CORRECTION + Functions.Right ( SNEWTEXT ,  (int) ( (Functions.Length( SNEWTEXT ) - ((IPOSITION - 1) + Functions.Length( CORRECT[ O ].SEARCHSTRING ))) ) )  ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 232;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (CORRECT[ O ].ACTION == "Upper") ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( SNEWTEXT ) >= ((IPOSITION - 1) + CORRECT[ O ].ACTIONPOSITION) ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Byte( SNEWTEXT , (int)( ((IPOSITION - 1) + CORRECT[ O ].ACTIONPOSITION) ) ) > 96 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Byte( SNEWTEXT , (int)( ((IPOSITION - 1) + CORRECT[ O ].ACTIONPOSITION) ) ) < 123 ) )) ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 237;
                                            Trace( "--->Correct Function Upper, iPosition={0:d}", (short)IPOSITION) ; 
                                            __context__.SourceCodeLine = 238;
                                            SNEWTEXT  .UpdateValue ( Functions.Left ( SNEWTEXT ,  (int) ( ((IPOSITION - 1) + (CORRECT[ O ].ACTIONPOSITION - 1)) ) ) + Functions.Upper ( Functions.Chr (  (int) ( Byte( SNEWTEXT , (int)( ((IPOSITION - 1) + CORRECT[ O ].ACTIONPOSITION) ) ) ) ) ) + Functions.Right ( SNEWTEXT ,  (int) ( (Functions.Length( SNEWTEXT ) - ((IPOSITION - 1) + CORRECT[ O ].ACTIONPOSITION)) ) )  ) ; 
                                            } 
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 243;
                        ILENGTH = (ushort) ( Functions.Length( SNEWTEXT ) ) ; 
                        __context__.SourceCodeLine = 244;
                        I = (ushort) ( (IPOSITION + 1) ) ; 
                        __context__.SourceCodeLine = 245;
                        IPOSITION = (ushort) ( 0 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 249;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 190;
                    } 
                
                __context__.SourceCodeLine = 188;
                } 
            
            __context__.SourceCodeLine = 253;
            if ( Functions.TestForTrue  ( ( ICORRECTION)  ) ) 
                {
                __context__.SourceCodeLine = 254;
                return ( SNEWTEXT ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 256;
                return ( SDATA ) ; 
                }
            
            
            return ""; // default return value (none specified in module)
            }
            
        private CrestronString FXML_ELEMENT_PARSE (  SplusExecutionContext __context__, CrestronString DATA , CrestronString TAG ) 
            { 
            CrestronString SSTART;
            CrestronString SEND;
            SSTART  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 22, this );
            SEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 23, this );
            
            CrestronString SRETURN;
            SRETURN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 254, this );
            
            ushort ISTART = 0;
            ushort IEND = 0;
            
            
            __context__.SourceCodeLine = 265;
            SSTART  .UpdateValue ( "<" + TAG + ">"  ) ; 
            __context__.SourceCodeLine = 266;
            SEND  .UpdateValue ( "</" + TAG + ">"  ) ; 
            __context__.SourceCodeLine = 267;
            ISTART = (ushort) ( (Functions.Find( SSTART , DATA ) + Functions.Length( SSTART )) ) ; 
            __context__.SourceCodeLine = 268;
            IEND = (ushort) ( Functions.Find( SEND , DATA ) ) ; 
            __context__.SourceCodeLine = 270;
            SRETURN  .UpdateValue ( Functions.Mid ( DATA ,  (int) ( ISTART ) ,  (int) ( (IEND - ISTART) ) )  ) ; 
            __context__.SourceCodeLine = 272;
            return ( SRETURN ) ; 
            
            }
            
        private void FDRIVER_RETRIEVE (  SplusExecutionContext __context__ ) 
            { 
            short IFIND = 0;
            short IHANDLE = 0;
            short IBYTES = 0;
            
            CrestronString SPATH;
            CrestronString SDRIVERDATA;
            SPATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
            SDRIVERDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
            
            CrestronString SITEM;
            CrestronString SINTEGER;
            SITEM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 510, this );
            SINTEGER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
            
            ushort IITEM = 0;
            ushort ISIZE = 0;
            ushort X = 0;
            
            FILE_INFO L_FILEINFO;
            L_FILEINFO  = new FILE_INFO();
            L_FILEINFO .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 283;
            Trace( "--->Smart Keyboard Driver Read Function") ; 
            __context__.SourceCodeLine = 284;
            IFIND = (short) ( 1 ) ; 
            __context__.SourceCodeLine = 286;
            SPATH  .UpdateValue ( "\\" + DIRECTORY + "\\" + "KeyboardCorrectionDriver*.**.xml"  ) ; 
            __context__.SourceCodeLine = 288;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 290;
            IFIND = (short) ( FindFirst( SPATH , ref L_FILEINFO ) ) ; 
            __context__.SourceCodeLine = 291;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 292;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IFIND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 294;
                SPATH  .UpdateValue ( DIRECTORY + L_FILEINFO .  Name  ) ; 
                __context__.SourceCodeLine = 295;
                ISIZE = (ushort) ( Functions.LowWord( (uint)( L_FILEINFO.lSize ) ) ) ; 
                __context__.SourceCodeLine = 296;
                IHANDLE = (short) ( FileOpen( SPATH ,(ushort) (0 | 32768) ) ) ; 
                __context__.SourceCodeLine = 297;
                IBYTES = (short) ( FileRead( (short)( IHANDLE ) , SDRIVERDATA , (ushort)( ISIZE ) ) ) ; 
                __context__.SourceCodeLine = 298;
                if ( Functions.TestForTrue  ( ( IBYTES)  ) ) 
                    { 
                    __context__.SourceCodeLine = 300;
                    AUTO_CORRECTION_FILE  .UpdateValue ( L_FILEINFO .  Name  ) ; 
                    __context__.SourceCodeLine = 301;
                    AUTO_CORRECTION_FILE_DATE  .UpdateValue ( Functions.FileDate ( L_FILEINFO ,  (ushort) ( 1 ) )  ) ; 
                    __context__.SourceCodeLine = 302;
                    AUTO_CORRECTION_FILE_TIME  .UpdateValue ( Functions.FileTime ( L_FILEINFO )  ) ; 
                    __context__.SourceCodeLine = 303;
                    AUTO_CORRECTION_FILE_SIZE  .UpdateValue ( Functions.ItoA (  (int) ( FileLength( (short)( IHANDLE ) ) ) )  ) ; 
                    __context__.SourceCodeLine = 305;
                    FileClose (  (short) ( IHANDLE ) ) ; 
                    __context__.SourceCodeLine = 306;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 307;
                    Trace( "------>Found File : {0}", SPATH ) ; 
                    __context__.SourceCodeLine = 308;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "<KeyboardCorrectionDriver>" , SDRIVERDATA ) ) && Functions.TestForTrue ( Functions.Find( "</KeyboardCorrectionDriver>" , SDRIVERDATA ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 311;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "</Item>" , SDRIVERDATA , Functions.Find( "<Correction>" , SDRIVERDATA ) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 313;
                            G_IITEMCOUNT = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 314;
                            X = (ushort) ( Functions.Find( "<Correction>" , SDRIVERDATA ) ) ; 
                            __context__.SourceCodeLine = 315;
                            while ( Functions.TestForTrue  ( ( Functions.Find( "</Item>" , SDRIVERDATA , X ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 317;
                                X = (ushort) ( Functions.Find( "</Item>" , SDRIVERDATA , X ) ) ; 
                                __context__.SourceCodeLine = 318;
                                Trace( "--------->Position of </Item> : {0:d}", (short)X) ; 
                                __context__.SourceCodeLine = 319;
                                X = (ushort) ( (X + 8) ) ; 
                                __context__.SourceCodeLine = 320;
                                G_IITEMCOUNT = (ushort) ( (G_IITEMCOUNT + 1) ) ; 
                                __context__.SourceCodeLine = 315;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 324;
                        Trace( "------>Item Count ={0:d}", (short)G_IITEMCOUNT) ; 
                        __context__.SourceCodeLine = 328;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)G_IITEMCOUNT; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( IITEM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IITEM  >= __FN_FORSTART_VAL__1) && (IITEM  <= __FN_FOREND_VAL__1) ) : ( (IITEM  <= __FN_FORSTART_VAL__1) && (IITEM  >= __FN_FOREND_VAL__1) ) ; IITEM  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 330;
                            SITEM  .UpdateValue ( Functions.Remove ( "</Item>" , SDRIVERDATA )  ) ; 
                            __context__.SourceCodeLine = 331;
                            CORRECT [ IITEM] . SEARCHSTRING  .UpdateValue ( FXML_ELEMENT_PARSE (  __context__ , SITEM, "SearchString")  ) ; 
                            __context__.SourceCodeLine = 332;
                            CORRECT [ IITEM] . SENSITIVE = (ushort) ( Functions.Atoi( FXML_ELEMENT_PARSE( __context__ , SITEM , "Sensitive" ) ) ) ; 
                            __context__.SourceCodeLine = 333;
                            CORRECT [ IITEM] . CORRECTION  .UpdateValue ( FXML_ELEMENT_PARSE (  __context__ , SITEM, "Correct")  ) ; 
                            __context__.SourceCodeLine = 334;
                            CORRECT [ IITEM] . ACTION  .UpdateValue ( FXML_ELEMENT_PARSE (  __context__ , SITEM, "Action")  ) ; 
                            __context__.SourceCodeLine = 338;
                            SINTEGER  .UpdateValue ( FXML_ELEMENT_PARSE (  __context__ , SITEM, "ActionPosition")  ) ; 
                            __context__.SourceCodeLine = 339;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "-" , SINTEGER ))  ) ) 
                                {
                                __context__.SourceCodeLine = 340;
                                CORRECT [ IITEM] . ACTIONPOSITION = (short) ( (0 - Functions.Atoi( SINTEGER )) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 342;
                                CORRECT [ IITEM] . ACTIONPOSITION = (short) ( Functions.Atoi( SINTEGER ) ) ; 
                                }
                            
                            __context__.SourceCodeLine = 344;
                            SINTEGER  .UpdateValue ( FXML_ELEMENT_PARSE (  __context__ , SITEM, "Offset")  ) ; 
                            __context__.SourceCodeLine = 345;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "-" , SINTEGER ))  ) ) 
                                {
                                __context__.SourceCodeLine = 346;
                                CORRECT [ IITEM] . OFFSET = (short) ( (0 - Functions.Atoi( SINTEGER )) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 348;
                                CORRECT [ IITEM] . OFFSET = (short) ( Functions.Atoi( SINTEGER ) ) ; 
                                }
                            
                            __context__.SourceCodeLine = 351;
                            Trace( "------>Keyboard Driver Parse Start") ; 
                            __context__.SourceCodeLine = 352;
                            Trace( "--------->Item[{0:d}] Search String ={1}", (short)IITEM, CORRECT [ IITEM] . SEARCHSTRING ) ; 
                            __context__.SourceCodeLine = 353;
                            Trace( "--------->Item[{0:d}] Sensitivity ={1:d}", (short)IITEM, (short)CORRECT[ IITEM ].SENSITIVE) ; 
                            __context__.SourceCodeLine = 354;
                            Trace( "--------->Item[{0:d}] Correct ={1}", (short)IITEM, CORRECT [ IITEM] . CORRECTION ) ; 
                            __context__.SourceCodeLine = 355;
                            Trace( "--------->Item[{0:d}] Action ={1}", (short)IITEM, CORRECT [ IITEM] . ACTION ) ; 
                            __context__.SourceCodeLine = 356;
                            Trace( "--------->Item[{0:d}] Action Position ={1:d}", (short)IITEM, (short)CORRECT[ IITEM ].ACTIONPOSITION) ; 
                            __context__.SourceCodeLine = 357;
                            Trace( "--------->Item[{0:d}] Offset ={1:d}", (short)IITEM, (short)CORRECT[ IITEM ].OFFSET) ; 
                            __context__.SourceCodeLine = 358;
                            Trace( "------>Keyboard Driver Parse End") ; 
                            __context__.SourceCodeLine = 328;
                            } 
                        
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 364;
                    FileClose (  (short) ( IHANDLE ) ) ; 
                    __context__.SourceCodeLine = 365;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 366;
                    GenerateUserError ( "Keyboard Driver Read Error : {0}", SPATH ) ; 
                    __context__.SourceCodeLine = 367;
                    Trace( "------>Keyboard Driver Read Error : {0}", SPATH ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 372;
                FileClose (  (short) ( IHANDLE ) ) ; 
                __context__.SourceCodeLine = 373;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 374;
                GenerateUserError ( "Keyboard Driver Not Found : {0}", SPATH ) ; 
                __context__.SourceCodeLine = 375;
                Trace( "--->Keyboard Driver Not Found : {0}", SPATH ) ; 
                } 
            
            
            }
            
        object READ_DRIVER_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 382;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (READ_BUSY_FB  .Value == 0) ) && Functions.TestForTrue ( ENABLE  .Value )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 384;
                    READ_BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 385;
                    FDRIVER_RETRIEVE (  __context__  ) ; 
                    __context__.SourceCodeLine = 386;
                    READ_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object IN_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort ILENGTH = 0;
            ushort O = 0;
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 394;
            ILENGTH = (ushort) ( Functions.Length( IN ) ) ; 
            __context__.SourceCodeLine = 396;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IN != G_SLASTTEXT))  ) ) 
                { 
                __context__.SourceCodeLine = 398;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( IN ) > 1 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 400;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( IN ) != Functions.Length( G_SLASTTEXT )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 402;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Left( IN , (int)( (Functions.Length( IN ) - 1) ) ) == Functions.Left( G_SLASTTEXT , (int)( (Functions.Length( IN ) - 1) ) )))  ) ) 
                            { 
                            __context__.SourceCodeLine = 404;
                            Trace( "--->Process Same Text but New character at the end: {0}", IN ) ; 
                            __context__.SourceCodeLine = 405;
                            G_SLASTTEXT  .UpdateValue ( FCORRECT (  __context__ , IN)  ) ; 
                            __context__.SourceCodeLine = 406;
                            OUT  .UpdateValue ( G_SLASTTEXT  ) ; 
                            __context__.SourceCodeLine = 407;
                            Functions.TerminateEvent (); 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 411;
                            Trace( "--->Process New Text of different Length, Possible text inserted : {0}", IN ) ; 
                            __context__.SourceCodeLine = 414;
                            G_SLASTTEXT  .UpdateValue ( IN  ) ; 
                            __context__.SourceCodeLine = 415;
                            Functions.TerminateEvent (); 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 429;
                        Trace( "--->Process New Text But Same Length as Old text : {0}", IN ) ; 
                        __context__.SourceCodeLine = 430;
                        G_SLASTTEXT  .UpdateValue ( IN  ) ; 
                        __context__.SourceCodeLine = 431;
                        Functions.TerminateEvent (); 
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 434;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( IN ) == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( Byte( IN , (int)( 1 ) ) < 122 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Byte( IN , (int)( 1 ) ) > 97 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 436;
                        Trace( "--->Process New Text of Length 1, Upper Routine : {0}", IN ) ; 
                        __context__.SourceCodeLine = 438;
                        G_SLASTTEXT  .UpdateValue ( Functions.Upper ( IN )  ) ; 
                        __context__.SourceCodeLine = 439;
                        OUT  .UpdateValue ( G_SLASTTEXT  ) ; 
                        __context__.SourceCodeLine = 440;
                        Functions.TerminateEvent (); 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 455;
                        Trace( "--->New Text of Length 0") ; 
                        } 
                    
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
        
        __context__.SourceCodeLine = 465;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 466;
        if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 467;
            FDRIVER_RETRIEVE (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_IPOSITION  = new ushort[ 255,47 ];
    G_SLASTTEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 140, this );
    CORRECT  = new STRCCORRECT[ 51 ];
    for( uint i = 0; i < 51; i++ )
    {
        CORRECT [i] = new STRCCORRECT( this, true );
        CORRECT [i].PopulateCustomAttributeList( false );
        
    }
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    READ_DRIVER = new Crestron.Logos.SplusObjects.DigitalInput( READ_DRIVER__DigitalInput__, this );
    m_DigitalInputList.Add( READ_DRIVER__DigitalInput__, READ_DRIVER );
    
    READ_BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( READ_BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( READ_BUSY_FB__DigitalOutput__, READ_BUSY_FB );
    
    IN = new Crestron.Logos.SplusObjects.StringInput( IN__AnalogSerialInput__, 140, this );
    m_StringInputList.Add( IN__AnalogSerialInput__, IN );
    
    OUT = new Crestron.Logos.SplusObjects.StringOutput( OUT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( OUT__AnalogSerialOutput__, OUT );
    
    AUTO_CORRECTION_FILE = new Crestron.Logos.SplusObjects.StringOutput( AUTO_CORRECTION_FILE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( AUTO_CORRECTION_FILE__AnalogSerialOutput__, AUTO_CORRECTION_FILE );
    
    AUTO_CORRECTION_FILE_DATE = new Crestron.Logos.SplusObjects.StringOutput( AUTO_CORRECTION_FILE_DATE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( AUTO_CORRECTION_FILE_DATE__AnalogSerialOutput__, AUTO_CORRECTION_FILE_DATE );
    
    AUTO_CORRECTION_FILE_TIME = new Crestron.Logos.SplusObjects.StringOutput( AUTO_CORRECTION_FILE_TIME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( AUTO_CORRECTION_FILE_TIME__AnalogSerialOutput__, AUTO_CORRECTION_FILE_TIME );
    
    AUTO_CORRECTION_FILE_SIZE = new Crestron.Logos.SplusObjects.StringOutput( AUTO_CORRECTION_FILE_SIZE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( AUTO_CORRECTION_FILE_SIZE__AnalogSerialOutput__, AUTO_CORRECTION_FILE_SIZE );
    
    DIRECTORY = new StringParameter( DIRECTORY__Parameter__, this );
    m_ParameterList.Add( DIRECTORY__Parameter__, DIRECTORY );
    
    
    READ_DRIVER.OnDigitalPush.Add( new InputChangeHandlerWrapper( READ_DRIVER_OnPush_0, false ) );
    IN.OnSerialChange.Add( new InputChangeHandlerWrapper( IN_OnChange_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_SMART_TEXT_PROCESSOR_V1_0_5 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ENABLE__DigitalInput__ = 0;
const uint READ_DRIVER__DigitalInput__ = 1;
const uint IN__AnalogSerialInput__ = 0;
const uint READ_BUSY_FB__DigitalOutput__ = 0;
const uint OUT__AnalogSerialOutput__ = 0;
const uint AUTO_CORRECTION_FILE__AnalogSerialOutput__ = 1;
const uint AUTO_CORRECTION_FILE_DATE__AnalogSerialOutput__ = 2;
const uint AUTO_CORRECTION_FILE_TIME__AnalogSerialOutput__ = 3;
const uint AUTO_CORRECTION_FILE_SIZE__AnalogSerialOutput__ = 4;
const uint DIRECTORY__Parameter__ = 10;

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
public class STRCCORRECT : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  SEARCHSTRING;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  SENSITIVE = 0;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  CORRECTION;
    
    [SplusStructAttribute(3, false, false)]
    public CrestronString  ACTION;
    
    [SplusStructAttribute(4, false, false)]
    public short  ACTIONPOSITION = 0;
    
    [SplusStructAttribute(5, false, false)]
    public short  OFFSET = 0;
    
    
    public STRCCORRECT( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SEARCHSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, Owner );
        CORRECTION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, Owner );
        ACTION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 7, Owner );
        
        
    }
    
}

}
