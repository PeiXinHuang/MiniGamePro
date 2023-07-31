using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
   
    private void Start()
    {
        UIManager.Instance.OpenView("MainView");
        GameManager.Instance.StartGame(1);
        RankControl.send_get_rank_data_c2s(66);
        NetManager.Instance.StartDownloadRes(() =>
        {
            UDebug.Log("обть");
        });
    }

    void Update()
    {
        
    }
}
