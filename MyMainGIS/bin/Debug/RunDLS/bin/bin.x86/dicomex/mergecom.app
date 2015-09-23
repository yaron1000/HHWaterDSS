#============================================================================
#                      MERGECOM-3 Application Configurations
#============================================================================
#
#                   ==== MergeCOM-3 Application Profiles ===
#
#      The location of this file is provided in the MERGECOM_3_APPLICATIONS
#          parameter of the [MergeCOM3] section of the MERGE.INI file
# .
#============================================================================
#
#  Contains the following sections:
#    [<remote_application_title>]- Section describing a remote DICOM application
#                                  <remote_application_title> names must be
#                                  1 to 16 bytes in length with no embedded 
#                                  spaces.  This section is only used by 
#                                  SCU applications to configure systems they 
#                                  will connect with.
#                                 
#    [<service_list_name>]      - List[s] of DICOM services (referenced by
#                                 entries in the [<remote_application_title>] 
#                                 sections.  These section names are also used
#                                 by the MC_Wait_For_Association function to
#                                 specify an SCP's services supported.
#                                 <service_list_name> names must be
#                                 1 to 33 bytes in length with no embedded 
#                                 spaces.  
#                                 
#    [<syntax_list_name>]       - List[s] of DICOM transfer syntaxes (referenced 
#                                 by optional entries in the [<service_list_name>]
#                                 sections. 
#                                 <syntax_list_name> names must be
#                                 1 to 33 bytes in length with no embedded 
#                                 spaces.
#


# Each [<remote_application_title>] section is of this format:
#       PORT_NUMBER     = <port>          is the TCP/IP port on which the 
#                                         remote DICOM system listens for 
#                                         connections.  The commonly used port 
#                                         number is 104. This default value may
#                                         be overriden by the 
#                                         MC_Open_Association() function call.
#       HOST_NAME       = <TCP/IP name>   is the name of the remote host as it
#                                         is known to your TCP/IP system.  This
#                                         default value may be overriden by 
#                                         the MC_Open_Association() function 
#                                         call.
#                                         <TCP/IP name> must be 1 to 19 bytes 
#                                         in length with no embedded spaces.
#       SERVICE_LIST    = <list name>     is the name of another section in 
#                                         this file which provides a list of 
#                                         services local applications will 
#                                         negotiate for when attempting to
#                                         establish an association.  This is a
#                                         default list; another list may be 
#                                         specified in the 
#                                         MC_Open_Association() call.
#                                         <list name> names must be 1 to 33 
#                                         bytes in length with no embedded 
#                                         spaces.

[MERGE_STORE_SCP]
    PORT_NUMBER     = 104        # port 104 is the standard DICOM port and is
#                                      priviledged
    HOST_NAME       = myhost     # Put the remote machine name here
    SERVICE_LIST    = Storage_SCU_Service_List

[MERGE_STORE_SCU]
    PORT_NUMBER     = 104        # port 104 is the standard DICOM port and is
#                                      priviledged.  Note that if the storage
#                                      commitment SCU and SCP are running on
#                                      the same machine, a new port number
#                                      must be placed here so both applications
#                                      can listen on different ports.
    HOST_NAME       = myhost     # Put the remote machine name here
    SERVICE_LIST    = Storage_Commitment_SCP_Service_List

[MERGE_MEDIA_FSU]
    PORT_NUMBER     = 104        # port 104 is the standard DICOM port and is
#                                      priviledged
    HOST_NAME       = myhost     # Put the remote machine name here
    SERVICE_LIST    = Storage_SCP_Service_List 
    
[MERGE_QR_SCP]
    PORT_NUMBER     = 104        # port 104 is the standard DICOM port and is
#                                      priviledged
    HOST_NAME       = myhost     # Put the remote machine name here
    SERVICE_LIST    = Query_SCU_Service_List
    
[MERGE_QR_SCU]
    PORT_NUMBER     = 1115        # port 104 is the standard DICOM port and is
#                                      priviledged.  This example has a
#                                      different port to prevent conflicts when
#                                      testing both applications on the same
#                                      machine.  Both the Q/R SCU and SCP samples
#                                      SCP samples listen for associations.
    HOST_NAME       = myhost      # Put the remote machine name here
    SERVICE_LIST    = Storage_SCP_Service_List    

