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

namespace UserModule_GP_LABELS_V2_5
{
    public class UserModuleClass_GP_LABELS_V2_5 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput READ;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_SAVE;
        Crestron.Logos.SplusObjects.StringInput EDIT_TEXT;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_INDEX;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_PATH_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_TIME_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_DATE_FB;
        Crestron.Logos.SplusObjects.StringOutput EDIT_LABEL_REPLACE_TEXT_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LABEL_FB;
        UShortParameter DIRECTORY;
        StringParameter FILE_NAME;
        StringParameter TAG;
        StringParameter ATTRIBUTE;
        StringParameter FILE_COMMENT;
        InOutArray<StringParameter> DEFAULT_LABEL;
        ushort G_INUMLABELS = 0;
        CrestronString G_SREADPATH;
        CrestronString G_SDEFAULT;
        CrestronString G_SFILE_NAME;
        CrestronString G_STAG;
        CrestronString G_SATTRIBUTE;
        CrestronString G_SFOLDER;
        CrestronString [] G_SCURRENTLABELS;
        private void FUPDATESIMPL (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 202;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_INUMLABELS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 204;
                LABEL_FB [ I]  .UpdateValue ( G_SCURRENTLABELS [ I ]  ) ; 
                __context__.SourceCodeLine = 202;
                } 
            
            
            }
            
        private void FPARSE (  SplusExecutionContext __context__, CrestronString DATA ) 
            { 
            ushort ISTART = 0;
            ushort IEND = 0;
            ushort ICOUNT = 0;
            ushort IINDEX = 0;
            
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16384, this );
            
            CrestronString SITEM;
            SITEM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            CrestronString SENDTAG;
            SENDTAG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            CrestronString SINDEXSEARCH;
            SINDEXSEARCH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            
            __context__.SourceCodeLine = 216;
            SENDTAG  .UpdateValue ( "</" + G_STAG + ">"  ) ; 
            __context__.SourceCodeLine = 217;
            SDATA  .UpdateValue ( DATA  ) ; 
            __context__.SourceCodeLine = 218;
            if ( Functions.TestForTrue  ( ( Functions.Find( "-->\r\n\t" , SDATA ))  ) ) 
                {
                __context__.SourceCodeLine = 219;
                SITEM  .UpdateValue ( Functions.Remove ( "-->\r\n\t" , SDATA )  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 220;
                if ( Functions.TestForTrue  ( ( Functions.Find( "-->\r\u0020\u0020" , SDATA ))  ) ) 
                    {
                    __context__.SourceCodeLine = 221;
                    SITEM  .UpdateValue ( Functions.Remove ( "-->\r\u0020\u0020" , SDATA )  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 223;
                    SITEM  .UpdateValue ( Functions.Remove ( "xmlns=\u0022http://www.greenpointtdi.com/cfgXML\u0022>" , SDATA )  ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 224;
            SINDEXSEARCH  .UpdateValue ( G_SATTRIBUTE + "=\u0022"  ) ; 
            __context__.SourceCodeLine = 226;
            while ( Functions.TestForTrue  ( ( Functions.Find( SENDTAG , SDATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 228;
                SITEM  .UpdateValue ( Functions.Remove ( SENDTAG , SDATA )  ) ; 
                __context__.SourceCodeLine = 230;
                ISTART = (ushort) ( (Functions.Find( SINDEXSEARCH , SITEM ) + Functions.Length( SINDEXSEARCH )) ) ; 
                __context__.SourceCodeLine = 231;
                IINDEX = (ushort) ( Functions.Atoi( Functions.Mid( SITEM , (int)( ISTART ) , (int)( (Functions.Find( "\u0022>" , SITEM , ISTART ) - ISTART) ) ) ) ) ; 
                __context__.SourceCodeLine = 233;
                ISTART = (ushort) ( (Functions.Find( ">" , SITEM ) + 1) ) ; 
                __context__.SourceCodeLine = 234;
                IEND = (ushort) ( Functions.Find( SENDTAG , SITEM ) ) ; 
                __context__.SourceCodeLine = 235;
                ICOUNT = (ushort) ( (IEND - ISTART) ) ; 
                __context__.SourceCodeLine = 236;
                G_SCURRENTLABELS [ Functions.Atoi( SITEM ) ]  .UpdateValue ( Functions.Mid ( SITEM ,  (int) ( ISTART ) ,  (int) ( ICOUNT ) )  ) ; 
                __context__.SourceCodeLine = 226;
                } 
            
            __context__.SourceCodeLine = 238;
            __context__.SourceCodeLine = 239;
            Trace( "Labels Read Complete - {0}\r\n", GetSymbolInstanceName ( ) ) ; 
            
            
            }
            
        private ushort FREAD (  SplusExecutionContext __context__ ) 
            { 
            short IHANDLE = 0;
            short IFIND = 0;
            short IDIR = 0;
            
            int IBYTES = 0;
            
            FILE_INFO FILEINFO;
            FILEINFO  = new FILE_INFO();
            FILEINFO .PopulateDefaults();
            
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16384, this );
            
            
            __context__.SourceCodeLine = 250;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 251;
            IFIND = (short) ( FindFirst( G_SREADPATH , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 252;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 253;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IFIND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 255;
                IHANDLE = (short) ( FileOpen( G_SREADPATH ,(ushort) ((256 | 0) | 16384) ) ) ; 
                __context__.SourceCodeLine = 256;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 259;
                    IBYTES = (int) ( FileRead( (short)( IHANDLE ) , SDATA , (ushort)( FileLength( (short)( IHANDLE ) ) ) ) ) ; 
                    __context__.SourceCodeLine = 260;
                    FileClose (  (short) ( IHANDLE ) ) ; 
                    __context__.SourceCodeLine = 261;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 262;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBYTES >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 264;
                        __context__.SourceCodeLine = 264;
                        Trace( "File Existed : Bytes={0:d}", (int)IBYTES) ; 
                        
                        __context__.SourceCodeLine = 265;
                        FPARSE (  __context__ , SDATA) ; 
                        __context__.SourceCodeLine = 266;
                        FILE_PATH_FB  .UpdateValue ( G_SREADPATH  ) ; 
                        __context__.SourceCodeLine = 267;
                        FILE_TIME_FB  .UpdateValue ( Functions.FileTime ( FILEINFO )  ) ; 
                        __context__.SourceCodeLine = 268;
                        FILE_DATE_FB  .UpdateValue ( Functions.FileDate ( FILEINFO ,  (ushort) ( 1 ) )  ) ; 
                        __context__.SourceCodeLine = 269;
                        return (ushort)( 1) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 273;
                        __context__.SourceCodeLine = 273;
                        Trace( "File Read Fail : Err={0:d}", (int)IBYTES) ; 
                        
                        __context__.SourceCodeLine = 274;
                        return (ushort)( 0) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 279;
                    FileClose (  (short) ( IHANDLE ) ) ; 
                    __context__.SourceCodeLine = 280;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 281;
                    __context__.SourceCodeLine = 281;
                    Trace( "File Open Fail: Err={0:d}", (short)IHANDLE) ; 
                    
                    __context__.SourceCodeLine = 282;
                    return (ushort)( 0) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 287;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (DIRECTORY  .Value == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (DIRECTORY  .Value == 3) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 289;
                    IDIR = (short) ( MakeDirectory( G_SFOLDER ) ) ; 
                    __context__.SourceCodeLine = 290;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IDIR == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (IDIR == Functions.ToSignedLongInteger( -( 3025 ) )) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 292;
                        IHANDLE = (short) ( FileOpen( G_SREADPATH ,(ushort) (((256 | 512) | 1) | 16384) ) ) ; 
                        __context__.SourceCodeLine = 293;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IHANDLE >= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 295;
                            IBYTES = (int) ( FileWrite( (short)( IHANDLE ) , G_SDEFAULT , (ushort)( Functions.Length( G_SDEFAULT ) ) ) ) ; 
                            __context__.SourceCodeLine = 296;
                            FileClose (  (short) ( IHANDLE ) ) ; 
                            __context__.SourceCodeLine = 297;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 298;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBYTES > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 300;
                                __context__.SourceCodeLine = 301;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDIR == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 302;
                                    Trace( "Directory and File Created") ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 303;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDIR == Functions.ToSignedLongInteger( -( 3025 ) )))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 304;
                                        Trace( "Directory Existed and File Created") ; 
                                        }
                                    
                                    }
                                
                                
                                __context__.SourceCodeLine = 306;
                                return (ushort)( 2) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 310;
                                __context__.SourceCodeLine = 310;
                                Trace( "Directory and File Created but File Write Failed: Err={0:d}", (int)IBYTES) ; 
                                
                                __context__.SourceCodeLine = 311;
                                return (ushort)( 0) ; 
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 316;
                            FileClose (  (short) ( IHANDLE ) ) ; 
                            __context__.SourceCodeLine = 317;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 318;
                            __context__.SourceCodeLine = 318;
                            Trace( "Directory Created but File Creation Failed: Err={0:d}", (short)IHANDLE) ; 
                            
                            __context__.SourceCodeLine = 319;
                            return (ushort)( 0) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 324;
                        FileClose (  (short) ( IHANDLE ) ) ; 
                        __context__.SourceCodeLine = 325;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 326;
                        __context__.SourceCodeLine = 326;
                        Trace( "Directory Create Failed : Err={0:d}", (short)IHANDLE) ; 
                        
                        __context__.SourceCodeLine = 327;
                        return (ushort)( 0) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 332;
                    IHANDLE = (short) ( FileOpen( G_SREADPATH ,(ushort) (((256 | 512) | 1) | 16384) ) ) ; 
                    __context__.SourceCodeLine = 333;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IHANDLE >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 335;
                        IBYTES = (int) ( FileWrite( (short)( IHANDLE ) , G_SDEFAULT , (ushort)( Functions.Length( G_SDEFAULT ) ) ) ) ; 
                        __context__.SourceCodeLine = 336;
                        FileClose (  (short) ( IHANDLE ) ) ; 
                        __context__.SourceCodeLine = 337;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 338;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBYTES > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 340;
                            __context__.SourceCodeLine = 340;
                            Trace( "Root File Created") ; 
                            
                            __context__.SourceCodeLine = 341;
                            return (ushort)( 2) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 345;
                            __context__.SourceCodeLine = 345;
                            Trace( "Root File Created but File Write Failed: Err={0:d}", (int)IBYTES) ; 
                            
                            __context__.SourceCodeLine = 346;
                            return (ushort)( 0) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 351;
                        FileClose (  (short) ( IHANDLE ) ) ; 
                        __context__.SourceCodeLine = 352;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 353;
                        __context__.SourceCodeLine = 353;
                        Trace( "Root File Create Failed: Err={0:d}", (short)IHANDLE) ; 
                        
                        __context__.SourceCodeLine = 354;
                        return (ushort)( 0) ; 
                        } 
                    
                    } 
                
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort FWRITE (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            short IHANDLE = 0;
            short IFIND = 0;
            
            int IBYTES = 0;
            
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16384, this );
            
            
            __context__.SourceCodeLine = 368;
            SDATA  .UpdateValue ( "<?xml version=\u00221.0\u0022\u0020" + "encoding=\u0022UTF-8\u0022\u0020" + "standalone=\u0022yes\u0022 ?>\r\n\r\n<" + G_SFILE_NAME + "\u0020" + "xmlns=\u0022http://www.greenpointtdi.com/cfgXML\u0022>" + "\r\n\t" + "<!--" + FILE_COMMENT + "-->\r\n\t"  ) ; 
            __context__.SourceCodeLine = 374;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_INUMLABELS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 376;
                SDATA  .UpdateValue ( SDATA + "<" + G_STAG + "\u0020" + G_SATTRIBUTE + "=\u0022" + Functions.ItoA (  (int) ( I ) ) + "\u0022>" + G_SCURRENTLABELS [ I ] + "</" + G_STAG + ">\r\n\t"  ) ; 
                __context__.SourceCodeLine = 374;
                } 
            
            __context__.SourceCodeLine = 382;
            SDATA  .UpdateValue ( Functions.Left ( SDATA ,  (int) ( (Functions.Length( SDATA ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 383;
            SDATA  .UpdateValue ( SDATA + "</" + G_SFILE_NAME + ">\r"  ) ; 
            __context__.SourceCodeLine = 385;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 386;
            IHANDLE = (short) ( FileOpen( G_SREADPATH ,(ushort) (((256 | 512) | 1) | 16384) ) ) ; 
            __context__.SourceCodeLine = 387;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 389;
                IBYTES = (int) ( FileWrite( (short)( IHANDLE ) , SDATA , (ushort)( Functions.Length( SDATA ) ) ) ) ; 
                __context__.SourceCodeLine = 390;
                FileClose (  (short) ( IHANDLE ) ) ; 
                __context__.SourceCodeLine = 391;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 392;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBYTES >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 394;
                    __context__.SourceCodeLine = 394;
                    Trace( "File Write Success") ; 
                    
                    __context__.SourceCodeLine = 395;
                    return (ushort)( 1) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 399;
                    __context__.SourceCodeLine = 399;
                    Trace( "File Write Error = {0:d}", (int)IBYTES) ; 
                    
                    __context__.SourceCodeLine = 400;
                    return (ushort)( 0) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 405;
                FileClose (  (short) ( IHANDLE ) ) ; 
                __context__.SourceCodeLine = 406;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 407;
                __context__.SourceCodeLine = 407;
                Trace( "File Open for Write Error = {0:d}", (short)IHANDLE) ; 
                
                __context__.SourceCodeLine = 408;
                return (ushort)( 0) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private CrestronString FWELLFORMED (  SplusExecutionContext __context__, CrestronString DATA ) 
            { 
            ushort IFIRSTCHR = 0;
            ushort I = 0;
            
            CrestronString SFIRSTTHREECHRS;
            SFIRSTTHREECHRS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
            
            
            __context__.SourceCodeLine = 417;
            IFIRSTCHR = (ushort) ( Byte( DATA , (int)( 1 ) ) ) ; 
            __context__.SourceCodeLine = 420;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IFIRSTCHR < 65 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IFIRSTCHR > 90 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IFIRSTCHR < 97 ) )) ) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt ( IFIRSTCHR > 122 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 422;
                SetString ( "x" , (int)1, DATA ) ; 
                } 
            
            __context__.SourceCodeLine = 425;
            SFIRSTTHREECHRS  .UpdateValue ( Functions.Left ( DATA ,  (int) ( 3 ) )  ) ; 
            __context__.SourceCodeLine = 426;
            if ( Functions.TestForTrue  ( ( Functions.FindNoCase( "xml" , SFIRSTTHREECHRS ))  ) ) 
                { 
                __context__.SourceCodeLine = 428;
                DATA  .UpdateValue ( "x_m_l" + Functions.Right ( DATA ,  (int) ( (Functions.Length( DATA ) - 3) ) )  ) ; 
                } 
            
            __context__.SourceCodeLine = 431;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)44; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 433;
                while ( Functions.TestForTrue  ( ( Functions.Find( Functions.Chr( (int)( I ) ) , DATA ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 435;
                    SetString ( "-" , (int)Functions.Find( Functions.Chr( (int)( I ) ) , DATA ), DATA ) ; 
                    __context__.SourceCodeLine = 433;
                    } 
                
                __context__.SourceCodeLine = 431;
                } 
            
            __context__.SourceCodeLine = 439;
            while ( Functions.TestForTrue  ( ( Functions.Find( Functions.Chr( (int)( 47 ) ) , DATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 441;
                SetString ( "-" , (int)Functions.Find( Functions.Chr( (int)( 47 ) ) , DATA ), DATA ) ; 
                __context__.SourceCodeLine = 439;
                } 
            
            __context__.SourceCodeLine = 444;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 58 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)64; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 446;
                while ( Functions.TestForTrue  ( ( Functions.Find( Functions.Chr( (int)( I ) ) , DATA ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 448;
                    SetString ( "-" , (int)Functions.Find( Functions.Chr( (int)( I ) ) , DATA ), DATA ) ; 
                    __context__.SourceCodeLine = 446;
                    } 
                
                __context__.SourceCodeLine = 444;
                } 
            
            __context__.SourceCodeLine = 452;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 91 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)96; 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                { 
                __context__.SourceCodeLine = 454;
                while ( Functions.TestForTrue  ( ( Functions.Find( Functions.Chr( (int)( I ) ) , DATA ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 456;
                    SetString ( "-" , (int)Functions.Find( Functions.Chr( (int)( I ) ) , DATA ), DATA ) ; 
                    __context__.SourceCodeLine = 454;
                    } 
                
                __context__.SourceCodeLine = 452;
                } 
            
            __context__.SourceCodeLine = 460;
            ushort __FN_FORSTART_VAL__4 = (ushort) ( 123 ) ;
            ushort __FN_FOREND_VAL__4 = (ushort)127; 
            int __FN_FORSTEP_VAL__4 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                { 
                __context__.SourceCodeLine = 462;
                while ( Functions.TestForTrue  ( ( Functions.Find( Functions.Chr( (int)( I ) ) , DATA ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 464;
                    SetString ( "-" , (int)Functions.Find( Functions.Chr( (int)( I ) ) , DATA ), DATA ) ; 
                    __context__.SourceCodeLine = 462;
                    } 
                
                __context__.SourceCodeLine = 460;
                } 
            
            __context__.SourceCodeLine = 467;
            return ( DATA ) ; 
            
            }
            
        object READ_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort IRETURN = 0;
                
                
                __context__.SourceCodeLine = 476;
                if ( Functions.TestForTrue  ( ( Functions.Not( BUSY_FB  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 478;
                    BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 479;
                    IRETURN = (ushort) ( FREAD( __context__ ) ) ; 
                    __context__.SourceCodeLine = 480;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IRETURN == 2))  ) ) 
                        {
                        __context__.SourceCodeLine = 481;
                        IRETURN = (ushort) ( FREAD( __context__ ) ) ; 
                        }
                    
                    __context__.SourceCodeLine = 482;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IRETURN == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 483;
                        FUPDATESIMPL (  __context__  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 484;
                    BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object EDIT_SAVE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 489;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( BUSY_FB  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( EDIT_INDEX  .UshortValue > 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( EDIT_INDEX  .UshortValue <= G_INUMLABELS ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 491;
                BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 492;
                if ( Functions.TestForTrue  ( ( FREAD( __context__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 494;
                    G_SCURRENTLABELS [ EDIT_INDEX  .UshortValue ]  .UpdateValue ( EDIT_TEXT  ) ; 
                    __context__.SourceCodeLine = 496;
                    if ( Functions.TestForTrue  ( ( FWRITE( __context__ ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 498;
                        FUPDATESIMPL (  __context__  ) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 501;
                BUSY_FB  .Value = (ushort) ( 0 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object EDIT_INDEX_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 506;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( EDIT_INDEX  .UshortValue > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( EDIT_INDEX  .UshortValue <= G_INUMLABELS ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 508;
            EDIT_LABEL_REPLACE_TEXT_FB  .UpdateValue ( G_SCURRENTLABELS [ EDIT_INDEX  .UshortValue ]  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 519;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 250 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 521;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( LABEL_FB[ I ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 523;
                G_INUMLABELS = (ushort) ( I ) ; 
                __context__.SourceCodeLine = 524;
                break ; 
                } 
            
            __context__.SourceCodeLine = 519;
            } 
        
        __context__.SourceCodeLine = 527;
        __context__.SourceCodeLine = 527;
        Trace( "{0}, g_iNumLabels = {1:d}", GetSymbolInstanceName ( ) , (short)G_INUMLABELS) ; 
        
        __context__.SourceCodeLine = 529;
        Functions.ResizeArray (  ref G_SCURRENTLABELS , (int)G_INUMLABELS, (int)32, null ) ; 
        __context__.SourceCodeLine = 531;
        G_SFILE_NAME  .UpdateValue ( FWELLFORMED (  __context__ , FILE_NAME )  ) ; 
        __context__.SourceCodeLine = 532;
        G_STAG  .UpdateValue ( FWELLFORMED (  __context__ , TAG )  ) ; 
        __context__.SourceCodeLine = 533;
        G_SATTRIBUTE  .UpdateValue ( FWELLFORMED (  __context__ , ATTRIBUTE )  ) ; 
        __context__.SourceCodeLine = 535;
        switch ((int)DIRECTORY  .Value)
        
            { 
            case 0 : 
            
                { 
                __context__.SourceCodeLine = 537;
                G_SREADPATH  .UpdateValue ( "\\NVRAM\\" + G_SFILE_NAME + ".xml"  ) ; 
                __context__.SourceCodeLine = 537;
                break ; 
                } 
            
            goto case 1 ;
            case 1 : 
            
                { 
                __context__.SourceCodeLine = 538;
                G_SREADPATH  .UpdateValue ( "\\CF0\\" + G_SFILE_NAME + ".xml"  ) ; 
                __context__.SourceCodeLine = 538;
                break ; 
                } 
            
            goto case 2 ;
            case 2 : 
            
                { 
                __context__.SourceCodeLine = 540;
                G_SREADPATH  .UpdateValue ( "\\CF0\\Labels" + "\\" + G_SFILE_NAME + ".xml"  ) ; 
                __context__.SourceCodeLine = 541;
                G_SFOLDER  .UpdateValue ( "\\CF0\\Labels"  ) ; 
                __context__.SourceCodeLine = 541;
                break ; 
                } 
            
            goto case 3 ;
            case 3 : 
            
                { 
                __context__.SourceCodeLine = 543;
                G_SREADPATH  .UpdateValue ( "\\MMC\\Labels" + "\\" + G_SFILE_NAME + ".xml"  ) ; 
                __context__.SourceCodeLine = 544;
                G_SFOLDER  .UpdateValue ( "\\MMC\\Labels"  ) ; 
                __context__.SourceCodeLine = 544;
                break ; 
                } 
            
            goto case 4 ;
            case 4 : 
            
                { 
                __context__.SourceCodeLine = 545;
                G_SREADPATH  .UpdateValue ( "\\MMC\\" + G_SFILE_NAME + ".xml"  ) ; 
                __context__.SourceCodeLine = 545;
                break ; 
                } 
            
            break;
            } 
            
        
        __context__.SourceCodeLine = 548;
        G_SDEFAULT  .UpdateValue ( "<?xml version=\u00221.0\u0022\u0020" + "encoding=\u0022UTF-8\u0022\u0020" + "standalone=\u0022yes\u0022 ?>\r\n\r\n" + "<" + G_SFILE_NAME + "\u0020" + "xmlns=\u0022http://www.greenpointtdi.com/cfgXML\u0022>" + "\r\n\t" + "<!--" + FILE_COMMENT + "-->\r\n\t"  ) ; 
        __context__.SourceCodeLine = 554;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)G_INUMLABELS; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 556;
            G_SDEFAULT  .UpdateValue ( G_SDEFAULT + "<" + G_STAG + "\u0020" + G_SATTRIBUTE + "=\u0022" + Functions.ItoA (  (int) ( I ) ) + "\u0022>" + DEFAULT_LABEL [ I ] + "</" + G_STAG + ">\r\n\t"  ) ; 
            __context__.SourceCodeLine = 554;
            } 
        
        __context__.SourceCodeLine = 561;
        G_SDEFAULT  .UpdateValue ( Functions.Left ( G_SDEFAULT ,  (int) ( (Functions.Length( G_SDEFAULT ) - 1) ) )  ) ; 
        __context__.SourceCodeLine = 562;
        G_SDEFAULT  .UpdateValue ( G_SDEFAULT + "</" + G_SFILE_NAME + ">\r\n"  ) ; 
        __context__.SourceCodeLine = 564;
        __context__.SourceCodeLine = 564;
        Trace( "Length of Default File={0:d}", (short)Functions.Length( G_SDEFAULT )) ; 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SREADPATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 48, this );
    G_SDEFAULT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16384, this );
    G_SFILE_NAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
    G_STAG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    G_SATTRIBUTE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    G_SFOLDER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    G_SCURRENTLABELS  = new CrestronString[ 251 ];
    for( uint i = 0; i < 251; i++ )
        G_SCURRENTLABELS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
    
    READ = new Crestron.Logos.SplusObjects.DigitalInput( READ__DigitalInput__, this );
    m_DigitalInputList.Add( READ__DigitalInput__, READ );
    
    EDIT_SAVE = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_SAVE__DigitalInput__, EDIT_SAVE );
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    EDIT_INDEX = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_INDEX__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_INDEX__AnalogSerialInput__, EDIT_INDEX );
    
    EDIT_TEXT = new Crestron.Logos.SplusObjects.StringInput( EDIT_TEXT__AnalogSerialInput__, 32, this );
    m_StringInputList.Add( EDIT_TEXT__AnalogSerialInput__, EDIT_TEXT );
    
    FILE_PATH_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_PATH_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_PATH_FB__AnalogSerialOutput__, FILE_PATH_FB );
    
    FILE_TIME_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_TIME_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_TIME_FB__AnalogSerialOutput__, FILE_TIME_FB );
    
    FILE_DATE_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_DATE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_DATE_FB__AnalogSerialOutput__, FILE_DATE_FB );
    
    EDIT_LABEL_REPLACE_TEXT_FB = new Crestron.Logos.SplusObjects.StringOutput( EDIT_LABEL_REPLACE_TEXT_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_LABEL_REPLACE_TEXT_FB__AnalogSerialOutput__, EDIT_LABEL_REPLACE_TEXT_FB );
    
    LABEL_FB = new InOutArray<StringOutput>( 250, this );
    for( uint i = 0; i < 250; i++ )
    {
        LABEL_FB[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LABEL_FB__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LABEL_FB__AnalogSerialOutput__ + i, LABEL_FB[i+1] );
    }
    
    DIRECTORY = new UShortParameter( DIRECTORY__Parameter__, this );
    m_ParameterList.Add( DIRECTORY__Parameter__, DIRECTORY );
    
    FILE_NAME = new StringParameter( FILE_NAME__Parameter__, this );
    m_ParameterList.Add( FILE_NAME__Parameter__, FILE_NAME );
    
    TAG = new StringParameter( TAG__Parameter__, this );
    m_ParameterList.Add( TAG__Parameter__, TAG );
    
    ATTRIBUTE = new StringParameter( ATTRIBUTE__Parameter__, this );
    m_ParameterList.Add( ATTRIBUTE__Parameter__, ATTRIBUTE );
    
    FILE_COMMENT = new StringParameter( FILE_COMMENT__Parameter__, this );
    m_ParameterList.Add( FILE_COMMENT__Parameter__, FILE_COMMENT );
    
    DEFAULT_LABEL = new InOutArray<StringParameter>( 250, this );
    for( uint i = 0; i < 250; i++ )
    {
        DEFAULT_LABEL[i+1] = new StringParameter( DEFAULT_LABEL__Parameter__ + i, DEFAULT_LABEL__Parameter__, this );
        m_ParameterList.Add( DEFAULT_LABEL__Parameter__ + i, DEFAULT_LABEL[i+1] );
    }
    
    
    READ.OnDigitalPush.Add( new InputChangeHandlerWrapper( READ_OnPush_0, false ) );
    EDIT_SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_SAVE_OnPush_1, false ) );
    EDIT_INDEX.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_INDEX_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_LABELS_V2_5 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint READ__DigitalInput__ = 0;
const uint EDIT_SAVE__DigitalInput__ = 1;
const uint EDIT_TEXT__AnalogSerialInput__ = 0;
const uint EDIT_INDEX__AnalogSerialInput__ = 1;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint FILE_PATH_FB__AnalogSerialOutput__ = 0;
const uint FILE_TIME_FB__AnalogSerialOutput__ = 1;
const uint FILE_DATE_FB__AnalogSerialOutput__ = 2;
const uint EDIT_LABEL_REPLACE_TEXT_FB__AnalogSerialOutput__ = 3;
const uint LABEL_FB__AnalogSerialOutput__ = 4;
const uint DIRECTORY__Parameter__ = 10;
const uint FILE_NAME__Parameter__ = 11;
const uint TAG__Parameter__ = 12;
const uint ATTRIBUTE__Parameter__ = 13;
const uint FILE_COMMENT__Parameter__ = 14;
const uint DEFAULT_LABEL__Parameter__ = 15;

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
