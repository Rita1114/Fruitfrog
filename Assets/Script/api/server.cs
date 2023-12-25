using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class server : MonoBehaviour
{

    public Getnewapi getnewapi;
    
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(getnewapi.GetNewsApi<Mydata>("/endpoint", OnGetData, OnError));
     
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(getnewapi.PostNewsApi<Mydata>("/endpoint", new Mydata { id = "123", uid = "456" }, OnPostData, OnError));
    }
   private void OnGetData(Mydata data)
    {
        
    }
    private void OnError(string error)
    {
       
       // Debug.LogError($"Error: {error}");
    }
    private void OnPostData(Mydata mydata)
    {
        Debug.LogError($"Error: {mydata}");
    }
}
