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

namespace UserModule_GP_BSS_NODE_PROCESSOR_R0_2
{
    public class UserModuleClass_GP_BSS_NODE_PROCESSOR_R0_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput NODE_ID;
        Crestron.Logos.SplusObjects.BufferInput MODULESTX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NODE_ID_FB;
        Crestron.Logos.SplusObjects.StringOutput MODULESRX__DOLLAR__;
        ushort XOK1 = 0;
        CrestronString TEMPSTRING1;
        ushort CHECKSUM = 0;
        ushort I = 0;
        CrestronString SENDSTRING;
        ushort XOK2 = 0;
        CrestronString TEMPSTRING2;
        CrestronString TEMPSTRING3;
        ushort J = 0;
        CrestronString RECEIVESTRING;
        ushort MARKER1 = 0;
        ushort MARKER2 = 0;
        CrestronString G_SNODE_ID;
        StringParameter DEFAULT_NODE_ID;
        private void SEND (  SplusExecutionContext __context__, CrestronString STR1 ) 
            { 
            ushort ILOGIC = 0;
            
            
            __context__.SourceCodeLine = 81;
            CHECKSUM = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 82;
            SENDSTRING  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 85;
            ILOGIC = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 86;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( STR1 , (int)( 1 ) ) == 255))  ) ) 
                { 
                __context__.SourceCodeLine = 88;
                ILOGIC = (ushort) ( Functions.GetC( STR1 ) ) ; 
                } 
            
            __context__.SourceCodeLine = 91;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( STR1 ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 93;
                CHECKSUM = (ushort) ( (CHECKSUM ^ Byte( STR1 , (int)( I ) )) ) ; 
                __context__.SourceCodeLine = 94;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( STR1 , (int)( I ) ) == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( STR1 , (int)( I ) ) == 3) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( STR1 , (int)( I ) ) == 6) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( STR1 , (int)( I ) ) == 21) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( STR1 , (int)( I ) ) == 27) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 96;
                    MakeString ( SENDSTRING , "{0}\u001B{1}", SENDSTRING , Functions.Chr (  (int) ( (Byte( STR1 , (int)( I ) ) + 128) ) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 100;
                    MakeString ( SENDSTRING , "{0}{1}", SENDSTRING , Functions.Chr (  (int) ( Byte( STR1 , (int)( I ) ) ) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 91;
                } 
            
            __context__.SourceCodeLine = 103;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (CHECKSUM == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (CHECKSUM == 3) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (CHECKSUM == 6) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (CHECKSUM == 21) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (CHECKSUM == 27) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 105;
                MakeString ( TX__DOLLAR__ , "\u0002{0}\u001B{1}\u0003", SENDSTRING , Functions.Chr (  (int) ( (CHECKSUM + 128) ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 109;
                MakeString ( TX__DOLLAR__ , "\u0002{0}{1}\u0003", SENDSTRING , Functions.Chr (  (int) ( CHECKSUM ) ) ) ; 
                } 
            
            
            }
            
        private CrestronString RECEIVE (  SplusExecutionContext __context__, CrestronString STR2 ) 
            { 
            
            __context__.SourceCodeLine = 116;
            RECEIVESTRING  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 117;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( STR2 ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 119;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( STR2 , (int)( J ) ) == 27))  ) ) 
                    { 
                    __context__.SourceCodeLine = 121;
                    RECEIVESTRING  .UpdateValue ( RECEIVESTRING + Functions.Chr (  (int) ( (Byte( STR2 , (int)( (J + 1) ) ) - 128) ) )  ) ; 
                    __context__.SourceCodeLine = 122;
                    J = (ushort) ( (J + 1) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 126;
                    RECEIVESTRING  .UpdateValue ( RECEIVESTRING + Functions.Chr (  (int) ( Byte( STR2 , (int)( J ) ) ) )  ) ; 
                    } 
                
                __context__.SourceCodeLine = 117;
                } 
            
            __context__.SourceCodeLine = 129;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( RECEIVESTRING , (int)( 1 ) ) == 6))  ) ) 
                { 
                __context__.SourceCodeLine = 131;
                RECEIVESTRING  .UpdateValue ( Functions.Right ( RECEIVESTRING ,  (int) ( (Functions.Length( RECEIVESTRING ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 129;
                } 
            
            __context__.SourceCodeLine = 133;
            return ( RECEIVESTRING ) ; 
            
            }
            
        object MODULESTX__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 139;
                if ( Functions.TestForTrue  ( ( XOK1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 141;
                    XOK1 = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 142;
                    while ( Functions.TestForTrue  ( ( Functions.Length( MODULESTX__DOLLAR__ ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 144;
                        MARKER1 = (ushort) ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , MODULESTX__DOLLAR__ ) ) ; 
                        __context__.SourceCodeLine = 145;
                        MARKER2 = (ushort) ( (MARKER1 + 5) ) ; 
                        __context__.SourceCodeLine = 146;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MARKER2 <= Functions.Length( MODULESTX__DOLLAR__ ) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 148;
                            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( MODULESTX__DOLLAR__ , (int)( MARKER2 ) ) == 3))  ) ) 
                                { 
                                __context__.SourceCodeLine = 150;
                                MARKER1 = (ushort) ( (MARKER1 + 1) ) ; 
                                __context__.SourceCodeLine = 151;
                                MARKER2 = (ushort) ( (MARKER2 + 1) ) ; 
                                __context__.SourceCodeLine = 152;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MARKER2 > Functions.Length( MODULESTX__DOLLAR__ ) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 154;
                                    break ; 
                                    } 
                                
                                __context__.SourceCodeLine = 148;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 158;
                        if ( Functions.TestForTrue  ( ( MARKER1)  ) ) 
                            { 
                            __context__.SourceCodeLine = 160;
                            MARKER1 = (ushort) ( (MARKER1 + 4) ) ; 
                            __context__.SourceCodeLine = 161;
                            TEMPSTRING1  .UpdateValue ( Functions.Remove ( Functions.Mid ( MODULESTX__DOLLAR__ ,  (int) ( 1 ) ,  (int) ( MARKER1 ) ) , MODULESTX__DOLLAR__ )  ) ; 
                            __context__.SourceCodeLine = 162;
                            MakeString ( TEMPSTRING1 , "{0}{1}{2}", Functions.Left ( TEMPSTRING1 ,  (int) ( 1 ) ) , G_SNODE_ID , Functions.Right ( TEMPSTRING1 ,  (int) ( (Functions.Length( TEMPSTRING1 ) - 3) ) ) ) ; 
                            __context__.SourceCodeLine = 163;
                            SEND (  __context__ , Functions.Left( TEMPSTRING1 , (int)( (Functions.Length( TEMPSTRING1 ) - 5) ) )) ; 
                            __context__.SourceCodeLine = 164;
                            Functions.ClearBuffer ( TEMPSTRING1 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 142;
                        } 
                    
                    __context__.SourceCodeLine = 167;
                    XOK1 = (ushort) ( 1 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object RX__DOLLAR___OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 175;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 177;
                TEMPSTRING2  .UpdateValue ( Functions.Gather ( "\u0003" , RX__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 179;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPSTRING2 , (int)( 1 ) ) == 6))  ) ) 
                    { 
                    __context__.SourceCodeLine = 181;
                    TEMPSTRING2  .UpdateValue ( Functions.Right ( TEMPSTRING2 ,  (int) ( (Functions.Length( TEMPSTRING2 ) - 1) ) )  ) ; 
                    } 
                
                __context__.SourceCodeLine = 184;
                TEMPSTRING3  .UpdateValue ( RECEIVE (  __context__ , TEMPSTRING2)  ) ; 
                __context__.SourceCodeLine = 186;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TEMPSTRING3 ) >= 4 ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPSTRING3 , (int)( 3 ) ) == Byte( G_SNODE_ID , (int)( 1 ) )) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPSTRING3 , (int)( 4 ) ) == Byte( G_SNODE_ID , (int)( 2 ) )) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 188;
                    MODULESRX__DOLLAR__  .UpdateValue ( TEMPSTRING3 + "\u0003\u0003\u0003\u0003"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 191;
                Functions.ClearBuffer ( TEMPSTRING2 ) ; 
                __context__.SourceCodeLine = 192;
                Functions.ClearBuffer ( TEMPSTRING3 ) ; 
                __context__.SourceCodeLine = 175;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object NODE_ID_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 197;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( NODE_ID ) == 2))  ) ) 
            { 
            __context__.SourceCodeLine = 199;
            G_SNODE_ID  .UpdateValue ( NODE_ID  ) ; 
            __context__.SourceCodeLine = 200;
            NODE_ID_FB  .UpdateValue ( G_SNODE_ID  ) ; 
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
        
        __context__.SourceCodeLine = 207;
        G_SNODE_ID  .UpdateValue ( DEFAULT_NODE_ID  ) ; 
        __context__.SourceCodeLine = 208;
        NODE_ID_FB  .UpdateValue ( G_SNODE_ID  ) ; 
        __context__.SourceCodeLine = 210;
        XOK1 = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 211;
        XOK2 = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    TEMPSTRING1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 80, this );
    SENDSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 80, this );
    TEMPSTRING2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 80, this );
    TEMPSTRING3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 80, this );
    RECEIVESTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 80, this );
    G_SNODE_ID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    
    NODE_ID = new Crestron.Logos.SplusObjects.StringInput( NODE_ID__AnalogSerialInput__, 2, this );
    m_StringInputList.Add( NODE_ID__AnalogSerialInput__, NODE_ID );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    NODE_ID_FB = new Crestron.Logos.SplusObjects.StringOutput( NODE_ID_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( NODE_ID_FB__AnalogSerialOutput__, NODE_ID_FB );
    
    MODULESRX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( MODULESRX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( MODULESRX__DOLLAR____AnalogSerialOutput__, MODULESRX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 2048, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    MODULESTX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( MODULESTX__DOLLAR____AnalogSerialInput__, 2048, this );
    m_StringInputList.Add( MODULESTX__DOLLAR____AnalogSerialInput__, MODULESTX__DOLLAR__ );
    
    DEFAULT_NODE_ID = new StringParameter( DEFAULT_NODE_ID__Parameter__, this );
    m_ParameterList.Add( DEFAULT_NODE_ID__Parameter__, DEFAULT_NODE_ID );
    
    
    MODULESTX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( MODULESTX__DOLLAR___OnChange_0, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_1, true ) );
    NODE_ID.OnSerialChange.Add( new InputChangeHandlerWrapper( NODE_ID_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_BSS_NODE_PROCESSOR_R0_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint NODE_ID__AnalogSerialInput__ = 1;
const uint MODULESTX__DOLLAR____AnalogSerialInput__ = 2;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint NODE_ID_FB__AnalogSerialOutput__ = 1;
const uint MODULESRX__DOLLAR____AnalogSerialOutput__ = 2;
const uint DEFAULT_NODE_ID__Parameter__ = 10;

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
