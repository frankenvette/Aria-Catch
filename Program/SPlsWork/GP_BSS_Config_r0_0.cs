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

namespace UserModule_GP_BSS_CONFIG_R0_0
{
    public class UserModuleClass_GP_BSS_CONFIG_R0_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput READ;
        Crestron.Logos.SplusObjects.StringInput SEARCH_FILEEXT;
        Crestron.Logos.SplusObjects.DigitalOutput FILE_OPS_BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_OPS_MESSAGE_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_PATH_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_TIME_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_DATE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput DSP_NUMBER_OF_CONTROLS_READ_FB;
        Crestron.Logos.SplusObjects.StringOutput DSP_NODE_ID;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DSP_OBJECT_LABEL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DSP_OBJECT_ID;
        StringParameter FILE_PATH;
        StringParameter DEFUALT_SEARCH_FILEEXT;
        CrestronString G_SFILE;
        CrestronString G_SPATHFILEEXT;
        CrestronString G_SPATHFILEEXT_SRCH;
        CrestronString G_SNODE;
        private CrestronString FXML_ATTRIBUTE (  SplusExecutionContext __context__, CrestronString DATA , CrestronString TAG , CrestronString ATTRIBUTE ) 
            { 
            ushort ISTART = 0;
            ushort ICOUNT = 0;
            
            CrestronString SRETURN;
            SRETURN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
            
            CrestronString SATTRIBUTE;
            SATTRIBUTE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            CrestronString STAG;
            STAG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            
            __context__.SourceCodeLine = 84;
            STAG  .UpdateValue ( "<" + TAG  ) ; 
            __context__.SourceCodeLine = 86;
            if ( Functions.TestForTrue  ( ( Functions.Find( STAG , DATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 88;
                ISTART = (ushort) ( (Functions.Find( STAG , DATA ) + Functions.Length( STAG )) ) ; 
                __context__.SourceCodeLine = 89;
                SATTRIBUTE  .UpdateValue ( ATTRIBUTE + "=\u0022"  ) ; 
                __context__.SourceCodeLine = 91;
                if ( Functions.TestForTrue  ( ( Functions.Find( SATTRIBUTE , DATA , ISTART ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 93;
                    ISTART = (ushort) ( (Functions.Find( SATTRIBUTE , DATA , ISTART ) + Functions.Length( SATTRIBUTE )) ) ; 
                    __context__.SourceCodeLine = 94;
                    ICOUNT = (ushort) ( Functions.Find( "\u0022" , DATA , ISTART ) ) ; 
                    __context__.SourceCodeLine = 95;
                    ICOUNT = (ushort) ( (ICOUNT - ISTART) ) ; 
                    __context__.SourceCodeLine = 96;
                    SRETURN  .UpdateValue ( Functions.Mid ( DATA ,  (int) ( ISTART ) ,  (int) ( ICOUNT ) )  ) ; 
                    __context__.SourceCodeLine = 98;
                    return ( SRETURN ) ; 
                    } 
                
                __context__.SourceCodeLine = 100;
                return ( "" ) ; 
                } 
            
            __context__.SourceCodeLine = 102;
            return ( "" ) ; 
            
            }
            
        private void FPARSE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString SHQA;
            SHQA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
            
            CrestronString SNODE;
            SNODE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            CrestronString SOBJ;
            SOBJ  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 113;
            I = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 114;
            if ( Functions.TestForTrue  ( ( Functions.Find( "?>" , G_SFILE ))  ) ) 
                { 
                __context__.SourceCodeLine = 116;
                SDATA  .UpdateValue ( Functions.Remove ( "?>" , G_SFILE )  ) ; 
                } 
            
            __context__.SourceCodeLine = 118;
            if ( Functions.TestForTrue  ( ( Functions.Find( "-->" , G_SFILE ))  ) ) 
                { 
                __context__.SourceCodeLine = 120;
                SDATA  .UpdateValue ( Functions.Remove ( "-->" , G_SFILE )  ) ; 
                } 
            
            __context__.SourceCodeLine = 122;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "</dspConfig>" , G_SFILE ) ) && Functions.TestForTrue ( Functions.Find( "<dspConfig>" , G_SFILE ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 124;
                SDATA  .UpdateValue ( Functions.Remove ( "<dspConfig>" , G_SFILE )  ) ; 
                __context__.SourceCodeLine = 125;
                while ( Functions.TestForTrue  ( ( Functions.Find( "<obj " , G_SFILE ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 127;
                    I = (ushort) ( (I + 1) ) ; 
                    __context__.SourceCodeLine = 128;
                    SDATA  .UpdateValue ( Functions.Remove ( "/>" , G_SFILE )  ) ; 
                    __context__.SourceCodeLine = 129;
                    if ( Functions.TestForTrue  ( ( IsSignalDefined( DSP_OBJECT_ID[ I ] ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 131;
                        DSP_OBJECT_LABEL [ I]  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "obj", "L")  ) ; 
                        __context__.SourceCodeLine = 132;
                        SHQA  .UpdateValue ( FXML_ATTRIBUTE (  __context__ , SDATA, "obj", "HQA")  ) ; 
                        __context__.SourceCodeLine = 133;
                        SNODE  .UpdateValue ( Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( SHQA , (int)( 3 ) , (int)( 2 ) ) ) ) )  ) ; 
                        __context__.SourceCodeLine = 134;
                        SNODE  .UpdateValue ( SNODE + Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( SHQA , (int)( 5 ) , (int)( 2 ) ) ) ) )  ) ; 
                        __context__.SourceCodeLine = 135;
                        SOBJ  .UpdateValue ( Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( SHQA , (int)( 9 ) , (int)( 2 ) ) ) ) )  ) ; 
                        __context__.SourceCodeLine = 136;
                        SOBJ  .UpdateValue ( SOBJ + Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( SHQA , (int)( 11 ) , (int)( 2 ) ) ) ) )  ) ; 
                        __context__.SourceCodeLine = 137;
                        DSP_OBJECT_ID [ I]  .UpdateValue ( SOBJ + Functions.Chr (  (int) ( Functions.HextoI( Functions.Mid( SHQA , (int)( 13 ) , (int)( 2 ) ) ) ) )  ) ; 
                        __context__.SourceCodeLine = 138;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SNODE != SNODE))  ) ) 
                            { 
                            __context__.SourceCodeLine = 140;
                            if ( Functions.TestForTrue  ( ( Functions.Length( G_SNODE ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 142;
                                FILE_OPS_MESSAGE_FB  .UpdateValue ( "Error : Parsed Multiple Node Addresses"  ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 146;
                                G_SNODE  .UpdateValue ( SNODE  ) ; 
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 149;
                        Functions.Delay (  (int) ( 10 ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 125;
                    } 
                
                __context__.SourceCodeLine = 153;
                DSP_NUMBER_OF_CONTROLS_READ_FB  .Value = (ushort) ( I ) ; 
                __context__.SourceCodeLine = 154;
                DSP_NODE_ID  .UpdateValue ( G_SNODE  ) ; 
                __context__.SourceCodeLine = 155;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 155;
                    FILE_OPS_MESSAGE_FB  .UpdateValue ( "Error : Could not find any <obj Tag"  ) ; 
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 159;
                FILE_OPS_MESSAGE_FB  .UpdateValue ( "Error : Could not find <dspConfig> </dspConfig> root Tags"  ) ; 
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
            
            
            __context__.SourceCodeLine = 169;
            FILE_OPS_BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 171;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 172;
            SIFIND = (short) ( FindFirst( G_SPATHFILEEXT_SRCH , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 173;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 174;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIFIND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 176;
                G_SPATHFILEEXT  .UpdateValue ( FILE_PATH + FILEINFO .  Name  ) ; 
                __context__.SourceCodeLine = 177;
                SIHANDLE = (short) ( FileOpen( G_SPATHFILEEXT ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 178;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SIHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 180;
                    SLIBYTES = (int) ( FileRead( (short)( SIHANDLE ) , G_SFILE , (ushort)( FileLength( (short)( SIHANDLE ) ) ) ) ) ; 
                    __context__.SourceCodeLine = 181;
                    FileClose (  (short) ( SIHANDLE ) ) ; 
                    __context__.SourceCodeLine = 182;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 183;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SLIBYTES >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 185;
                        FPARSE (  __context__  ) ; 
                        __context__.SourceCodeLine = 186;
                        FILE_PATH_FB  .UpdateValue ( G_SPATHFILEEXT  ) ; 
                        __context__.SourceCodeLine = 187;
                        FILE_TIME_FB  .UpdateValue ( Functions.FileTime ( FILEINFO )  ) ; 
                        __context__.SourceCodeLine = 188;
                        FILE_DATE_FB  .UpdateValue ( Functions.FileDate ( FILEINFO ,  (ushort) ( 1 ) )  ) ; 
                        __context__.SourceCodeLine = 189;
                        FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 190;
                        return (ushort)( 1) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 194;
                        MakeString ( FILE_OPS_MESSAGE_FB , "File Read Fail: Err={0:d}", (int)SLIBYTES) ; 
                        __context__.SourceCodeLine = 195;
                        FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 196;
                        return (ushort)( 0) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 201;
                    FileClose (  (short) ( SIHANDLE ) ) ; 
                    __context__.SourceCodeLine = 202;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 203;
                    MakeString ( FILE_OPS_MESSAGE_FB , "File Open Fail: Handle Err={0:d}", (short)SIHANDLE) ; 
                    __context__.SourceCodeLine = 204;
                    FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 205;
                    return (ushort)( 0) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 210;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 211;
                MakeString ( FILE_OPS_MESSAGE_FB , "File Not Found: {0}", G_SPATHFILEEXT_SRCH ) ; 
                __context__.SourceCodeLine = 212;
                FILE_OPS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 213;
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
                
                __context__.SourceCodeLine = 221;
                if ( Functions.TestForTrue  ( ( Functions.Not( FILE_OPS_BUSY_FB  .Value ))  ) ) 
                    {
                    __context__.SourceCodeLine = 221;
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
            
            __context__.SourceCodeLine = 225;
            if ( Functions.TestForTrue  ( ( Functions.Length( SEARCH_FILEEXT ))  ) ) 
                {
                __context__.SourceCodeLine = 225;
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
        
        __context__.SourceCodeLine = 231;
        G_SPATHFILEEXT_SRCH  .UpdateValue ( FILE_PATH + DEFUALT_SEARCH_FILEEXT  ) ; 
        __context__.SourceCodeLine = 232;
        G_SNODE  .UpdateValue ( ""  ) ; 
        
        
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
    G_SNODE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    
    READ = new Crestron.Logos.SplusObjects.DigitalInput( READ__DigitalInput__, this );
    m_DigitalInputList.Add( READ__DigitalInput__, READ );
    
    FILE_OPS_BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FILE_OPS_BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILE_OPS_BUSY_FB__DigitalOutput__, FILE_OPS_BUSY_FB );
    
    DSP_NUMBER_OF_CONTROLS_READ_FB = new Crestron.Logos.SplusObjects.AnalogOutput( DSP_NUMBER_OF_CONTROLS_READ_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( DSP_NUMBER_OF_CONTROLS_READ_FB__AnalogSerialOutput__, DSP_NUMBER_OF_CONTROLS_READ_FB );
    
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
    
    DSP_NODE_ID = new Crestron.Logos.SplusObjects.StringOutput( DSP_NODE_ID__AnalogSerialOutput__, this );
    m_StringOutputList.Add( DSP_NODE_ID__AnalogSerialOutput__, DSP_NODE_ID );
    
    DSP_OBJECT_LABEL = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSP_OBJECT_LABEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DSP_OBJECT_LABEL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DSP_OBJECT_LABEL__AnalogSerialOutput__ + i, DSP_OBJECT_LABEL[i+1] );
    }
    
    DSP_OBJECT_ID = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        DSP_OBJECT_ID[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DSP_OBJECT_ID__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DSP_OBJECT_ID__AnalogSerialOutput__ + i, DSP_OBJECT_ID[i+1] );
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

public UserModuleClass_GP_BSS_CONFIG_R0_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint READ__DigitalInput__ = 0;
const uint SEARCH_FILEEXT__AnalogSerialInput__ = 0;
const uint FILE_OPS_BUSY_FB__DigitalOutput__ = 0;
const uint FILE_OPS_MESSAGE_FB__AnalogSerialOutput__ = 0;
const uint FILE_PATH_FB__AnalogSerialOutput__ = 1;
const uint FILE_TIME_FB__AnalogSerialOutput__ = 2;
const uint FILE_DATE_FB__AnalogSerialOutput__ = 3;
const uint DSP_NUMBER_OF_CONTROLS_READ_FB__AnalogSerialOutput__ = 4;
const uint DSP_NODE_ID__AnalogSerialOutput__ = 5;
const uint DSP_OBJECT_LABEL__AnalogSerialOutput__ = 6;
const uint DSP_OBJECT_ID__AnalogSerialOutput__ = 56;
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
