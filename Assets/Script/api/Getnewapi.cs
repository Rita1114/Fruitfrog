using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.Net;
using System;
using UnityEditor.PackageManager;


public class Getnewapi : MonoBehaviour
{

    private const string url = "https://random-data-api.com/api/v2/banks";

    public Text content;

    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Get());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*IEnumerable UpLoadFileCoroutine(string data)
    {
        WWWForm form = new WWWForm();
        form.AddField("action","load");
        form.AddField("file","file");
        byte[] bytes = Encoding.Default.GetBytes(data);
        form.AddBinaryData("file", bytes, data, "");

        UnityWebRequest request = UnityWebRequest.Post(url,form);
        yield return request.SendWebRequest();


        if(request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("error");
        }
        else
        {
            if(request.isDone)
            {
                Debug.Log("success");
                yield return new WaitForSeconds(1f);
            }
        }
    }*/
    IEnumerator Get()
    {
        UnityWebRequest webrequest = UnityWebRequest.Get(url);
        yield return webrequest.SendWebRequest();
        if(webrequest.result == UnityWebRequest.Result.Success)
        {
            string responseData = webrequest.downloadHandler.text;
            Mydata myDatas = JsonUtility.FromJson<Mydata>(responseData);
            content.text = responseData;
        }

    }

    public IEnumerator GetNewsApi<T>(string endpoint,Action<T>onSuccess,Action<string>onError)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string responsedata = webRequest.downloadHandler.text;
                if (!string.IsNullOrEmpty(responsedata))
                {
                    T mydata = JsonUtility.FromJson<T>(responsedata);
                    onSuccess?.Invoke(mydata);
                    content.text = mydata.ToString();
                    Debug.Log(responsedata);
                    content.text = responsedata;
                }
                Debug.Log("123"); 
            }
            else
            {
               // onError?.Invoke(webRequest.error);
            }
        }
            
   }
    public IEnumerator PostNewsApi<T>(string endpoint,object newsdata,Action<T>onSuccess,Action<string>Error)
    {
        string jsonData = JsonUtility.ToJson(newsdata);
        byte[] postDataBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

        using(UnityWebRequest webRequest = UnityWebRequest.Post(url,endpoint))
        {
            yield return webRequest.SendWebRequest();
            if(webRequest.result ==UnityWebRequest.Result.Success)
            {
                webRequest.uploadHandler = new UploadHandlerRaw(postDataBytes);
                webRequest.uploadHandler.contentType = "application/json";
                //webRequest.downloadHandler = new DownloadHandlerBuffer();
                //webRequest.SetRequestHeader("content type","application/json");
                string json = webRequest.downloadHandler.text;
                T data = JsonUtility.FromJson<T>(json);
                onSuccess?.Invoke(data);
                Debug.Log(jsonData);
                Debug.Log("666");
            }
            else
            {
                Error?.Invoke(webRequest.error);
            }
            Debug.Log("456");
        }
    }
        
 }
    
