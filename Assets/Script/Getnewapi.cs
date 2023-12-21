using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.Net;


public class Getnewapi : MonoBehaviour
{
    
    private  string url ="https://random-data-api.com/api/v2/users";

    public Text content;

    public Mydata mydata;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetNewsApi());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerable UpLoadFileCoroutine(string data)
    {
        WWWForm form = new WWWForm();
        form.AddField("action","load");
        form.AddField("file","file");
        byte[] bytes = Encoding.Default.GetBytes(data);
        form.AddBinaryData("file", bytes, data, "");

        UnityWebRequest request = UnityWebRequest.Post(url,form);
        yield return request.SendWebRequest();


        if(request.isNetworkError || request.isHttpError)
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
    }




    IEnumerator GetNewsApi()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            string responsedate = webRequest.downloadHandler.text;

           List<Mydata> myDatas = JsonUtility.FromJson<List<Mydata>>(responsedate);
           //Debug.Log("Data Count: " + myDates.Count);
           
            myDatas = myDatas.OrderBy(data => data.Name).ToList();
            
            foreach (Mydata data in myDatas)
            {
                Debug.Log("name:" + data.Name + ", uid" +data.Score);
            }
            //Debug.Log(responsedate);
            content.text = responsedate;
        }
        else
        {
          //  Debug.Log("Error"+webRequest.error);
        }
    }
    
}
