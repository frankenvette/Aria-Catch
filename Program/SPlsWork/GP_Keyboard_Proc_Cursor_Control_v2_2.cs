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

namespace UserModule_GP_KEYBOARD_PROC_CURSOR_CONTROL_V2_2
{
    public class UserModuleClass_GP_KEYBOARD_PROC_CURSOR_CONTROL_V2_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput KEYBOARDGO;
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_MASK;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR;
        Crestron.Logos.SplusObjects.DigitalInput BACK;
        Crestron.Logos.SplusObjects.DigitalInput CURSORLEFT;
        Crestron.Logos.SplusObjects.DigitalInput CURSORRIGHT;
        Crestron.Logos.SplusObjects.DigitalInput HOME;
        Crestron.Logos.SplusObjects.DigitalInput END;
        Crestron.Logos.SplusObjects.AnalogInput MAXCHARACTERS;
        Crestron.Logos.SplusObjects.AnalogInput KEYBOARDAN;
        Crestron.Logos.SplusObjects.StringInput TEXT;
        Crestron.Logos.SplusObjects.StringInput PREPEND_TEXT;
        Crestron.Logos.SplusObjects.StringInput APPEND_TEXT;
        Crestron.Logos.SplusObjects.StringInput INSERT_TEXT;
        Crestron.Logos.SplusObjects.StringOutput TEXT_CURSOR__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TEXT__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TEXT_MASKED__DOLLAR__;
        ushort G_ILENGTH = 0;
        ushort G_ICURSOR = 0;
        CrestronString G_SLEFT;
        object CURSORRIGHT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort [] IC;
                IC  = new ushort[ 2 ];
                
                
                __context__.SourceCodeLine = 56;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( G_ICURSOR > 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt (G_ICURSOR != G_ILENGTH) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 58;
                    G_SLEFT  .UpdateValue ( Functions.Remove ( (G_ICURSOR - 1), TEXT )  ) ; 
                    __context__.SourceCodeLine = 59;
                    IC [ 0] = (ushort) ( Functions.GetC( TEXT ) ) ; 
                    __context__.SourceCodeLine = 60;
                    IC [ 1] = (ushort) ( Functions.GetC( TEXT ) ) ; 
                    __context__.SourceCodeLine = 61;
                    TEXT_CURSOR__DOLLAR__  .UpdateValue ( G_SLEFT + Functions.Chr (  (int) ( IC[ 1 ] ) ) + Functions.Chr (  (int) ( IC[ 0 ] ) ) + TEXT  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 63;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_ICURSOR == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TEXT ) > 1 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 65;
                        IC [ 0] = (ushort) ( Functions.GetC( TEXT ) ) ; 
                        __context__.SourceCodeLine = 66;
                        IC [ 1] = (ushort) ( Functions.GetC( TEXT ) ) ; 
                        __context__.SourceCodeLine = 67;
                        TEXT_CURSOR__DOLLAR__  .UpdateValue ( Functions.Chr (  (int) ( IC[ 1 ] ) ) + Functions.Chr (  (int) ( IC[ 0 ] ) ) + TEXT  ) ; 
                        } 
                    
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CURSORLEFT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort [] IC;
            IC  = new ushort[ 2 ];
            
            
            __context__.SourceCodeLine = 74;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_ICURSOR > 2 ))  ) ) 
                { 
                __context__.SourceCodeLine = 76;
                G_SLEFT  .UpdateValue ( Functions.Remove ( (G_ICURSOR - 2), TEXT )  ) ; 
                __context__.SourceCodeLine = 77;
                IC [ 0] = (ushort) ( Functions.GetC( TEXT ) ) ; 
                __context__.SourceCodeLine = 78;
                IC [ 1] = (ushort) ( Functions.GetC( TEXT ) ) ; 
                __context__.SourceCodeLine = 79;
                TEXT_CURSOR__DOLLAR__  .UpdateValue ( G_SLEFT + Functions.Chr (  (int) ( IC[ 1 ] ) ) + Functions.Chr (  (int) ( IC[ 0 ] ) ) + TEXT  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 81;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_ICURSOR > 1 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 83;
                    IC [ 0] = (ushort) ( Functions.GetC( TEXT ) ) ; 
                    __context__.SourceCodeLine = 84;
                    IC [ 1] = (ushort) ( Functions.GetC( TEXT ) ) ; 
                    __context__.SourceCodeLine = 85;
                    TEXT_CURSOR__DOLLAR__  .UpdateValue ( Functions.Chr (  (int) ( IC[ 1 ] ) ) + Functions.Chr (  (int) ( IC[ 0 ] ) ) + TEXT  ) ; 
                    } 
                
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object KEYBOARDGO_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 91;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_ILENGTH < MAXCHARACTERS  .UshortValue ))  ) ) 
            { 
            __context__.SourceCodeLine = 93;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_ICURSOR == G_ILENGTH))  ) ) 
                { 
                __context__.SourceCodeLine = 95;
                TEXT_CURSOR__DOLLAR__  .UpdateValue ( Functions.Left ( TEXT ,  (int) ( (G_ILENGTH - 1) ) ) + Functions.Chr (  (int) ( KEYBOARDAN  .UshortValue ) ) + "|"  ) ; 
                __context__.SourceCodeLine = 96;
                TEXT__DOLLAR__  .UpdateValue ( Functions.Left ( TEXT ,  (int) ( (G_ILENGTH - 1) ) ) + Functions.Chr (  (int) ( KEYBOARDAN  .UshortValue ) )  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 98;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_ICURSOR == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 100;
                    TEXT_CURSOR__DOLLAR__  .UpdateValue ( Functions.Chr (  (int) ( KEYBOARDAN  .UshortValue ) ) + TEXT  ) ; 
                    __context__.SourceCodeLine = 101;
                    TEXT__DOLLAR__  .UpdateValue ( Functions.Chr (  (int) ( KEYBOARDAN  .UshortValue ) ) + Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - 1) ) )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 105;
                    G_SLEFT  .UpdateValue ( Functions.Remove ( (G_ICURSOR - 1), TEXT )  ) ; 
                    __context__.SourceCodeLine = 106;
                    TEXT_CURSOR__DOLLAR__  .UpdateValue ( G_SLEFT + Functions.Chr (  (int) ( KEYBOARDAN  .UshortValue ) ) + TEXT  ) ; 
                    __context__.SourceCodeLine = 107;
                    TEXT__DOLLAR__  .UpdateValue ( G_SLEFT + Functions.Chr (  (int) ( KEYBOARDAN  .UshortValue ) ) + Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - 1) ) )  ) ; 
                    } 
                
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOME_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IC = 0;
        
        
        __context__.SourceCodeLine = 115;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_ICURSOR > 1 ))  ) ) 
            { 
            __context__.SourceCodeLine = 117;
            G_SLEFT  .UpdateValue ( Functions.Remove ( (G_ICURSOR - 1), TEXT )  ) ; 
            __context__.SourceCodeLine = 118;
            IC = (ushort) ( Functions.GetC( TEXT ) ) ; 
            __context__.SourceCodeLine = 119;
            TEXT_CURSOR__DOLLAR__  .UpdateValue ( "|" + G_SLEFT + TEXT  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object END_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IC = 0;
        
        
        __context__.SourceCodeLine = 126;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( G_ICURSOR > 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt (G_ICURSOR != G_ILENGTH) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 128;
            G_SLEFT  .UpdateValue ( Functions.Remove ( (G_ICURSOR - 1), TEXT )  ) ; 
            __context__.SourceCodeLine = 129;
            IC = (ushort) ( Functions.GetC( TEXT ) ) ; 
            __context__.SourceCodeLine = 130;
            TEXT_CURSOR__DOLLAR__  .UpdateValue ( G_SLEFT + TEXT + "|"  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 132;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_ICURSOR == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 134;
                IC = (ushort) ( Functions.GetC( TEXT ) ) ; 
                __context__.SourceCodeLine = 135;
                TEXT_CURSOR__DOLLAR__  .UpdateValue ( TEXT + "|"  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLEAR_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 140;
        TEXT_CURSOR__DOLLAR__  .UpdateValue ( "|"  ) ; 
        __context__.SourceCodeLine = 141;
        TEXT__DOLLAR__  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACK_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 146;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_ICURSOR > 2 ))  ) ) 
            { 
            __context__.SourceCodeLine = 148;
            G_SLEFT  .UpdateValue ( Functions.Remove ( (G_ICURSOR - 2), TEXT )  ) ; 
            __context__.SourceCodeLine = 149;
            TEXT_CURSOR__DOLLAR__  .UpdateValue ( G_SLEFT + Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 150;
            TEXT__DOLLAR__  .UpdateValue ( G_SLEFT + Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - 2) ) )  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 152;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_ICURSOR == 2))  ) ) 
                { 
                __context__.SourceCodeLine = 154;
                TEXT_CURSOR__DOLLAR__  .UpdateValue ( Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 155;
                TEXT__DOLLAR__  .UpdateValue ( Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - 2) ) )  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TEXT_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        CrestronString SMASK;
        SMASK  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 240, this );
        
        
        __context__.SourceCodeLine = 163;
        G_ICURSOR = (ushort) ( Functions.Find( "|" , TEXT ) ) ; 
        __context__.SourceCodeLine = 164;
        G_ILENGTH = (ushort) ( Functions.Length( TEXT ) ) ; 
        __context__.SourceCodeLine = 165;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_ICURSOR == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 167;
            TEXT_CURSOR__DOLLAR__  .UpdateValue ( TEXT + "|"  ) ; 
            } 
        
        __context__.SourceCodeLine = 169;
        if ( Functions.TestForTrue  ( ( ENABLE_MASK  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 171;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( TEXT ) > 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 173;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(Functions.Length( TEXT ) - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 175;
                    SMASK  .UpdateValue ( SMASK + "*"  ) ; 
                    __context__.SourceCodeLine = 173;
                    } 
                
                __context__.SourceCodeLine = 177;
                TEXT_MASKED__DOLLAR__  .UpdateValue ( SMASK  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 181;
                TEXT_MASKED__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PREPEND_TEXT_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 187;
        TEXT_CURSOR__DOLLAR__  .UpdateValue ( PREPEND_TEXT + TEXT  ) ; 
        __context__.SourceCodeLine = 188;
        TEXT__DOLLAR__  .UpdateValue ( PREPEND_TEXT + Functions.Left ( TEXT ,  (int) ( (Functions.Find( "|" , TEXT ) - 1) ) ) + Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - Functions.Find( "|" , TEXT )) ) )  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object APPEND_TEXT_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 192;
        TEXT_CURSOR__DOLLAR__  .UpdateValue ( TEXT + APPEND_TEXT  ) ; 
        __context__.SourceCodeLine = 193;
        TEXT__DOLLAR__  .UpdateValue ( Functions.Left ( TEXT ,  (int) ( (Functions.Find( "|" , TEXT ) - 1) ) ) + Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - Functions.Find( "|" , TEXT )) ) ) + APPEND_TEXT  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INSERT_TEXT_OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 197;
        if ( Functions.TestForTrue  ( ( G_ICURSOR)  ) ) 
            { 
            __context__.SourceCodeLine = 199;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_ICURSOR == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 201;
                TEXT_CURSOR__DOLLAR__  .UpdateValue ( INSERT_TEXT + TEXT  ) ; 
                __context__.SourceCodeLine = 202;
                TEXT__DOLLAR__  .UpdateValue ( INSERT_TEXT  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 212;
                G_SLEFT  .UpdateValue ( Functions.Remove ( (G_ICURSOR - 1), TEXT )  ) ; 
                __context__.SourceCodeLine = 213;
                TEXT_CURSOR__DOLLAR__  .UpdateValue ( G_SLEFT + INSERT_TEXT + TEXT  ) ; 
                __context__.SourceCodeLine = 214;
                TEXT__DOLLAR__  .UpdateValue ( G_SLEFT + INSERT_TEXT + Functions.Right ( TEXT ,  (int) ( (Functions.Length( TEXT ) - 1) ) )  ) ; 
                } 
            
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
        
        __context__.SourceCodeLine = 221;
        TEXT_CURSOR__DOLLAR__  .UpdateValue ( "|"  ) ; 
        __context__.SourceCodeLine = 222;
        TEXT__DOLLAR__  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SLEFT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 240, this );
    
    KEYBOARDGO = new Crestron.Logos.SplusObjects.DigitalInput( KEYBOARDGO__DigitalInput__, this );
    m_DigitalInputList.Add( KEYBOARDGO__DigitalInput__, KEYBOARDGO );
    
    ENABLE_MASK = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_MASK__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE_MASK__DigitalInput__, ENABLE_MASK );
    
    CLEAR = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR__DigitalInput__, CLEAR );
    
    BACK = new Crestron.Logos.SplusObjects.DigitalInput( BACK__DigitalInput__, this );
    m_DigitalInputList.Add( BACK__DigitalInput__, BACK );
    
    CURSORLEFT = new Crestron.Logos.SplusObjects.DigitalInput( CURSORLEFT__DigitalInput__, this );
    m_DigitalInputList.Add( CURSORLEFT__DigitalInput__, CURSORLEFT );
    
    CURSORRIGHT = new Crestron.Logos.SplusObjects.DigitalInput( CURSORRIGHT__DigitalInput__, this );
    m_DigitalInputList.Add( CURSORRIGHT__DigitalInput__, CURSORRIGHT );
    
    HOME = new Crestron.Logos.SplusObjects.DigitalInput( HOME__DigitalInput__, this );
    m_DigitalInputList.Add( HOME__DigitalInput__, HOME );
    
    END = new Crestron.Logos.SplusObjects.DigitalInput( END__DigitalInput__, this );
    m_DigitalInputList.Add( END__DigitalInput__, END );
    
    MAXCHARACTERS = new Crestron.Logos.SplusObjects.AnalogInput( MAXCHARACTERS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MAXCHARACTERS__AnalogSerialInput__, MAXCHARACTERS );
    
    KEYBOARDAN = new Crestron.Logos.SplusObjects.AnalogInput( KEYBOARDAN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( KEYBOARDAN__AnalogSerialInput__, KEYBOARDAN );
    
    TEXT = new Crestron.Logos.SplusObjects.StringInput( TEXT__AnalogSerialInput__, 240, this );
    m_StringInputList.Add( TEXT__AnalogSerialInput__, TEXT );
    
    PREPEND_TEXT = new Crestron.Logos.SplusObjects.StringInput( PREPEND_TEXT__AnalogSerialInput__, 240, this );
    m_StringInputList.Add( PREPEND_TEXT__AnalogSerialInput__, PREPEND_TEXT );
    
    APPEND_TEXT = new Crestron.Logos.SplusObjects.StringInput( APPEND_TEXT__AnalogSerialInput__, 240, this );
    m_StringInputList.Add( APPEND_TEXT__AnalogSerialInput__, APPEND_TEXT );
    
    INSERT_TEXT = new Crestron.Logos.SplusObjects.StringInput( INSERT_TEXT__AnalogSerialInput__, 240, this );
    m_StringInputList.Add( INSERT_TEXT__AnalogSerialInput__, INSERT_TEXT );
    
    TEXT_CURSOR__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TEXT_CURSOR__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TEXT_CURSOR__DOLLAR____AnalogSerialOutput__, TEXT_CURSOR__DOLLAR__ );
    
    TEXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TEXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TEXT__DOLLAR____AnalogSerialOutput__, TEXT__DOLLAR__ );
    
    TEXT_MASKED__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TEXT_MASKED__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TEXT_MASKED__DOLLAR____AnalogSerialOutput__, TEXT_MASKED__DOLLAR__ );
    
    
    CURSORRIGHT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CURSORRIGHT_OnPush_0, false ) );
    CURSORLEFT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CURSORLEFT_OnPush_1, false ) );
    KEYBOARDGO.OnDigitalPush.Add( new InputChangeHandlerWrapper( KEYBOARDGO_OnPush_2, false ) );
    HOME.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOME_OnPush_3, false ) );
    END.OnDigitalPush.Add( new InputChangeHandlerWrapper( END_OnPush_4, false ) );
    CLEAR.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_OnPush_5, false ) );
    BACK.OnDigitalPush.Add( new InputChangeHandlerWrapper( BACK_OnPush_6, false ) );
    TEXT.OnSerialChange.Add( new InputChangeHandlerWrapper( TEXT_OnChange_7, false ) );
    PREPEND_TEXT.OnSerialChange.Add( new InputChangeHandlerWrapper( PREPEND_TEXT_OnChange_8, false ) );
    APPEND_TEXT.OnSerialChange.Add( new InputChangeHandlerWrapper( APPEND_TEXT_OnChange_9, false ) );
    INSERT_TEXT.OnSerialChange.Add( new InputChangeHandlerWrapper( INSERT_TEXT_OnChange_10, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_KEYBOARD_PROC_CURSOR_CONTROL_V2_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint KEYBOARDGO__DigitalInput__ = 0;
const uint ENABLE_MASK__DigitalInput__ = 1;
const uint CLEAR__DigitalInput__ = 2;
const uint BACK__DigitalInput__ = 3;
const uint CURSORLEFT__DigitalInput__ = 4;
const uint CURSORRIGHT__DigitalInput__ = 5;
const uint HOME__DigitalInput__ = 6;
const uint END__DigitalInput__ = 7;
const uint MAXCHARACTERS__AnalogSerialInput__ = 0;
const uint KEYBOARDAN__AnalogSerialInput__ = 1;
const uint TEXT__AnalogSerialInput__ = 2;
const uint PREPEND_TEXT__AnalogSerialInput__ = 3;
const uint APPEND_TEXT__AnalogSerialInput__ = 4;
const uint INSERT_TEXT__AnalogSerialInput__ = 5;
const uint TEXT_CURSOR__DOLLAR____AnalogSerialOutput__ = 0;
const uint TEXT__DOLLAR____AnalogSerialOutput__ = 1;
const uint TEXT_MASKED__DOLLAR____AnalogSerialOutput__ = 2;

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
