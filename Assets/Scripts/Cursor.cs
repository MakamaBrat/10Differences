using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Gameplay gameplay;
    public bool marks = false;
    public bool misss = false;
    public float timer = 0;
    public Collider2D Collider2D;
    public Collider2D[] colliders;
  
    
  
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Collider2D = collision;
            

    }


    void Start()
    {
        
    }

    public void Makeclick()
    {
        colliders = Physics2D.OverlapCircleAll(gameObject.GetComponent<Transform>().position, 0.001f);
        foreach (Collider2D col in colliders)
        {




            gameObject.SetActive(false);
            Touch touch = Input.GetTouch(0);
            touch.phase = TouchPhase.Ended;



            if (col.transform.tag == "misss")
            { misss = true; }
            else { misss = false; }

            if (col.transform.tag == "mark")
            { marks = true; }
            else
            {
                marks = false;

            }

            if (marks == true)
            {
             
                if (col.GetComponent<Marks>().cheked == false)
                {
                    
                    if (gameplay.dif < 10)
                    {

                        col.GetComponent<Marks>().founded();
                        gameplay.eqmark();


                    }
                    if (gameplay.dif == 10)
                    {

                        gameplay.levelmanager.coin += 3;
                        if (gameplay.current < 6)
                        { gameplay.levelmanager.levelopen[gameplay.current + 1] = 1; }
                        gameplay.levelmanager.golevelchoise();

                    }

                    return;
                }
               

            }


        }
        if (misss == true)
        { gameplay.health -= 1; }

    }
    // Update is called once per frame
    void Update()
    {
       
        }
      
    
}
