using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System.Reflection;
using System.IO;


namespace GameBase {
    public class GameManager : Manager {
        protected static bool initialize = false;

        /// <summary>
        /// 初始化游戏管理器
        /// </summary>
        void Awake() {
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        void Init() {
            DontDestroyOnLoad(gameObject);  //防止销毁自己

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Application.targetFrameRate = AppConst.GameFrameRate;

            LuaManager.InitStart();
        }


        /// <summary>
        /// 析构函数
        /// </summary>
        void OnDestroy() {
            if (LuaManager != null) {
                LuaManager.Close();
            }
            Debug.Log("~GameManager was destroyed");
        }
    }
}