[MERGE_PRINT_SCP]
    PORT_NUMBER     = 104        # port 104 is the standard DICOM port and is
#                                      priviledged
    HOST_NAME       = myhost     # Put the remote machine name here
    SERVICE_LIST    = Print_Service_List

[MERGE_WORK_SCP]
    PORT_NUMBER     = 104        # port 104 is the standard DICOM port and is
#                                      priviledged
    HOST_NAME       = myhost     # Put the remote machine name here
    SERVICE_LIST    = Worklist_Service_List




# Each [<service_list_name>] section must contain a SERVICES_SUPPORTED
#       parameter to specify the number of services in the list.  Optionally,
#       if an application supports DICOM asynchronous communications, the 
#       maximum operations invoked and performed by the application can be
#       specified in the service list.  MAX_OPERATIONS_INVOKED specifies
#       the maximum number of requests messages an application will send
#       before processing a response message.  MAX_OPERATIONS_PERFORMED
#       specifies how many requests messages an application can recieve
#       before sending a response message.  Setting a value of '0' means
#       unlimited requests can be invoked or performed.  Leaving these 
#       options out of the service list will cause this not to be negotiated
#       and synchronous communication will be used over the association.
#
#       MAX_OPERATIONS_INVOKED = 10
#       MAX_OPERATIONS_PERFORMED = 10
#
#       Finally, a service list has four parameters for each service, of 
#       the following format:
#
#       SERVICE_n = <service name>
#       SYNTAX_LIST_n = <syntax_list_name>  (this parameter is optional)
#       ROLE_n = <role type>
#       EXT_NEG_INFO_n = <neg info>
#
#       where:
#               SERVICE_n       the character string "SERVICE_n", with n 
#                               replaced by the number of the service being 
#                               named.
#               ROLE_n          the character string "ROLE_n", with n replaced
#                               by the number of the role being set.  The only
#                               values which may be set are SCU, SCP, or BOTH.
#                               This section is optional.  Not specifying a
#                               role will default to a requestor = SCU, and
#                               acceptor = SCP.
#               SYNTAX_LIST_n   the character string "SYNTAX_LIST_n", with n 
#                               replaced by the number of the service for 
#                               which a list of transfer syntaxes to support
#                               is specified.
#               EXT_NEG_INFO_n  the character string "EXT_NEG_INFO_n", with n 
#                               replaced by the number of the service for 
#                               which extended negotiation is specified.  Note
#                               that this extended negotation information is 
#                               only used by the SCU.
#               <service name>  is the name of one of the services supported by
#                               your MergeCOM-3 system.  It must match one of 
#                               the service names described in the MergeCOM-3 
#                               Services Profile (named by the 
#                               MERGECOM_3_SERVICES parameter in the merge.ini 
#                               file).
#               <syntax_list_name>  is the name of a section that contains a 
#                               list of transfer syntaxes to support.  This
#                               parameter is optional.
#               <neg info>      is a string of hex characters signaling the 
#                               DICOM extended negotiation info to be used by
#                               an SCU when proposing an association.  The 
#                               string would be of the format 0x01 0x00 0x01, 
#                               etc.
#
# If a transfer syntax list is not specified, the tool kit will use the three
# non-encapsulated transfer syntaxes defined in the mergecom.pro configuration
# file (implicit VR little endian, explicit VR little endian and explicit VR big
# endian).


# Service list used by the Echo SCU component
[Echo_SCU_Service_List]
    SERVICES_SUPPORTED      = 1 # Number of Services in list
    SERVICE_1               = STANDARD_ECHO

