using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;

public class Getnewapi : MonoBehaviour
{
    
    private  string url ="https://random-data-api.com/api/v2/users";

    public Text content;

    public Mydate _mydate;
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

            List<Mydate> myDates = JsonUtility.FromJson<List<Mydate>>(responsedate);
            Debug.Log("Data Count: " + myDates.Count);
           
            myDates = myDates.OrderBy(date => date.Password).ToList();
            
            
            foreach (Mydate date in myDates)
            {
                Debug.Log("name:" + date.ID + ", uid" +date.Uid);
            }
            Debug.Log(responsedate);

            content.text = responsedate;
        }
        else
        {
            
            Debug.Log("Error"+webRequest.error);
        }
    }
    
}
