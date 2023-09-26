using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstantiateCanvasOnClick : MonoBehaviour
{
    //要產生的canvas
    public GameObject canvasPrefab;
    // Start is called before the first frame update
    void Start()
    {
       
        //按下按鈕時，呼叫ClickEvent()
        GetComponent<Button>().onClick.AddListener(() =>
        {
            ClickEvent();
        });
    }

    void ClickEvent()
    {
        //要生成的canvas
        //Instantiate(canvasPrefab, Vector2.zero, Quaternion.identity);
        canvasPrefab.SetActive(true);

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
