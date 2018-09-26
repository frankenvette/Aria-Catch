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

namespace UserModule_TIME_SERIALIZER
{
    public class UserModuleClass_TIME_SERIALIZER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput OSC_CHANGE;
        Crestron.Logos.SplusObjects.DigitalInput TIME_FORMAT_12_HOUR;
        Crestron.Logos.SplusObjects.DigitalInput TIME_FORMAT_24_HOUR;
        Crestron.Logos.SplusObjects.StringOutput CUR_TIME_OUT;
        Crestron.Logos.SplusObjects.DigitalOutput TIME_FORMAT_12_HOUR_FB;
        Crestron.Logos.SplusObjects.DigitalOutput TIME_FORMAT_24_HOUR_FB;
        ushort SETTINGS_12_HOUR_MODE = 0;
        ushort CUR_TIME_HOUR = 0;
        ushort CUR_TIME_MIN = 0;
        ushort CUR_TIME_DATE = 0;
        private void UPDATETIME (  SplusExecutionContext __context__ ) 
            { 
            CrestronString TEMP_HOUR;
            CrestronString TEMP_MIN;
            CrestronString TEMP_AMPM;
            TEMP_HOUR  = new CrestronString( InheritedStringEncoding, 2, this );
            TEMP_MIN  = new CrestronString( InheritedStringEncoding, 2, this );
            TEMP_AMPM  = new CrestronString( InheritedStringEncoding, 2, this );
            
            
            __context__.SourceCodeLine = 87;
            CUR_TIME_HOUR = (ushort) ( Functions.GetHourNum() ) ; 
            __context__.SourceCodeLine = 88;
            CUR_TIME_MIN = (ushort) ( Functions.GetMinutesNum() ) ; 
            __context__.SourceCodeLine = 89;
            CUR_TIME_DATE = (ushort) ( Functions.GetDateNum() ) ; 
            __context__.SourceCodeLine = 92;
            TEMP_HOUR  .UpdateValue ( Functions.ItoA (  (int) ( CUR_TIME_HOUR ) )  ) ; 
            __context__.SourceCodeLine = 93;
            TEMP_MIN  .UpdateValue ( Functions.ItoA (  (int) ( CUR_TIME_MIN ) )  ) ; 
            __context__.SourceCodeLine = 93;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( TEMP_MIN ) == 1))  ) ) 
                {
                __context__.SourceCodeLine = 93;
                TEMP_MIN  .UpdateValue ( "0" + TEMP_MIN  ) ; 
                }
            
            __context__.SourceCodeLine = 96;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SETTINGS_12_HOUR_MODE == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 98;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( CUR_TIME_HOUR > 12 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 99;
                    TEMP_AMPM  .UpdateValue ( "PM"  ) ; 
                    __context__.SourceCodeLine = 100;
                    TEMP_HOUR  .UpdateValue ( Functions.ItoA (  (int) ( (CUR_TIME_HOUR - 12) ) )  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 101;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CUR_TIME_HOUR == 12))  ) ) 
                        { 
                        __context__.SourceCodeLine = 102;
                        TEMP_AMPM  .UpdateValue ( "PM"  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 103;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CUR_TIME_HOUR == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 104;
                            TEMP_HOUR  .UpdateValue ( "12"  ) ; 
                            __context__.SourceCodeLine = 105;
                            TEMP_AMPM  .UpdateValue ( "AM"  ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 107;
                            TEMP_AMPM  .UpdateValue ( "AM"  ) ; 
                            } 
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 111;
                CUR_TIME_OUT  .UpdateValue ( TEMP_HOUR + ":" + TEMP_MIN + " " + TEMP_AMPM  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 114;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( TEMP_HOUR ) == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 115;
                    TEMP_HOUR  .UpdateValue ( "0" + TEMP_HOUR  ) ; 
                    }
                
                __context__.SourceCodeLine = 117;
                CUR_TIME_OUT  .UpdateValue ( TEMP_HOUR + ":" + TEMP_MIN  ) ; 
                } 
            
            
            }
            
        object OSC_CHANGE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort CHECK_ALARM_FLAG = 0;
                
                
                __context__.SourceCodeLine = 138;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CUR_TIME_MIN != Functions.GetMinutesNum()))  ) ) 
                    { 
                    __context__.SourceCodeLine = 140;
                    UPDATETIME (  __context__  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object TIME_FORMAT_12_HOUR_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 147;
            SETTINGS_12_HOUR_MODE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 149;
            TIME_FORMAT_12_HOUR_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 150;
            TIME_FORMAT_24_HOUR_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 152;
            UPDATETIME (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object TIME_FORMAT_24_HOUR_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 157;
        SETTINGS_12_HOUR_MODE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 159;
        TIME_FORMAT_12_HOUR_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 160;
        TIME_FORMAT_24_HOUR_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 162;
        UPDATETIME (  __context__  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 168;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 169;
        SETTINGS_12_HOUR_MODE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 170;
        TIME_FORMAT_12_HOUR_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 171;
        UPDATETIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    OSC_CHANGE = new Crestron.Logos.SplusObjects.DigitalInput( OSC_CHANGE__DigitalInput__, this );
    m_DigitalInputList.Add( OSC_CHANGE__DigitalInput__, OSC_CHANGE );
    
    TIME_FORMAT_12_HOUR = new Crestron.Logos.SplusObjects.DigitalInput( TIME_FORMAT_12_HOUR__DigitalInput__, this );
    m_DigitalInputList.Add( TIME_FORMAT_12_HOUR__DigitalInput__, TIME_FORMAT_12_HOUR );
    
    TIME_FORMAT_24_HOUR = new Crestron.Logos.SplusObjects.DigitalInput( TIME_FORMAT_24_HOUR__DigitalInput__, this );
    m_DigitalInputList.Add( TIME_FORMAT_24_HOUR__DigitalInput__, TIME_FORMAT_24_HOUR );
    
    TIME_FORMAT_12_HOUR_FB = new Crestron.Logos.SplusObjects.DigitalOutput( TIME_FORMAT_12_HOUR_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( TIME_FORMAT_12_HOUR_FB__DigitalOutput__, TIME_FORMAT_12_HOUR_FB );
    
    TIME_FORMAT_24_HOUR_FB = new Crestron.Logos.SplusObjects.DigitalOutput( TIME_FORMAT_24_HOUR_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( TIME_FORMAT_24_HOUR_FB__DigitalOutput__, TIME_FORMAT_24_HOUR_FB );
    
    CUR_TIME_OUT = new Crestron.Logos.SplusObjects.StringOutput( CUR_TIME_OUT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CUR_TIME_OUT__AnalogSerialOutput__, CUR_TIME_OUT );
    
    
    OSC_CHANGE.OnDigitalChange.Add( new InputChangeHandlerWrapper( OSC_CHANGE_OnChange_0, false ) );
    TIME_FORMAT_12_HOUR.OnDigitalPush.Add( new InputChangeHandlerWrapper( TIME_FORMAT_12_HOUR_OnPush_1, false ) );
    TIME_FORMAT_24_HOUR.OnDigitalPush.Add( new InputChangeHandlerWrapper( TIME_FORMAT_24_HOUR_OnPush_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TIME_SERIALIZER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint OSC_CHANGE__DigitalInput__ = 0;
const uint TIME_FORMAT_12_HOUR__DigitalInput__ = 1;
const uint TIME_FORMAT_24_HOUR__DigitalInput__ = 2;
const uint CUR_TIME_OUT__AnalogSerialOutput__ = 0;
const uint TIME_FORMAT_12_HOUR_FB__DigitalOutput__ = 0;
const uint TIME_FORMAT_24_HOUR_FB__DigitalOutput__ = 1;

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
