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

namespace UserModule_CF__ITOA
{
    public class UserModuleClass_CF__ITOA : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> I;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> A;
        object I_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort J = 0;
                
                
                __context__.SourceCodeLine = 39;
                J = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 41;
                MakeString ( A [ J] , "{0}", Functions.Left ( Functions.ItoA (  (int) ( I[ J ] .UshortValue ) ) ,  (int) ( 3 ) ) ) ; 
                
                
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
        
        I = new InOutArray<AnalogInput>( 20, this );
        for( uint i = 0; i < 20; i++ )
        {
            I[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( I__AnalogSerialInput__ + i, I__AnalogSerialInput__, this );
            m_AnalogInputList.Add( I__AnalogSerialInput__ + i, I[i+1] );
        }
        
        A = new InOutArray<StringOutput>( 20, this );
        for( uint i = 0; i < 20; i++ )
        {
            A[i+1] = new Crestron.Logos.SplusObjects.StringOutput( A__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( A__AnalogSerialOutput__ + i, A[i+1] );
        }
        
        
        for( uint i = 0; i < 20; i++ )
            I[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( I_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_CF__ITOA ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint I__AnalogSerialInput__ = 0;
    const uint A__AnalogSerialOutput__ = 0;
    
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