# Service list used by the Storage and Storage Commitment SCP application.
# This is a seperate service list because the SCU does not want to include
# the storage commitment push service class its association request.
[Storage_SCP_Service_List]
    SERVICES_SUPPORTED      = 47       # Number of Services in list    
    SERVICE_1               = STANDARD_CR
    SYNTAX_LIST_1           = Full_Syntax_List
    SERVICE_2               = STANDARD_DX_PRESENT
    SYNTAX_LIST_2           = Full_Syntax_List
    SERVICE_3               = STANDARD_DX_PROCESS
    SYNTAX_LIST_3           = Full_Syntax_List
    SERVICE_4               = STANDARD_MG_PRESENT
    SYNTAX_LIST_4           = Full_Syntax_List
    SERVICE_5               = STANDARD_MG_PROCESS
    SYNTAX_LIST_5           = Full_Syntax_List
    SERVICE_6               = STANDARD_IO_PRESENT
    SYNTAX_LIST_6           = Full_Syntax_List
    SERVICE_7               = STANDARD_IO_PROCESS
    SYNTAX_LIST_7           = Full_Syntax_List
    SERVICE_8               = STANDARD_CT
    SYNTAX_LIST_8           = Full_Syntax_List
    SERVICE_9               = STANDARD_US_MF_RETIRED
    SYNTAX_LIST_9           = Full_Syntax_List
    SERVICE_10              = STANDARD_US_MF
    SYNTAX_LIST_10          = Full_Syntax_List
    SERVICE_11              = STANDARD_MR
    SYNTAX_LIST_11          = Full_Syntax_List
    SERVICE_12              = ENHANCED_MR_IMAGE
    SYNTAX_LIST_12          = Full_Syntax_List
    SERVICE_13              = MR_SPECTROSCOPY
    SYNTAX_LIST_13          = Full_Syntax_List
    SERVICE_14              = STANDARD_NM_RETIRED
    SYNTAX_LIST_14          = Full_Syntax_List
    SERVICE_15              = STANDARD_US_RETIRED
    SYNTAX_LIST_15          = Full_Syntax_List
    SERVICE_16              = STANDARD_US
    SYNTAX_LIST_16          = Full_Syntax_List
    SERVICE_17              = STANDARD_SEC_CAPTURE
    SYNTAX_LIST_17          = Full_Syntax_List
    SERVICE_18              = SC_MULTIFRAME_GRAYSCALE_BYTE
    SYNTAX_LIST_18          = Full_Syntax_List
    SERVICE_19              = SC_MULTIFRAME_GRAYSCALE_WORD
    SYNTAX_LIST_19          = Full_Syntax_List
    SERVICE_20              = SC_MULTIFRAME_SINGLE_BIT
    SYNTAX_LIST_20          = Full_Syntax_List
    SERVICE_21              = SC_MULTIFRAME_TRUE_COLOR
    SYNTAX_LIST_21          = Full_Syntax_List
    SERVICE_22              = STANDARD_OVERLAY
    SYNTAX_LIST_22          = Full_Syntax_List
    SERVICE_23              = STANDARD_CURVE
    SYNTAX_LIST_23          = Full_Syntax_List
    SERVICE_24              = STANDARD_MODALITY_LUT
    SYNTAX_LIST_24          = Full_Syntax_List
    SERVICE_25              = STANDARD_VOI_LUT
    SYNTAX_LIST_25          = Full_Syntax_List
    SERVICE_26              = STANDARD_GRAYSCALE_SOFTCOPY_PS
    SYNTAX_LIST_26          = Full_Syntax_List
    SERVICE_27              = STANDARD_XRAY_ANGIO
    SYNTAX_LIST_27          = Full_Syntax_List
    SERVICE_28              = STANDARD_XRAY_RF
    SYNTAX_LIST_28          = Full_Syntax_List
    SERVICE_29              = STANDARD_XRAY_ANGIO_BIPLANE
    SYNTAX_LIST_29          = Full_Syntax_List
    SERVICE_30              = STANDARD_NM
    SYNTAX_LIST_30          = Full_Syntax_List
    SERVICE_31              = RAW_DATA
    SYNTAX_LIST_31          = Full_Syntax_List
    SERVICE_32              = STANDARD_VL_ENDOSCOPIC
    SYNTAX_LIST_32          = Full_Syntax_List
    SERVICE_33              = STANDARD_VL_MICROSCOPIC
    SYNTAX_LIST_33          = Full_Syntax_List
    SERVICE_34              = STANDARD_VL_SLIDE_MICROSCOPIC
    SYNTAX_LIST_34          = Full_Syntax_List
    SERVICE_35              = STANDARD_VL_PHOTOGRAPHIC
    SYNTAX_LIST_35          = Full_Syntax_List
    SERVICE_36              = STANDARD_BASIC_TEXT_SR
    SYNTAX_LIST_36          = Full_Syntax_List
    SERVICE_37              = STANDARD_ENHANCED_SR
    SYNTAX_LIST_37          = Full_Syntax_List
    SERVICE_38              = STANDARD_COMPREHENSIVE_SR
    SYNTAX_LIST_38          = Full_Syntax_List
    SERVICE_39              = STANDARD_PET
    SYNTAX_LIST_39          = Full_Syntax_List
    SERVICE_40              = STANDARD_PET_CURVE
    SYNTAX_LIST_40          = Full_Syntax_List
    SERVICE_41              = STANDARD_RT_IMAGE
    SYNTAX_LIST_41          = Full_Syntax_List
    SERVICE_42              = STANDARD_RT_DOSE
    SYNTAX_LIST_42          = Full_Syntax_List
    SERVICE_43              = STANDARD_RT_STRUCTURE_SET
    SYNTAX_LIST_43          = Full_Syntax_List
    SERVICE_44              = STANDARD_RT_BEAMS_TREAT
    SYNTAX_LIST_44          = Full_Syntax_List
    SERVICE_45              = STANDARD_RT_PLAN
    SYNTAX_LIST_45          = Full_Syntax_List
    SERVICE_46              = STANDARD_RT_BRACHY_TREAT
    SYNTAX_LIST_46          = Full_Syntax_List
    SERVICE_47              = STANDARD_RT_TREAT_SUM
    SYNTAX_LIST_47          = Full_Syntax_List


