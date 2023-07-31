using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetManager : Manager<NetManager>
{
    private string serverUrl = "http://127.0.0.1:8000";
    
    private List<string> DebugModule = new List<string>
    {
        "rank",
    };

    public void Send<T,K>(string module, T sendData, System.Action<K> callback)
    {
        string msgData = JsonUtility.ToJson(sendData);
        if (DebugModule.Contains(module))
        {
            UDebug.Log(string.Format("{0}:{1}", module.ToString(), msgData.ToString()));
        }
        StartCoroutine(PostRequest<K>(module, msgData, callback));
    }

    private IEnumerator PostRequest<K>(string module, string jsonData, System.Action<K> callBack)
    {
        using (UnityWebRequest request = new UnityWebRequest(serverUrl + "/" + module, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            if(request.result == UnityWebRequest.Result.Success)
            {
                try
                {
                    K responseData = JsonUtility.FromJson<K>(request.downloadHandler.text);
                    if (DebugModule.Contains(module))
                    {
                        UDebug.Log(string.Format("{0}:{1}:{2}", module.ToString(), typeof(K).Name, request.downloadHandler.text.ToString()));
                    }
                    callBack(responseData);
                }
                catch (System.Exception ex)
                {
                    UDebug.LogError(string.Format("web receive {0} error {1}", module.ToString(), ex.ToString()));
                }
            }
            else
            {
                UDebug.LogError("Error:" + request.error);
            }
        }
    }

    private string downloadUrl = "http://127.0.0.1:8001";
  
    public void StartDownloadRes(System.Action callback)
    {
        StartCoroutine(DownloadResource("01.txt", callback));
    }
    private IEnumerator DownloadResource(string path, System.Action callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(downloadUrl + "/" + path);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            byte[] data = request.downloadHandler.data;
            UDebug.Log("AssetBundle downloaded successfully!" + System.Text.Encoding.UTF8.GetString(data));
        }
        else
        {
            UDebug.LogError("Failed to download AssetBundle. Error: " + request.error);
        }
    }
}
