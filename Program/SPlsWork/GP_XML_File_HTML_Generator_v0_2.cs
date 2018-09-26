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

namespace UserModule_GP_XML_FILE_HTML_GENERATOR_V0_2
{
    public class UserModuleClass_GP_XML_FILE_HTML_GENERATOR_V0_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput READ;
        Crestron.Logos.SplusObjects.StringInput SEARCH_FILEEXT;
        Crestron.Logos.SplusObjects.DigitalOutput FILE_OPS_BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_OPS_MESSAGE_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_PATH_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_TIME_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_DATE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput HTML_OBJECTS_READ_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> HTML_OBJECT_ID;
        StringParameter FILE_PATH;
        StringParameter DEFUALT_SEARCH_FILEEXT;
        CrestronString G_SFILE;
        CrestronString G_SPATHFILEEXT;
        CrestronString G_SPATHFILEEXT_SRCH;
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
            
            
            __context__.SourceCodeLine = 80;
            STAG  .UpdateValue ( "<" + TAG  ) ; 
            __context__.SourceCodeLine = 82;
            if ( Functions.TestForTrue  ( ( Functions.Find( STAG , DATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 84;
                ISTART = (ushort) ( (Functions.Find( STAG , DATA ) + Functions.Length( STAG )) ) ; 
                __context__.SourceCodeLine = 85;
                SATTRIBUTE  .UpdateValue ( ATTRIBUTE + "=\u0022"  ) ; 
                __context__.SourceCodeLine = 88;
                if ( Functions.TestForTrue  ( ( Functions.Find( SATTRIBUTE , DATA , ISTART ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 90;
                    ISTART = (ushort) ( (Functions.Find( SATTRIBUTE , DATA , ISTART ) + Functions.Length( SATTRIBUTE )) ) ; 
                    __context__.SourceCodeLine = 91;
                    ICOUNT = (ushort) ( Functions.Find( "\u0022" , DATA , ISTART ) ) ; 
                    __context__.SourceCodeLine = 92;
                    ICOUNT = (ushort) ( (ICOUNT - ISTART) ) ; 
                    __context__.SourceCodeLine = 93;
                    SRETURN  .UpdateValue ( Functions.Mid ( DATA ,  (int) ( ISTART ) ,  (int) ( ICOUNT ) )  ) ; 
                    __context__.SourceCodeLine = 95;
                    return ( SRETURN ) ; 
                    } 
                
                __context__.SourceCodeLine = 97;
                return ( "" ) ; 
                } 
            
            __context__.SourceCodeLine = 99;
            return ( "" ) ; 
            
            }
            
        private void FPARSE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
            
            CrestronString SDATA2;
            SDATA2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
            
            CrestronString [] SFFS;
            SFFS  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SFFS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString [] SFFF;
            SFFF  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SFFF [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString [] SFFC;
            SFFC  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SFFC [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            CrestronString [] SFSP;
            SFSP  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SFSP [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            CrestronString [] SCT;
            SCT  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SCT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString [] SCSJ;
            SCSJ  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SCSJ [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            CrestronString [] SCDT;
            SCDT  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SCDT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            CrestronString [] SCAT;
            SCAT  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SCAT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            CrestronString [] SFFT;
            SFFT  = new CrestronString[ 11 ];
            for( uint i = 0; i < 11; i++ )
                SFFT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            CrestronString [] HTML_OBJECT_TEMP;
            HTML_OBJECT_TEMP  = new CrestronString[ 6 ];
            for( uint i = 0; i < 6; i++ )
                HTML_OBJECT_TEMP [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
            
            CrestronString HTML_TEMP_STR;
            HTML_TEMP_STR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
            
            ushort I = 0;
            ushort J = 0;
            ushort K = 0;
            
            
            __context__.SourceCodeLine = 120;
            I = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 121;
            if ( Functions.TestForTrue  ( ( Functions.Find( "?>" , G_SFILE ))  ) ) 
                { 
                __context__.SourceCodeLine = 123;
                SDATA  .UpdateValue ( Functions.Remove ( "?>" , G_SFILE )  ) ; 
                } 
            
            __context__.SourceCodeLine = 125;
            if ( Functions.TestForTrue  ( ( Functions.Find( "-->" , G_SFILE ))  ) ) 
                { 
                __context__.SourceCodeLine = 127;
                SDATA  .UpdateValue ( Functions.Remove ( "-->" , G_SFILE )  ) ; 
                } 
            
            __context__.SourceCodeLine = 129;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "</HTMLConfig>" , G_SFILE ) ) && Functions.TestForTrue ( Functions.Find( "<HTMLConfig>" , G_SFILE ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 131;
                SDATA  .UpdateValue ( Functions.Remove ( "<HTMLConfig>" , G_SFILE )  ) ; 
                __context__.SourceCodeLine = 133;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "<Font " , G_SFILE ) ) || Functions.TestForTrue ( Functions.Find( "<CIPS " , G_SFILE ) )) ) ) || Functions.TestForTrue ( Functions.Find( "<Format " , G_SFILE ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 135;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "<obj>" , G_SFILE ) ) && Functions.TestForTrue ( Functions.Find( "</obj>" , G_SFILE ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 137;
                        SDATA2  .UpdateValue ( Functions.Remove ( "</obj>" , G_SFILE )  ) ; 
                        __context__.SourceCodeLine = 138;
                        SDATA  .UpdateValue ( Functions.Remove ( "<obj>" , SDATA2 )  ) ; 
                        __context__.SourceCodeLine = 139;
                        I = (ushort) ( (I + 1) ) ; 
                        __context__.SourceCodeLine = 140;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "<Font " , SDATA2 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 142;
                            ; 
                            __context__.SourceCodeLine = 143;
                            SDATA  .UpdateValue ( Functions.Remove ( "/>" , SDATA2 )  ) ; 
                            __context__.SourceCodeLine = 144;
                            SFFS [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Font", "FS")  ) ; 
                            __context__.SourceCodeLine = 145;
                            SFFF [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Font", "FF")  ) ; 
                            __context__.SourceCodeLine = 146;
                            SFFC [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Font", "FC")  ) ; 
                            __context__.SourceCodeLine = 147;
                            SFSP [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Font", "SP")  ) ; 
                            __context__.SourceCodeLine = 149;
                            Functions.Delay (  (int) ( 10 ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 152;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "<CIPS " , SDATA2 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 154;
                            SDATA  .UpdateValue ( Functions.Remove ( "/>" , SDATA2 )  ) ; 
                            __context__.SourceCodeLine = 155;
                            SCT [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "CIPS", "T")  ) ; 
                            __context__.SourceCodeLine = 156;
                            SCSJ [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "CIPS", "SJ")  ) ; 
                            __context__.SourceCodeLine = 157;
                            SCDT [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "CIPS", "DT")  ) ; 
                            __context__.SourceCodeLine = 158;
                            SCAT [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "CIPS", "AT")  ) ; 
                            __context__.SourceCodeLine = 159;
                            Functions.Delay (  (int) ( 10 ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 162;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "<Format " , SDATA2 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 164;
                            SDATA  .UpdateValue ( Functions.Remove ( "/>" , SDATA2 )  ) ; 
                            __context__.SourceCodeLine = 165;
                            SFFT [ I ]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "Format", "FT")  ) ; 
                            __context__.SourceCodeLine = 167;
                            Functions.Delay (  (int) ( 10 ) ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 133;
                    } 
                
                __context__.SourceCodeLine = 175;
                HTML_OBJECTS_READ_FB  .Value = (ushort) ( I ) ; 
                __context__.SourceCodeLine = 177;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(150 - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 181;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)I; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( K  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (K  >= __FN_FORSTART_VAL__2) && (K  <= __FN_FOREND_VAL__2) ) : ( (K  <= __FN_FORSTART_VAL__2) && (K  >= __FN_FOREND_VAL__2) ) ; K  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 183;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SCSJ[ K ] ) == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 185;
                            HTML_OBJECT_TEMP [ K ]  .UpdateValue ( "<Font " + "size=" + "\u0022" + SFFS [ K ] + "\u0022" + " " + "face=" + "\u0022" + SFFF [ K ] + "\u0022" + " " + "color=" + "\u0022" + SFFC [ K ] + "\u0022" + ">" + SFSP [ K ] + SCDT [ K ] + SFFT [ K ] + "</FONT>"  ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 192;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SCAT[ K ] ) == 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 194;
                                HTML_OBJECT_TEMP [ K ]  .UpdateValue ( "<Font " + "size=" + "\u0022" + SFFS [ K ] + "\u0022" + " " + "face=" + "\u0022" + SFFF [ K ] + "\u0022" + " " + "color=" + "\u0022" + SFFC [ K ] + "\u0022" + ">" + SFSP [ K ] + "<cip" + Functions.Lower ( SCT [ K ] ) + ">" + SCT [ K ] + "$" + Functions.ItoA (  (int) ( (Functions.Atoi( SCSJ[ K ] ) + J) ) ) + "?" + SCDT [ K ] + "</cip" + Functions.Lower ( SCT [ K ] ) + ">" + SFFT [ K ] + "</FONT>"  ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 199;
                                HTML_OBJECT_TEMP [ K ]  .UpdateValue ( "<Font " + "size=" + "\u0022" + SFFS [ K ] + "\u0022" + " " + "face=" + "\u0022" + SFFF [ K ] + "\u0022" + " " + "color=" + "\u0022" + SFFC [ K ] + "\u0022" + ">" + SFSP [ K ] + "<cip" + Functions.Lower ( SCT [ K ] ) + ">" + SCT [ K ] + "$" + Functions.ItoA (  (int) ( (Functions.Atoi( SCSJ[ K ] ) + J) ) ) + "?" + SCDT [ K ] + "</cip" + Functions.Lower ( SCT [ K ] ) + ">" + SFFT [ K ] + "</FONT>" + "<Font " + "size=" + "\u0022" + SFFS [ K ] + "\u0022" + " " + "face=" + "\u0022" + SFFF [ K ] + "\u0022" + " " + "color=" + "\u0022" + SFFC [ K ] + "\u0022" + ">" + SCAT [ K ] + "<" + "</FONT>"  ) ; 
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 204;
                        HTML_TEMP_STR  .UpdateValue ( HTML_TEMP_STR + HTML_OBJECT_TEMP [ K ]  ) ; 
                        __context__.SourceCodeLine = 181;
                        } 
                    
                    __context__.SourceCodeLine = 206;
                    HTML_OBJECT_ID [ (J + 1)]  .UpdateValue ( "<P>" + HTML_TEMP_STR + "</textformat>" + "</P>"  ) ; 
                    __context__.SourceCodeLine = 207;
                    HTML_TEMP_STR  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 177;
                    } 
                
                __context__.SourceCodeLine = 210;
                ; 
                __context__.SourceCodeLine = 211;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 211;
                    FILE_OPS_MESSAGE_FB  .UpdateValue ( "Error : Could not find any tags"  ) ; 
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 216;
                FILE_OPS_MESSAGE_FB  .UpdateValue ( "Error : Could not find <HTMLConfig> </HTMLConfig> root Tags"  ) ; 
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
            
            
            __context__.SourceCodeLine = 227;
            FILE_OPS_BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 229;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 230;
            SIFIND = (short) ( FindFirst( G_SPATHFILEEXT_SRCH , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 231;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 232;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIFIND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 234;
                G_SPATHFILEEXT  .UpdateValue ( FILE_PATH + FILEINFO .  Name  ) ; 
                __context__.SourceCodeLine = 235;
                SIHANDLE = (short) ( FileOpen( G_SPATHFILEEXT ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 236;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 238;
                    SLIBYTES = (int) ( FileRead( (short)( SIHANDLE ) , G_SFILE , (ushort)( FileLength( (short)( SIHANDLE ) ) ) ) ) ; 
                    __context__.SourceCodeLine = 239;
                    FileClose (  (short) ( SIHANDLE ) ) ; 
                    __context__.SourceCodeLine = 240;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 241;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SLIBYTES >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 243;
                        FPARSE (  __context__  ) ; 
                        __context__.SourceCodeLine = 244;
                        FILE_PATH_FB  .UpdateValue ( G_SPATHFILEEXT  ) ; 
                        __context__.SourceCodeLine = 245;
                        FILE_TIME_FB  .UpdateValue ( Functions.FileTime ( FILEINFO )  ) ; 
                        __context__.SourceCodeLine = 246;
                        FILE_DATE_FB  .UpdateValue ( Functions.FileDate ( FILEINFO ,  (ushort) ( 1 ) )  ) ; 
                        __context__.SourceCodeLine = 247;
                        FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 248;
                        return (ushort)( 1) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 252;
                        MakeString ( FILE_OPS_MESSAGE_FB , "File Read Fail: Err={0:d}", (int)SLIBYTES) ; 
                        __context__.SourceCodeLine = 253;
                        FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 254;
                        return (ushort)( 0) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 259;
                    FileClose (  (short) ( SIHANDLE ) ) ; 
                    __context__.SourceCodeLine = 260;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 261;
                    MakeString ( FILE_OPS_MESSAGE_FB , "File Open Fail: Handle Err={0:d}", (short)SIHANDLE) ; 
                    __context__.SourceCodeLine = 262;
                    FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 263;
                    return (ushort)( 0) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 268;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 269;
                MakeString ( FILE_OPS_MESSAGE_FB , "File Not Found: {0}", G_SPATHFILEEXT_SRCH ) ; 
                __context__.SourceCodeLine = 270;
                FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 271;
                return (ushort)( 0) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        object READ_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 279;
                if ( Functions.TestForTrue  ( ( Functions.Not( FILE_OPS_BUSY_FB  .Value ))  ) ) 
                    {
                    __context__.SourceCodeLine = 279;
                    FREAD (  __context__  ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SEARCH_FILEEXT_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 283;
            if ( Functions.TestForTrue  ( ( Functions.Length( SEARCH_FILEEXT ))  ) ) 
                {
                __context__.SourceCodeLine = 283;
                G_SPATHFILEEXT_SRCH  .UpdateValue ( FILE_PATH + SEARCH_FILEEXT  ) ; 
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
        
        __context__.SourceCodeLine = 289;
        G_SPATHFILEEXT_SRCH  .UpdateValue ( FILE_PATH + DEFUALT_SEARCH_FILEEXT  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SFILE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16384, this );
    G_SPATHFILEEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    G_SPATHFILEEXT_SRCH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    
    READ = new Crestron.Logos.SplusObjects.DigitalInput( READ__DigitalInput__, this );
    m_DigitalInputList.Add( READ__DigitalInput__, READ );
    
    FILE_OPS_BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FILE_OPS_BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILE_OPS_BUSY_FB__DigitalOutput__, FILE_OPS_BUSY_FB );
    
    HTML_OBJECTS_READ_FB = new Crestron.Logos.SplusObjects.AnalogOutput( HTML_OBJECTS_READ_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( HTML_OBJECTS_READ_FB__AnalogSerialOutput__, HTML_OBJECTS_READ_FB );
    
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
    
    HTML_OBJECT_ID = new InOutArray<StringOutput>( 150, this );
    for( uint i = 0; i < 150; i++ )
    {
        HTML_OBJECT_ID[i+1] = new Crestron.Logos.SplusObjects.StringOutput( HTML_OBJECT_ID__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( HTML_OBJECT_ID__AnalogSerialOutput__ + i, HTML_OBJECT_ID[i+1] );
    }
    
    FILE_PATH = new StringParameter( FILE_PATH__Parameter__, this );
    m_ParameterList.Add( FILE_PATH__Parameter__, FILE_PATH );
    
    DEFUALT_SEARCH_FILEEXT = new StringParameter( DEFUALT_SEARCH_FILEEXT__Parameter__, this );
    m_ParameterList.Add( DEFUALT_SEARCH_FILEEXT__Parameter__, DEFUALT_SEARCH_FILEEXT );
    
    
    READ.OnDigitalPush.Add( new InputChangeHandlerWrapper( READ_OnPush_0, false ) );
    SEARCH_FILEEXT.OnSerialChange.Add( new InputChangeHandlerWrapper( SEARCH_FILEEXT_OnChange_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_XML_FILE_HTML_GENERATOR_V0_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint READ__DigitalInput__ = 0;
const uint SEARCH_FILEEXT__AnalogSerialInput__ = 0;
const uint FILE_OPS_BUSY_FB__DigitalOutput__ = 0;
const uint FILE_OPS_MESSAGE_FB__AnalogSerialOutput__ = 0;
const uint FILE_PATH_FB__AnalogSerialOutput__ = 1;
const uint FILE_TIME_FB__AnalogSerialOutput__ = 2;
const uint FILE_DATE_FB__AnalogSerialOutput__ = 3;
const uint HTML_OBJECTS_READ_FB__AnalogSerialOutput__ = 4;
const uint HTML_OBJECT_ID__AnalogSerialOutput__ = 5;
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
