#============================================================================
#
#====================== MergeCOM-3 System Profile ===========================
#
#       The location of this file is provided in the MERGECOM_3_PROFILE
#          parameter of the [MergeCOM3] section of the MERGE.INI file
#
#============================================================================
#
#  Contains the following sections:
#    [ASSOC_PARMS]      - MergeCOM association parameters
#    [DIMSE_PARMS]      - DIMSE Layer parameters
#    [DUL_PARMS]        - Upper Layer parameters
#    [TRANSPORT_PARMS]  - Transport Layer parameters
#    [MESSAGE_PARMS]    - Message parameters
#




#============================================================================
#                    MergeCOM-3 ASSOCIATION CONFIGURATION SECTION
#============================================================================
#    LICENSE                            The MergeCOM-3 Tool Kit license number that
#                                        was supplied when the tool kit was purchased.
#    IMPLEMENTATION_CLASS_UID           The DICOM Implementation Class UID (as
#                                        specified in your DICOM conformance statement)
#    IMPLEMENTATION_VERSION             16 characters maximum. The implementation
#                                        version number (as specified in your DICOM
#                                        conformance statement)
#    LOCAL_APPL_CONTEXT_NAME            The DICOM Application Context Name (UID) (as 
#                                        specified in the DICOM Standard)
#    ACCEPT_ANY_CONTEXT_NAME            If yes, the remote system need not
#                                        specify the LOCAL_APPL_CONTEXT_NAME
#                                        when requesting an association. If No,
#                                        the correct context name must be used.
#    ACCEPT_ANY_APPLICATION_TITLE       If Yes, the remote system need not specify a 
#                                        correct DICOM application title when requesting
#                                        an association.  The tool kit will report the
#                                        remote application as connecting to the first
#                                        application registered. If no, a correct
#                                        application title must be used.
#    ACCEPT_DIFFERENT_IC_UID            If No, the remote system must specify the local
#                                        IMPLEMENTATION_CLASS_UID when requesting an
#                                        association. If Yes, a different implementation
#                                        class UID may be used.
#    ACCEPT_DIFFERENT_VERSION           If No, the remote system must specify the local
#                                        IMPLEMENTATION_VERSION when requesting an
#                                        association.  If Yes, a different implementation
#                                        version may be used.
#    ACCEPT_ANY_PROTOCOL_VERSION        if received
#    ACCEPT_ANY_PRESENTATION_CONTEXT    presentation context negotiated for
#                                        service must match context used with
#                                        message
#    ACCEPT_MULTIPLE_PRES_CONTEXTS      Allow more than one presentation
#                                        context per service to be negotiated
#    ACCEPT_ANY_HOSTNAME                Hosts connecting must have entry in 
#                                        hosts file or domain name server.
#    AUTO_ECHO_SUPPORT                  Automatically handle ECHOs
#    HARD_CLOSE_TCP_IP_CONNECTION       When set to No, connections are closed
#                                        with a FIN packet.  When set to Yes,
#                                        connections are closed with a RST packet.
#    PDU_MAXIMUM_LENGTH                 Max size of Protocol Data Units
#                                        that can be received by this
#                                        MergeCOM-3 implementation
#                                        Must be 4K, 8K, or 16K or >16K
#                                        This value will also place a limit on
#                                        how large PDU values being sent can 
#                                        be. Note also to see the 
#                                        TCPIP_SEND_BUFFER_SIZE and 
#                                        TCPIP_RECEIVE_BUFFER_SIZE 
#                                        configuration values for 
#                                        improving performance.
#                           
# Transfer Syntax UIDs   - Use <none> to prevent using a given syntax
#                          (implicit little endian ALWAYS used)
#     
#    IMPLICIT_LITTLE_ENDIAN_SYNTAX
#    IMPLICIT_BIG_ENDIAN_SYNTAX
#    EXPLICIT_LITTLE_ENDIAN_SYNTAX
#    EXPLICIT_BIG_ENDIAN_SYNTAX
#    
#    DEFLATED_EXPLICIT_LITTLE_ENDIAN_SYNTAX
#
# Encapsulated transfer syntax UIDs
#    RLE_SYNTAX
#    JPEG_BASELINE_SYNTAX
#    JPEG_EXTENDED_2_4_SYNTAX
#    JPEG_EXTENDED_3_5_SYNTAX
#    JPEG_SPEC_NON_HIER_6_8_SYNTAX
#    JPEG_SPEC_NON_HIER_7_9_SYNTAX
#    JPEG_FULL_PROG_NON_HIER_10_12_SYNTAX
#    JPEG_FULL_PROG_NON_HIER_11_13_SYNTAX
#    JPEG_LOSSLESS_NON_HIER_14_SYNTAX
#    JPEG_LOSSLESS_NON_HIER_15_SYNTAX
#    JPEG_EXTENDED_HIER_16_18_SYNTAX
#    JPEG_EXTENDED_HIER_17_19_SYNTAX
#    JPEG_SPEC_HIER_20_22_SYNTAX
#    JPEG_SPEC_HIER_21_23_SYNTAX
#    JPEG_FULL_PROG_HIER_24_26_SYNTAX
#    JPEG_FULL_PROG_HIER_25_27_SYNTAX
#    JPEG_LOSSLESS_HIER_28_SYNTAX
#    JPEG_LOSSLESS_HIER_29_SYNTAX
#    JPEG_LOSSLESS_HIER_14_SYNTAX
#    JPEG_2000_LOSSLESS_ONLY_SYNTAX
#    JPEG_2000_SYNTAX
#    JPEG_LS_LOSSLESS_SYNTAX
#    JPEG_LS_LOSSY_SYNTAX
#    MPEG2_MPML_SYNTAX
#
# Private Transfer Syntaxes
#    PRIVATE_SYNTAX_1_SYNTAX                UID to be used to identify
#                                            private transfer syntax 1
#    PRIVATE_SYNTAX_1_LITTLE_ENDIAN         If Yes, syntax 1 is little
#                                            endian, if No, syntax is 
#                                            big endian
#    PRIVATE_SYNTAX_1_EXPLICIT_VR           If Yes, syntax 1 is explicit VR
#    PRIVATE_SYNTAX_1_ENCAPSULATED          If Yes, transfer syntax is 
#                                            encapsulated and encapsulated 
#                                            rules must be followed for
#                                            pixel data (7fe0,0010).
#    PRIVATE_SYNTAX_2_SYNTAX                UID to be used to identify
#                                            private transfer syntax 2
#    PRIVATE_SYNTAX_2_LITTLE_ENDIAN         If Yes, syntax 2 is little 
#                                            endian, if No, syntax is 
#                                            big endian
#    PRIVATE_SYNTAX_2_EXPLICIT_VR           If Yes, syntax 2 is explicit VR
#    PRIVATE_SYNTAX_2_ENCAPSULATED          If Yes, transfer syntax is 
#                                            encapsulated and encapsulated
#                                            rules must be followed for
#                                            pixel data (7fe0,0010).
#

