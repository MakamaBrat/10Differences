using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marks : MonoBehaviour
{
    public Gameplay gameplay;
    Animator anim;
    public int mouse = 0;
    public Color color1 = new Color(0, 0, 0, 0);
    public Color color2 = new Color(255, 255, 255, 255);
    public bool cheked;
    float timer = 0;

  
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = color1;
        cheked = false;
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name=="Cursor")
        {
            if (Input.GetMouseButton(0) && Input.touchCount == 1)
            {

                if (gameObject.GetComponent<SpriteRenderer>().color == color1 && Input.touchCount == 1)
                {
                    timer += Time.deltaTime;

                    if (timer > 1.5f)
                    {
                        mouse = 2;
                        gameObject.GetComponent<SpriteRenderer>().color = color2;
                        gameplay.eqmark();
                        gameplay.dif += 1;
                        cheked = true;
                        mouse = 0;
                    }
                }
            }
            else { timer = 0; }
        }
    }

    void Update()
    {
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            if (cheked == false && distance<0.5f && !gameplay.massages_ative())
            {
                makesprite();
                gameplay.eqmark();
                gameplay.dif += 1;
                cheked = true;
                gameplay.health += 3;
                anim.SetBool("click",true);
                if (gameplay.dif == 10)
                {
                    gameplay.opennextlevel();

                }
            }
           
        }

    }

   
    

        

    

    public void founded()
    {
        mouse = 2;
        gameObject.GetComponent<SpriteRenderer>().color = color2;
        gameplay.eqmark();
        gameplay.dif += 1;
        cheked = true;


    }

    public bool opened()
    { if (gameObject.GetComponent<SpriteRenderer>().color == color1)
            return true;
        else return false; }

    public void makesprite()
    { gameObject.GetComponent<SpriteRenderer>().color = color2; }

    public GameObject myself()
    { return gameObject; }

   
}
