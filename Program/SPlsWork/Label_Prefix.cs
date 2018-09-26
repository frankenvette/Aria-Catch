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

namespace UserModule_LABEL_PREFIX
{
    public class UserModuleClass_LABEL_PREFIX : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.StringInput> LABEL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LABEL_FB;
        InOutArray<StringParameter> PREFIX;
        object LABEL_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 64;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 66;
                MakeString ( LABEL_FB [ I] , "{0}{1}", PREFIX [ I ] , LABEL [ I ] ) ; 
                
                
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
        
        LABEL = new InOutArray<StringInput>( 253, this );
        for( uint i = 0; i < 253; i++ )
        {
            LABEL[i+1] = new Crestron.Logos.SplusObjects.StringInput( LABEL__AnalogSerialInput__ + i, LABEL__AnalogSerialInput__, 64, this );
            m_StringInputList.Add( LABEL__AnalogSerialInput__ + i, LABEL[i+1] );
        }
        
        LABEL_FB = new InOutArray<StringOutput>( 253, this );
        for( uint i = 0; i < 253; i++ )
        {
            LABEL_FB[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LABEL_FB__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( LABEL_FB__AnalogSerialOutput__ + i, LABEL_FB[i+1] );
        }
        
        PREFIX = new InOutArray<StringParameter>( 253, this );
        for( uint i = 0; i < 253; i++ )
        {
            PREFIX[i+1] = new StringParameter( PREFIX__Parameter__ + i, PREFIX__Parameter__, this );
            m_ParameterList.Add( PREFIX__Parameter__ + i, PREFIX[i+1] );
        }
        
        
        for( uint i = 0; i < 253; i++ )
            LABEL[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( LABEL_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_LABEL_PREFIX ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint LABEL__AnalogSerialInput__ = 0;
    const uint LABEL_FB__AnalogSerialOutput__ = 0;
    const uint PREFIX__Parameter__ = 10;
    
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
