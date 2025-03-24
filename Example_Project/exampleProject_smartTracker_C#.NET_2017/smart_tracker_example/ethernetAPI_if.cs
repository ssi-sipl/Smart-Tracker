using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace smart_tracker_example
{
    public class ethernetAPI_if
    {

        [DllImport("ethernetAPI.dll", EntryPoint = "ETH_getApiVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern ETHResult_t ETH_getApiVersion(ref float version);

        [DllImport("ethernetAPI.dll", EntryPoint = "ETH_exitSystem", CallingConvention = CallingConvention.Cdecl)]
        public static extern ETHResult_t ETH_exitSystem(IntPtr pHandle);

        [DllImport("ethernetAPI.dll", EntryPoint = "ETH_initSystem", CallingConvention = CallingConvention.Cdecl)]
        public static extern ETHResult_t ETH_initSystem(ref IntPtr pHandle, Byte ipPart1, Byte ipPart2, Byte ipPart3, Byte ipPart4, UInt32 udpPortNumber);

        [DllImport("ethernetAPI.dll", EntryPoint = "ETH_getTargetList", CallingConvention = CallingConvention.Cdecl)]
        public static extern ETHResult_t ETH_getTargetList(IntPtr pHandle, IntPtr pTargetList);                             /* get target list  */

        public const int ETH_MAX_TARGETS = 512;

        public enum ETHResult_t {
            ETH_ERR_OK = 0,
            ETH_ERR_HANDLE_NOT_INITIALISED,
            ETH_ERR_SYSTEM_ALREADY_INITIALISED,
            ETH_ERR_SYSTEM_NOT_INITIALISED,
            ETH_ERR_CREATE_HANDLE,
            ETH_ERR_NULL_POINTER,
            ETH_ERR_FUNCTION_DEPRECATED, // 50
            ETH_ERR_PORT_ALREADY_INITIALISED,
            ETH_ERR_PORT_IN_USE,
            ETH_ERR_CONNECTION_CLOSED,
            ETH_ERR_CONNECTION_RESET,
            ETH_ERR_COMMUNICATION_TIMEOUT,
            ETH_ERR_COMMUNICATION_ERROR,
            ETH_ERR_CONNECTION_LOST,
            ETH_ERR_TARGET_NOT_ENOUGH_DATA_AVAILABLE,
            ETH_ERR_TARGET_DATA_CORRUPTED,
            ETH_ERR_TARGET_DATA_SIZE,
            ETH_ERR_RAW_NOT_ENOUGH_DATA_AVAILABLE,
            ETH_ERR_RAW_DATA_CORRUPTED,
            ETH_ERR_RAW_DATA_SIZE,
            ETH_ERR_MUTEX_ERROR,
            ETH_ERR_NETWORK_INTERFACE
        }

        public enum ETHTargetListError_t
        {
            ETH_TARGET_LIST_OK = 0,
            ETH_TARGET_LIST_FULL = 1,
            ETH_TARGET_LIST_ALREADY_REQUESTED = 2,
            ETH_TARGET_LIST_NOT_ACTIVE = 3,
            ETH_TARGET_LIST_DATA_CORRUPTED = 4
        }

        public struct ETHTarget_t
        {
            public float signalStrength;   /* [dB] */
            public float range;            /* [m]*/
            public float velocity;         /* [m/s] */
            public float angleAzimuth;     /* [°] */
            public float reserved1;
            public float reserved2;
        }

        public struct ETHTargetListError_u
        {
            public ETHTargetListError_t ETHTargetListError;
            public UInt32 dummy;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct ETHTargetList_t
        {
            public UInt32 iError;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ETH_MAX_TARGETS)]
            public ETHTarget_t[] targetList;
            public UInt16 nrOfTargets;
            public UInt16 frameID;
        }


    }
}
