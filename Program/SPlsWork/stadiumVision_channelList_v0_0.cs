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
using stadiumVision;

namespace UserModule_STADIUMVISION_CHANNELLIST_V0_0
{
    public class UserModuleClass_STADIUMVISION_CHANNELLIST_V0_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput PRINTCHANNELS;
        Crestron.Logos.SplusObjects.StringInput PIN_F;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_LIST_SELECT;
        Crestron.Logos.SplusObjects.StringOutput DEBUG_FB;
        Crestron.Logos.SplusObjects.StringOutput MESSAGE_FB;
        Crestron.Logos.SplusObjects.StringOutput FILTER_STRING_FB;
        Crestron.Logos.SplusObjects.StringOutput GROUP_ID_FB;
        Crestron.Logos.SplusObjects.StringOutput GROUP_NAME_FB;
        Crestron.Logos.SplusObjects.StringOutput GROUP_EXTERNAL_ID_FB;
        Crestron.Logos.SplusObjects.StringOutput PIN_F_FB;
        Crestron.Logos.SplusObjects.AnalogOutput ACK_NCK_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_LIST_NAME_FB;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_COUNT_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_ID_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_NAME_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_DESCRIPTION_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_SHORT_NAME_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_LONG_NAME_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_LOGICAL_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_PHYSICAL_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_FAVORITE_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_FAVORITE_ORDER_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_SOURCE_ID_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_LOGO_SMALL_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_LOGO_MEDIUM_FB;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL_LOGO_LARGE_FB;
        StringParameter DEFAULT_PIN_FIXED;
        stadiumVision.channelList THIS;
        public void CBF_DEBUG_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 91;
                DEBUG_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_MESSAGE_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 92;
                MESSAGE_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_FILTER_STRING_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 94;
                FILTER_STRING_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_GROUP_ID_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 96;
                GROUP_ID_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_GROUP_NAME_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 97;
                GROUP_NAME_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_GROUP_EXTERNAL_ID_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 98;
                GROUP_EXTERNAL_ID_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_PIN_F_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 100;
                PIN_F_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_CHANNEL_LIST_NAME_FB ( SimplSharpString S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 101;
                CHANNEL_LIST_NAME_FB  .UpdateValue ( S  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_CHANNEL_COUNT_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 102;
                CHANNEL_COUNT_FB  .Value = (ushort) ( S ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ELIST_SELECT_FB ( object __sender__ /*stadiumVision.ListSelectEventArgs S */) 
            { 
            ListSelectEventArgs  S  = (ListSelectEventArgs )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 106;
                CHANNEL_ID_FB  .UpdateValue ( S . Id  ) ; 
                __context__.SourceCodeLine = 107;
                CHANNEL_NAME_FB  .UpdateValue ( S . Name  ) ; 
                __context__.SourceCodeLine = 108;
                CHANNEL_DESCRIPTION_FB  .UpdateValue ( S . Description  ) ; 
                __context__.SourceCodeLine = 109;
                CHANNEL_SHORT_NAME_FB  .UpdateValue ( S . ShortName  ) ; 
                __context__.SourceCodeLine = 110;
                CHANNEL_LONG_NAME_FB  .UpdateValue ( S . LongName  ) ; 
                __context__.SourceCodeLine = 111;
                CHANNEL_LOGICAL_FB  .UpdateValue ( S . LogicalChannel  ) ; 
                __context__.SourceCodeLine = 112;
                CHANNEL_PHYSICAL_FB  .UpdateValue ( S . PhysicalChannel  ) ; 
                __context__.SourceCodeLine = 113;
                CHANNEL_FAVORITE_FB  .UpdateValue ( S . Favorite  ) ; 
                __context__.SourceCodeLine = 114;
                CHANNEL_FAVORITE_ORDER_FB  .UpdateValue ( S . FavoriteOrder  ) ; 
                __context__.SourceCodeLine = 115;
                CHANNEL_SOURCE_ID_FB  .UpdateValue ( S . SourceId  ) ; 
                __context__.SourceCodeLine = 116;
                CHANNEL_LOGO_SMALL_FB  .UpdateValue ( S . LogoSmall  ) ; 
                __context__.SourceCodeLine = 117;
                CHANNEL_LOGO_MEDIUM_FB  .UpdateValue ( S . LogoMedium  ) ; 
                __context__.SourceCodeLine = 118;
                CHANNEL_LOGO_LARGE_FB  .UpdateValue ( S . LogoLarge  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_ACK_NAK_FB ( ushort S ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 122;
                ACK_NCK_FB  .Value = (ushort) ( S ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object INITIALIZE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 126;
                THIS . init ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object PRINTCHANNELS_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 127;
            THIS . printChannelList ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object PIN_F_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 128;
        THIS . pin_F  =  ( PIN_F  )  .ToString() ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_LIST_SELECT_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 129;
        THIS . List_Select ( (ushort)( CHANNEL_LIST_SELECT  .UshortValue )) ; 
        
        
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
        
        __context__.SourceCodeLine = 134;
        // RegisterDelegate( THIS , MESSAGE_ , CBF_MESSAGE_FB ) 
        THIS .Message_  = CBF_MESSAGE_FB; ; 
        __context__.SourceCodeLine = 135;
        // RegisterDelegate( THIS , DEBUG_ , CBF_DEBUG_FB ) 
        THIS .Debug_  = CBF_DEBUG_FB; ; 
        __context__.SourceCodeLine = 137;
        // RegisterDelegate( THIS , FILTER_STRING_ , CBF_FILTER_STRING_FB ) 
        THIS .Filter_String_  = CBF_FILTER_STRING_FB; ; 
        __context__.SourceCodeLine = 139;
        // RegisterDelegate( THIS , GROUP_ID_ , CBF_GROUP_ID_FB ) 
        THIS .Group_Id_  = CBF_GROUP_ID_FB; ; 
        __context__.SourceCodeLine = 140;
        // RegisterDelegate( THIS , GROUP_NAME_ , CBF_GROUP_NAME_FB ) 
        THIS .Group_Name_  = CBF_GROUP_NAME_FB; ; 
        __context__.SourceCodeLine = 141;
        // RegisterDelegate( THIS , GROUP_EXTERNAL_ID_ , CBF_GROUP_EXTERNAL_ID_FB ) 
        THIS .Group_External_Id_  = CBF_GROUP_EXTERNAL_ID_FB; ; 
        __context__.SourceCodeLine = 143;
        // RegisterDelegate( THIS , PIN_F_ , CBF_PIN_F_FB ) 
        THIS .Pin_F_  = CBF_PIN_F_FB; ; 
        __context__.SourceCodeLine = 144;
        // RegisterDelegate( THIS , ACK_NAK_ , CBF_ACK_NAK_FB ) 
        THIS .Ack_Nak_  = CBF_ACK_NAK_FB; ; 
        __context__.SourceCodeLine = 146;
        // RegisterDelegate( THIS , LIST_NAME_ , CBF_CHANNEL_LIST_NAME_FB ) 
        THIS .List_Name_  = CBF_CHANNEL_LIST_NAME_FB; ; 
        __context__.SourceCodeLine = 147;
        // RegisterDelegate( THIS , CHANNEL_COUNT_ , CBF_CHANNEL_COUNT_FB ) 
        THIS .Channel_Count_  = CBF_CHANNEL_COUNT_FB; ; 
        __context__.SourceCodeLine = 149;
        // RegisterEvent( channelList , ONLIST_SELECT_CHANGE , ELIST_SELECT_FB ) 
        try { g_criticalSection.Enter(); channelList .onList_Select_Change  += ELIST_SELECT_FB; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 152;
        THIS . pin_F  =  ( DEFAULT_PIN_FIXED  )  .ToString() ; 
        
        
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
    
    PRINTCHANNELS = new Crestron.Logos.SplusObjects.DigitalInput( PRINTCHANNELS__DigitalInput__, this );
    m_DigitalInputList.Add( PRINTCHANNELS__DigitalInput__, PRINTCHANNELS );
    
    CHANNEL_LIST_SELECT = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_LIST_SELECT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_LIST_SELECT__AnalogSerialInput__, CHANNEL_LIST_SELECT );
    
    ACK_NCK_FB = new Crestron.Logos.SplusObjects.AnalogOutput( ACK_NCK_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ACK_NCK_FB__AnalogSerialOutput__, ACK_NCK_FB );
    
    CHANNEL_COUNT_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_COUNT_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_COUNT_FB__AnalogSerialOutput__, CHANNEL_COUNT_FB );
    
    PIN_F = new Crestron.Logos.SplusObjects.StringInput( PIN_F__AnalogSerialInput__, 32, this );
    m_StringInputList.Add( PIN_F__AnalogSerialInput__, PIN_F );
    
    DEBUG_FB = new Crestron.Logos.SplusObjects.StringOutput( DEBUG_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( DEBUG_FB__AnalogSerialOutput__, DEBUG_FB );
    
    MESSAGE_FB = new Crestron.Logos.SplusObjects.StringOutput( MESSAGE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( MESSAGE_FB__AnalogSerialOutput__, MESSAGE_FB );
    
    FILTER_STRING_FB = new Crestron.Logos.SplusObjects.StringOutput( FILTER_STRING_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILTER_STRING_FB__AnalogSerialOutput__, FILTER_STRING_FB );
    
    GROUP_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( GROUP_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( GROUP_ID_FB__AnalogSerialOutput__, GROUP_ID_FB );
    
    GROUP_NAME_FB = new Crestron.Logos.SplusObjects.StringOutput( GROUP_NAME_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( GROUP_NAME_FB__AnalogSerialOutput__, GROUP_NAME_FB );
    
    GROUP_EXTERNAL_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( GROUP_EXTERNAL_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( GROUP_EXTERNAL_ID_FB__AnalogSerialOutput__, GROUP_EXTERNAL_ID_FB );
    
    PIN_F_FB = new Crestron.Logos.SplusObjects.StringOutput( PIN_F_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PIN_F_FB__AnalogSerialOutput__, PIN_F_FB );
    
    CHANNEL_LIST_NAME_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_LIST_NAME_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_LIST_NAME_FB__AnalogSerialOutput__, CHANNEL_LIST_NAME_FB );
    
    CHANNEL_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_ID_FB__AnalogSerialOutput__, CHANNEL_ID_FB );
    
    CHANNEL_NAME_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_NAME_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_NAME_FB__AnalogSerialOutput__, CHANNEL_NAME_FB );
    
    CHANNEL_DESCRIPTION_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_DESCRIPTION_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_DESCRIPTION_FB__AnalogSerialOutput__, CHANNEL_DESCRIPTION_FB );
    
    CHANNEL_SHORT_NAME_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_SHORT_NAME_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_SHORT_NAME_FB__AnalogSerialOutput__, CHANNEL_SHORT_NAME_FB );
    
    CHANNEL_LONG_NAME_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_LONG_NAME_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_LONG_NAME_FB__AnalogSerialOutput__, CHANNEL_LONG_NAME_FB );
    
    CHANNEL_LOGICAL_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_LOGICAL_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_LOGICAL_FB__AnalogSerialOutput__, CHANNEL_LOGICAL_FB );
    
    CHANNEL_PHYSICAL_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_PHYSICAL_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_PHYSICAL_FB__AnalogSerialOutput__, CHANNEL_PHYSICAL_FB );
    
    CHANNEL_FAVORITE_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_FAVORITE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_FAVORITE_FB__AnalogSerialOutput__, CHANNEL_FAVORITE_FB );
    
    CHANNEL_FAVORITE_ORDER_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_FAVORITE_ORDER_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_FAVORITE_ORDER_FB__AnalogSerialOutput__, CHANNEL_FAVORITE_ORDER_FB );
    
    CHANNEL_SOURCE_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_SOURCE_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_SOURCE_ID_FB__AnalogSerialOutput__, CHANNEL_SOURCE_ID_FB );
    
