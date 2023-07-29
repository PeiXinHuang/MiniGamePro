using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView
{
    public string viewName { get; }
    private GameObject gameObject;
    private RectTransform rect;
    public BaseView(string viewName)
    {
        this.viewName = viewName;
        Init();
    }

    private void Init()
    {
        GameObject prefab = ResourcesManager.Instance.LoadPrefab(viewName);
        gameObject = GameObject.Instantiate(prefab);
#if UNITY_EDITOR
        gameObject.name = this.viewName;
#endif
        rect = gameObject.GetComponent<RectTransform>();        
        gameObject.SetActive(false);
        OnInitUI();
    }
    protected virtual void OnInitUI()
    {
        OnCustomInit();
    }
    protected virtual void OnCustomInit()
    {

    }
    public virtual void OnAfterOpen()
    {

    }
    public virtual void OnBeforeClose()
    {

    }
    public virtual void OnDestroy()
    {

    }
    public void SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent, true);
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }
    public void SetVisiable(bool visiable) {
        this.gameObject.SetActive(visiable);
    }
}