[ASSOC_PARMS]

LICENSE                              = XXXX-XXXXX
IMPLEMENTATION_CLASS_UID             = 2.16.840.1.114226
IMPLEMENTATION_VERSION               = IDL_2.1.0_3.4.0
LOCAL_APPL_CONTEXT_NAME              = 1.2.840.10008.3.1.1.1
ACCEPT_ANY_CONTEXT_NAME              = Yes
ACCEPT_ANY_APPLICATION_TITLE         = No
ACCEPT_DIFFERENT_IC_UID              = Yes
ACCEPT_DIFFERENT_VERSION             = Yes
ACCEPT_ANY_PROTOCOL_VERSION          = No
ACCEPT_ANY_PRESENTATION_CONTEXT      = No
ACCEPT_MULTIPLE_PRES_CONTEXTS        = Yes
ACCEPT_ANY_HOSTNAME                  = Yes
AUTO_ECHO_SUPPORT                    = Yes
HARD_CLOSE_TCP_IP_CONNECTION         = No
PDU_MAXIMUM_LENGTH                   = 28672
                      
IMPLICIT_LITTLE_ENDIAN_SYNTAX        = 1.2.840.10008.1.2
IMPLICIT_BIG_ENDIAN_SYNTAX           = <none>
EXPLICIT_LITTLE_ENDIAN_SYNTAX        = 1.2.840.10008.1.2.1
EXPLICIT_BIG_ENDIAN_SYNTAX           = 1.2.840.10008.1.2.2

