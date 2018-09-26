namespace Crestron.DateTimeFunctions;
        // class declarations
         class SimplSharpDateTimeClass;
     class SimplSharpDateTimeClass 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION GetNthDayOfNthWeek ( SIGNED_LONG_INTEGER year , SIGNED_LONG_INTEGER month , SIGNED_LONG_INTEGER dayOfWeek , SIGNED_LONG_INTEGER whichWeek );
        SIGNED_LONG_INTEGER_FUNCTION GetDayOfWeek ( SIGNED_LONG_INTEGER year , SIGNED_LONG_INTEGER month , SIGNED_LONG_INTEGER day );
        STRING_FUNCTION GetDateTime ( SIGNED_LONG_INTEGER year , SIGNED_LONG_INTEGER month , SIGNED_LONG_INTEGER day );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING DateFormat[];
    };

