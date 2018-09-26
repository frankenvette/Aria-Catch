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

namespace UserModule_GP_TEXT_LIST_V0_4
{
    public class UserModuleClass_GP_TEXT_LIST_V0_4 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE_FILE;
        Crestron.Logos.SplusObjects.DigitalInput READ;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_SAVE;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_INDEX;
        Crestron.Logos.SplusObjects.StringInput EDIT_TEXT;
        Crestron.Logos.SplusObjects.StringInput PATHFILE;
        Crestron.Logos.SplusObjects.DigitalOutput FILE_BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput FILE_TIME_STAMP_FB;
        Crestron.Logos.SplusObjects.AnalogOutput LIST_SIZE_CURRENT_FB;
        Crestron.Logos.SplusObjects.AnalogOutput LIST_SIZE_LIMIT_FB;
        Crestron.Logos.SplusObjects.StringOutput EDIT_SELECTED_TEXT_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TEXT_FB;
        StringParameter DEFAULT_PATHFILE;
        InOutArray<StringParameter> UNUSED;
        InOutArray<StringParameter> INITIALIZE_TEXT;
        ushort G_INUM_TEXT_SIGNALS_DEFINED = 0;
        CrestronString [] G_STEXT;
        CrestronString G_SFILECONTENTS;
        CrestronString G_SPATHFILEEXT;
        short G_SIFIND = 0;
        short G_SIHANDLE = 0;
        int G_SLIBYTES = 0;
        FILE_INFO G_FILEINFO;
        private void FEXPORT (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            ushort X = 0;
            
            
            __context__.SourceCodeLine = 97;
            I = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 99;
            while ( Functions.TestForTrue  ( ( Functions.Find( "\u001F" , G_SFILECONTENTS ))  ) ) 
                { 
                __context__.SourceCodeLine = 101;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I < G_INUM_TEXT_SIGNALS_DEFINED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 103;
                    I = (ushort) ( (I + 1) ) ; 
                    __context__.SourceCodeLine = 104;
                    G_STEXT [ I ]  .UpdateValue ( Functions.Remove ( "\u001F" , G_SFILECONTENTS )  ) ; 
                    __context__.SourceCodeLine = 105;
                    G_STEXT [ I ]  .UpdateValue ( Functions.Left ( G_STEXT [ I ] ,  (int) ( (Functions.Length( G_STEXT[ I ] ) - 1) ) )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 109;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 99;
                } 
            
            __context__.SourceCodeLine = 112;
            LIST_SIZE_CURRENT_FB  .Value = (ushort) ( I ) ; 
            __context__.SourceCodeLine = 114;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 116;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)I; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 118;
                TEXT_FB [ X]  .UpdateValue ( G_STEXT [ X ]  ) ; 
                __context__.SourceCodeLine = 116;
                } 
            
