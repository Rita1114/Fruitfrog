using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameoverCanvas : MonoBehaviour
{
    public Text FinalScore;

    
    // Start is called before the first frame update
    void Start()
    {
        
       
        //Debug.Log("抓");

        FinalScore.text = "最終分數是:";
    }

    public void ClickButtion()
    {
        SceneManager.LoadScene(0);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