DEFLATED_EXPLICIT_LITTLE_ENDIAN_SYNTAX    = 1.2.840.10008.1.2.1.99

RLE_SYNTAX                           = 1.2.840.10008.1.2.5    
JPEG_BASELINE_SYNTAX                 = 1.2.840.10008.1.2.4.50    
JPEG_EXTENDED_2_4_SYNTAX             = 1.2.840.10008.1.2.4.51    
JPEG_EXTENDED_3_5_SYNTAX             = 1.2.840.10008.1.2.4.52    
JPEG_SPEC_NON_HIER_6_8_SYNTAX        = 1.2.840.10008.1.2.4.53    
JPEG_SPEC_NON_HIER_7_9_SYNTAX        = 1.2.840.10008.1.2.4.54    
JPEG_FULL_PROG_NON_HIER_10_12_SYNTAX = 1.2.840.10008.1.2.4.55    
JPEG_FULL_PROG_NON_HIER_11_13_SYNTAX = 1.2.840.10008.1.2.4.56    
JPEG_LOSSLESS_NON_HIER_14_SYNTAX     = 1.2.840.10008.1.2.4.57    
JPEG_LOSSLESS_NON_HIER_15_SYNTAX     = 1.2.840.10008.1.2.4.58    
JPEG_EXTENDED_HIER_16_18_SYNTAX      = 1.2.840.10008.1.2.4.59    
JPEG_EXTENDED_HIER_17_19_SYNTAX      = 1.2.840.10008.1.2.4.60    
JPEG_SPEC_HIER_20_22_SYNTAX          = 1.2.840.10008.1.2.4.61    
JPEG_SPEC_HIER_21_23_SYNTAX          = 1.2.840.10008.1.2.4.62    
JPEG_FULL_PROG_HIER_24_26_SYNTAX     = 1.2.840.10008.1.2.4.63    
JPEG_FULL_PROG_HIER_25_27_SYNTAX     = 1.2.840.10008.1.2.4.64    
JPEG_LOSSLESS_HIER_28_SYNTAX         = 1.2.840.10008.1.2.4.65    
JPEG_LOSSLESS_HIER_29_SYNTAX         = 1.2.840.10008.1.2.4.66    
JPEG_LOSSLESS_HIER_14_SYNTAX         = 1.2.840.10008.1.2.4.70    
JPEG_2000_LOSSLESS_ONLY_SYNTAX       = 1.2.840.10008.1.2.4.90
JPEG_2000_SYNTAX                     = 1.2.840.10008.1.2.4.91
JPEG_LS_LOSSLESS_SYNTAX              = 1.2.840.10008.1.2.4.80
JPEG_LS_LOSSY_SYNTAX                 = 1.2.840.10008.1.2.4.81
MPEG2_MPML_SYNTAX                    = 1.2.840.10008.1.2.4.100

PRIVATE_SYNTAX_1_SYNTAX              = <none>
PRIVATE_SYNTAX_1_LITTLE_ENDIAN       = Yes
PRIVATE_SYNTAX_1_EXPLICIT_VR         = Yes
PRIVATE_SYNTAX_1_ENCAPSULATED        = No
PRIVATE_SYNTAX_2_SYNTAX              = <none>
PRIVATE_SYNTAX_2_LITTLE_ENDIAN       = Yes
PRIVATE_SYNTAX_2_EXPLICIT_VR         = Yes
PRIVATE_SYNTAX_2_ENCAPSULATED        = No



#============================================================================
#                    MergeCOM-3 DIMSE LAYER CONFIGURATION SECTION
#============================================================================
#
#  Default DICOM DIMSE Layer Parameters
#
#    SEND_SOP_CLASS_UID         Version 3 command field
#    SEND_SOP_INSTANCE_UID      Version 3 command field
#
#    INITIATOR_NAME             Retired   command field
#    RECEIVER_NAME              Retired   command field
#    SEND_LENGTH_TO_END         Retired   command field
#    SEND_RECOGNITION_CODE      Retired   command field 
#    SEND_MSG_ID_RESPONSE       Version 2 command field  
#    SEND_ECHO_PRIORITY         Version 2 command field
#    SEND_RESPONSE_PRIORITY     Version 2 command field 

