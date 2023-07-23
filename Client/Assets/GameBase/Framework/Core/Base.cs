using UnityEngine;
using System.Collections;
using GameBase;
using System.Collections.Generic;

public class Base : MonoBehaviour {
    private AppFacade m_Facade;
    private LuaManager m_LuaMgr;



    protected AppFacade facade
    {
        get
        {
            if (m_Facade == null)
            {
                m_Facade = AppFacade.Instance;
            }
            return m_Facade;
        }
    }

    protected LuaManager LuaManager {
        get {
            if (m_LuaMgr == null) {
                m_LuaMgr = facade.GetManager<LuaManager>(ManagerName.Lua);
            }
            return m_LuaMgr;
        }
    }
}
