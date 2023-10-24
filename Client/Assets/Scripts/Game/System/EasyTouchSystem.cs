using HedgehogTeam.EasyTouch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyTouchSystem : BaseSystem
{
    private bool isDragging = false;
    private GameObject draggedObject;
    private Vector3 offset;

    public EasyTouchSystem()
    {
        EasyTouch.On_SimpleTap += OnTouchClick;
        EasyTouch.On_DragStart += OnDragStart;
        EasyTouch.On_Drag += OnDrag;
        EasyTouch.On_DragEnd += OnDragEnd;
    }

    private void OnTouchClick(Gesture gesture)
    {
        GameObject pickobj = gesture.pickedObject;
        if(pickobj)
        {
            WorldObjHelper worldObj = pickobj.GetComponent<WorldObjHelper>();
            if (worldObj)
            {
                Entity entity = EntityManager.Instance.GetEntityById(worldObj.uid);
                entity.OnTouchClick();
            }
        }
    }
    private void OnDragStart(Gesture gesture)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(gesture.position);
        if (Physics.Raycast(ray, out hit))
        {
            draggedObject = hit.collider.gameObject;
            offset = draggedObject.transform.position - gesture.GetTouchToWorldPoint(draggedObject.transform.position);
            isDragging = true;
        }
    }

    private void OnDrag(Gesture gesture)
    {
        if (isDragging && draggedObject != null)
        {
            Debug.Log(draggedObject);
            Ray ray = Camera.main.ScreenPointToRay(gesture.position);
            draggedObject.transform.position = gesture.GetTouchToWorldPoint(draggedObject.transform.position) + offset;
        }
    }

    private void OnDragEnd(Gesture gesture)
    {
        isDragging = false;
        draggedObject = null;
    }

    public void onDestroy()
    {
        EasyTouch.On_SimpleTap -= OnTouchClick;
        EasyTouch.On_DragStart -= OnDragStart;
        EasyTouch.On_Drag -= OnDrag;
        EasyTouch.On_DragEnd -= OnDragEnd;
    }
}

