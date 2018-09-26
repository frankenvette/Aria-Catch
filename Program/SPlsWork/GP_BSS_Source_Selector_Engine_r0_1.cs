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

namespace UserModule_GP_BSS_SOURCE_SELECTOR_ENGINE_R0_1
{
    public class UserModuleClass_GP_BSS_SOURCE_SELECTOR_ENGINE_R0_1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput OBJECT_ID;
        Crestron.Logos.SplusObjects.AnalogInput IN;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput OBJECT_ID_FB;
        Crestron.Logos.SplusObjects.AnalogOutput IN_FB;
        ushort G_IRX_OK = 0;
        CrestronString G_SOBJECT_ID;
        CrestronString G_SREPLY;
        StringParameter DEFAULT_OBJECT_ID;
        object IN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 58;
                MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0000\u0000\u0000\u0000{1}\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID , Functions.Chr (  (int) ( IN  .UshortValue ) ) ) ; 
                __context__.SourceCodeLine = 59;
                if ( Functions.TestForTrue  ( ( SUBSCRIBE  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 61;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u0000\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID ) ; 
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
            
            __context__.SourceCodeLine = 67;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u0000\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID ) ; 
            
            
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
        
        __context__.SourceCodeLine = 72;
        MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u0000\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", G_SOBJECT_ID ) ; 
        
        
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
        
        __context__.SourceCodeLine = 77;
        if ( Functions.TestForTrue  ( ( G_IRX_OK)  ) ) 
            { 
            __context__.SourceCodeLine = 79;
            G_IRX_OK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 80;
            while ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 82;
                G_SREPLY  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 84;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Length( RX__DOLLAR__ ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 1 ) ) == 3) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 86;
                    G_SREPLY  .UpdateValue ( G_SREPLY + Functions.Remove ( 1, RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 84;
                    } 
                
                __context__.SourceCodeLine = 88;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( G_SREPLY , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( G_SREPLY , (int)( 6 ) , (int)( 3 ) ) == G_SOBJECT_ID) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 90;
                    IN_FB  .Value = (ushort) ( Byte( G_SREPLY , (int)( 14 ) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 80;
                } 
            
            __context__.SourceCodeLine = 93;
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
        
        __context__.SourceCodeLine = 99;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( OBJECT_ID ) == 3))  ) ) 
            { 
            __context__.SourceCodeLine = 101;
            G_SOBJECT_ID  .UpdateValue ( OBJECT_ID  ) ; 
            __context__.SourceCodeLine = 102;
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
        
        __context__.SourceCodeLine = 109;
        G_SOBJECT_ID  .UpdateValue ( DEFAULT_OBJECT_ID  ) ; 
        __context__.SourceCodeLine = 110;
        OBJECT_ID_FB  .UpdateValue ( G_SOBJECT_ID  ) ; 
        __context__.SourceCodeLine = 112;
        G_IRX_OK = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SOBJECT_ID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    G_SREPLY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    
    SUBSCRIBE = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DigitalInput__, SUBSCRIBE );
    
    IN = new Crestron.Logos.SplusObjects.AnalogInput( IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( IN__AnalogSerialInput__, IN );
    
    IN_FB = new Crestron.Logos.SplusObjects.AnalogOutput( IN_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( IN_FB__AnalogSerialOutput__, IN_FB );
    
    OBJECT_ID = new Crestron.Logos.SplusObjects.StringInput( OBJECT_ID__AnalogSerialInput__, 3, this );
    m_StringInputList.Add( OBJECT_ID__AnalogSerialInput__, OBJECT_ID );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    OBJECT_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( OBJECT_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( OBJECT_ID_FB__AnalogSerialOutput__, OBJECT_ID_FB );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    DEFAULT_OBJECT_ID = new StringParameter( DEFAULT_OBJECT_ID__Parameter__, this );
    m_ParameterList.Add( DEFAULT_OBJECT_ID__Parameter__, DEFAULT_OBJECT_ID );
    
    
    IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( IN_OnChange_0, false ) );
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

public UserModuleClass_GP_BSS_SOURCE_SELECTOR_ENGINE_R0_1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SUBSCRIBE__DigitalInput__ = 0;
const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint OBJECT_ID__AnalogSerialInput__ = 1;
const uint IN__AnalogSerialInput__ = 2;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint OBJECT_ID_FB__AnalogSerialOutput__ = 1;
const uint IN_FB__AnalogSerialOutput__ = 2;
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
