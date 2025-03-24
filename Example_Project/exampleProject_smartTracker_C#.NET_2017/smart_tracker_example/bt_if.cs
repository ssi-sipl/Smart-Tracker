using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace smart_tracker_example
{
    public class bt_if
    {
        [DllImport("itl.dll", EntryPoint = "itl_init_tracker", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_init_tracker(float cycleTime_s);

        [DllImport("itl.dll", EntryPoint = "itl_execute_tracker", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_execute_tracker(IntPtr pTargetList, UInt16 nrOfTargets);

        [DllImport("itl.dll", EntryPoint = "itl_receive_track_list", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_receive_track_list(IntPtr pTrackList, ref UInt16 pNrOfTracks);

        [DllImport("itl.dll", EntryPoint = "itl_set_ignore_zones", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_set_ignore_zones(IntPtr pIgnoreZones, UInt16 nrOfIgnoreZones);

        [DllImport("itl.dll", EntryPoint = "itl_get_ignore_zones", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_get_ignore_zones(IntPtr pIgnoreZones);

        [DllImport("itl.dll", EntryPoint = "itl_set_default_values", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_set_default_values(ITLProductCode_t productCode);

        [DllImport("itl.dll", EntryPoint = "itl_set_installation_height", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_set_installation_height(float height);

        [DllImport("itl.dll", EntryPoint = "itl_get_installation_height", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_get_installation_height(ref float height);

        [DllImport("itl.dll", EntryPoint = "itl_set_installation_angle", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_set_installation_angle(float angle);

        [DllImport("itl.dll", EntryPoint = "itl_get_installation_angle", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_get_installation_angle(ref float angle);









        [DllImport("itl.dll", EntryPoint = "itl_set_parameter_f32", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_set_parameter_f32(bt_parameter_enum_t parameterType, float Value);

        [DllImport("itl.dll", EntryPoint = "itl_set_parameter_ui16", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_set_parameter_ui16(bt_parameter_enum_t parameterType, UInt16 Value);

        [DllImport("itl.dll", EntryPoint = "itl_set_parameter_si16", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_set_parameter_si16(bt_parameter_enum_t parameterType, Int16 Value);

        [DllImport("itl.dll", EntryPoint = "itl_get_parameter_f32", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_get_parameter_f32(bt_parameter_enum_t parameterType, ref float pValue);

        [DllImport("itl.dll", EntryPoint = "itl_get_parameter_ui16", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_get_parameter_ui16(bt_parameter_enum_t parameterType, ref UInt16 pValue);

        [DllImport("itl.dll", EntryPoint = "itl_get_parameter_ui32", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_get_parameter_ui32(bt_parameter_enum_t parameterType, ref UInt32 pValue);

        [DllImport("itl.dll", EntryPoint = "itl_get_parameter_si16", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_get_parameter_si16(bt_parameter_enum_t parameterType, ref Int16 pValue);

        [DllImport("itl.dll", EntryPoint = "itl_get_compilation_date", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_get_compilation_date(IntPtr pDate, ref UInt16 pSizeOfArray);

        [DllImport("itl.dll", EntryPoint = "itl_reset_tracks", CallingConvention = CallingConvention.Cdecl)]
        public static extern ITLResult_t itl_reset_tracks();

        public const int BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE = 10;
        public const int BT_MAX_NR_OF_IGNORE_ZONES = 10;
        public const int BT_MAX_NR_OF_TARGETS = 256;
        public const int BT_MAX_NR_OF_TRACKS = 64;
        public const double PI_I = 3.14159265;


        public enum ITLResult_t{
            ITL_OK = 0,
            ITL_ERROR_PROCESSING,
            ITL_ERROR_MEMORY_ALLOCATION,
            ITL_ERROR_PARAMETER,
            ITL_ERROR_STRUCT_SIZE,
            ITL_ERROR_PRODUCT_CODE
        }

        public enum ITLProductCode_t
        {
            ITL_PRODUCT_iSYS5011 = 5011,
            ITL_PRODUCT_iSYS5021 = 5021
        }
        

        public enum bt_parameter_enum_t{
            /* Version */
            BT_PARAMETER_UI32_VERSION_MAJOR = 0x0001,
            BT_PARAMETER_UI32_VERSION_FIXED,
            BT_PARAMETER_UI32_VERSION_MINOR,
            BT_PARAMETER_UI32_VERSION_DATE,
            BT_PARAMETER_UI32_COMPILE_DATE,

            /* Wind Filter */
            BT_PARAMETER_F32_WIND_FILTER_DISTANCE = 0x0410,
            BT_PARAMETER_UI16_WIND_FILTER_ACTIVE
        }

        public enum bt_track_class_t{
            BT_TRACK_CLASS_UNCLASSIFIED = 0,
            BT_TRACK_CLASS_PEDESTRIAN = 1,
            BT_TRACK_CLASS_VEHICLE = 2,
            BT_TRACK_CLASS_OTHER = 3
        }

        public struct v2d_f32_it{
            public float x;
            public float y;
        }

        public struct bt_ignore_zone_t{
            public ushort b_active;
            public UInt16 ui16_nrOfVertices;
            public v2d_f32_it v2d_min;     /* optimization for faster ignore zone check */
            public v2d_f32_it v2d_max;     /* optimization for faster ignore zone check */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE)]
            public v2d_f32_it[] v2d_vertex;     /* polygon vertex points */
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct bt_ignore_zone_array_t{
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = BT_MAX_NR_OF_IGNORE_ZONES)]
            public bt_ignore_zone_t[] IgnoreZone;
        }

        public struct bt_target_list_rv_t
        {
            public float f32_rcs_m2;              /* [dB] */
            public float f32_range_m;             /* [m]*/
            public float f32_velocity_mps;        /* [m/s] */
            public float f32_angleAzimuth_deg;    /* [deg] */
            public float f32_reserved1;
            public float f32_reserved2;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct bt_target_list_array_t
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = BT_MAX_NR_OF_TARGETS)]
            public bt_target_list_rv_t[] TargetList;
        }

        /* external track list just with key information */
        public struct bt_ext_track_list_t
        {
            /* track identifier */
            public UInt32 ui32_objectID;
            /* additional states */
            public UInt16 ui16_ageCount;
            public UInt16 ui16_predictionCount;
            public UInt16 ui16_staticCount;
            public float f32_trackQuality;
            bt_track_class_t classID;
            /* track position and velocity */
            public float f32_positionX_m;
            public float f32_positionY_m;
            public float f32_velocityX_mps;
            public float f32_velocityY_mps;
            public float f32_directionX;
            public float f32_directionY;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct bt_ext_track_list_array_t
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = BT_MAX_NR_OF_TRACKS)]
            public bt_ext_track_list_t[] TrackList;
        }



    }
}
