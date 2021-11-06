using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_item_click : MonoBehaviour
{

    public Levelmanager Levelmanager;
    public int num=0;
    public Gameplay gameplay;
    public int state = 0;
   public SpriteRenderer sp;
    public Sprite[] sprites= new Sprite[4];
  
    public void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        Levelmanager = GameObject.Find("Main Camera").GetComponent<Levelmanager>();
        Transform[] allchild = GetComponentsInChildren<Transform>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (sp.sprite==sprites[1] && Input.GetMouseButtonUp(0))
        {
           
            sp.sprite = sprites[0];
        }
        if (sp.sprite == sprites[3] && Input.GetMouseButtonUp(0))
        {
            click();
            sp.sprite = sprites[2];
        }

    }

    public void click()
    {
        gameplay.current = num;
        if (Levelmanager.levelopen[num] == 1)
        {
            gameplay.imageupdate();
            Levelmanager.gogameplay();
           
            gameplay.regame();
        }
        if (Levelmanager.levelopen[num] == 0 && Levelmanager.coin>=3)
        {
            Levelmanager.coin-= 3;
            Levelmanager.levelopen[num] = 1;
            GetComponentInParent<Menu_choise>().stateupdate();
     
        }
    }


    public void Refresh()
    {
       

        if (state == 0)
        { sp.sprite = sprites[0]; }
        else { sp.sprite = sprites[2]; }
        
        
        

    }

    private void OnMouseDown()
    {

        if (state == 0)
        { sp.sprite = sprites[1]; }
        else { sp.sprite = sprites[3]; }

        
         


    }
    
    


}
