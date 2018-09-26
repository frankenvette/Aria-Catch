namespace mediaTune;
        // class declarations
         class MessageEventArgs;
         class Message;
         class SocketEventArgs;
         class SocketBusy;
         class analogEventArgs;
         class digitalEventArgs;
         class serialEventArgs;
         class ChannelCountEventArgs;
         class ChannelIndexEventArgs;
         class ChannelIndex;
         class ChannelCount_MediaTune;
         class ChannelCount_Config;
         class SubscriptionCountEventArgs;
         class SubscriptionCount_Core;
         class InitializeEventArgs;
         class EventInitialize;
         class ChannelCount_Remote;
         class SubscriptionFB_EventArgs;
         class SubscriptionFB_Remote;
         class htmlConfigEventArgs;
         class filterTextEventArgs;
         class GlobalChannel;
         class configChannel;
         class mediaTuneChannel;
         class RemoteList;
         class RemoteCore;
         class Core;
         class subscription;
     class MessageEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Message[];
    };

    static class Message 
    {
        // class delegates

        // class events
        static EventHandler onMessage_Change ( MessageEventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Text[];
    };

     class SocketEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Socket_Busy;
    };

    static class SocketBusy 
    {
        // class delegates

        // class events
        static EventHandler onSocket_Busy_Change ( SocketEventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Socket_Busy;
    };

     class analogEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER value;
    };

     class digitalEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER value;
    };

     class serialEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING value[];
    };

     class ChannelCountEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Channel_Count;
    };

     class ChannelIndexEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Channel_Index;
    };

    static class ChannelIndex 
    {
        // class delegates

        // class events
        static EventHandler onChannelIndex_Data_Change ( ChannelIndexEventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static INTEGER _Channel_Index;

        // class properties
        INTEGER Channel_Index;
    };

    static class ChannelCount_MediaTune 
    {
        // class delegates

        // class events
        static EventHandler onChannelCount_MediaTune_Change ( ChannelCountEventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER ChannelCount;
    };

    static class ChannelCount_Config 
    {
        // class delegates

        // class events
        static EventHandler onChannelCount_Config_Change ( ChannelCountEventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER ChannelCount;
    };

     class SubscriptionCountEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Subscription_Count;
    };

    static class SubscriptionCount_Core 
    {
        // class delegates

        // class events
        static EventHandler onSubscriptionCount_Change ( SubscriptionCountEventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER SubscriptionCount;
    };

     class InitializeEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_INTEGER Initialize_Value_FB;
    };

    static class EventInitialize 
    {
        // class delegates

        // class events
        static EventHandler onInitialize_Value_Change ( InitializeEventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_INTEGER Initialize_Value_FB;
    };

    static class ChannelCount_Remote 
    {
        // class delegates

        // class events
        static EventHandler onChannelCount_Remote_Change ( ChannelCountEventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER ChannelCount;
    };

     class SubscriptionFB_EventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER SubscriptionFB;
    };

    static class SubscriptionFB_Remote 
    {
        // class delegates

        // class events
        static EventHandler onSubscription_FB_Change ( SubscriptionFB_EventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static INTEGER _SubscriptionFB;

        // class properties
        INTEGER SubscriptionFB;
    };

     class htmlConfigEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING chansize[];
        STRING chanface[];
        STRING chancolor[];
        STRING contsize[];
        STRING contface[];
        STRING contcolor[];
        STRING srchcolor[];
    };

     class filterTextEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER index;
        STRING text[];
    };

     class GlobalChannel 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class configChannel 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING channel[];
        INTEGER iMajor;
        STRING sMajor[];
        INTEGER iMinor;
        STRING sMinor[];
        STRING name[];
        STRING callsign[];
        STRING provider[];
        LONG_INTEGER iId;
        STRING sId[];
        LONG_INTEGER iIconIndex;
        STRING sIconIndex[];
        STRING sIconBaseURL[];
        STRING sIconFile[];
    };

     class mediaTuneChannel 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING l[];
        STRING contentNow[];
        STRING contentNext[];
        STRING content[];
        STRING category[];
        STRING channel[];
        INTEGER iMajor;
        STRING sMajor[];
        INTEGER iMinor;
        STRING sMinor[];
        STRING name[];
        STRING callsign[];
        STRING provider[];
        LONG_INTEGER iId;
        STRING sId[];
        LONG_INTEGER iIconIndex;
        STRING sIconIndex[];
        STRING sIconBaseURL[];
        STRING sIconFile[];
    };

     class RemoteList 
    {
        // class delegates
        delegate FUNCTION analogDelagate ( INTEGER x );
        delegate FUNCTION filterTextDelagate ( INTEGER index , SIMPLSHARPSTRING text );
        delegate FUNCTION htmlConfigDelagate ( SIMPLSHARPSTRING channel_size , SIMPLSHARPSTRING channel_face , SIMPLSHARPSTRING channel_color , SIMPLSHARPSTRING content_size , SIMPLSHARPSTRING content_face , SIMPLSHARPSTRING content_color , SIMPLSHARPSTRING search_color );

        // class events

        // class functions
        FUNCTION filterText ( INTEGER i , STRING text );
        FUNCTION htmlFormatSet ( STRING chanSize , STRING chanFace , STRING chanColor , STRING contSize , STRING contFace , STRING contColor , STRING searchColor );
        FUNCTION initialize ();
        FUNCTION refresh ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING filter_text[][];
        STRING htmlList[][];
        INTEGER iconIndexList[];
        INTEGER majorList[];

        // class properties
        DelegateProperty analogDelagate listBusyChange;
        INTEGER listBusy;
        DelegateProperty analogDelagate filterChange;
        INTEGER filter;
        DelegateProperty filterTextDelagate filterTextChange;
        DelegateProperty analogDelagate sortChange;
        INTEGER sort;
        DelegateProperty htmlConfigDelagate htmlConfigChange;
        STRING channelCallsign_htmlFormatting[];
        STRING content_htmlFormatting[];
        DelegateProperty analogDelagate searchNoResultChange;
        DelegateProperty analogDelagate searchAttributesChange;
        INTEGER searchAttributes;
        STRING searchText[];
        DelegateProperty analogDelagate listChange;
        DelegateProperty analogDelagate localChannelFilterCountChange;
        SIGNED_LONG_INTEGER localChannelFilterCount;
        STRING localChannelFilter[];
    };

    static class RemoteCore 
    {
        // class delegates
        delegate FUNCTION serialDelagate ( SIMPLSHARPSTRING x );
        delegate FUNCTION analogDelagate ( INTEGER x );

        // class events

        // class functions
        static FUNCTION subscription ( INTEGER cmd );
        static FUNCTION initialize ();
        static STRING_FUNCTION getChannelData ( INTEGER key , INTEGER dataIndex );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty serialDelagate ipAdrChange;
        STRING ipAdr[];
        DelegateProperty analogDelagate TCPServerPortChange;
        INTEGER TCPServerPort;
        DelegateProperty analogDelagate localChannelFilterCountChange;
        SIGNED_LONG_INTEGER localChannelFilterCount;
        STRING localChannelFilter[];
    };

    static class Core 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION initialize ();
        static STRING_FUNCTION getChannelData ( INTEGER key , INTEGER dataIndex );
        static FUNCTION getPage ( STRING sPage );
        static FUNCTION debug ( INTEGER p );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING ipAdr[];
        STRING configDirFileExt[];
    };

     class subscription 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING fileData[];
        STRING key[];
        SIGNED_LONG_INTEGER connectFailures;
    };

