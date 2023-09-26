using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCanvasOnClick : MonoBehaviour
{
    //要移除的canvas
    public GameObject canvas;
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
        //要關閉的canvas
       canvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
