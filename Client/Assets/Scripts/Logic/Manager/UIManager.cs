using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager<UIManager>
{
 
    public UIManager() { }

    private Transform uiRoot = null;
    public Dictionary<string, BaseView> openViewDir;
    private void Awake()
    {
        uiRoot = GameObject.Find("Canvas").GetComponent<Transform>();
        openViewDir = new Dictionary<string, BaseView>();
    }

    public BaseView OpenView(string viewName)
    {
        if(!openViewDir.ContainsKey(viewName))
        {
            var newView = this.CreateView(viewName);
            return newView;
        }
        return openViewDir[viewName];
    }

    public BaseView CreateView(string viewName)
    {
        BaseView baseView = new BaseView(viewName);

        baseView.SetParent(uiRoot);
        baseView.SetVisiable(true);
        baseView.OnAfterOpen();

        return baseView;
    }
}
