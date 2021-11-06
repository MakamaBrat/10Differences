using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ScrollRect TopScrollRect;
    public ScrollRect BottomScrollRect;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       










    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        TopScrollRect?.OnBeginDrag(eventData);
        BottomScrollRect?.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
       TopScrollRect?.OnDrag(eventData);
       BottomScrollRect?.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        TopScrollRect?.OnEndDrag(eventData);
        BottomScrollRect?.OnEndDrag(eventData);
    }



    public void Click()
    {
        Debug.Log("Clicked");
    }
}
