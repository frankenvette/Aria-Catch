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

namespace UserModule_GP_SCHEDULE_FIRE_CONFIG_V1_0
{
    public class UserModuleClass_GP_SCHEDULE_FIRE_CONFIG_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.AnalogInput RECALL;
        Crestron.Logos.SplusObjects.AnalogInput VIEW;
        Crestron.Logos.SplusObjects.DigitalInput SAVE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PREINCLUDEZ;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SAVE_DONE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PREINCLUDEDZ;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FIREPRESET;
        StringParameter PATHFILEEXT;
        ushort [,] G_IVALUES;
        object RECALL_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                short IHANDLE = 0;
                short IBYTES = 0;
                
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 56;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( BUSY_FB  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( RECALL  .UshortValue <= 64 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (RECALL  .UshortValue != 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 58;
                    BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 60;
                    StartFileOperations ( ) ; 
                    __context__.SourceCodeLine = 63;
                    IHANDLE = (short) ( FileOpen( PATHFILEEXT  ,(ushort) (0 | 32768) ) ) ; 
                    __context__.SourceCodeLine = 64;
                    IBYTES = (short) ( ReadIntegerArray( (short)( IHANDLE ) , ref G_IVALUES ) ) ; 
                    __context__.SourceCodeLine = 65;
                    /* Trace( " {0:d} Bytes read", (short)IBYTES) */ ; 
                    __context__.SourceCodeLine = 66;
                    FileClose (  (short) ( IHANDLE ) ) ; 
                    __context__.SourceCodeLine = 69;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 71;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBYTES > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 73;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)64; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 75;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_IVALUES[ RECALL  .UshortValue , I ] == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 77;
                                Functions.Pulse ( 50, FIREPRESET [ I] ) ; 
                                __context__.SourceCodeLine = 78;
                                CreateWait ( "__SPLS_TMPVAR__WAITLABEL_1__" , 200 , __SPLS_TMPVAR__WAITLABEL_1___Callback ) ;
                                } 
                            
                            __context__.SourceCodeLine = 73;
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 83;
                    BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_1___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            {
            __context__.SourceCodeLine = 78;
            ; 
            }
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
object VIEW_OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short IHANDLE = 0;
        short IBYTES = 0;
        
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 90;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( BUSY_FB  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VIEW  .UshortValue <= 64 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (VIEW  .UshortValue != 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 93;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 95;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 98;
            IHANDLE = (short) ( FileOpen( PATHFILEEXT  ,(ushort) (0 | 32768) ) ) ; 
            __context__.SourceCodeLine = 99;
            IBYTES = (short) ( ReadIntegerArray( (short)( IHANDLE ) , ref G_IVALUES ) ) ; 
            __context__.SourceCodeLine = 100;
            /* Trace( " {0:d} Bytes read", (short)IBYTES) */ ; 
            __context__.SourceCodeLine = 101;
            FileClose (  (short) ( IHANDLE ) ) ; 
            __context__.SourceCodeLine = 104;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 105;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)64; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 107;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_IVALUES[ VIEW  .UshortValue , I ] == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 109;
                    PREINCLUDEDZ [ I]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 111;
                    PREINCLUDEDZ [ I]  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 105;
                } 
            
            __context__.SourceCodeLine = 114;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            } 
        
        
        
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
        
        
        __context__.SourceCodeLine = 122;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( BUSY_FB  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VIEW  .UshortValue <= 64 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (VIEW  .UshortValue != 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 124;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 126;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)64; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 128;
                if ( Functions.TestForTrue  ( ( PREINCLUDEDZ[ I ] .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 128;
                    G_IVALUES [ VIEW  .UshortValue , I] = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 129;
                    G_IVALUES [ VIEW  .UshortValue , I] = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 126;
                } 
            
            __context__.SourceCodeLine = 131;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 132;
            IHANDLE = (short) ( FileOpen( PATHFILEEXT  ,(ushort) (((256 | 512) | 2) | 32768) ) ) ; 
            __context__.SourceCodeLine = 133;
            IBYTES = (short) ( WriteIntegerArray( (short)( IHANDLE ) , G_IVALUES ) ) ; 
            __context__.SourceCodeLine = 134;
            Print( " {0:d} Bytes Written", (short)IBYTES) ; 
            __context__.SourceCodeLine = 135;
            FileClose (  (short) ( IHANDLE ) ) ; 
            __context__.SourceCodeLine = 136;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 138;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBYTES > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 140;
                Functions.Pulse ( 50, SAVE_DONE ) ; 
                __context__.SourceCodeLine = 141;
                /* Trace( "Saved Preset:{0:d}", (short)VIEW  .UshortValue) */ ; 
                } 
            
            __context__.SourceCodeLine = 144;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PREINCLUDEZ_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 150;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 151;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PREINCLUDEDZ[ I ] .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 151;
            PREINCLUDEDZ [ I]  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 152;
            PREINCLUDEDZ [ I]  .Value = (ushort) ( 0 ) ; 
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
    G_IVALUES  = new ushort[ 65,65 ];
    
    SAVE = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE__DigitalInput__, SAVE );
    
    PREINCLUDEZ = new InOutArray<DigitalInput>( 64, this );
    for( uint i = 0; i < 64; i++ )
    {
        PREINCLUDEZ[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PREINCLUDEZ__DigitalInput__ + i, PREINCLUDEZ__DigitalInput__, this );
        m_DigitalInputList.Add( PREINCLUDEZ__DigitalInput__ + i, PREINCLUDEZ[i+1] );
    }
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    SAVE_DONE = new Crestron.Logos.SplusObjects.DigitalOutput( SAVE_DONE__DigitalOutput__, this );
    m_DigitalOutputList.Add( SAVE_DONE__DigitalOutput__, SAVE_DONE );
    
    PREINCLUDEDZ = new InOutArray<DigitalOutput>( 64, this );
    for( uint i = 0; i < 64; i++ )
    {
        PREINCLUDEDZ[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PREINCLUDEDZ__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PREINCLUDEDZ__DigitalOutput__ + i, PREINCLUDEDZ[i+1] );
    }
    
    FIREPRESET = new InOutArray<DigitalOutput>( 64, this );
    for( uint i = 0; i < 64; i++ )
    {
        FIREPRESET[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FIREPRESET__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( FIREPRESET__DigitalOutput__ + i, FIREPRESET[i+1] );
    }
    
    RECALL = new Crestron.Logos.SplusObjects.AnalogInput( RECALL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RECALL__AnalogSerialInput__, RECALL );
    
    VIEW = new Crestron.Logos.SplusObjects.AnalogInput( VIEW__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VIEW__AnalogSerialInput__, VIEW );
    
    PATHFILEEXT = new StringParameter( PATHFILEEXT__Parameter__, this );
    m_ParameterList.Add( PATHFILEEXT__Parameter__, PATHFILEEXT );
    
    __SPLS_TMPVAR__WAITLABEL_1___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_1___CallbackFn );
    
    RECALL.OnAnalogChange.Add( new InputChangeHandlerWrapper( RECALL_OnChange_0, false ) );
    VIEW.OnAnalogChange.Add( new InputChangeHandlerWrapper( VIEW_OnChange_1, false ) );
    SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_2, false ) );
    for( uint i = 0; i < 64; i++ )
        PREINCLUDEZ[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PREINCLUDEZ_OnPush_3, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_SCHEDULE_FIRE_CONFIG_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_1___Callback;


const uint RECALL__AnalogSerialInput__ = 0;
const uint VIEW__AnalogSerialInput__ = 1;
const uint SAVE__DigitalInput__ = 0;
const uint PREINCLUDEZ__DigitalInput__ = 1;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint SAVE_DONE__DigitalOutput__ = 1;
const uint PREINCLUDEDZ__DigitalOutput__ = 2;
const uint FIREPRESET__DigitalOutput__ = 66;
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


}
