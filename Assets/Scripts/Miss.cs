using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss : MonoBehaviour
{
   public Gameplay gameplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (!gameplay.massages_ative())
        {
            gameplay.miss = true;
            if (Input.touchCount == 1)
            {
                gameplay.miss = true;
            }
        }
       
    }

    IEnumerator reload()
    {

        yield return new WaitForSeconds(0.1f);
        gameplay.miss = false;
    }
}
