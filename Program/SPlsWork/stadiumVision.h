namespace stadiumVision;
        // class declarations
         class channel;
         class director;
         class credentials;
         class channelList;
         class analogEventArgs;
         class serialEventArgs;
         class groupListSelectPlayerEventArgs;
         class ListSelectEventArgs;
         class groupFeature;
         class playerFeature;
         class player;
         class dmp;
         class group;
         class Qitem;
         class av_input;
     class channel 
    {
        // class delegates
        delegate FUNCTION serialDelagate ( SIMPLSHARPSTRING x );

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty serialDelagate Id_;
        STRING Id[];
        DelegateProperty serialDelagate Name_;
        STRING Name[];
        DelegateProperty serialDelagate Description_;
        STRING Description[];
        DelegateProperty serialDelagate ShortName_;
        STRING ShortName[];
        DelegateProperty serialDelagate LongName_;
        STRING LongName[];
        DelegateProperty serialDelagate LogicalChannel_;
        STRING LogicalChannel[];
        DelegateProperty serialDelagate PhysicalChannel_;
        STRING PhysicalChannel[];
        DelegateProperty serialDelagate Favorite_;
        STRING Favorite[];
        DelegateProperty serialDelagate FavoriteOrder_;
        STRING FavoriteOrder[];
        DelegateProperty serialDelagate SourceId_;
        STRING SourceId[];
        DelegateProperty serialDelagate LogoSmall_;
        STRING LogoSmall[];
        DelegateProperty serialDelagate LogoMedium_;
        STRING LogoMedium[];
        DelegateProperty serialDelagate LogoLarge_;
        STRING LogoLarge[];
        STRING FilterChannel[];
    };

    static class director 
    {
        // class delegates
        delegate FUNCTION serialDelagate ( SIMPLSHARPSTRING x );
        delegate FUNCTION analogDelagate ( INTEGER x );

        // class events

        // class functions
        static FUNCTION Q_Count ();
        static FUNCTION verbose ( INTEGER newState );
        static FUNCTION init ();
        static FUNCTION Q_Clear ();
        static FUNCTION Q_Item_Add ( Qitem call );
        static FUNCTION Q_Check ();
        static STRING_FUNCTION serverCode ( SIGNED_LONG_INTEGER c );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty serialDelagate Message_;
        DelegateProperty serialDelagate Debug_;
        DelegateProperty analogDelagate Q_Count_;
        DelegateProperty analogDelagate Init_;
        INTEGER Initialized;
        STRING baseUri[];
        DelegateProperty serialDelagate Ip_;
        STRING Ip[];
        DelegateProperty serialDelagate Id_;
        STRING Id[];
    };

     class credentials 
    {
        // class delegates
        delegate FUNCTION serialDelagate ( SIMPLSHARPSTRING x );

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty serialDelagate Auth_;
        STRING auth[];
        DelegateProperty serialDelagate Pin_V_;
        STRING pin_V[];
        DelegateProperty serialDelagate Pin_F_;
        STRING pin_F[];
        DelegateProperty serialDelagate Pin_M_;
        STRING pin_M[];
        DelegateProperty serialDelagate Group_Id_;
        STRING group_id[];
        DelegateProperty serialDelagate Group_Name_;
        STRING group_name[];
        DelegateProperty serialDelagate Group_External_Id_;
        STRING group_external_Id[];
    };

     class channelList 
    {
        // class delegates
        delegate FUNCTION serialDelagate ( SIMPLSHARPSTRING x );
        delegate FUNCTION analogDelagate ( INTEGER x );

        // class events
        static EventHandler onList_Select_Change ( ListSelectEventArgs e );

        // class functions
        FUNCTION printChannelList ();
        FUNCTION List_Select ( INTEGER index );
        FUNCTION init ();
        FUNCTION getGuide ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty serialDelagate Message_;
        DelegateProperty serialDelagate Debug_;
        DelegateProperty analogDelagate Ack_Nak_;
        DelegateProperty serialDelagate Filter_String_;
        STRING group_id[];
        DelegateProperty serialDelagate List_Name_;
        STRING list_name[];
        DelegateProperty analogDelagate Channel_Count_;
        DelegateProperty serialDelagate Auth_;
        STRING auth[];
        DelegateProperty serialDelagate Pin_V_;
        STRING pin_V[];
        DelegateProperty serialDelagate Pin_F_;
        STRING pin_F[];
        DelegateProperty serialDelagate Pin_M_;
        STRING pin_M[];
        DelegateProperty serialDelagate Group_Id_;
        DelegateProperty serialDelagate Group_Name_;
        STRING group_name[];
        DelegateProperty serialDelagate Group_External_Id_;
        STRING group_external_Id[];
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

     class groupListSelectPlayerEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Player_Id[];
        STRING Player_Name[];
        STRING Player_External_Id[];
        STRING Player_Logical_Id[];
        STRING Location[];
        STRING Network_Address[];
        STRING Mac_Address[];
        STRING Player_Model[];
        STRING TV_Model[];
        INTEGER Power;
        INTEGER Channel;
        INTEGER Volume;
        INTEGER Volume_Mute;
        INTEGER Input;
        INTEGER CC;
        STRING CC_Option[];
    };

     class ListSelectEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Id[];
        STRING Name[];
        STRING Description[];
        STRING ShortName[];
        STRING LongName[];
        STRING LogicalChannel[];
        STRING PhysicalChannel[];
        STRING Favorite[];
        STRING FavoriteOrder[];
        STRING SourceId[];
        STRING LogoSmall[];
        STRING LogoMedium[];
        STRING LogoLarge[];
    };

    static class groupFeature // enum
    {
        static SIGNED_LONG_INTEGER NONE;
        static SIGNED_LONG_INTEGER TV_CONTROL;
        static SIGNED_LONG_INTEGER ALBUM_CONTROL;
        static SIGNED_LONG_INTEGER XXX;
        static SIGNED_LONG_INTEGER YYY;
        static SIGNED_LONG_INTEGER ZZZ;
    };

    static class playerFeature // enum
    {
        static SIGNED_LONG_INTEGER NONE;
        static SIGNED_LONG_INTEGER POWER_STATE;
        static SIGNED_LONG_INTEGER MUTING;
        static SIGNED_LONG_INTEGER CHANNEL_CHANGE_RELATIVE;
        static SIGNED_LONG_INTEGER CLOSE_CAPTION;
        static SIGNED_LONG_INTEGER VOLUME_CHANGE_ABSOLUTE;
        static SIGNED_LONG_INTEGER UNMUTING;
        static SIGNED_LONG_INTEGER CHANNEL_CHANGE_ABSOLUTE;
        static SIGNED_LONG_INTEGER VIDEO_INPUT;
    };

     class player 
    {
        // class delegates
        delegate FUNCTION serialDelagate ( SIMPLSHARPSTRING x );
        delegate FUNCTION analogDelagate ( INTEGER x );

        // class events

        // class functions
        FUNCTION player_init ( STRING p_Id , STRING p_F );
        FUNCTION player_send ( STRING restParams );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty serialDelagate Message_;
        DelegateProperty serialDelagate Debug_;
        DelegateProperty analogDelagate Ack_Nak_;
        DelegateProperty serialDelagate Player_Id_;
        STRING player_id[];
        DelegateProperty serialDelagate Player_Name_;
        STRING player_name[];
        DelegateProperty serialDelagate Player_External_Id_;
        STRING player_external_Id[];
        DelegateProperty serialDelagate Player_Logical_Id_;
        STRING player_logical_Id[];
        DelegateProperty serialDelagate Location_;
        STRING location[];
        DelegateProperty serialDelagate Network_Address_;
        STRING network_address[];
        DelegateProperty serialDelagate Mac_Address_;
        STRING mac_address[];
        DelegateProperty serialDelagate Player_Model_;
        STRING player_model[];
        DelegateProperty serialDelagate TV_Model_;
        STRING TV_model[];
        DelegateProperty analogDelagate Power_;
        INTEGER power;
        DelegateProperty analogDelagate Channel_;
        INTEGER channel;
        STRING chan[];
        DelegateProperty analogDelagate Volume_;
        INTEGER volume;
        STRING vol[];
        DelegateProperty analogDelagate Volume_Mute_;
        INTEGER volume_mute;
        STRING vol_mute[];
        DelegateProperty analogDelagate Input_;
        INTEGER input;
        STRING inpt[];
        DelegateProperty analogDelagate CC_;
        INTEGER cc;
        STRING cc_state[];
        DelegateProperty serialDelagate CC_Option_;
        STRING cc_option[];
        DelegateProperty serialDelagate Auth_;
        STRING auth[];
        DelegateProperty serialDelagate Pin_V_;
        STRING pin_V[];
        DelegateProperty serialDelagate Pin_F_;
        STRING pin_F[];
        DelegateProperty serialDelagate Pin_M_;
        STRING pin_M[];
        DelegateProperty serialDelagate Group_Id_;
        STRING group_id[];
        DelegateProperty serialDelagate Group_Name_;
        STRING group_name[];
        DelegateProperty serialDelagate Group_External_Id_;
        STRING group_external_Id[];
    };

     class dmp 
    {
        // class delegates
        delegate FUNCTION serialDelagate ( SIMPLSHARPSTRING x );
        delegate FUNCTION analogDelagate ( INTEGER x );

        // class events

        // class functions
        FUNCTION send_input ( STRING inputName );
        FUNCTION send ( STRING restParams );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty serialDelagate Message_;
        DelegateProperty serialDelagate Debug_;
        DelegateProperty analogDelagate Ack_Nak_;
        DelegateProperty serialDelagate Dmp_Id_;
        STRING dmp_id[];
        DelegateProperty serialDelagate Logical_Id_;
        STRING logical_Id[];
        DelegateProperty analogDelagate Power_;
        INTEGER power;
        DelegateProperty analogDelagate Channel_;
        INTEGER channel;
        STRING chan[];
        DelegateProperty analogDelagate Volume_;
        INTEGER volume;
        STRING vol[];
        DelegateProperty analogDelagate Volume_Mute_;
        INTEGER volume_mute;
        STRING vol_mute[];
        DelegateProperty analogDelagate Input_;
        INTEGER input;
        STRING inpt[];
        DelegateProperty analogDelagate CC_;
        INTEGER cc;
        STRING cc_state[];
        DelegateProperty serialDelagate CC_Option_;
        STRING cc_option[];
        DelegateProperty serialDelagate Auth_;
        STRING auth[];
        DelegateProperty serialDelagate Pin_V_;
        STRING pin_V[];
        DelegateProperty serialDelagate Pin_F_;
        STRING pin_F[];
        DelegateProperty serialDelagate Pin_M_;
        STRING pin_M[];
        DelegateProperty serialDelagate Group_Id_;
        STRING group_id[];
        DelegateProperty serialDelagate Group_Name_;
        STRING group_name[];
        DelegateProperty serialDelagate Group_External_Id_;
        STRING group_external_Id[];
    };

     class group 
    {
        // class delegates
        delegate FUNCTION serialDelagate ( SIMPLSHARPSTRING x );
        delegate FUNCTION analogDelagate ( INTEGER x );
        delegate FUNCTION groupListSelectPlayerDelagate ( SIMPLSHARPSTRING Player_Id , SIMPLSHARPSTRING Player_Name , SIMPLSHARPSTRING Player_External_Id , SIMPLSHARPSTRING Player_Logical_Id , SIMPLSHARPSTRING Location , SIMPLSHARPSTRING Network_Address , SIMPLSHARPSTRING Mac_Address , SIMPLSHARPSTRING Player_Model , SIMPLSHARPSTRING TV_Model , INTEGER Power , INTEGER Channel , INTEGER Volume , INTEGER Volume_Mute , INTEGER Input , INTEGER CC , SIMPLSHARPSTRING CC_Option );

        // class events

        // class functions
        FUNCTION init ();
        FUNCTION listSelect ( INTEGER listIndex );
        FUNCTION send ( STRING restParams );
        FUNCTION playerSend ( STRING restParams );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING list_player_name[][];

        // class properties
        DelegateProperty serialDelagate Message_;
        DelegateProperty serialDelagate Debug_;
        DelegateProperty analogDelagate Player_Ack_Nak_;
        STRING pin_F[];
        DelegateProperty analogDelagate TV_Control_;
        INTEGER TV_Control;
        DelegateProperty analogDelagate Album_Control_;
        INTEGER Album_Control;
        DelegateProperty analogDelagate Player_Count_;
        INTEGER player_count;
        DelegateProperty groupListSelectPlayerDelagate List_Select_Player_;
        DelegateProperty serialDelagate List_Select_Key_;
        STRING list_select_key[];
        DelegateProperty serialDelagate Auth_;
        STRING auth[];
        DelegateProperty serialDelagate Pin_V_;
        STRING pin_V[];
        DelegateProperty serialDelagate Pin_F_;
        DelegateProperty serialDelagate Pin_M_;
        STRING pin_M[];
        DelegateProperty serialDelagate Group_Id_;
        STRING group_id[];
        DelegateProperty serialDelagate Group_Name_;
        STRING group_name[];
        DelegateProperty serialDelagate Group_External_Id_;
        STRING group_external_Id[];
    };

     class Qitem 
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

     class av_input 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING name[];
        STRING value[];
    };

