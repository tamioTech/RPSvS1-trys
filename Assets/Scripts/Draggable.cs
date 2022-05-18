using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler ,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("clicked on something");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("begin drag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("dragging");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("stop dragging");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    

    
}
