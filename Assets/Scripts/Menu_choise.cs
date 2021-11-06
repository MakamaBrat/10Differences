using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Menu_choise : MonoBehaviour
{
    public Sprite[] sprites ;
    public Sprite[] sprites_closed;
    public SpriteRenderer[] item;
    public Transform[] it;
    Menu_item_click[] but;
    public Levelmanager Levelmanager;

    public void Start()
    { int d = 0;
        it = gameObject.GetComponentsInChildren<Transform>();
        item = new SpriteRenderer[Levelmanager.levelopen.Length];
        foreach (Transform k in it)
        {if (k.tag == "item")
            {
                item[d] = k.gameObject.GetComponent<SpriteRenderer>();
               
                d++;
            }
        }
        but = gameObject.GetComponentsInChildren<Menu_item_click>();
        stateupdate();
      


        

    }

    private void OnEnable()
    {
        stateupdate();
    }
   

    public void stateupdate()
    {
       

        for (int b = 0; b < Levelmanager.levelopen.Length; b++)
        {

                if (Levelmanager.levelopen[b] == 0)
                {
                 


                }
                else
                {
                    
                but[b].state = 1;
                but[b].Refresh();


                }
                



            if (Levelmanager.levelgone[b] == 0)
            {
                item[b].sprite =
                sprites_closed[b];


            }
            else
            {
                item[b].sprite = sprites[b];
             


            }
            but[b].num = b;


        }



    }
    }


    