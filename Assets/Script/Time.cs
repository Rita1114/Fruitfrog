using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{

    public int time_int = 30;//時間
    public Text Time_UI;
    public GameObject player,OverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("timer", 1, 1);  
    }
   
    void timer()
    {
        time_int -= 1;
        Time_UI.text = time_int + "";
        if (time_int == 0)
        {
            //Time_UI.text = "Time\nup";

        }
        
    }

 

    // Update is called once per frame
    void Update()
    {
        if (time_int <= 0)
        {
            player.SetActive(false);
            OverCanvas.SetActive(true);


            if (Input.GetKey(KeyCode.R))
            {
                player.SetActive(true);
                player.transform.position = new Vector3(0, 0, 0);
                
                
            }
        }


    }
}