            __context__.SourceCodeLine = 121;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( (I + 1) ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)G_INUM_TEXT_SIGNALS_DEFINED; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( X  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (X  >= __FN_FORSTART_VAL__2) && (X  <= __FN_FOREND_VAL__2) ) : ( (X  <= __FN_FORSTART_VAL__2) && (X  >= __FN_FOREND_VAL__2) ) ; X  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 123;
                G_STEXT [ X ]  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 124;
                TEXT_FB [ X]  .UpdateValue ( G_STEXT [ X ]  ) ; 
                __context__.SourceCodeLine = 121;
                } 
            
            __context__.SourceCodeLine = 127;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_INDEX  .UshortValue <= G_INUM_TEXT_SIGNALS_DEFINED ))  ) ) 
                { 
                __context__.SourceCodeLine = 129;
                if ( Functions.TestForTrue  ( ( EDIT_INDEX  .UshortValue)  ) ) 
                    {
                    __context__.SourceCodeLine = 130;
                    EDIT_SELECTED_TEXT_FB  .UpdateValue ( G_STEXT [ EDIT_INDEX  .UshortValue ]  ) ; 
                    }
                
                } 
            
            
            }
            
        private void FCREATEFILE (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 138;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_INUM_TEXT_SIGNALS_DEFINED; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 140;
                if ( Functions.TestForTrue  ( ( Functions.Length( INITIALIZE_TEXT[ I ] ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 142;
                    G_SFILECONTENTS  .UpdateValue ( G_SFILECONTENTS + INITIALIZE_TEXT [ I ] + "\u001F"  ) ; 
                    } 
                
                __context__.SourceCodeLine = 138;
                } 
            
            __context__.SourceCodeLine = 146;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 148;
            G_SIHANDLE = (short) ( FileOpen( G_SPATHFILEEXT ,(ushort) (((1 | 256) | 512) | 16384) ) ) ; 
            __context__.SourceCodeLine = 150;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_SIHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 152;
                MakeString ( FILE_TIME_STAMP_FB , "{0} File Created.", GetSymbolInstanceName ( ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 156;
                G_SLIBYTES = (int) ( Functions.ToSignedLongInteger( -( 1 ) ) ) ; 
                __context__.SourceCodeLine = 157;
                MakeString ( FILE_TIME_STAMP_FB , "{0} Error File Create: {1:d}", GetSymbolInstanceName ( ) , (short)G_SIHANDLE) ; 
                } 
            
            __context__.SourceCodeLine = 159;
            FileClose (  (short) ( G_SIHANDLE ) ) ; 
            __context__.SourceCodeLine = 161;
            EndFileOperations ( ) ; 
            
            }
            
        private void FWRITE (  SplusExecutionContext __context__, ushort INITIALIZE ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 168;
            G_SFILECONTENTS  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 169;
            if ( Functions.TestForTrue  ( ( INITIALIZE)  ) ) 
                { 
                __context__.SourceCodeLine = 171;
                FCREATEFILE (  __context__  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 175;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)G_INUM_TEXT_SIGNALS_DEFINED; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 177;
                    if ( Functions.TestForTrue  ( ( Functions.Length( G_STEXT[ I ] ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 179;
                        G_SFILECONTENTS  .UpdateValue ( G_SFILECONTENTS + G_STEXT [ I ] + "\u001F"  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 175;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 184;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 186;
            G_SIHANDLE = (short) ( FileOpen( G_SPATHFILEEXT ,(ushort) ((256 | 1) | 16384) ) ) ; 
            __context__.SourceCodeLine = 188;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_SIHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 190;
                G_SLIBYTES = (int) ( FileWrite( (short)( G_SIHANDLE ) , G_SFILECONTENTS , (ushort)( Functions.Length( G_SFILECONTENTS ) ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 194;
                G_SLIBYTES = (int) ( Functions.ToSignedLongInteger( -( 1 ) ) ) ; 
                __context__.SourceCodeLine = 195;
                MakeString ( FILE_TIME_STAMP_FB , "{0} Error Write Open: {1:d}", GetSymbolInstanceName ( ) , (short)G_SIHANDLE) ; 
                } 
            
            __context__.SourceCodeLine = 197;
            FileClose (  (short) ( G_SIHANDLE ) ) ; 
            __context__.SourceCodeLine = 199;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 201;
            if ( Functions.TestForTrue  ( ( G_SLIBYTES)  ) ) 
                { 
                __context__.SourceCodeLine = 203;
                FEXPORT (  __context__  ) ; 
                __context__.SourceCodeLine = 204;
                MakeString ( FILE_TIME_STAMP_FB , "{0}   {1}", Functions.Date (  (int) ( 3 ) ) , Functions.Time ( ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 208;
                MakeString ( FILE_TIME_STAMP_FB , "{0} Error Write: {1:d}", GetSymbolInstanceName ( ) , (int)G_SLIBYTES) ; 
                } 
            
            
            }
            
        private void FREAD (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 216;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 218;
            G_SIFIND = (short) ( FindFirst( G_SPATHFILEEXT , ref G_FILEINFO ) ) ; 
            __context__.SourceCodeLine = 219;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 221;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SIFIND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 223;
                G_SIHANDLE = (short) ( FileOpen( G_SPATHFILEEXT ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 225;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_SIHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 227;
                    G_SLIBYTES = (int) ( FileRead( (short)( G_SIHANDLE ) , G_SFILECONTENTS , (ushort)( FileLength( (short)( G_SIHANDLE ) ) ) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 231;
                    G_SLIBYTES = (int) ( G_SIHANDLE ) ; 
                    __context__.SourceCodeLine = 232;
                    MakeString ( FILE_TIME_STAMP_FB , "{0} Error Read Open: {1:d}", GetSymbolInstanceName ( ) , (int)G_SLIBYTES) ; 
                    } 
                
                __context__.SourceCodeLine = 234;
                FileClose (  (short) ( G_SIHANDLE ) ) ; 
                __context__.SourceCodeLine = 235;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 237;
                if ( Functions.TestForTrue  ( ( G_SLIBYTES)  ) ) 
                    { 
                    __context__.SourceCodeLine = 239;
                    FEXPORT (  __context__  ) ; 
                    __context__.SourceCodeLine = 240;
                    FILE_TIME_STAMP_FB  .UpdateValue ( Functions.FileDate ( G_FILEINFO ,  (ushort) ( 1 ) ) + "  " + Functions.FileTime ( G_FILEINFO )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 245;
                    MakeString ( FILE_TIME_STAMP_FB , "{0} Error Read: {1:d}", GetSymbolInstanceName ( ) , (int)G_SLIBYTES) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 250;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 251;
                FWRITE (  __context__ , (ushort)( 1 )) ; 
                } 
            
            
            }
            
        object INITIALIZE_FILE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 259;
                if ( Functions.TestForTrue  ( ( Functions.Not( FILE_BUSY_FB  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 261;
                    FILE_BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 262;
                    FWRITE (  __context__ , (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 263;
                    FILE_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object READ_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 273;
            if ( Functions.TestForTrue  ( ( Functions.Not( FILE_BUSY_FB  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 275;
                FILE_BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 276;
                FREAD (  __context__  ) ; 
                __context__.SourceCodeLine = 277;
                FILE_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                } 
            
            else 
                { 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object EDIT_SAVE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 286;
        if ( Functions.TestForTrue  ( ( Functions.Not( FILE_BUSY_FB  .Value ))  ) ) 
            { 
            __context__.SourceCodeLine = 288;
            if ( Functions.TestForTrue  ( ( EDIT_INDEX  .UshortValue)  ) ) 
                { 
                __context__.SourceCodeLine = 290;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_INDEX  .UshortValue <= G_INUM_TEXT_SIGNALS_DEFINED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 292;
                    FILE_BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 293;
                    G_STEXT [ EDIT_INDEX  .UshortValue ]  .UpdateValue ( EDIT_TEXT  ) ; 
                    __context__.SourceCodeLine = 294;
                    FWRITE (  __context__ , (ushort)( 0 )) ; 
                    __context__.SourceCodeLine = 295;
                    FILE_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    } 
                
                } 
            
            else 
                { 
                } 
            
            } 
        
        else 
            { 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_INDEX_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 314;
        if ( Functions.TestForTrue  ( ( Functions.Not( FILE_BUSY_FB  .Value ))  ) ) 
            { 
            __context__.SourceCodeLine = 316;
            if ( Functions.TestForTrue  ( ( EDIT_INDEX  .UshortValue)  ) ) 
                { 
                __context__.SourceCodeLine = 318;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_INDEX  .UshortValue <= G_INUM_TEXT_SIGNALS_DEFINED ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 320;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EDIT_INDEX  .UshortValue <= LIST_SIZE_CURRENT_FB  .Value ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 322;
                        EDIT_TEXT  .UpdateValue ( G_STEXT [ EDIT_INDEX  .UshortValue ]  ) ; 
                        __context__.SourceCodeLine = 323;
                        EDIT_SELECTED_TEXT_FB  .UpdateValue ( G_STEXT [ EDIT_INDEX  .UshortValue ]  ) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    } 
                
                } 
            
            else 
                { 
                } 
            
            } 
        
        else 
            { 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PATHFILE_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 344;
        if ( Functions.TestForTrue  ( ( Functions.Length( PATHFILE ))  ) ) 
            { 
            __context__.SourceCodeLine = 346;
            G_SPATHFILEEXT  .UpdateValue ( PATHFILE + ".lst"  ) ; 
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
        
        __context__.SourceCodeLine = 355;
        G_SPATHFILEEXT  .UpdateValue ( DEFAULT_PATHFILE + ".lst"  ) ; 
        __context__.SourceCodeLine = 357;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 200 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( G_INUM_TEXT_SIGNALS_DEFINED  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (G_INUM_TEXT_SIGNALS_DEFINED  >= __FN_FORSTART_VAL__1) && (G_INUM_TEXT_SIGNALS_DEFINED  <= __FN_FOREND_VAL__1) ) : ( (G_INUM_TEXT_SIGNALS_DEFINED  <= __FN_FORSTART_VAL__1) && (G_INUM_TEXT_SIGNALS_DEFINED  >= __FN_FOREND_VAL__1) ) ; G_INUM_TEXT_SIGNALS_DEFINED  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 359;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( TEXT_FB[ G_INUM_TEXT_SIGNALS_DEFINED ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 361;
                break ; 
                } 
            
            __context__.SourceCodeLine = 357;
            } 
        
        __context__.SourceCodeLine = 365;
        LIST_SIZE_LIMIT_FB  .Value = (ushort) ( G_INUM_TEXT_SIGNALS_DEFINED ) ; 
        __context__.SourceCodeLine = 367;
        Functions.ResizeArray (  ref G_STEXT , (int)G_INUM_TEXT_SIGNALS_DEFINED, (int)255, null ) ; 
        __context__.SourceCodeLine = 369;
        I = (ushort) ( (G_INUM_TEXT_SIGNALS_DEFINED + (G_INUM_TEXT_SIGNALS_DEFINED * 255)) ) ; 
        __context__.SourceCodeLine = 372;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I < 65535 ))  ) ) 
            { 
            __context__.SourceCodeLine = 374;
            Functions.ResizeString (  ref G_SFILECONTENTS , I, null ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 378;
            Functions.ResizeString (  ref G_SFILECONTENTS , 65500, null ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_SFILECONTENTS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65500, this );
    G_SPATHFILEEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    G_STEXT  = new CrestronString[ 256 ];
    for( uint i = 0; i < 256; i++ )
        G_STEXT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    G_FILEINFO  = new FILE_INFO();
    G_FILEINFO .PopulateDefaults();
    
    INITIALIZE_FILE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE_FILE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE_FILE__DigitalInput__, INITIALIZE_FILE );
    
    READ = new Crestron.Logos.SplusObjects.DigitalInput( READ__DigitalInput__, this );
    m_DigitalInputList.Add( READ__DigitalInput__, READ );
    
    EDIT_SAVE = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_SAVE__DigitalInput__, EDIT_SAVE );
    
    FILE_BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FILE_BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILE_BUSY_FB__DigitalOutput__, FILE_BUSY_FB );
    
    EDIT_INDEX = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_INDEX__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_INDEX__AnalogSerialInput__, EDIT_INDEX );
    
    LIST_SIZE_CURRENT_FB = new Crestron.Logos.SplusObjects.AnalogOutput( LIST_SIZE_CURRENT_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LIST_SIZE_CURRENT_FB__AnalogSerialOutput__, LIST_SIZE_CURRENT_FB );
    
    LIST_SIZE_LIMIT_FB = new Crestron.Logos.SplusObjects.AnalogOutput( LIST_SIZE_LIMIT_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LIST_SIZE_LIMIT_FB__AnalogSerialOutput__, LIST_SIZE_LIMIT_FB );
    
    EDIT_TEXT = new Crestron.Logos.SplusObjects.StringInput( EDIT_TEXT__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( EDIT_TEXT__AnalogSerialInput__, EDIT_TEXT );
    
    PATHFILE = new Crestron.Logos.SplusObjects.StringInput( PATHFILE__AnalogSerialInput__, 128, this );
    m_StringInputList.Add( PATHFILE__AnalogSerialInput__, PATHFILE );
    
    FILE_TIME_STAMP_FB = new Crestron.Logos.SplusObjects.StringOutput( FILE_TIME_STAMP_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILE_TIME_STAMP_FB__AnalogSerialOutput__, FILE_TIME_STAMP_FB );
    
    EDIT_SELECTED_TEXT_FB = new Crestron.Logos.SplusObjects.StringOutput( EDIT_SELECTED_TEXT_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_SELECTED_TEXT_FB__AnalogSerialOutput__, EDIT_SELECTED_TEXT_FB );
    
    TEXT_FB = new InOutArray<StringOutput>( 200, this );
    for( uint i = 0; i < 200; i++ )
    {
        TEXT_FB[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TEXT_FB__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TEXT_FB__AnalogSerialOutput__ + i, TEXT_FB[i+1] );
    }
    
    DEFAULT_PATHFILE = new StringParameter( DEFAULT_PATHFILE__Parameter__, this );
    m_ParameterList.Add( DEFAULT_PATHFILE__Parameter__, DEFAULT_PATHFILE );
    
    UNUSED = new InOutArray<StringParameter>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        UNUSED[i+1] = new StringParameter( UNUSED__Parameter__ + i, UNUSED__Parameter__, this );
        m_ParameterList.Add( UNUSED__Parameter__ + i, UNUSED[i+1] );
    }
    
    INITIALIZE_TEXT = new InOutArray<StringParameter>( 200, this );
    for( uint i = 0; i < 200; i++ )
    {
        INITIALIZE_TEXT[i+1] = new StringParameter( INITIALIZE_TEXT__Parameter__ + i, INITIALIZE_TEXT__Parameter__, this );
        m_ParameterList.Add( INITIALIZE_TEXT__Parameter__ + i, INITIALIZE_TEXT[i+1] );
    }
    
    
    INITIALIZE_FILE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_FILE_OnPush_0, false ) );
    READ.OnDigitalPush.Add( new InputChangeHandlerWrapper( READ_OnPush_1, false ) );
    EDIT_SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_SAVE_OnPush_2, false ) );
    EDIT_INDEX.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_INDEX_OnChange_3, false ) );
    PATHFILE.OnSerialChange.Add( new InputChangeHandlerWrapper( PATHFILE_OnChange_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GP_TEXT_LIST_V0_4 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE_FILE__DigitalInput__ = 0;
const uint READ__DigitalInput__ = 1;
const uint EDIT_SAVE__DigitalInput__ = 2;
const uint EDIT_INDEX__AnalogSerialInput__ = 0;
const uint EDIT_TEXT__AnalogSerialInput__ = 1;
const uint PATHFILE__AnalogSerialInput__ = 2;
const uint FILE_BUSY_FB__DigitalOutput__ = 0;
const uint FILE_TIME_STAMP_FB__AnalogSerialOutput__ = 0;
const uint LIST_SIZE_CURRENT_FB__AnalogSerialOutput__ = 1;
const uint LIST_SIZE_LIMIT_FB__AnalogSerialOutput__ = 2;
const uint EDIT_SELECTED_TEXT_FB__AnalogSerialOutput__ = 3;
const uint TEXT_FB__AnalogSerialOutput__ = 4;
const uint DEFAULT_PATHFILE__Parameter__ = 10;
const uint UNUSED__Parameter__ = 11;
const uint INITIALIZE_TEXT__Parameter__ = 16;

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