[DIMSE_PARMS]

SEND_SOP_CLASS_UID         =  YES
SEND_SOP_INSTANCE_UID      =  YES

INITIATOR_NAME             =  <NONE>
RECEIVER_NAME              =  <NONE>
SEND_LENGTH_TO_END         =  NO
SEND_RECOGNITION_CODE      =  NO
SEND_MSG_ID_RESPONSE       =  NO
SEND_ECHO_PRIORITY         =  NO
SEND_RESPONSE_PRIORITY     =  NO
    



#============================================================================
#                    MergeCOM-3 UPPER LAYER CONFIGURATION SECTION
#============================================================================
#
#  DICOM Upper Layer Parameters
#    The Upper Layer ALWAYS uses reads this section for its parameters
#
#    ARTIM_TIMEOUT              The number of seconds to use as a
#                                timeout waiting for association
#                                request or waiting for the peer
#                                to shut down an association.
#    ASSOC_REPLY_TIMEOUT        The number of seconds to wait
#                                for reply to associate request.
#    RELEASE_TIMEOUT            The number of seconds to wait
#                                for reply to associate release.
#    WRITE_TIMEOUT              The number of seconds to wait
#                                for a network write to be accepted.
#    CONNECT_TIMEOUT            The number of seconds to wait
#                                for a network connect to be accepted.
#    INACTIVITY_TIMEOUT         The number of seconds to wait for data
#                                between TCP/IP packets on a call to
#                                MC_Read_Message().

[DUL_PARMS]

ARTIM_TIMEOUT             = 30
ASSOC_REPLY_TIMEOUT       = 15
RELEASE_TIMEOUT           = 15
WRITE_TIMEOUT             = 15
CONNECT_TIMEOUT           = 15
INACTIVITY_TIMEOUT        = 15