[Storage_SCU_Service_List]
    SERVICES_SUPPORTED      = 47       # Number of Services in list    
    SERVICE_1               = STANDARD_CR
    SYNTAX_LIST_1           = Full_Syntax_List
    SERVICE_2               = STANDARD_DX_PRESENT
    SYNTAX_LIST_2           = Full_Syntax_List
    SERVICE_3               = STANDARD_DX_PROCESS
    SYNTAX_LIST_3           = Full_Syntax_List
    SERVICE_4               = STANDARD_MG_PRESENT
    SYNTAX_LIST_4           = Full_Syntax_List
    SERVICE_5               = STANDARD_MG_PROCESS
    SYNTAX_LIST_5           = Full_Syntax_List
    SERVICE_6               = STANDARD_IO_PRESENT
    SYNTAX_LIST_6           = Full_Syntax_List
    SERVICE_7               = STANDARD_IO_PROCESS
    SYNTAX_LIST_7           = Full_Syntax_List
    SERVICE_8               = STANDARD_CT
    SYNTAX_LIST_8           = Full_Syntax_List
    SERVICE_9               = STANDARD_US_MF_RETIRED
    SYNTAX_LIST_9           = Full_Syntax_List
    SERVICE_10              = STANDARD_US_MF
    SYNTAX_LIST_10          = Full_Syntax_List
    SERVICE_11              = STANDARD_MR
    SYNTAX_LIST_11          = Full_Syntax_List
    SERVICE_12              = ENHANCED_MR_IMAGE
    SYNTAX_LIST_12          = Full_Syntax_List
    SERVICE_13              = MR_SPECTROSCOPY
    SYNTAX_LIST_13          = Full_Syntax_List
    SERVICE_14              = STANDARD_NM_RETIRED
    SYNTAX_LIST_14          = Full_Syntax_List
    SERVICE_15              = STANDARD_US_RETIRED
    SYNTAX_LIST_15          = Full_Syntax_List
    SERVICE_16              = STANDARD_US
    SYNTAX_LIST_16          = Full_Syntax_List
    SERVICE_17              = STANDARD_SEC_CAPTURE
    SYNTAX_LIST_17          = Full_Syntax_List
    SERVICE_18              = SC_MULTIFRAME_GRAYSCALE_BYTE
    SYNTAX_LIST_18          = Full_Syntax_List
    SERVICE_19              = SC_MULTIFRAME_GRAYSCALE_WORD
    SYNTAX_LIST_19          = Full_Syntax_List
    SERVICE_20              = SC_MULTIFRAME_SINGLE_BIT
    SYNTAX_LIST_20          = Full_Syntax_List
    SERVICE_21              = SC_MULTIFRAME_TRUE_COLOR
    SYNTAX_LIST_21          = Full_Syntax_List
    SERVICE_22              = STANDARD_OVERLAY
    SYNTAX_LIST_22          = Full_Syntax_List
    SERVICE_23              = STANDARD_CURVE
    SYNTAX_LIST_23          = Full_Syntax_List
    SERVICE_24              = STANDARD_MODALITY_LUT
    SYNTAX_LIST_24          = Full_Syntax_List
    SERVICE_25              = STANDARD_VOI_LUT
    SYNTAX_LIST_25          = Full_Syntax_List
    SERVICE_26              = STANDARD_GRAYSCALE_SOFTCOPY_PS
    SYNTAX_LIST_26          = Full_Syntax_List
    SERVICE_27              = STANDARD_XRAY_ANGIO
    SYNTAX_LIST_27          = Full_Syntax_List
    SERVICE_28              = STANDARD_XRAY_RF
    SYNTAX_LIST_28          = Full_Syntax_List
    SERVICE_29              = STANDARD_XRAY_ANGIO_BIPLANE
    SYNTAX_LIST_29          = Full_Syntax_List
    SERVICE_30              = STANDARD_NM
    SYNTAX_LIST_30          = Full_Syntax_List
    SERVICE_31              = RAW_DATA
    SYNTAX_LIST_31          = Full_Syntax_List
    SERVICE_32              = STANDARD_VL_ENDOSCOPIC
    SYNTAX_LIST_32          = Full_Syntax_List
    SERVICE_33              = STANDARD_VL_MICROSCOPIC
    SYNTAX_LIST_33          = Full_Syntax_List
    SERVICE_34              = STANDARD_VL_SLIDE_MICROSCOPIC
    SYNTAX_LIST_34          = Full_Syntax_List
    SERVICE_35              = STANDARD_VL_PHOTOGRAPHIC
    SYNTAX_LIST_35          = Full_Syntax_List
    SERVICE_36              = STANDARD_BASIC_TEXT_SR
    SYNTAX_LIST_36          = Full_Syntax_List
    SERVICE_37              = STANDARD_ENHANCED_SR
    SYNTAX_LIST_37          = Full_Syntax_List
    SERVICE_38              = STANDARD_COMPREHENSIVE_SR
    SYNTAX_LIST_38          = Full_Syntax_List
    SERVICE_39              = STANDARD_PET
    SYNTAX_LIST_39          = Full_Syntax_List
    SERVICE_40              = STANDARD_PET_CURVE
    SYNTAX_LIST_40          = Full_Syntax_List
    SERVICE_41              = STANDARD_RT_IMAGE
    SYNTAX_LIST_41          = Full_Syntax_List
    SERVICE_42              = STANDARD_RT_DOSE
    SYNTAX_LIST_42          = Full_Syntax_List
    SERVICE_43              = STANDARD_RT_STRUCTURE_SET
    SYNTAX_LIST_43          = Full_Syntax_List
    SERVICE_44              = STANDARD_RT_BEAMS_TREAT
    SYNTAX_LIST_44          = Full_Syntax_List
    SERVICE_45              = STANDARD_RT_PLAN
    SYNTAX_LIST_45          = Full_Syntax_List
    SERVICE_46              = STANDARD_RT_BRACHY_TREAT
    SYNTAX_LIST_46          = Full_Syntax_List
    SERVICE_47              = STANDARD_RT_TREAT_SUM
    SYNTAX_LIST_47          = Full_Syntax_List


