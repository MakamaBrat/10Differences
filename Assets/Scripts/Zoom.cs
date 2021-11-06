using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class Zoom : MonoBehaviour
{

    public GameObject TopImage;
    public GameObject BottomImage;

    public float ZoomOutMin = 1f;
    public float ZoomOutMax = 4f;
    public float zoomMultyplayer = 0.01f;

    Vector3 start_position1;
    Vector3 start_position2;

    private Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
       start_position1 = TopImage.GetComponent<Transform>().position;
       start_position2 = BottomImage.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            var distant = Vector3.Distance(touchOne.position, touchZero.position);
            var diz = Vector3.Distance(touchOne.position, touchZero.position) - Vector3.Distance(touchOne.deltaPosition, touchZero.deltaPosition);

            

            if (distant>500 && diz>0)
       { HandleZoom(-1); }

           if (distant < 500 && diz < 0)
        { HandleZoom(1); }
            /*
           // var distant_delta = Vector3.Distance(touchOne.deltaPosition, touchZero.deltaPosition);

            var touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            var touchOnePrevPosition = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPosition).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;
           
            HandleZoom(-1*(difference * zoomMultyplayer));
            
    */

        }

        HandleZoom(-Input.GetAxis("Mouse ScrollWheel"));
      
        
        /*
        if (Input.touchCount >= 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            
            var touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            var touchOnePrevPosition = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPosition).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude/prevMagnitude;

            HandleZoom(-1 * (difference * zoomMultyplayer));
        }
        */
       // if (TopImage.GetComponent<Transform>().localScale.x!=3)
      //  { tostartpos(); }
    }
   
    private void HandleZoom(float increment)
    {
        float ZoomMagnitude = Mathf.Clamp(TopImage.GetComponent<Image>().rectTransform.localScale.x - increment, ZoomOutMin, ZoomOutMax);
        BottomImage.GetComponent<Image>().rectTransform.localScale = new Vector3(ZoomMagnitude, ZoomMagnitude);
        TopImage.GetComponent<Image>().rectTransform.localScale = new Vector3(ZoomMagnitude, ZoomMagnitude);
       

    }

   
}
