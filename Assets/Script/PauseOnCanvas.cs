using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        //打開頁面時間暫停
        UnityEngine.Time.timeScale = 0f;
    }

    private void OnDisable()
    { 
        //恢復正常速度
        UnityEngine.Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
