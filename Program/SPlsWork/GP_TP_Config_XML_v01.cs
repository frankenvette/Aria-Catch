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

namespace UserModule_GP_TP_CONFIG_XML_V01
{
    public class UserModuleClass_GP_TP_CONFIG_XML_V01 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput READ;
        Crestron.Logos.SplusObjects.DigitalInput SAVE;
        Crestron.Logos.SplusObjects.StringInput SEARCH_FILEEXT;
        Crestron.Logos.SplusObjects.DigitalOutput FILE_OPS_BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_OPS_MESSAGE_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_PATH_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_TIME_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_DATE_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> CONFIG_LABEL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> AREA_LABEL;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> AREA_TYPE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> AREA_VIDEO;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> AREA_AUDIO;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MENU_ITEMS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MENU_ITEM_TYPE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MENU_ITEM_ICON;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MENU_ITEM_LABEL;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MENU_ITEM_OUTPUTS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MENU_ITEM_OUTPUT_ORDER;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MENU_ITEM_INPUTS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MENU_ITEM_INPUT_ORDER;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MENU_ITEM_OUT_DFLT;
        StringParameter FILE_PATH;
        StringParameter DEFUALT_SEARCH_FILEEXT;
        CrestronString G_SFILE;
        CrestronString G_SPATHFILEEXT;
        CrestronString G_SPATHFILEEXT_SRCH;
        ushort G_ICURRENT = 0;
        private CrestronString FXML_ATTRIBUTE (  SplusExecutionContext __context__, CrestronString DATA , CrestronString TAG , CrestronString ATTRIBUTE ) 
            { 
            ushort ISTART = 0;
            ushort ICOUNT = 0;
            ushort ITMP = 0;
            
            CrestronString SRETURN;
            SRETURN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            CrestronString SATTRIBUTE;
            SATTRIBUTE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            CrestronString STAG;
            STAG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            
            __context__.SourceCodeLine = 106;
            STAG  .UpdateValue ( "<" + TAG  ) ; 
            __context__.SourceCodeLine = 108;
            if ( Functions.TestForTrue  ( ( Functions.Find( STAG , DATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 110;
                ISTART = (ushort) ( (Functions.Find( STAG , DATA ) + Functions.Length( STAG )) ) ; 
                __context__.SourceCodeLine = 111;
                SATTRIBUTE  .UpdateValue ( ATTRIBUTE + "=\u0022"  ) ; 
                __context__.SourceCodeLine = 114;
                if ( Functions.TestForTrue  ( ( Functions.Find( SATTRIBUTE , DATA , ISTART ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 116;
                    ISTART = (ushort) ( (Functions.Find( SATTRIBUTE , DATA , ISTART ) + Functions.Length( SATTRIBUTE )) ) ; 
                    __context__.SourceCodeLine = 117;
                    ICOUNT = (ushort) ( Functions.Find( "\u0022" , DATA , ISTART ) ) ; 
                    __context__.SourceCodeLine = 118;
                    ICOUNT = (ushort) ( (ICOUNT - ISTART) ) ; 
                    __context__.SourceCodeLine = 119;
                    SRETURN  .UpdateValue ( Functions.Mid ( DATA ,  (int) ( ISTART ) ,  (int) ( ICOUNT ) )  ) ; 
                    __context__.SourceCodeLine = 121;
                    return ( SRETURN ) ; 
                    } 
                
                __context__.SourceCodeLine = 123;
                return ( "" ) ; 
                } 
            
            __context__.SourceCodeLine = 125;
            return ( "" ) ; 
            
            }
            
        private void FPARSE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3200, this );
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16344, this );
            
            CrestronString SDATA2;
            SDATA2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3200, this );
            
            CrestronString SLL;
            SLL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            CrestronString SAREA;
            SAREA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString SAREATYPE;
            SAREATYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString SAREAVIDEO;
            SAREAVIDEO  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString SAREAAUDIO;
            SAREAAUDIO  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString SMENU;
            SMENU  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString [] SAP;
            SAP  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SAP [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString [] SAT;
            SAT  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SAT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString [] SATY;
            SATY  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SATY [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString [] SAL;
            SAL  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SAL [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString [] SAZ;
            SAZ  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SAZ [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString [] SAS;
            SAS  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SAS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString [] SAD;
            SAD  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SAD [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString [] SAZO;
            SAZO  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SAZO [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65, this );
            
            CrestronString [] SASO;
            SASO  = new CrestronString[ 10 ];
            for( uint i = 0; i < 10; i++ )
                SASO [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65, this );
            
            ushort I = 0;
            ushort J = 0;
            ushort K = 0;
            ushort L = 0;
            
            
            __context__.SourceCodeLine = 150;
            I = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 151;
            STEMP  .UpdateValue ( G_SFILE  ) ; 
            __context__.SourceCodeLine = 152;
            if ( Functions.TestForTrue  ( ( Functions.Find( "?>" , G_SFILE ))  ) ) 
                { 
                __context__.SourceCodeLine = 154;
                SDATA  .UpdateValue ( Functions.Remove ( "?>" , STEMP )  ) ; 
                } 
            
            __context__.SourceCodeLine = 156;
            if ( Functions.TestForTrue  ( ( Functions.Find( "-->" , STEMP ))  ) ) 
                { 
                __context__.SourceCodeLine = 158;
                SDATA  .UpdateValue ( Functions.Remove ( "-->" , STEMP )  ) ; 
                } 
            
            __context__.SourceCodeLine = 160;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "</ProgConfig>" , STEMP ) ) && Functions.TestForTrue ( Functions.Find( "<ProgConfig>" , STEMP ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 162;
                SDATA  .UpdateValue ( Functions.Remove ( "<ProgConfig>" , STEMP )  ) ; 
                __context__.SourceCodeLine = 164;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "<obj>" , STEMP ) ) && Functions.TestForTrue ( Functions.Find( "</obj>" , STEMP ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 168;
                    SDATA2  .UpdateValue ( Functions.Remove ( "</obj>" , STEMP )  ) ; 
                    __context__.SourceCodeLine = 169;
                    SDATA  .UpdateValue ( Functions.Remove ( "<obj>" , SDATA2 )  ) ; 
                    __context__.SourceCodeLine = 170;
                    I = (ushort) ( (I + 1) ) ; 
                    __context__.SourceCodeLine = 171;
                    while ( Functions.TestForTrue  ( ( Functions.Find( "<Label " , SDATA2 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 173;
                        SDATA  .UpdateValue ( Functions.Remove ( "/>" , SDATA2 )  ) ; 
                        __context__.SourceCodeLine = 174;
                        SLL  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Label", "l")  ) ; 
                        __context__.SourceCodeLine = 175;
                        CONFIG_LABEL [ I]  .UpdateValue ( SLL  ) ; 
                        __context__.SourceCodeLine = 171;
                        } 
                    
                    __context__.SourceCodeLine = 177;
                    while ( Functions.TestForTrue  ( ( Functions.Find( "<Area " , SDATA2 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 179;
                        SDATA  .UpdateValue ( Functions.Remove ( "/>" , SDATA2 )  ) ; 
                        __context__.SourceCodeLine = 180;
                        SAREA  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Area", "l")  ) ; 
                        __context__.SourceCodeLine = 181;
                        SAREATYPE  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Area", "t")  ) ; 
                        __context__.SourceCodeLine = 182;
                        SAREAVIDEO  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Area", "v")  ) ; 
                        __context__.SourceCodeLine = 183;
                        SAREAAUDIO  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Area", "a")  ) ; 
                        __context__.SourceCodeLine = 184;
                        AREA_LABEL [ I]  .UpdateValue ( SAREA  ) ; 
                        __context__.SourceCodeLine = 185;
                        AREA_TYPE [ I]  .Value = (ushort) ( Functions.Atoi( SAREATYPE ) ) ; 
                        __context__.SourceCodeLine = 186;
                        AREA_VIDEO [ I]  .Value = (ushort) ( Functions.Atoi( SAREAVIDEO ) ) ; 
                        __context__.SourceCodeLine = 187;
                        AREA_AUDIO [ I]  .Value = (ushort) ( Functions.Atoi( SAREAAUDIO ) ) ; 
                        __context__.SourceCodeLine = 177;
                        } 
                    
                    __context__.SourceCodeLine = 189;
                    while ( Functions.TestForTrue  ( ( Functions.Find( "<Menu " , SDATA2 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 191;
                        SDATA  .UpdateValue ( Functions.Remove ( "/>" , SDATA2 )  ) ; 
                        __context__.SourceCodeLine = 192;
                        SMENU  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Menu", "items")  ) ; 
                        __context__.SourceCodeLine = 193;
                        MENU_ITEMS [ I]  .Value = (ushort) ( Functions.Atoi( SMENU ) ) ; 
                        __context__.SourceCodeLine = 189;
                        } 
                    
                    __context__.SourceCodeLine = 195;
                    while ( Functions.TestForTrue  ( ( Functions.Find( "<Att " , SDATA2 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 197;
                        J = (ushort) ( (J + 1) ) ; 
                        __context__.SourceCodeLine = 198;
                        SDATA  .UpdateValue ( Functions.Remove ( "/>" , SDATA2 )  ) ; 
                        __context__.SourceCodeLine = 199;
                        SAP [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "pos")  ) ; 
                        __context__.SourceCodeLine = 200;
                        SAT [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "type")  ) ; 
                        __context__.SourceCodeLine = 201;
                        SATY [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "icon")  ) ; 
                        __context__.SourceCodeLine = 202;
                        SAL [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "label")  ) ; 
                        __context__.SourceCodeLine = 203;
                        SAZ [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "zones")  ) ; 
                        __context__.SourceCodeLine = 204;
                        SAZO [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "zOrder")  ) ; 
                        __context__.SourceCodeLine = 205;
                        SAS [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "sources")  ) ; 
                        __context__.SourceCodeLine = 206;
                        SASO [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "sOrder")  ) ; 
                        __context__.SourceCodeLine = 207;
                        SAD [ J ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Att", "default")  ) ; 
                        __context__.SourceCodeLine = 208;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atoi( SAP[ J ] ) <= 9 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 208;
                            K = (ushort) ( Functions.Atoi( SAP[ J ] ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 209;
                        
                            {
                            int __SPLS_TMPVAR__SWTCH_1__ = ((int)I);
                            
                                { 
                                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                    { 
                                    __context__.SourceCodeLine = 213;
                                    MENU_ITEM_TYPE [ K]  .Value = (ushort) ( Functions.Atoi( SAT[ J ] ) ) ; 
                                    __context__.SourceCodeLine = 214;
                                    MENU_ITEM_LABEL [ K]  .UpdateValue ( SAL [ J ]  ) ; 
                                    __context__.SourceCodeLine = 215;
                                    MENU_ITEM_ICON [ K]  .Value = (ushort) ( Functions.Atoi( SATY[ J ] ) ) ; 
                                    __context__.SourceCodeLine = 216;
                                    MENU_ITEM_OUTPUTS [ K]  .Value = (ushort) ( Functions.Atoi( SAZ[ J ] ) ) ; 
                                    __context__.SourceCodeLine = 217;
                                    MENU_ITEM_OUTPUT_ORDER [ K]  .UpdateValue ( SAZO [ J ]  ) ; 
                                    __context__.SourceCodeLine = 218;
                                    MENU_ITEM_INPUTS [ K]  .Value = (ushort) ( Functions.Atoi( SAS[ J ] ) ) ; 
                                    __context__.SourceCodeLine = 219;
                                    MENU_ITEM_INPUT_ORDER [ K]  .UpdateValue ( SASO [ J ]  ) ; 
                                    __context__.SourceCodeLine = 220;
                                    MENU_ITEM_OUT_DFLT [ K]  .Value = (ushort) ( Functions.Atoi( SAD[ J ] ) ) ; 
                                    } 
                                
                                } 
                                
                            }
                            
                        
                        __context__.SourceCodeLine = 195;
                        } 
                    
                    __context__.SourceCodeLine = 164;
                    } 
                
                __context__.SourceCodeLine = 234;
                J = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 235;
                SDATA2  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 240;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I == 0))  ) ) 
                {
                __context__.SourceCodeLine = 240;
                FILE_OPS_MESSAGE_FB  .UpdateValue ( "Error : Could not find <ProgConfig> </ProgConfig> root Tags"  ) ; 
                }
            
            
            }
            
        private ushort FREAD (  SplusExecutionContext __context__ ) 
            { 
            short SIHANDLE = 0;
            short SIFIND = 0;
            
            int SLIBYTES = 0;
            
            FILE_INFO FILEINFO;
            FILEINFO  = new FILE_INFO();
            FILEINFO .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 344;
            FILE_OPS_BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 346;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 347;
            SIFIND = (short) ( FindFirst( G_SPATHFILEEXT_SRCH , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 348;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 349;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIFIND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 351;
                G_SPATHFILEEXT  .UpdateValue ( FILE_PATH + FILEINFO .  Name  ) ; 
                __context__.SourceCodeLine = 352;
                SIHANDLE = (short) ( FileOpen( G_SPATHFILEEXT ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 353;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 355;
                    SLIBYTES = (int) ( FileRead( (short)( SIHANDLE ) , G_SFILE , (ushort)( FileLength( (short)( SIHANDLE ) ) ) ) ) ; 
                    __context__.SourceCodeLine = 356;
                    FileClose (  (short) ( SIHANDLE ) ) ; 
                    __context__.SourceCodeLine = 357;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 358;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SLIBYTES >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 362;
                        FPARSE (  __context__  ) ; 
                        __context__.SourceCodeLine = 363;
                        FILE_PATH_FB  .UpdateValue ( G_SPATHFILEEXT  ) ; 
                        __context__.SourceCodeLine = 364;
                        FILE_TIME_FB  .UpdateValue ( Functions.FileTime ( FILEINFO )  ) ; 
                        __context__.SourceCodeLine = 365;
                        FILE_DATE_FB  .UpdateValue ( Functions.FileDate ( FILEINFO ,  (ushort) ( 1 ) )  ) ; 
                        __context__.SourceCodeLine = 366;
                        FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 371;
                        MakeString ( FILE_OPS_MESSAGE_FB , "File Read Fail: Err={0:d}", (int)SLIBYTES) ; 
                        __context__.SourceCodeLine = 372;
                        FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 378;
                    FileClose (  (short) ( SIHANDLE ) ) ; 
                    __context__.SourceCodeLine = 379;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 380;
                    MakeString ( FILE_OPS_MESSAGE_FB , "File Open Fail: Handle Err={0:d}", (short)SIHANDLE) ; 
                    __context__.SourceCodeLine = 381;
                    FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 386;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 387;
                MakeString ( FILE_OPS_MESSAGE_FB , "File Not Found: {0}", G_SPATHFILEEXT_SRCH ) ; 
                __context__.SourceCodeLine = 388;
                FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        object READ_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 397;
                if ( Functions.TestForTrue  ( ( Functions.Not( FILE_OPS_BUSY_FB  .Value ))  ) ) 
                    {
                    __context__.SourceCodeLine = 397;
                    FREAD (  __context__  ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SAVE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SEARCH_FILEEXT_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMP;
        CrestronString TEMP2;
        TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
        TEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
        
        
        __context__.SourceCodeLine = 408;
        if ( Functions.TestForTrue  ( ( Functions.Length( SEARCH_FILEEXT ))  ) ) 
            { 
            __context__.SourceCodeLine = 410;
            TEMP2  .UpdateValue ( SEARCH_FILEEXT  ) ; 
            __context__.SourceCodeLine = 411;
            if ( Functions.TestForTrue  ( ( Functions.Find( "Config" , TEMP2 ))  ) ) 
                { 
                __context__.SourceCodeLine = 411;
                TEMP  .UpdateValue ( Functions.Remove ( "Config" , TEMP2 )  ) ; 
                } 
            
            __context__.SourceCodeLine = 414;
            G_SPATHFILEEXT_SRCH  .UpdateValue ( FILE_PATH + TEMP + TEMP2  ) ; 
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
        
        __context__.SourceCodeLine = 423;
        G_SPATHFILEEXT_SRCH  .UpdateValue ( FILE_PATH + DEFUALT_SEARCH_FILEEXT  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    G_SFILE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16384, this );
    G_SPATHFILEEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    G_SPATHFILEEXT_SRCH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    
    READ = new Crestron.Logos.SplusObjects.DigitalInput( READ__DigitalInput__, this );
    m_DigitalInputList.Add( READ__DigitalInput__, READ );
    
    SAVE = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE__DigitalInput__, SAVE );
    
    FILE_OPS_BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FILE_OPS_BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILE_OPS_BUSY_FB__DigitalOutput__, FILE_OPS_BUSY_FB );
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    AREA_TYPE = new InOutArray<AnalogOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        AREA_TYPE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( AREA_TYPE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( AREA_TYPE__AnalogSerialOutput__ + i, AREA_TYPE[i+1] );
    }
    
    AREA_VIDEO = new InOutArray<AnalogOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        AREA_VIDEO[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( AREA_VIDEO__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( AREA_VIDEO__AnalogSerialOutput__ + i, AREA_VIDEO[i+1] );
    }
    
    AREA_AUDIO = new InOutArray<AnalogOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        AREA_AUDIO[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( AREA_AUDIO__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( AREA_AUDIO__AnalogSerialOutput__ + i, AREA_AUDIO[i+1] );
    }
    
    MENU_ITEMS = new InOutArray<AnalogOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        MENU_ITEMS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MENU_ITEMS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MENU_ITEMS__AnalogSerialOutput__ + i, MENU_ITEMS[i+1] );
    }
    
    MENU_ITEM_TYPE = new InOutArray<AnalogOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        MENU_ITEM_TYPE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MENU_ITEM_TYPE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MENU_ITEM_TYPE__AnalogSerialOutput__ + i, MENU_ITEM_TYPE[i+1] );
    }
    
    MENU_ITEM_ICON = new InOutArray<AnalogOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        MENU_ITEM_ICON[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MENU_ITEM_ICON__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MENU_ITEM_ICON__AnalogSerialOutput__ + i, MENU_ITEM_ICON[i+1] );
    }
    
    MENU_ITEM_OUTPUTS = new InOutArray<AnalogOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        MENU_ITEM_OUTPUTS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MENU_ITEM_OUTPUTS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MENU_ITEM_OUTPUTS__AnalogSerialOutput__ + i, MENU_ITEM_OUTPUTS[i+1] );
    }
    
    MENU_ITEM_INPUTS = new InOutArray<AnalogOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        MENU_ITEM_INPUTS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MENU_ITEM_INPUTS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MENU_ITEM_INPUTS__AnalogSerialOutput__ + i, MENU_ITEM_INPUTS[i+1] );
    }
    
    MENU_ITEM_OUT_DFLT = new InOutArray<AnalogOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        MENU_ITEM_OUT_DFLT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MENU_ITEM_OUT_DFLT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MENU_ITEM_OUT_DFLT__AnalogSerialOutput__ + i, MENU_ITEM_OUT_DFLT[i+1] );
    }
    
    SEARCH_FILEEXT = new Crestron.Logos.SplusObjects.StringInput( SEARCH_FILEEXT__AnalogSerialInput__, 64, this );
    m_StringInputList.Add( SEARCH_FILEEXT__AnalogSerialInput__, SEARCH_FILEEXT );
    
    FILE_OPS_MESSAGE_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_OPS_MESSAGE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_OPS_MESSAGE_FB__AnalogSerialOutput__, FILE_OPS_MESSAGE_FB );
    
    FILE_PATH_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_PATH_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_PATH_FB__AnalogSerialOutput__, FILE_PATH_FB );
    
    FILE_TIME_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_TIME_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_TIME_FB__AnalogSerialOutput__, FILE_TIME_FB );
    
    FILE_DATE_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_DATE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_DATE_FB__AnalogSerialOutput__, FILE_DATE_FB );
    
    CONFIG_LABEL = new InOutArray<StringOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        CONFIG_LABEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( CONFIG_LABEL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( CONFIG_LABEL__AnalogSerialOutput__ + i, CONFIG_LABEL[i+1] );
    }
    
    AREA_LABEL = new InOutArray<StringOutput>( 1, this );
    for( uint i = 0; i < 1; i++ )
    {
        AREA_LABEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( AREA_LABEL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( AREA_LABEL__AnalogSerialOutput__ + i, AREA_LABEL[i+1] );
    }
    
    MENU_ITEM_LABEL = new InOutArray<StringOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        MENU_ITEM_LABEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MENU_ITEM_LABEL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MENU_ITEM_LABEL__AnalogSerialOutput__ + i, MENU_ITEM_LABEL[i+1] );
    }
    
    MENU_ITEM_OUTPUT_ORDER = new InOutArray<StringOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        MENU_ITEM_OUTPUT_ORDER[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MENU_ITEM_OUTPUT_ORDER__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MENU_ITEM_OUTPUT_ORDER__AnalogSerialOutput__ + i, MENU_ITEM_OUTPUT_ORDER[i+1] );
    }
    
