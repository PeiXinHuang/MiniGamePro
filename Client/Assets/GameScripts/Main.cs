using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameBase;

public class Main : MonoBehaviour
{
    private void Start()
    {
        AppFacade.Instance.AddManager<LuaManager>(ManagerName.Lua);
        AppFacade.Instance.AddManager<GameManager>(ManagerName.Game);
    }
}