#============================================================================
#                    MergeCOM-3 MESSAGE CONFIGURATION SECTION
#============================================================================
#    LARGE_DATA_STORE                       MEM | FILE   Default = MEM
#    LARGE_DATA_SIZE
#    DICTIONARY_ACCESS                      MEM | FILE   Default = MEM
#    DICTIONARY_FILE
#    MSG_INFO_FILE
#    TEMP_FILE_DIRECTORY                    Note that on Windows 200 platforms,
#                                            this value can be changes to 
#                                            %TEMP% to specify the system's 
#                                            configured temporary directory
#
#    OBOW_BUFFER_SIZE                       Used when LARGE_DATA_STORE is set
#                                            to FILE.  This setting configures
#                                            the size chunks that OB or OW data
#                                            is spooled to the temporary files
#                                            in.
#    WORK_BUFFER_SIZE                       Recommend 28K (28672 bytes)
#                                            Buffer size used when streaming in
#                                            or out messages/files.  Using 
#                                            larger values for this option can 
#                                            improve performance
#    ELIMINATE_ITEM_REFERENCES              When Yes, the  MC_Free_Item()
#                                            will check all other open messages
#                                            for references to this item. 
#                                            Setting this value to No will 
#                                            greatly improve the performance of
#                                            free'ing DICOMDIRs
#    FORCE_JAVA_BIG_ENDIAN                  Java environment only - Default:Yes
#                                            If yes OW/OF/OL data delivered in
#                                            Big Endian to Java; otherwise in
#                                            endian of the host machine
#    FORCE_OPEN_EMPTY_ITEM                  Force MC_Open_Item() to
#                                            behave similar to the 
#                                            MC_Open_Empty_Message().
#                                            This will reduce the amount of 
#                                            memory required to store items.
#    EMPTY_PRIVATE_CREATOR_CODES            MC_Empty_Message() will empty 
#                                            private creator codes when Yes
#    UNKNOWN_VR_CODE                        Valid values: UN, OB.
#                                            VR Code to use for unknown VRs, ie    
#                                            private attributes that are not in
#                                            the data dictionary which are 
#                                            received in the implicit VR little 
#                                            endian transfer syntax.  'UN' is 
#                                            the official DICOM VR, however, 
#                                            'OB' may need to be used if an  
#                                            implementation does not understand  
#                                            'UN' and the private attributes 
#                                            are to be preserved.
#    ALLOW_INVALID_PRIVATE_ATTRIBUTES       When set to 'No', private attributes 
#                                            that are not encoded according to 
#                                            DICOM will be ignored by the library.
#                                            IE, if a private attribute does not
#                                            have a creator code associated with   
#                                            it.  When set to 'Yes', these 
#                                            attributes are treated as "garbage
#                                            in, garbage out".
#    ALLOW_INVALID_PRIVATE_CREATOR_CODES    When set to 'No', private 
#                                            creator codes that are not encoded 
#                                            according to DICOM will be ignored
#                                            by the library.  Private elements
#                                            associated with these creator codes
#                                            will also be ignored.
#    CALLBACK_MIN_DATA_SIZE                 Minimum size OB/OW tag for which to
#                                            use a callback function registered 
#                                            with MC_Register_Callback_Funciton().
#                                            This is useful to ignore small pixel
#                                            data in a message such as an Icon.
#    REMOVE_PADDING_CHARS                   When set to Yes, the tool kit will
#                                            remove space padding characters from
#                                            all text based attributes.  This
#                                            removal will occur when the attribute
#                                            is encoded with one of the MC_Set_Value
#                                            functions, or when the attributes are
#                                            read into the tool kit with one of
#                                            the streaming or network read
#                                            functions.
#    EXPORT_UN_VR_TO_NETWORK                When set to No, do not export UN VR 
#                                            attributes while using the 
#                                            MC_Send_Request_Message() and 
#                                            MC_Send_Response_Message() functions
#    EXPORT_PRIVATE_ATTRIBUTES_TO_NETWORK   When set to no, do not export 
#                                            private attributes while using the 
#                                            MC_Send_Request_Message() and 
#                                            MC_Send_Response_Message() functions
#    ALLOW_COMMA_IN_DS_FL_FD_STRINGS        If Yes, a comma or a period will be allowed 
#                                            in the value passed to MC_Set_Value_From_String
#                                            for attributes with a VR of DS or FL or FD.
#                                            If No, only a period will be acceptable
#                                            as the radix character.  (In any case,
#                                            the tool kit will insure that DS attributes
#                                            use the period character when streaming
#                                            to the network or to a file, regardless
#                                            of the current locale settings.)
#    RETURN_COMMA_IN_DS_FL_FD_STRINGS       If Yes, the tool kit will return a comma
#                                            in the value when MC_Get_Value_To_String
#                                            is called for an attribute with a VR of DS, FL or FD.
#                                            If No, the value will be returned with
#                                            a period used as the radix character.
#                                            (In any case, the tool kit will properly
#                                            decode DS values regardless of the current
#                                            locale settings.)
#   NULL_TYPE3_VALIDATION                   Valid Values: ERR, WARN, INFO.  This is
#                                            to configure how the toolkit will validate a
#                                            single NULL value in a type 3 attribute with
#                                            VM>1
#   FLATE_GROW_OUTPUT_BUF_SIZE              There is no accurate way of predicting 
#                                            the size of deflated or inflated data 
#                                            from the input, so the output buffer 
#                                            may be reallocated if not enough space 
#                                            was provided. The initial size is the 
#                                            size of the first "chunk" of data 
#                                            provided to the function.  If it is
#                                            insufficient, it grows by this amount.
#                                            An Info message is logged so you may
#                                            check the effectiveness of your chosen
#                                            value.
#   DEFLATE_COMPRESSION_LEVEL               Value 0 through 9, and -1
#                                            -1 = Default Compression
#                                             0 = No Compression
#                                             1 = Best Speed
#                                             9 = Best Compression
#   DEFLATE_ALLOW_FLUSH                     If Yes, the toolkit will request that 
#                                            deflate flushes on calls that would 
#                                            normally return data if this were not 
#                                            a deflated message.  Flushing may 
#                                            degrade compression, but is an 
#                                            alternative to buffering data.  If 
#                                            fewer large chunks (versus a lot of 
#                                            small chunks) are being provided, the 
#                                            difference may be negligible.  If No, 
#                                            the toolkit will feed all of the data
#                                            to deflate and take any output it returns, 
#                                            but may buffer all deflated data until
#                                            the last input is provided.
#   REMOVE_SQ                               MC_Set_Value_To_Empty/Null does not free
#                                            item IDs from sequences when this is No.
#                                            Setting it to yes will allow items that
#                                            have no other references to be freed.
#   COMPRESSION_LUM_FACTOR                  Config Parameter for MC_Standard_Compressor.
#                                            Value 0 through 255. 0 is the highest 
#                                            quality, giving a quantization table 
#                                            of all 1's. 32 corresponds to the standard 
#                                            quantization tables. For values between 0 
#                                            and 128, the standard tables are scaled 
#                                            linearly. For values between 128 and 255, 
#                                            the standard tables are scaled non-linearly
#                                            and the compression increases (and the
#                                            quality decreases) by a very large amount.
#   COMPRESSION_CHROM_FACTOR = 32           Config Parameter for MC_Standard_Compressor.
#                                            Value 0 through 255.The chrominance 
#                                            compression factor is used to adjust
#                                            the default chrominance quantization 
#                                            table values. When ChromFactor is 32, 
#                                            the default chrominance quantization
#                                            table values are used as is.  A value of
#                                            255 corresponds to high compression, low
#                                            quality.
#   COMPRESSION_ALLOW_FRAGS = Yes           Config Parameter for MC_Standard_Compressor.
#                                            The Pegasus libraries allow compressed 
#                                            image data to be returned as it continues
#                                            to compress more image data.  This may 
#                                            result in an image frame having one or 
#                                            more fragments.  This is perfectly legal,
#                                            however some viewers may not be able to
#                                            display the image if they do not support
#                                            multiple fragments per frame.
#   COMPRESSION_WHEN_J2K_USE_LOSSY = No     Config Parameter for MC_Standard_Compressor.
#                                            When the JPEG_2000 transfer syntax is set
#                                            for a message, and the compressor is called,
#                                            the toolkit needs to know if lossy or
#                                            lossless is desired.  When set to No, the
#                                            image will be losslessly compressed.
#   COMPRESSION_J2K_LOSSY_RATIO = 10        Config Parameter for MC_Standard_Compressor.
#                                            Lossy compression ratio for Jpeg 2000.
#                                            Controls final image size (1->400, 1 being
#                                            least compression). The compressor will try
#                                            to compress the image to a final size of 
#                                            1/COMPRESSION_J2K_RATIO.
#   COMPRESSION_J2K_LOSSY_QUALITY = 1       Config Parameter for MC_Standard_Compressor.
#                                            Lossy compression quality for Jpeg 2000.
#                                            Controls degree of compression (1->10, 1
#                                            being highest compression, lowest quality). 
#   COMPRESSION_J2K_LOSSY_USE_QUALITY = Yes Config Parameter for MC_Standard_Compressor.
#                                            Specifies which scheme should be used for
#                                            J2K lossy compression, QUALITY or RATIO
#   DUPLICATE_ENCAPSULATED_ICON = No        When duplicating an unencapsulated message
#                                            to an encapsulated message, the toolkit
#                                            has no way to know the format for the
#                                            ICON_IMAGE's pixel data.  When set to No,
#                                            this pixel data will be unencapsulated.
#
#   PEGASUS_OP_LIP3PLUS_NAME                Config Parameter for MC_Standard_(De)Compressor.
#   PEGASUS_OP_LIP3PLUS_REGISTRATION         Specifying values for these parameters will
#   PEGASUS_OP_LIE3PLUS_NAME                 use YOUR registered name and registration
#   PEGASUS_OP_LIE3PLUS_REGISTRATION         values for unlocking the Pegasus compressor
#   PEGASUS_OP_D2SEPLUS_NAME                 and decompressor.  The 3 frame/second limit
#   PEGASUS_OP_D2SEPLUS_REGISTRATION         will be removed for JPEG_BASELINE,
#   PEGASUS_OP_SE2DPLUS_NAME                 JPEG_EXTENDED_2_4, and JPEG_LOSSLESS_HIER_14.
#   PEGASUS_OP_SE2DPLUS_REGISTRATION         The "nag" screen will be removed from JPEG_2000
#   PEGASUS_OP_J2KP_NAME
#   PEGASUS_OP_J2KP_REGISTRATION
#   PEGASUS_OP_J2KE_NAME
#   PEGASUS_OP_J2KE_REGISTRATION
#
#   MSG_FILE_ITEM_OBJ_TRACE		     Config Parameter to allow the tracking of 
#   					     message/file/item object creation/referencing/freeing.
#					     T1 must be turned on in merge.ini
#   COMPRESSION_RGB_TRANSFORM_FORMAT	     YBR_FULL | YBR_FULL_422	Default = YBR_FULL_422 
#					     Create YBR_FULL/YBR_FULL_422 images whenever 
#					     compression is done with one of the Lossy JPEG 
#					     algorithms
	