    CHANNEL_LOGO_SMALL_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_LOGO_SMALL_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_LOGO_SMALL_FB__AnalogSerialOutput__, CHANNEL_LOGO_SMALL_FB );
    
    CHANNEL_LOGO_MEDIUM_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_LOGO_MEDIUM_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_LOGO_MEDIUM_FB__AnalogSerialOutput__, CHANNEL_LOGO_MEDIUM_FB );
    
    CHANNEL_LOGO_LARGE_FB = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL_LOGO_LARGE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL_LOGO_LARGE_FB__AnalogSerialOutput__, CHANNEL_LOGO_LARGE_FB );
    
    DEFAULT_PIN_FIXED = new StringParameter( DEFAULT_PIN_FIXED__Parameter__, this );
    m_ParameterList.Add( DEFAULT_PIN_FIXED__Parameter__, DEFAULT_PIN_FIXED );
    
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    PRINTCHANNELS.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRINTCHANNELS_OnPush_1, false ) );
    PIN_F.OnSerialChange.Add( new InputChangeHandlerWrapper( PIN_F_OnChange_2, false ) );
    CHANNEL_LIST_SELECT.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_LIST_SELECT_OnChange_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    THIS  = new stadiumVision.channelList();
    
    
}

public UserModuleClass_STADIUMVISION_CHANNELLIST_V0_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint PRINTCHANNELS__DigitalInput__ = 1;
const uint PIN_F__AnalogSerialInput__ = 0;
const uint CHANNEL_LIST_SELECT__AnalogSerialInput__ = 1;
const uint DEBUG_FB__AnalogSerialOutput__ = 0;
const uint MESSAGE_FB__AnalogSerialOutput__ = 1;
const uint FILTER_STRING_FB__AnalogSerialOutput__ = 2;
const uint GROUP_ID_FB__AnalogSerialOutput__ = 3;
const uint GROUP_NAME_FB__AnalogSerialOutput__ = 4;
const uint GROUP_EXTERNAL_ID_FB__AnalogSerialOutput__ = 5;
const uint PIN_F_FB__AnalogSerialOutput__ = 6;
const uint ACK_NCK_FB__AnalogSerialOutput__ = 7;
const uint CHANNEL_LIST_NAME_FB__AnalogSerialOutput__ = 8;
const uint CHANNEL_COUNT_FB__AnalogSerialOutput__ = 9;
const uint CHANNEL_ID_FB__AnalogSerialOutput__ = 10;
const uint CHANNEL_NAME_FB__AnalogSerialOutput__ = 11;
const uint CHANNEL_DESCRIPTION_FB__AnalogSerialOutput__ = 12;
const uint CHANNEL_SHORT_NAME_FB__AnalogSerialOutput__ = 13;
const uint CHANNEL_LONG_NAME_FB__AnalogSerialOutput__ = 14;
const uint CHANNEL_LOGICAL_FB__AnalogSerialOutput__ = 15;
const uint CHANNEL_PHYSICAL_FB__AnalogSerialOutput__ = 16;
const uint CHANNEL_FAVORITE_FB__AnalogSerialOutput__ = 17;
const uint CHANNEL_FAVORITE_ORDER_FB__AnalogSerialOutput__ = 18;
const uint CHANNEL_SOURCE_ID_FB__AnalogSerialOutput__ = 19;
const uint CHANNEL_LOGO_SMALL_FB__AnalogSerialOutput__ = 20;
const uint CHANNEL_LOGO_MEDIUM_FB__AnalogSerialOutput__ = 21;
const uint CHANNEL_LOGO_LARGE_FB__AnalogSerialOutput__ = 22;
const uint DEFAULT_PIN_FIXED__Parameter__ = 10;

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
