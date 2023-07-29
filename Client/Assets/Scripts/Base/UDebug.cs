using UnityEngine;

namespace Base{ 

    public enum DebugLevel
    {
        Error = 3,
        Warning = 2,
        Log = 1,
    }

    public static class UDebug
    {
        /// <summary>
        /// 是否开启Debug
        /// </summary>
        public static bool enableDebugLogs = true;
        
        /// <summary>
        /// Debug等级
        /// </summary>
        public static DebugLevel debugLevel = DebugLevel.Log;

        /// <summary>
        /// 是否可以Debug
        /// </summary>
        private static bool isCanLog(DebugLevel level)
        {
            if (!enableDebugLogs)
            {
                return false;
            }
            if (debugLevel > level)
            {
                return false;
            }
            return true;
        }

        public static void Log(string message)
        {
            if (isCanLog(DebugLevel.Log))
            {
                Debug.Log(message);
            }
        }
        public static void LogWarning(string message)
        {
            if (isCanLog(DebugLevel.Warning))
            {
                Debug.LogWarning(message);
            }
        }
        public static void LogError(string message)
        {
            if (isCanLog(DebugLevel.Error))
            {
                Debug.LogError(message);
            }
        }
    }
}