[MESSAGE_PARMS]

LARGE_DATA_STORE                        = MEM
LARGE_DATA_SIZE                         = 4096
DICTIONARY_ACCESS                       = MEM
DICTIONARY_FILE                         =D:\RSI\IDL63\bin\bin.x86\dicomex\mrgcom3.dct
MSG_INFO_FILE                           =D:\RSI\IDL63\bin\bin.x86\dicomex\mrgcom3.msg
TEMP_FILE_DIRECTORY                     =D:\RSI\IDL63\bin\bin.x86\dicomex\

OBOW_BUFFER_SIZE                        = 16384
WORK_BUFFER_SIZE                        = 28672

ELIMINATE_ITEM_REFERENCES               = No

FORCE_JAVA_BIG_ENDIAN                   = Yes

FORCE_OPEN_EMPTY_ITEM                   = No
EMPTY_PRIVATE_CREATOR_CODES             = Yes
UNKNOWN_VR_CODE                         = UN
ALLOW_INVALID_PRIVATE_ATTRIBUTES        = No
ALLOW_INVALID_PRIVATE_CREATOR_CODES     = No
CALLBACK_MIN_DATA_SIZE                  = 1     
REMOVE_PADDING_CHARS                    = No    
EXPORT_UN_VR_TO_NETWORK                 = Yes   
EXPORT_PRIVATE_ATTRIBUTES_TO_NETWORK    = Yes

