using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
   
    private void Start()
    {
        UIManager.Instance.OpenView("MainView");
        GameManager.Instance.StartGame(1);
    }

    void Update()
    {
        
    }
}