[Query_SCU_Service_List]
    SERVICES_SUPPORTED      = 4 # Number of Services in list
    SERVICE_1               = STUDY_ROOT_QR_FIND
    SERVICE_2               = STUDY_ROOT_QR_MOVE
    SERVICE_3               = PATIENT_ROOT_QR_FIND
    SERVICE_4               = PATIENT_ROOT_QR_MOVE

[Query_SCP_Service_List]
    SERVICES_SUPPORTED      = 4 # Number of Services in list
    SERVICE_1               = STUDY_ROOT_QR_FIND
    SERVICE_2               = STUDY_ROOT_QR_MOVE
    SERVICE_3               = PATIENT_ROOT_QR_FIND
    SERVICE_4               = PATIENT_ROOT_QR_MOVE



# Each [<syntax_list_name>] section must contain a SYNTAXS_SUPPORTED
#       parameter to specify the number of transfer syntaxes in the 
#       list; plus one parameter for each syntax, of the following format:
#
#       SYNTAX_n = <transfer syntax name>
#
#       where:
#               SYNTAX_n        the character string "SYNTAX_n", with n 
#                               replaced by the number of the transfer 
#                               syntaxes being named.
#               <transfer syntax name>  is the name of one of the transfer
#                               syntaxes supported by your MergeCOM-3 system.  
#                               It must match one of the following DICOM transfer 
#                               syntaxes:
#                       IMPLICIT_LITTLE_ENDIAN
#                       IMPLICIT_BIG_ENDIAN
#                       EXPLICIT_LITTLE_ENDIAN
#                       EXPLICIT_BIG_ENDIAN 
#                       RLE
#                       JPEG_BASELINE  
#                       JPEG_EXTENDED_2_4
#                       JPEG_EXTENDED_3_5      
#                       JPEG_SPEC_NON_HIER_6_8
#                       JPEG_SPEC_NON_HIER_7_9   
#                       JPEG_FULL_PROG_NON_HIER_10_12
#                       JPEG_FULL_PROG_NON_HIER_11_13
#                       JPEG_LOSSLESS_NON_HIER_14   
#                       JPEG_LOSSLESS_NON_HIER_15   
#                       JPEG_EXTENDED_HIER_16_18    
#                       JPEG_EXTENDED_HIER_17_19    
#                       JPEG_SPEC_HIER_20_22        
#                       JPEG_SPEC_HIER_21_23        
#                       JPEG_FULL_PROG_HIER_24_26   
#                       JPEG_FULL_PROG_HIER_25_27   
#                       JPEG_LOSSLESS_HIER_28       
#                       JPEG_LOSSLESS_HIER_29       
#                       JPEG_LOSSLESS_HIER_14       
#                       PRIVATE_SYNTAX_1       
#                       PRIVATE_SYNTAX_2       
#
# Note that the order that these transfer syntaxes are listed
# defines how SCP applications using the tool kit will select 
# them during association negotiation.  The tool kit will place 
# the highest priority on the first syntax and decreasing 
# priority on following syntaxes in the transfer syntax list.