ALLOW_COMMA_IN_DS_FL_FD_STRINGS         = No
RETURN_COMMA_IN_DS_FL_FD_STRINGS        = No

NULL_TYPE3_VALIDATION                   = ERR

FLATE_GROW_OUTPUT_BUF_SIZE              = 1024
DEFLATE_COMPRESSION_LEVEL               = -1
DEFLATE_ALLOW_FLUSH                     = Yes    

REMOVE_SQ                               = No

COMPRESSION_LUM_FACTOR                  = 32     
COMPRESSION_CHROM_FACTOR                = 32
COMPRESSION_ALLOW_FRAGS                 = Yes
COMPRESSION_WHEN_J2K_USE_LOSSY          = Yes
COMPRESSION_J2K_LOSSY_RATIO             = 10
COMPRESSION_J2K_LOSSY_QUALITY           = 1
COMPRESSION_J2K_LOSSY_USE_QUALITY       = Yes

DUPLICATE_ENCAPSULATED_ICON             = No

PEGASUS_OP_LIP3PLUS_NAME                = YourCompanyName
PEGASUS_OP_LIP3PLUS_REGISTRATION        = 0x00000000
PEGASUS_OP_LIE3PLUS_NAME                = YourCompanyName
PEGASUS_OP_LIE3PLUS_REGISTRATION        = 0x00000000
PEGASUS_OP_D2SEPLUS_NAME                = YourCompanyName
PEGASUS_OP_D2SEPLUS_REGISTRATION        = 0x00000000
PEGASUS_OP_SE2DPLUS_NAME                = YourCompanyName
PEGASUS_OP_SE2DPLUS_REGISTRATION        = 0x00000000
PEGASUS_OP_J2KP_NAME                    = YourCompanyName
PEGASUS_OP_J2KP_REGISTRATION            = 0x00000000
PEGASUS_OP_J2KE_NAME                    = YourCompanyName
PEGASUS_OP_J2KE_REGISTRATION            = 0x00000000

MSG_FILE_ITEM_OBJ_TRACE			= No

COMPRESSION_RGB_TRANSFORM_FORMAT	= YBR_FULL_422

