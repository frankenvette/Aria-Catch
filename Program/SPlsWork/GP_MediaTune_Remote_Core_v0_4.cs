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
using mediaTune;

namespace UserModule_GP_MEDIATUNE_REMOTE_CORE_V0_4
{
    public class UserModuleClass_GP_MEDIATUNE_REMOTE_CORE_V0_4 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.AnalogInput SUBSCRIBE;
        Crestron.Logos.SplusObjects.StringInput IP;
        Crestron.Logos.SplusObjects.AnalogInput LISTEN_PORT;
        Crestron.Logos.SplusObjects.BufferInput LOCAL_CHANNEL_FILTER;
        Crestron.Logos.SplusObjects.DigitalOutput SOCKET_BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SUBSCRIBE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput INITIALIZE_FB;
        Crestron.Logos.SplusObjects.StringOutput MESSAGE_FB;
        Crestron.Logos.SplusObjects.StringOutput IP_FB;
        Crestron.Logos.SplusObjects.AnalogOutput LISTEN_PORT_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_COUNT_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_COUNT_LOCAL_FILTER_FB;
        StringParameter DEFAULT_IP;
        UShortParameter DEFAULT_LISTEN_PORT;
        public void EMESSAGE ( object __sender__ /*mediaTune.MessageEventArgs E */) 
            { 
            MessageEventArgs  E  = (MessageEventArgs )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 133;
                MESSAGE_FB  .UpdateValue ( E . Message  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void EINITIALIZE_VALUE ( object __sender__ /*mediaTune.InitializeEventArgs E */) 
            { 
            InitializeEventArgs  E  = (InitializeEventArgs )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 135;
                INITIALIZE_FB  .Value = (ushort) ( E.Initialize_Value_FB ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ECHANNEL_COUNT ( object __sender__ /*mediaTune.ChannelCountEventArgs E */) 
            { 
            ChannelCountEventArgs  E  = (ChannelCountEventArgs )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 136;
                CHANNEL_COUNT_FB  .Value = (ushort) ( E.Channel_Count ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ESUBSCRIPTIONFB ( object __sender__ /*mediaTune.SubscriptionFB_EventArgs E */) 
            { 
            SubscriptionFB_EventArgs  E  = (SubscriptionFB_EventArgs )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 137;
                SUBSCRIBE_FB  .Value = (ushort) ( E.SubscriptionFB ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_IP_FB ( SimplSharpString V ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 139;
                IP_FB  .UpdateValue ( V  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_LISTEN_PORT_FB ( ushort V ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 140;
                LISTEN_PORT_FB  .Value = (ushort) ( V ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_CHANNEL_COUNT_LOCAL_FILTER_FB ( ushort V ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 141;
                CHANNEL_COUNT_LOCAL_FILTER_FB  .Value = (ushort) ( V ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object INITIALIZE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                 RemoteCore.initialize()  ;  
 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SUBSCRIBE_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
             RemoteCore.subscription( (ushort)( SUBSCRIBE  .UshortValue ) )  ;  
 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object IP_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
         RemoteCore.ipAdr  =( IP )  .ToString()  ;  
 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LISTEN_PORT_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
         RemoteCore.TCPServerPort  =  (ushort)( LISTEN_PORT  .UshortValue )  ;  
 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LOCAL_CHANNEL_FILTER_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 150;
        if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003" , LOCAL_CHANNEL_FILTER ))  ) ) 
            { 
            __context__.SourceCodeLine = 152;
             RemoteCore.localChannelFilter  =( Functions.Remove( "\u0003" , LOCAL_CHANNEL_FILTER ) )  .ToString()  ;  
 
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
        
        __context__.SourceCodeLine = 158;
        // RegisterEvent( Message , ONMESSAGE_CHANGE , EMESSAGE ) 
        try { g_criticalSection.Enter(); Message .onMessage_Change  += EMESSAGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 160;
        // RegisterEvent( ChannelCount_Remote , ONCHANNELCOUNT_REMOTE_CHANGE , ECHANNEL_COUNT ) 
        try { g_criticalSection.Enter(); ChannelCount_Remote .onChannelCount_Remote_Change  += ECHANNEL_COUNT; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 161;
        // RegisterEvent( EventInitialize , ONINITIALIZE_VALUE_CHANGE , EINITIALIZE_VALUE ) 
        try { g_criticalSection.Enter(); EventInitialize .onInitialize_Value_Change  += EINITIALIZE_VALUE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 162;
        // RegisterEvent( SubscriptionFB_Remote , ONSUBSCRIPTION_FB_CHANGE , ESUBSCRIPTIONFB ) 
        try { g_criticalSection.Enter(); SubscriptionFB_Remote .onSubscription_FB_Change  += ESUBSCRIPTIONFB; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 164;
        // RegisterDelegate( RemoteCore , IPADRCHANGE , CBF_IP_FB ) 
        RemoteCore .ipAdrChange  = CBF_IP_FB; ; 
        __context__.SourceCodeLine = 165;
        // RegisterDelegate( RemoteCore , TCPSERVERPORTCHANGE , CBF_LISTEN_PORT_FB ) 
        RemoteCore .TCPServerPortChange  = CBF_LISTEN_PORT_FB; ; 
        __context__.SourceCodeLine = 166;
        // RegisterDelegate( RemoteCore , LOCALCHANNELFILTERCOUNTCHANGE , CBF_CHANNEL_COUNT_LOCAL_FILTER_FB ) 
        RemoteCore .localChannelFilterCountChange  = CBF_CHANNEL_COUNT_LOCAL_FILTER_FB; ; 
        __context__.SourceCodeLine = 168;
         RemoteCore.ipAdr  =( DEFAULT_IP  )  .ToString()  ;  
 
        __context__.SourceCodeLine = 169;
         RemoteCore.TCPServerPort  =  (ushort)( DEFAULT_LISTEN_PORT  .Value )  ;  
 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    SOCKET_BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SOCKET_BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SOCKET_BUSY_FB__DigitalOutput__, SOCKET_BUSY_FB );
    
    SUBSCRIBE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SUBSCRIBE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SUBSCRIBE_FB__DigitalOutput__, SUBSCRIBE_FB );
    
    SUBSCRIBE = new Crestron.Logos.SplusObjects.AnalogInput( SUBSCRIBE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SUBSCRIBE__AnalogSerialInput__, SUBSCRIBE );
    
    LISTEN_PORT = new Crestron.Logos.SplusObjects.AnalogInput( LISTEN_PORT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( LISTEN_PORT__AnalogSerialInput__, LISTEN_PORT );
    
    INITIALIZE_FB = new Crestron.Logos.SplusObjects.AnalogOutput( INITIALIZE_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( INITIALIZE_FB__AnalogSerialOutput__, INITIALIZE_FB );
    
    LISTEN_PORT_FB = new Crestron.Logos.SplusObjects.AnalogOutput( LISTEN_PORT_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LISTEN_PORT_FB__AnalogSerialOutput__, LISTEN_PORT_FB );
    
    CHANNEL_COUNT_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_COUNT_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_COUNT_FB__AnalogSerialOutput__, CHANNEL_COUNT_FB );
    
    CHANNEL_COUNT_LOCAL_FILTER_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_COUNT_LOCAL_FILTER_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_COUNT_LOCAL_FILTER_FB__AnalogSerialOutput__, CHANNEL_COUNT_LOCAL_FILTER_FB );
    
    IP = new Crestron.Logos.SplusObjects.StringInput( IP__AnalogSerialInput__, 16, this );
    m_StringInputList.Add( IP__AnalogSerialInput__, IP );
    
    MESSAGE_FB = new Crestron.Logos.SplusObjects.StringOutput( MESSAGE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( MESSAGE_FB__AnalogSerialOutput__, MESSAGE_FB );
    
    IP_FB = new Crestron.Logos.SplusObjects.StringOutput( IP_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( IP_FB__AnalogSerialOutput__, IP_FB );
    
    LOCAL_CHANNEL_FILTER = new Crestron.Logos.SplusObjects.BufferInput( LOCAL_CHANNEL_FILTER__AnalogSerialInput__, 4096, this );
    m_StringInputList.Add( LOCAL_CHANNEL_FILTER__AnalogSerialInput__, LOCAL_CHANNEL_FILTER );
    
    DEFAULT_LISTEN_PORT = new UShortParameter( DEFAULT_LISTEN_PORT__Parameter__, this );
    m_ParameterList.Add( DEFAULT_LISTEN_PORT__Parameter__, DEFAULT_LISTEN_PORT );
    
    DEFAULT_IP = new StringParameter( DEFAULT_IP__Parameter__, this );
    m_ParameterList.Add( DEFAULT_IP__Parameter__, DEFAULT_IP );
    
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    SUBSCRIBE.OnAnalogChange.Add( new InputChangeHandlerWrapper( SUBSCRIBE_OnChange_1, false ) );
    IP.OnSerialChange.Add( new InputChangeHandlerWrapper( IP_OnChange_2, false ) );
    LISTEN_PORT.OnAnalogChange.Add( new InputChangeHandlerWrapper( LISTEN_PORT_OnChange_3, false ) );
    LOCAL_CHANNEL_FILTER.OnSerialChange.Add( new InputChangeHandlerWrapper( LOCAL_CHANNEL_FILTER_OnChange_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_MEDIATUNE_REMOTE_CORE_V0_4 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint SUBSCRIBE__AnalogSerialInput__ = 0;
const uint IP__AnalogSerialInput__ = 1;
const uint LISTEN_PORT__AnalogSerialInput__ = 2;
const uint LOCAL_CHANNEL_FILTER__AnalogSerialInput__ = 3;
const uint SOCKET_BUSY_FB__DigitalOutput__ = 0;
const uint SUBSCRIBE_FB__DigitalOutput__ = 1;
const uint INITIALIZE_FB__AnalogSerialOutput__ = 0;
const uint MESSAGE_FB__AnalogSerialOutput__ = 1;
const uint IP_FB__AnalogSerialOutput__ = 2;
const uint LISTEN_PORT_FB__AnalogSerialOutput__ = 3;
const uint CHANNEL_COUNT_FB__AnalogSerialOutput__ = 4;
const uint CHANNEL_COUNT_LOCAL_FILTER_FB__AnalogSerialOutput__ = 5;
const uint DEFAULT_IP__Parameter__ = 10;
const uint DEFAULT_LISTEN_PORT__Parameter__ = 11;

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
