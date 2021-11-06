using UnityEngine;
using UnityEngine.EventSystems;



    public class zoom2 : MonoBehaviour
    {
        private Vector3 initialScale;
        public Vector3 desiredScale;
        [SerializeField]
        private float zoomSpeed = 0.1f;
        [SerializeField]
        private float maxZoom = 10f;
   public Transform transform_st;

        private void Awake()
        {
            initialScale = transform.localScale;
    
        }

    private void Update()
    {
        if (Input.touchCount >= 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            var touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            var touchOnePrevPosition = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPosition).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;

            

            var delta = Vector3.one * (difference/100 * zoomSpeed);
            var desiredScale = transform.localScale + delta;
            
            desiredScale = ClampDesiredScale(desiredScale);

            transform.localScale = desiredScale;
            transform_st.localScale = desiredScale;

        }
        }

        private Vector3 ClampDesiredScale(Vector3 desiredScale)
        {
            desiredScale = Vector3.Max(initialScale, desiredScale);
            desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
            return desiredScale;
        }
    }