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

namespace UserModule_GP_BSS_SOURCE_MATRIX_ENGINE_R0_1
{
    public class UserModuleClass_GP_BSS_SOURCE_MATRIX_ENGINE_R0_1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput OBJECT_ID;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> IN_FOR_OUT;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput OBJECT_ID_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> IN_FOR_OUT_FB;
        CrestronString G_SREPLY;
        CrestronString G_SOBJECT_ID;
        ushort G_IRX_OK = 0;
        ushort G_ISTATEVAR = 0;
        ushort G_INUM_OUT_USED = 0;
        StringParameter DEFAULT_OBJECT_ID;
        object IN_FOR_OUT_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort IOUT = 0;
                
                
                __context__.SourceCodeLine = 81;
                IOUT = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 82;
                G_ISTATEVAR = (ushort) ( (IOUT - 1) ) ; 
                __context__.SourceCodeLine = 84;
                MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000{1}\u0000\u0000\u0000{2}\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( G_ISTATEVAR ) ) , Functions.Chr (  (int) ( IN_FOR_OUT[ IOUT ] .UshortValue ) ) ) ; 
                __context__.SourceCodeLine = 85;
                if ( Functions.TestForTrue  ( ( SUBSCRIBE  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 87;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( G_ISTATEVAR ) ) ) ; 
                    __context__.SourceCodeLine = 88;
                    Functions.ProcessLogic ( ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SUBSCRIBE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 96;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_INUM_OUT_USED; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 98;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( (I - 1) ) ) ) ; 
                __context__.SourceCodeLine = 99;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 96;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SUBSCRIBE_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 107;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_INUM_OUT_USED; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 109;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( (I - 1) ) ) ) ; 
            __context__.SourceCodeLine = 110;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 107;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 116;
        if ( Functions.TestForTrue  ( ( G_IRX_OK)  ) ) 
            { 
            __context__.SourceCodeLine = 118;
            G_IRX_OK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 119;
            while ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 121;
                G_SREPLY  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 123;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Length( RX__DOLLAR__ ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 1 ) ) == 3) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 125;
                    G_SREPLY  .UpdateValue ( G_SREPLY + Functions.Remove ( 1, RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 123;
                    } 
                
                __context__.SourceCodeLine = 128;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( G_SREPLY , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( G_SREPLY , (int)( 6 ) , (int)( 3 ) ) == G_SOBJECT_ID) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 130;
                    IN_FOR_OUT_FB [ (Byte( G_SREPLY , (int)( 10 ) ) + 1)]  .Value = (ushort) ( Byte( G_SREPLY , (int)( 14 ) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 119;
                } 
            
            __context__.SourceCodeLine = 133;
            G_IRX_OK = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OBJECT_ID_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 139;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( OBJECT_ID ) == 3))  ) ) 
            { 
            __context__.SourceCodeLine = 141;
            G_SOBJECT_ID  .UpdateValue ( OBJECT_ID  ) ; 
            __context__.SourceCodeLine = 142;
            OBJECT_ID_FB  .UpdateValue ( G_SOBJECT_ID  ) ; 
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
        
        __context__.SourceCodeLine = 149;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 128 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( G_INUM_OUT_USED  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (G_INUM_OUT_USED  >= __FN_FORSTART_VAL__1) && (G_INUM_OUT_USED  <= __FN_FOREND_VAL__1) ) : ( (G_INUM_OUT_USED  <= __FN_FORSTART_VAL__1) && (G_INUM_OUT_USED  >= __FN_FOREND_VAL__1) ) ; G_INUM_OUT_USED  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 151;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( IN_FOR_OUT[ G_INUM_OUT_USED ] ))  ) ) 
                {
                __context__.SourceCodeLine = 151;
                break ; 
                }
            
            __context__.SourceCodeLine = 149;
            } 
        
        __context__.SourceCodeLine = 154;
        G_SOBJECT_ID  .UpdateValue ( DEFAULT_OBJECT_ID  ) ; 
        __context__.SourceCodeLine = 155;
        OBJECT_ID_FB  .UpdateValue ( G_SOBJECT_ID  ) ; 
        __context__.SourceCodeLine = 157;
        G_IRX_OK = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SREPLY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    G_SOBJECT_ID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    
    SUBSCRIBE = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DigitalInput__, SUBSCRIBE );
    
    IN_FOR_OUT = new InOutArray<AnalogInput>( 128, this );
    for( uint i = 0; i < 128; i++ )
    {
        IN_FOR_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( IN_FOR_OUT__AnalogSerialInput__ + i, IN_FOR_OUT__AnalogSerialInput__, this );
        m_AnalogInputList.Add( IN_FOR_OUT__AnalogSerialInput__ + i, IN_FOR_OUT[i+1] );
    }
    
    IN_FOR_OUT_FB = new InOutArray<AnalogOutput>( 128, this );
    for( uint i = 0; i < 128; i++ )
    {
        IN_FOR_OUT_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( IN_FOR_OUT_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( IN_FOR_OUT_FB__AnalogSerialOutput__ + i, IN_FOR_OUT_FB[i+1] );
    }
    
    OBJECT_ID = new Crestron.Logos.SplusObjects.StringInput( OBJECT_ID__AnalogSerialInput__, 3, this );
    m_StringInputList.Add( OBJECT_ID__AnalogSerialInput__, OBJECT_ID );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    OBJECT_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( OBJECT_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( OBJECT_ID_FB__AnalogSerialOutput__, OBJECT_ID_FB );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    DEFAULT_OBJECT_ID = new StringParameter( DEFAULT_OBJECT_ID__Parameter__, this );
    m_ParameterList.Add( DEFAULT_OBJECT_ID__Parameter__, DEFAULT_OBJECT_ID );
    
    
    for( uint i = 0; i < 128; i++ )
        IN_FOR_OUT[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( IN_FOR_OUT_OnChange_0, false ) );
        
    SUBSCRIBE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE_OnPush_1, false ) );
    SUBSCRIBE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SUBSCRIBE_OnRelease_2, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_3, false ) );
    OBJECT_ID.OnSerialChange.Add( new InputChangeHandlerWrapper( OBJECT_ID_OnChange_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_BSS_SOURCE_MATRIX_ENGINE_R0_1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SUBSCRIBE__DigitalInput__ = 0;
const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint OBJECT_ID__AnalogSerialInput__ = 1;
const uint IN_FOR_OUT__AnalogSerialInput__ = 2;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint OBJECT_ID_FB__AnalogSerialOutput__ = 1;
const uint IN_FOR_OUT_FB__AnalogSerialOutput__ = 2;
const uint DEFAULT_OBJECT_ID__Parameter__ = 10;

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
