using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveDataToJson(string filename ,Object data)
    {
       var json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, "Scoredata");


    }

    public void LoadDataFromJson()
    {

    }
}
