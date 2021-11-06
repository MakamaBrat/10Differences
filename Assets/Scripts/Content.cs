using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Content : MonoBehaviour
{
    public Gameplay gameplay;
    public int mouse = 0;
    float timer;
   public bool done = false;
    
    void Start()
    {
        
    }
  

    void Update()
    {
       
    }
    private void OnMouseOver()
    {
        done = false;

        if (Input.GetMouseButton(0) && Input.touchCount == 1 && done==false && gameplay.amount==0)
        {

          
            
                timer += Time.deltaTime;
                
            if (timer > 1.5f)
            {
                mouse = 1;

                gameplay.click();
                mouse = 0;
                done = true;

            }
        }
        else { timer = 0;
            done = false;
            gameplay.amount = 0;
        }

        


    }

    private void OnMouseExit()
    {


        if (Input.GetMouseButton(0))
        {

         
                done = false;



        }


    }




}