#============================================================================
#                    MergeCOM-3 MEDIA CONFIGURATION SECTION
#============================================================================
#   EXPORT_UN_VR_TO_MEDIA                  When set to no, do not write UN VR
#                                           attributes when using the 
#                                           MC_Write_File() and 
#                                           MC_Write_File_By_Callback()
#   EXPORT_PRIVATE_ATTRIBUTES_TO_MEDIA      When set to no, do not write 
#                                           private attributes when using the 
#                                           MC_Write_File() and
#                                           MC_Write_File_By_Callback()

[MEDIA_PARMS]

EXPORT_UN_VR_TO_MEDIA                   = Yes
EXPORT_PRIVATE_ATTRIBUTES_TO_MEDIA      = Yes
                                         



#============================================================================
#                    MergeCOM-3 TRANSPORT LAYER CONFIGURATION SECTION
#============================================================================
#   TCPIP_LISTEN_PORT           Note that the listen port potentially has to 
#                                be changed to a new value when this file is 
#                                used by the Q/R SCUsample application where 
#                                the Q/R SCP is running on the same machine.
#   MAX_PENDING_CONNECTIONS     Max number of open listen channels.  Note that
#                                this is not the "Maximum number of
#                                simmultaneous associations", but is rather
#                                a TCP/IP level configuraton value used when
#                                waiting for connections. 
#   TCPIP_SEND_BUFFER_SIZE      Set the send and receive OS network buffer
#   TCPIP_RECEIVE_BUFFER_SIZE    sizes.  Note that the maximum values for these
#                                constants are operating system dependant. If
#                                the values of these options are set too high,
#                                a message will be logged to the tool kit's log
#                                files, although no errors will be returned
#                                through the tool kit's API.  Larger values
#                                for these constants will greatly improve 
#                                network performance on networks with minimal
#                                network activity.  Note that for optimum
#                                performance, these values should be at least
#                                slightly larger than the PDU_MAXIMUM_LENGTH
#                                configuration value.
#   TCPIP_DISABLE_NAGLE = No    Disable Nagle Algorithm when sending
#   COMBINE_DATA_WITH_HEADER    Sometimes a 12 byte header is sent out separate
#                                from a small data packet. This option combines
#                                them into a single packet.
#
# Network Capture parameters
#    NETWORK_CAPTURE            Capture network data to a file that
#                                can be examined using the MergeDPM product.
#                                Default: No
#   CAPTURE_FILE_SIZE           The maximum size in kilobytes of capture files
#                                Default: 0 (no limit to file size)
#                                Capture stops when file would exceed nK 
#                                (zero means no limit)
#                                (If 1 thru 31, 32K is used)
#   CAPTURE_FILE                Default: merge.cap in current directory
#                                If NUMBER_OF_CAP_FILES > 1, nnn will be
#                                appended to the base file name 
#                                (e.g. merge001.cap)
#   NUMBER_OF_CAP_FILES         Max number of capture files to create
#                                Default: 1
#                                If 1, data from all associations is captured 
#                                in the one file; if > 1 each association is
#                                captured in its own file.
#                                If < 1, 1 will be assumed.
#                                (Ignored if CAPTURE_FILE_SIZE is <= 0)
#   REWRITE_CAPTURE_FILES       Default: Yes
#                                When all capture files have been written, the 
#                                oldest capture file will be rewritten if this is Yes,
#                                otherwise no more data will be captured.
#                                (Ignored if CAPTURE_FILE_SIZE is <= 0)


[TRANSPORT_PARMS]                  

#TCPIP_LISTEN_PORT          = 1115 
TCPIP_LISTEN_PORT           = 104 

MAX_PENDING_CONNECTIONS     = 5

TCPIP_SEND_BUFFER_SIZE      = 29696 
TCPIP_RECEIVE_BUFFER_SIZE   = 29696 
TCPIP_DISABLE_NAGLE         = No
COMBINE_DATA_WITH_HEADER    = No

NETWORK_CAPTURE             =No
CAPTURE_FILE_SIZE           =0
CAPTURE_FILE                =./merge.cap
NUMBER_OF_CAP_FILES         =1
REWRITE_CAPTURE_FILES       =Yes
