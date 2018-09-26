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

namespace UserModule_GP_BSS_MODULE_ROUTER_R0_3
{
    public class UserModuleClass_GP_BSS_MODULE_ROUTER_R0_3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> MODULE_ID;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MODULE;
        StringParameter DUMMY;
        InOutArray<StringParameter> DEFAULT_MODULE_ID;
        ushort G_INUMMODULES = 0;
        CrestronString [] G_SSRCHSTRING;
        CrestronString G_SREPLY;
        private void FBUILDSEARCHSTRINGS (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 86;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_INUMMODULES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 88;
                G_SSRCHSTRING [ I ]  .UpdateValue ( DEFAULT_MODULE_ID [ I ]  ) ; 
                __context__.SourceCodeLine = 86;
                } 
            
            
            }
            
        object RX__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString SRXMODULE;
                SRXMODULE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
                
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 97;
                while ( Functions.TestForTrue  ( ( 1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 99;
                    G_SREPLY  .UpdateValue ( Functions.Gather ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 101;
                    if ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 103;
                        while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 1 ) ) == 3))  ) ) 
                            { 
                            __context__.SourceCodeLine = 105;
                            G_SREPLY  .UpdateValue ( G_SREPLY + Functions.Remove ( 1, RX__DOLLAR__ )  ) ; 
                            __context__.SourceCodeLine = 103;
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 109;
                    SRXMODULE  .UpdateValue ( Functions.Mid ( G_SREPLY ,  (int) ( 6 ) ,  (int) ( 3 ) )  ) ; 
                    __context__.SourceCodeLine = 111;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)G_INUMMODULES; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 113;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SRXMODULE == G_SSRCHSTRING[ I ]))  ) ) 
                            { 
                            __context__.SourceCodeLine = 115;
                            MODULE [ I]  .UpdateValue ( G_SREPLY  ) ; 
                            __context__.SourceCodeLine = 116;
                            break ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 118;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SRXMODULE == "\u0000\u0000\u0000"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 120;
                                MODULE [ I]  .UpdateValue ( G_SREPLY  ) ; 
                                } 
                            
                            }
                        
                        __context__.SourceCodeLine = 111;
                        } 
                    
                    __context__.SourceCodeLine = 97;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object MODULE_ID_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 130;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 132;
            if ( Functions.TestForTrue  ( ( Functions.Length( MODULE_ID[ I ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 134;
                G_SSRCHSTRING [ I ]  .UpdateValue ( MODULE_ID [ I ]  ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 143;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 128 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( G_INUMMODULES  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (G_INUMMODULES  >= __FN_FORSTART_VAL__1) && (G_INUMMODULES  <= __FN_FOREND_VAL__1) ) : ( (G_INUMMODULES  <= __FN_FORSTART_VAL__1) && (G_INUMMODULES  >= __FN_FOREND_VAL__1) ) ; G_INUMMODULES  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 145;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( MODULE[ G_INUMMODULES ] ))  ) ) 
                {
                __context__.SourceCodeLine = 146;
                break ; 
                }
            
            __context__.SourceCodeLine = 143;
            } 
        
        __context__.SourceCodeLine = 148;
        FBUILDSEARCHSTRINGS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SREPLY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    G_SSRCHSTRING  = new CrestronString[ 129 ];
    for( uint i = 0; i < 129; i++ )
        G_SSRCHSTRING [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    
    MODULE_ID = new InOutArray<StringInput>( 128, this );
    for( uint i = 0; i < 128; i++ )
    {
        MODULE_ID[i+1] = new Crestron.Logos.SplusObjects.StringInput( MODULE_ID__AnalogSerialInput__ + i, MODULE_ID__AnalogSerialInput__, 4, this );
        m_StringInputList.Add( MODULE_ID__AnalogSerialInput__ + i, MODULE_ID[i+1] );
    }
    
    MODULE = new InOutArray<StringOutput>( 128, this );
    for( uint i = 0; i < 128; i++ )
    {
        MODULE[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MODULE__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MODULE__AnalogSerialOutput__ + i, MODULE[i+1] );
    }
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 1024, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    DUMMY = new StringParameter( DUMMY__Parameter__, this );
    m_ParameterList.Add( DUMMY__Parameter__, DUMMY );
    
    DEFAULT_MODULE_ID = new InOutArray<StringParameter>( 128, this );
    for( uint i = 0; i < 128; i++ )
    {
        DEFAULT_MODULE_ID[i+1] = new StringParameter( DEFAULT_MODULE_ID__Parameter__ + i, DEFAULT_MODULE_ID__Parameter__, this );
        m_ParameterList.Add( DEFAULT_MODULE_ID__Parameter__ + i, DEFAULT_MODULE_ID[i+1] );
    }
    
    
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_0, true ) );
    for( uint i = 0; i < 128; i++ )
        MODULE_ID[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( MODULE_ID_OnChange_1, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_BSS_MODULE_ROUTER_R0_3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint MODULE_ID__AnalogSerialInput__ = 1;
const uint MODULE__AnalogSerialOutput__ = 0;
const uint DUMMY__Parameter__ = 10;
const uint DEFAULT_MODULE_ID__Parameter__ = 11;

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