    MENU_ITEM_INPUT_ORDER = new InOutArray<StringOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        MENU_ITEM_INPUT_ORDER[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MENU_ITEM_INPUT_ORDER__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MENU_ITEM_INPUT_ORDER__AnalogSerialOutput__ + i, MENU_ITEM_INPUT_ORDER[i+1] );
    }
    
    FILE_PATH = new StringParameter( FILE_PATH__Parameter__, this );
    m_ParameterList.Add( FILE_PATH__Parameter__, FILE_PATH );
    
    DEFUALT_SEARCH_FILEEXT = new StringParameter( DEFUALT_SEARCH_FILEEXT__Parameter__, this );
    m_ParameterList.Add( DEFUALT_SEARCH_FILEEXT__Parameter__, DEFUALT_SEARCH_FILEEXT );
    
    
    READ.OnDigitalPush.Add( new InputChangeHandlerWrapper( READ_OnPush_0, false ) );
    SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_1, false ) );
    SEARCH_FILEEXT.OnSerialChange.Add( new InputChangeHandlerWrapper( SEARCH_FILEEXT_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_TP_CONFIG_XML_V01 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint READ__DigitalInput__ = 0;
const uint SAVE__DigitalInput__ = 1;
const uint SEARCH_FILEEXT__AnalogSerialInput__ = 0;
const uint FILE_OPS_BUSY_FB__DigitalOutput__ = 0;
const uint BUSY_FB__DigitalOutput__ = 1;
const uint FILE_OPS_MESSAGE_FB__AnalogSerialOutput__ = 0;
const uint FILE_PATH_FB__AnalogSerialOutput__ = 1;
const uint FILE_TIME_FB__AnalogSerialOutput__ = 2;
const uint FILE_DATE_FB__AnalogSerialOutput__ = 3;
const uint CONFIG_LABEL__AnalogSerialOutput__ = 4;
const uint AREA_LABEL__AnalogSerialOutput__ = 5;
const uint AREA_TYPE__AnalogSerialOutput__ = 6;
const uint AREA_VIDEO__AnalogSerialOutput__ = 7;
const uint AREA_AUDIO__AnalogSerialOutput__ = 8;
const uint MENU_ITEMS__AnalogSerialOutput__ = 9;
const uint MENU_ITEM_TYPE__AnalogSerialOutput__ = 10;
const uint MENU_ITEM_ICON__AnalogSerialOutput__ = 19;
const uint MENU_ITEM_LABEL__AnalogSerialOutput__ = 28;
const uint MENU_ITEM_OUTPUTS__AnalogSerialOutput__ = 37;
const uint MENU_ITEM_OUTPUT_ORDER__AnalogSerialOutput__ = 46;
const uint MENU_ITEM_INPUTS__AnalogSerialOutput__ = 55;
const uint MENU_ITEM_INPUT_ORDER__AnalogSerialOutput__ = 64;
const uint MENU_ITEM_OUT_DFLT__AnalogSerialOutput__ = 73;
const uint FILE_PATH__Parameter__ = 10;
const uint DEFUALT_SEARCH_FILEEXT__Parameter__ = 11;

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
