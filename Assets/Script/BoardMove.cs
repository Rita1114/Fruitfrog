using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoardMove : MonoBehaviour
{
    public float fadetime = 1f;

    public CanvasGroup canvasGroup;

    public RectTransform rectTransform;
    
    // Start is called before the first frame update

    
    public void Start()
    {
        fadeIn();
    }
    public void fadeIn()
    {

        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(752, 0, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0),fadetime,false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadetime);
    }
    public void fadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0, 0, 0);
        rectTransform.DOAnchorPos(new Vector2(752, 0),fadetime,false).SetEase(Ease.InElastic);
        canvasGroup.DOFade(0, fadetime);
    }
}
