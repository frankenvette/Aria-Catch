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

namespace UserModule_GP_CSV_RDWR_QUICK_SERIAL_ANALOG_V0_0
{
    public class UserModuleClass_GP_CSV_RDWR_QUICK_SERIAL_ANALOG_V0_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput READ;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_SAVE;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_ROW_INDEX;
        Crestron.Logos.SplusObjects.StringInput EDIT_CELL_A;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_CELL_B;
        Crestron.Logos.SplusObjects.DigitalOutput FILE_BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_TIME_STAMP_FB;
        Crestron.Logos.SplusObjects.StringOutput EDIT_SELECTED_CELL_A_FB;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_SELECTED_CELL_B_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> COLUMN_A_ROW;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> COLUMN_B_ROW;
        StringParameter PATHFILEEXT;
        InOutArray<UShortParameter> SKIP;
        InOutArray<StringParameter> DEFAULT_COLUMN_A_ROW;
        InOutArray<UShortParameter> DEFAULT_COLUMN_B_ROW;
        CrestronString [] G_SCELL_A;
        ushort [] G_ICELL_B;
        short G_IFIND = 0;
        short G_IHANDLE = 0;
        short G_IBYTES = 0;
        FILE_INFO FILEINFO;
        private void FPARSE (  SplusExecutionContext __context__, CrestronString SDATA ) 
            { 
            CrestronString SROW;
            SROW  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 99;
            I = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 100;
            Functions.SetArray ( COLUMN_A_ROW , "" ) ; 
            __context__.SourceCodeLine = 102;
            while ( Functions.TestForTrue  ( ( Functions.Find( "\r\n" , SDATA ))  ) ) 
                { 
                __context__.SourceCodeLine = 104;
                I = (ushort) ( (I + 1) ) ; 
                __context__.SourceCodeLine = 105;
                SROW  .UpdateValue ( Functions.Remove ( "\r\n" , SDATA )  ) ; 
                __context__.SourceCodeLine = 106;
                SROW  .UpdateValue ( Functions.Left ( SROW ,  (int) ( (Functions.Length( SROW ) - 2) ) )  ) ; 
                __context__.SourceCodeLine = 107;
                if ( Functions.TestForTrue  ( ( Functions.Find( "," , SROW ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 109;
                    G_SCELL_A [ I ]  .UpdateValue ( Functions.Left ( SROW ,  (int) ( (Functions.Find( "," , SROW ) - 1) ) )  ) ; 
                    __context__.SourceCodeLine = 110;
                    G_ICELL_B [ I] = (ushort) ( Functions.Atoi( Functions.Right( SROW , (int)( (Functions.Length( SROW ) - Functions.Find( "," , SROW )) ) ) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 114;
                    G_SCELL_A [ I ]  .UpdateValue ( SROW  ) ; 
                    __context__.SourceCodeLine = 115;
                    G_ICELL_B [ I] = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 117;
                COLUMN_A_ROW [ I]  .UpdateValue ( G_SCELL_A [ I ]  ) ; 
                __context__.SourceCodeLine = 118;
                COLUMN_B_ROW [ I]  .Value = (ushort) ( G_ICELL_B[ I ] ) ; 
                __context__.SourceCodeLine = 102;
                } 
            
            
            }
            
        private void FREAD (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2048, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 127;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 129;
            G_IFIND = (short) ( FindFirst( PATHFILEEXT  , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 130;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 132;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_IFIND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 134;
                G_IHANDLE = (short) ( FileOpen( PATHFILEEXT  ,(ushort) ((256 | 0) | 16384) ) ) ; 
                __context__.SourceCodeLine = 135;
                G_IBYTES = (short) ( FileRead( (short)( G_IHANDLE ) , SDATA , (ushort)( FileLength( (short)( G_IHANDLE ) ) ) ) ) ; 
                __context__.SourceCodeLine = 136;
                FileClose (  (short) ( G_IHANDLE ) ) ; 
                __context__.SourceCodeLine = 137;
                EndFileOperations ( ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 141;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)16; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 143;
                    SDATA  .UpdateValue ( SDATA + DEFAULT_COLUMN_A_ROW [ I ] + "," + Functions.ItoA (  (int) ( DEFAULT_COLUMN_B_ROW[ I ] .Value ) ) + "\r\n"  ) ; 
                    __context__.SourceCodeLine = 141;
                    } 
                
                __context__.SourceCodeLine = 147;
                G_IHANDLE = (short) ( FileOpen( PATHFILEEXT  ,(ushort) ((256 | 1) | 16384) ) ) ; 
                __context__.SourceCodeLine = 148;
                G_IBYTES = (short) ( FileWrite( (short)( G_IHANDLE ) , SDATA , (ushort)( Functions.Length( SDATA ) ) ) ) ; 
                __context__.SourceCodeLine = 149;
                FileClose (  (short) ( G_IHANDLE ) ) ; 
                __context__.SourceCodeLine = 150;
                EndFileOperations ( ) ; 
                } 
            
            __context__.SourceCodeLine = 152;
            if ( Functions.TestForTrue  ( ( G_IBYTES)  ) ) 
                { 
                __context__.SourceCodeLine = 154;
                FPARSE (  __context__ , SDATA) ; 
                __context__.SourceCodeLine = 155;
                FILE_TIME_STAMP_FB  .UpdateValue ( Functions.FileDate ( FILEINFO ,  (ushort) ( 1 ) ) + "  " + Functions.FileTime ( FILEINFO )  ) ; 
                } 
            
            
            }
            
        private void FWRITE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2048, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 164;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)16; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 166;
                SDATA  .UpdateValue ( SDATA + G_SCELL_A [ I ] + "," + Functions.ItoA (  (int) ( G_ICELL_B[ I ] ) ) + "\r\n"  ) ; 
                __context__.SourceCodeLine = 164;
                } 
            
            __context__.SourceCodeLine = 170;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 172;
            G_IHANDLE = (short) ( FileOpen( PATHFILEEXT  ,(ushort) ((256 | 1) | 16384) ) ) ; 
            __context__.SourceCodeLine = 173;
            G_IBYTES = (short) ( FileWrite( (short)( G_IHANDLE ) , SDATA , (ushort)( Functions.Length( SDATA ) ) ) ) ; 
            __context__.SourceCodeLine = 174;
            FileClose (  (short) ( G_IHANDLE ) ) ; 
            __context__.SourceCodeLine = 176;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 178;
            if ( Functions.TestForTrue  ( ( G_IBYTES)  ) ) 
                { 
                __context__.SourceCodeLine = 180;
                FPARSE (  __context__ , SDATA) ; 
                __context__.SourceCodeLine = 181;
                FILE_TIME_STAMP_FB  .UpdateValue ( Functions.FileDate ( FILEINFO ,  (ushort) ( 1 ) ) + "  " + Functions.FileTime ( FILEINFO )  ) ; 
                } 
            
            
            }
            
        object READ_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 190;
                if ( Functions.TestForTrue  ( ( Functions.Not( FILE_BUSY_FB  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 192;
                    FILE_BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 193;
                    FREAD (  __context__  ) ; 
                    __context__.SourceCodeLine = 194;
                    FILE_BUSY_FB  .Value = (ushort) ( 0 ) ; 
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
            
            __context__.SourceCodeLine = 199;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( FILE_BUSY_FB  .Value ) ) && Functions.TestForTrue ( EDIT_ROW_INDEX  .UshortValue )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 201;
                FILE_BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 202;
                G_SCELL_A [ EDIT_ROW_INDEX  .UshortValue ]  .UpdateValue ( EDIT_CELL_A  ) ; 
                __context__.SourceCodeLine = 203;
                G_ICELL_B [ EDIT_ROW_INDEX  .UshortValue] = (ushort) ( EDIT_CELL_B  .UshortValue ) ; 
                __context__.SourceCodeLine = 204;
                FWRITE (  __context__  ) ; 
                __context__.SourceCodeLine = 205;
                FILE_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object EDIT_ROW_INDEX_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 210;
        if ( Functions.TestForTrue  ( ( EDIT_ROW_INDEX  .UshortValue)  ) ) 
            { 
            __context__.SourceCodeLine = 214;
            EDIT_SELECTED_CELL_A_FB  .UpdateValue ( G_SCELL_A [ EDIT_ROW_INDEX  .UshortValue ]  ) ; 
            __context__.SourceCodeLine = 215;
            EDIT_SELECTED_CELL_B_FB  .Value = (ushort) ( G_ICELL_B[ EDIT_ROW_INDEX  .UshortValue ] ) ; 
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
    G_ICELL_B  = new ushort[ 17 ];
    G_SCELL_A  = new CrestronString[ 17 ];
    for( uint i = 0; i < 17; i++ )
        G_SCELL_A [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
    FILEINFO  = new FILE_INFO();
    FILEINFO .PopulateDefaults();
    
    READ = new Crestron.Logos.SplusObjects.DigitalInput( READ__DigitalInput__, this );
    m_DigitalInputList.Add( READ__DigitalInput__, READ );
    
    EDIT_SAVE = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_SAVE__DigitalInput__, EDIT_SAVE );
    
    FILE_BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FILE_BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILE_BUSY_FB__DigitalOutput__, FILE_BUSY_FB );
    
    EDIT_ROW_INDEX = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_ROW_INDEX__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_ROW_INDEX__AnalogSerialInput__, EDIT_ROW_INDEX );
    
    EDIT_CELL_B = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_CELL_B__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_CELL_B__AnalogSerialInput__, EDIT_CELL_B );
    
    EDIT_SELECTED_CELL_B_FB = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_SELECTED_CELL_B_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_SELECTED_CELL_B_FB__AnalogSerialOutput__, EDIT_SELECTED_CELL_B_FB );
    
    COLUMN_B_ROW = new InOutArray<AnalogOutput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        COLUMN_B_ROW[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( COLUMN_B_ROW__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( COLUMN_B_ROW__AnalogSerialOutput__ + i, COLUMN_B_ROW[i+1] );
    }
    
    EDIT_CELL_A = new Crestron.Logos.SplusObjects.StringInput( EDIT_CELL_A__AnalogSerialInput__, 32, this );
    m_StringInputList.Add( EDIT_CELL_A__AnalogSerialInput__, EDIT_CELL_A );
    
    FILE_TIME_STAMP_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_TIME_STAMP_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_TIME_STAMP_FB__AnalogSerialOutput__, FILE_TIME_STAMP_FB );
    
    EDIT_SELECTED_CELL_A_FB = new Crestron.Logos.SplusObjects.StringOutput( EDIT_SELECTED_CELL_A_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_SELECTED_CELL_A_FB__AnalogSerialOutput__, EDIT_SELECTED_CELL_A_FB );
    
    COLUMN_A_ROW = new InOutArray<StringOutput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        COLUMN_A_ROW[i+1] = new Crestron.Logos.SplusObjects.StringOutput( COLUMN_A_ROW__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( COLUMN_A_ROW__AnalogSerialOutput__ + i, COLUMN_A_ROW[i+1] );
    }
    
    SKIP = new InOutArray<UShortParameter>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        SKIP[i+1] = new UShortParameter( SKIP__Parameter__ + i, SKIP__Parameter__, this );
        m_ParameterList.Add( SKIP__Parameter__ + i, SKIP[i+1] );
    }
    
    DEFAULT_COLUMN_B_ROW = new InOutArray<UShortParameter>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        DEFAULT_COLUMN_B_ROW[i+1] = new UShortParameter( DEFAULT_COLUMN_B_ROW__Parameter__ + i, DEFAULT_COLUMN_B_ROW__Parameter__, this );
        m_ParameterList.Add( DEFAULT_COLUMN_B_ROW__Parameter__ + i, DEFAULT_COLUMN_B_ROW[i+1] );
    }
    
    PATHFILEEXT = new StringParameter( PATHFILEEXT__Parameter__, this );
    m_ParameterList.Add( PATHFILEEXT__Parameter__, PATHFILEEXT );
    
    DEFAULT_COLUMN_A_ROW = new InOutArray<StringParameter>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        DEFAULT_COLUMN_A_ROW[i+1] = new StringParameter( DEFAULT_COLUMN_A_ROW__Parameter__ + i, DEFAULT_COLUMN_A_ROW__Parameter__, this );
        m_ParameterList.Add( DEFAULT_COLUMN_A_ROW__Parameter__ + i, DEFAULT_COLUMN_A_ROW[i+1] );
    }
    
    
    READ.OnDigitalPush.Add( new InputChangeHandlerWrapper( READ_OnPush_0, false ) );
    EDIT_SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_SAVE_OnPush_1, false ) );
    EDIT_ROW_INDEX.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_ROW_INDEX_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_CSV_RDWR_QUICK_SERIAL_ANALOG_V0_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint READ__DigitalInput__ = 0;
const uint EDIT_SAVE__DigitalInput__ = 1;
const uint EDIT_ROW_INDEX__AnalogSerialInput__ = 0;
const uint EDIT_CELL_A__AnalogSerialInput__ = 1;
const uint EDIT_CELL_B__AnalogSerialInput__ = 2;
const uint FILE_BUSY_FB__DigitalOutput__ = 0;
const uint FILE_TIME_STAMP_FB__AnalogSerialOutput__ = 0;
const uint EDIT_SELECTED_CELL_A_FB__AnalogSerialOutput__ = 1;
const uint EDIT_SELECTED_CELL_B_FB__AnalogSerialOutput__ = 2;
const uint COLUMN_A_ROW__AnalogSerialOutput__ = 3;
const uint COLUMN_B_ROW__AnalogSerialOutput__ = 19;
const uint PATHFILEEXT__Parameter__ = 10;
const uint SKIP__Parameter__ = 11;
const uint DEFAULT_COLUMN_A_ROW__Parameter__ = 15;
const uint DEFAULT_COLUMN_B_ROW__Parameter__ = 31;

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
