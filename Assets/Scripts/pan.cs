using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class pan : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    public RectTransform rectTransform2;
    Vector3 startposition;
  
    public float x;
    public float y;
   

    private void Start()
    { 
        rectTransform = GetComponent<RectTransform>();
        startposition = rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
         x = rectTransform.position.x;
         y = rectTransform.position.y;
     


      
            { rectTransform.anchoredPosition += eventData.delta*1.6f;
            rectTransform2.anchoredPosition += eventData.delta*1.6f;
        }




    }
}