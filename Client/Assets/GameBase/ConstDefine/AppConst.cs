using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameBase {
    public class AppConst {
     
              
        public const bool LuaByteMode = false;                       //Lua字节码模式-默认关闭 
        public const bool DebugModel = true;                      //是否是debug模式，是的话直接读取编写中的lua文件
        public const bool LuaAbBuildModel = true;                  //是否编译lua文件为ab包

        public const int TimerInterval = 1;                         //游戏速率
        public const int GameFrameRate = 30;                        //游戏帧频

        public const string ABPackage = "ABPackage/";                //素材目录 
        public const string ABLuaPackage =  "ABPackage/Lua";         //Lua素材目录 
        public const string LuaFilePath = "ToLua/Lua";              //Lua项目文件夹    
        public const string LuaTempDir = "TempLua/";                //临时Lua存放目录

        public const string ExtName = ".unity3d";                   //素材扩展名
    }
}