# Example syntax list used by the Storage_Service_List above.

[Uncompressed_Syntax_List]
    SYNTAXES_SUPPORTED      = 3       # Number of Syntaxes in list
    SYNTAX_1                = EXPLICIT_LITTLE_ENDIAN
    SYNTAX_2                = EXPLICIT_BIG_ENDIAN
    SYNTAX_3                = IMPLICIT_LITTLE_ENDIAN


# The following two syntax lists are supplied as an example of how to 
# define syntax lists for compressed transfer syntaxes.  Only the default
# lossless and lossy compression syntaxes have been included.
[Compressed_Syntax_List]
    SYNTAXES_SUPPORTED      = 3       # Number of Syntaxes in list
    SYNTAX_1                = JPEG_LOSSLESS_HIER_14
    SYNTAX_2                = JPEG_BASELINE  
    SYNTAX_3                = JPEG_EXTENDED_2_4      
    
    
[Full_Syntax_List]
    SYNTAXES_SUPPORTED      = 8       # Number of Syntaxes in list
    SYNTAX_1                = JPEG_2000_LOSSLESS_ONLY
    SYNTAX_2                = JPEG_2000 
    SYNTAX_3                = JPEG_LOSSLESS_HIER_14
    SYNTAX_4                = JPEG_BASELINE  
    SYNTAX_5                = JPEG_EXTENDED_2_4      
    SYNTAX_6                = EXPLICIT_LITTLE_ENDIAN
    SYNTAX_7                = EXPLICIT_BIG_ENDIAN
    SYNTAX_8                = IMPLICIT_LITTLE_ENDIAN

