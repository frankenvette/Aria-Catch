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

namespace UserModule_GP_LIST_ORDER_W_PRESS_1_BUTTON__NO_PULSE_V1_3
{
    public class UserModuleClass_GP_LIST_ORDER_W_PRESS_1_BUTTON__NO_PULSE_V1_3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CHECK;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> BTN_PRESS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> BTN_FB;
        Crestron.Logos.SplusObjects.StringInput FROM_MODULE__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> ATT_LABEL;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> ATT_ANALOG;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput MESSAGE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput LIST_NUM;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PRESS_OUT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> LIST_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LIST_TEXT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LIST_ANALOG;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> ORDER;
        ushort G_IBUSY = 0;
        ushort G_IENABLE = 0;
        private void FORDER (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 48;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 49;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_IBUSY == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 51;
                G_IBUSY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 52;
                try 
                    { 
                    __context__.SourceCodeLine = 54;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)99; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 57;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ORDER[ I ] .Value > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 59;
                            LIST_TEXT [ I]  .UpdateValue ( ATT_LABEL [ ORDER[ I ] .Value ]  ) ; 
                            __context__.SourceCodeLine = 61;
                            LIST_FB [ I]  .Value = (ushort) ( BTN_FB[ ORDER[ I ] .Value ] .Value ) ; 
                            __context__.SourceCodeLine = 63;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIST_ANALOG[ I ] .Value != ATT_ANALOG[ ORDER[ I ] .Value ] .UshortValue))  ) ) 
                                { 
                                __context__.SourceCodeLine = 65;
                                LIST_ANALOG [ I]  .Value = (ushort) ( ATT_ANALOG[ ORDER[ I ] .Value ] .UshortValue ) ; 
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 54;
                        } 
                    
                    } 
                
                catch (Exception __splus_exception__)
                    { 
                    SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                    
                    __context__.SourceCodeLine = 72;
                    MESSAGE_FB  .UpdateValue ( "Exception in fOrder " + Functions.GetExceptionMessage (  __splus_exceptionobj__ )  ) ; 
                    
                    }
                    
                    __context__.SourceCodeLine = 74;
                    G_IBUSY = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 75;
                    BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 79;
                    MESSAGE_FB  .UpdateValue ( "fOrder Ignored busy"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 82;
                G_IENABLE = (ushort) ( 1 ) ; 
                
                }
                
            private void FPARSE (  SplusExecutionContext __context__ ) 
                { 
                ushort K = 0;
                
                CrestronString TEMP;
                TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 384, this );
                
                
                __context__.SourceCodeLine = 90;
                TEMP  .UpdateValue ( FROM_MODULE__DOLLAR__  ) ; 
                __context__.SourceCodeLine = 91;
                K = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 93;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "," , TEMP ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 95;
                    K = (ushort) ( (K + 1) ) ; 
                    __context__.SourceCodeLine = 96;
                    ORDER [ K]  .Value = (ushort) ( Functions.Atoi( Functions.Remove( "," , TEMP ) ) ) ; 
                    __context__.SourceCodeLine = 93;
                    } 
                
                __context__.SourceCodeLine = 99;
                K = (ushort) ( (K + 1) ) ; 
                __context__.SourceCodeLine = 100;
                ORDER [ K]  .Value = (ushort) ( Functions.Atoi( TEMP ) ) ; 
                __context__.SourceCodeLine = 102;
                LIST_NUM  .Value = (ushort) ( K ) ; 
                
                }
                
            private void FBTN_PRESS (  SplusExecutionContext __context__, ushort BTN_INDEX ) 
                { 
                
                __context__.SourceCodeLine = 108;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ORDER[ BTN_INDEX ] .Value > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 110;
                    Functions.Pulse ( 20, PRESS_OUT [ ORDER[ BTN_INDEX ] .Value] ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 114;
                    MESSAGE_FB  .UpdateValue ( "Button press function not Mapped or mapped Zero"  ) ; 
                    } 
                
                
                }
                
            private void FBTN_FB (  SplusExecutionContext __context__, ushort BTN_INDEX , ushort BTN_STATE ) 
                { 
                ushort J = 0;
                
                
                __context__.SourceCodeLine = 122;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)99; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 124;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ORDER[ J ] .Value == BTN_INDEX))  ) ) 
                        { 
                        __context__.SourceCodeLine = 126;
                        LIST_FB [ J]  .Value = (ushort) ( BTN_STATE ) ; 
                        __context__.SourceCodeLine = 127;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 122;
                    } 
                
                __context__.SourceCodeLine = 130;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( J > 99 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 132;
                    MESSAGE_FB  .UpdateValue ( "FB function not Mapped or mapped Zero"  ) ; 
                    } 
                
                
                }
                
            object FROM_MODULE__DOLLAR___OnChange_0 ( Object __EventInfo__ )
            
                { 
                Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
                try
                {
                    SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                    
                    __context__.SourceCodeLine = 141;
                    if ( Functions.TestForTrue  ( ( Functions.Length( FROM_MODULE__DOLLAR__ ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 143;
                        FPARSE (  __context__  ) ; 
                        __context__.SourceCodeLine = 144;
                        Functions.Delay (  (int) ( 50 ) ) ; 
                        __context__.SourceCodeLine = 145;
                        FORDER (  __context__  ) ; 
                        } 
                    
                    
                    
                }
                catch(Exception e) { ObjectCatchHandler(e); }
                finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                return this;
                
            }
            
        object CHECK_OnRelease_1 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 149;
                FORDER (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object BTN_PRESS_OnPush_2 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 155;
            if ( Functions.TestForTrue  ( ( G_IENABLE)  ) ) 
                { 
                __context__.SourceCodeLine = 157;
                FBTN_PRESS (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) )) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object BTN_FB_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 165;
        if ( Functions.TestForTrue  ( ( G_IENABLE)  ) ) 
            { 
            __context__.SourceCodeLine = 167;
            Functions.Delay (  (int) ( 20 ) ) ; 
            __context__.SourceCodeLine = 168;
            FBTN_FB (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 1 )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BTN_FB_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 174;
        if ( Functions.TestForTrue  ( ( G_IENABLE)  ) ) 
            { 
            __context__.SourceCodeLine = 176;
            Functions.Delay (  (int) ( 50 ) ) ; 
            __context__.SourceCodeLine = 177;
            FBTN_FB (  __context__ , (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 )) ; 
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
        
        __context__.SourceCodeLine = 184;
        G_IBUSY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 185;
        G_IENABLE = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    CHECK = new Crestron.Logos.SplusObjects.DigitalInput( CHECK__DigitalInput__, this );
    m_DigitalInputList.Add( CHECK__DigitalInput__, CHECK );
    
    BTN_PRESS = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        BTN_PRESS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( BTN_PRESS__DigitalInput__ + i, BTN_PRESS__DigitalInput__, this );
        m_DigitalInputList.Add( BTN_PRESS__DigitalInput__ + i, BTN_PRESS[i+1] );
    }
    
    BTN_FB = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        BTN_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( BTN_FB__DigitalInput__ + i, BTN_FB__DigitalInput__, this );
        m_DigitalInputList.Add( BTN_FB__DigitalInput__ + i, BTN_FB[i+1] );
    }
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    PRESS_OUT = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        PRESS_OUT[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PRESS_OUT__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PRESS_OUT__DigitalOutput__ + i, PRESS_OUT[i+1] );
    }
    
    LIST_FB = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        LIST_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( LIST_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( LIST_FB__DigitalOutput__ + i, LIST_FB[i+1] );
    }
    
    ATT_ANALOG = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ATT_ANALOG[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( ATT_ANALOG__AnalogSerialInput__ + i, ATT_ANALOG__AnalogSerialInput__, this );
        m_AnalogInputList.Add( ATT_ANALOG__AnalogSerialInput__ + i, ATT_ANALOG[i+1] );
    }
    
    LIST_NUM = new Crestron.Logos.SplusObjects.AnalogOutput( LIST_NUM__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LIST_NUM__AnalogSerialOutput__, LIST_NUM );
    
    LIST_ANALOG = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        LIST_ANALOG[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LIST_ANALOG__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LIST_ANALOG__AnalogSerialOutput__ + i, LIST_ANALOG[i+1] );
    }
    
    ORDER = new InOutArray<AnalogOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ORDER[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( ORDER__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( ORDER__AnalogSerialOutput__ + i, ORDER[i+1] );
    }
    
    FROM_MODULE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FROM_MODULE__DOLLAR____AnalogSerialInput__, 612, this );
    m_StringInputList.Add( FROM_MODULE__DOLLAR____AnalogSerialInput__, FROM_MODULE__DOLLAR__ );
    
    ATT_LABEL = new InOutArray<StringInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ATT_LABEL[i+1] = new Crestron.Logos.SplusObjects.StringInput( ATT_LABEL__AnalogSerialInput__ + i, ATT_LABEL__AnalogSerialInput__, 612, this );
        m_StringInputList.Add( ATT_LABEL__AnalogSerialInput__ + i, ATT_LABEL[i+1] );
    }
    
    MESSAGE_FB = new Crestron.Logos.SplusObjects.StringOutput( MESSAGE_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( MESSAGE_FB__AnalogSerialOutput__, MESSAGE_FB );
    
    LIST_TEXT = new InOutArray<StringOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        LIST_TEXT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LIST_TEXT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LIST_TEXT__AnalogSerialOutput__ + i, LIST_TEXT[i+1] );
    }
    
    
    FROM_MODULE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_MODULE__DOLLAR___OnChange_0, false ) );
    CHECK.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHECK_OnRelease_1, false ) );
    for( uint i = 0; i < 99; i++ )
        BTN_PRESS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( BTN_PRESS_OnPush_2, false ) );
        
    for( uint i = 0; i < 99; i++ )
        BTN_FB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( BTN_FB_OnPush_3, false ) );
        
    for( uint i = 0; i < 99; i++ )
        BTN_FB[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( BTN_FB_OnRelease_4, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_LIST_ORDER_W_PRESS_1_BUTTON__NO_PULSE_V1_3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CHECK__DigitalInput__ = 0;
const uint BTN_PRESS__DigitalInput__ = 1;
const uint BTN_FB__DigitalInput__ = 100;
const uint FROM_MODULE__DOLLAR____AnalogSerialInput__ = 0;
const uint ATT_LABEL__AnalogSerialInput__ = 1;
const uint ATT_ANALOG__AnalogSerialInput__ = 100;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint MESSAGE_FB__AnalogSerialOutput__ = 0;
const uint LIST_NUM__AnalogSerialOutput__ = 1;
const uint PRESS_OUT__DigitalOutput__ = 1;
const uint LIST_FB__DigitalOutput__ = 100;
const uint LIST_TEXT__AnalogSerialOutput__ = 2;
const uint LIST_ANALOG__AnalogSerialOutput__ = 101;
const uint ORDER__AnalogSerialOutput__ = 200;

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
