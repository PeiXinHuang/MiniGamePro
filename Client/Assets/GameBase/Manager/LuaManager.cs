using UnityEngine;
using System.Collections;
using LuaInterface;

namespace GameBase {
    public class LuaManager : Manager {
        private LuaState lua;
        private LuaLooper loop = null;

        // Use this for initialization
        void Awake() {
            lua = new LuaState();
            this.OpenLibs();
            lua.LuaSetTop(0);

            LuaBinder.Bind(lua);
            DelegateFactory.Init();
            LuaCoroutine.Register(lua, this);
        }

        public void InitStart() {
            this.lua.Start();    //启动LUAVM
            this.StartMain();
            this.StartLooper();
        }

        void StartLooper() {
            loop = gameObject.AddComponent<LuaLooper>();
            loop.luaState = lua;
        }


        void StartMain() {
            lua.DoFile("Main.lua");

            LuaFunction main = lua.GetFunction("Main");
            main.Call();
            main.Dispose();
            main = null;    
        }
        
        /// <summary>
        /// 初始化加载第三方库
        /// </summary>
        void OpenLibs() {
            lua.OpenLibs(LuaDLL.luaopen_pb);      
            lua.OpenLibs(LuaDLL.luaopen_lpeg);
            lua.OpenLibs(LuaDLL.luaopen_bit);
        }

        /// <summary>
        /// 初始化Lua代码加载路径
        /// </summary>
        void InitLuaPath() {
            //lua.AddSearchPath(Util.LuaDataPath);
        }

        /// <summary>
        /// 初始化LuaBundle
        /// </summary>
        void InitLuaBundle() {
            //if (loader.beZip)
            //{
      
            //}
        }

        public void DoFile(string filename) {
            lua.DoFile(filename);
        }

        // Update is called once per frame
        public object[] CallFunction(string funcName, params object[] args) {
            LuaFunction func = lua.GetFunction(funcName);
            if (func != null) {
                return func.LazyCall(args);
            }
            return null;
        }

        public void LuaGC() {
            lua.LuaGC(LuaGCOptions.LUA_GCCOLLECT);
        }

        public void Close() {
            loop.Destroy();
            loop = null;

            lua.Dispose();
            lua = null;
        }
    }
}