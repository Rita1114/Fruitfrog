using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Getnewapi : MonoBehaviour
{
    
    private  string url ="https://random-data-api.com/api/v2/users";

    public Text content;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetNewsApi());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetNewsApi()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            string responsedate = webRequest.downloadHandler.text;

            content.text = responsedate;
        }
        else
        {
            
            Debug.Log("Error"+webRequest.error);
        }
    }
}
