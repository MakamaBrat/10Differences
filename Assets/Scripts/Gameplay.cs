using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public Sprite[] sprites_up;
    public Sprite[] sprites_down;
    public Transform[] l;
    public int current = 0;
    public GameObject upimage;
    public GameObject downimage;
    public GameObject[] marks;
    public GameObject[] marks2;
    public bool miss;

    public Levelmanager levelmanager;
    public int amount = 0;
    public int health;
    public int dif;
    public GameObject[] massages;

    public Transform[] mark_dif;
 


    void Start()
    {
        l = gameObject.GetComponent<Transform>().GetComponentsInChildren<Transform>();

        int b = 0;
        foreach (Transform k in l)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0) && miss == true && !massages_ative())
        {missed(); }




    }

    public void imageupdate()
    {
        upimage.GetComponent<Image>().sprite = sprites_up[current];
        downimage.GetComponent<Image>().sprite = sprites_down[current];
        for (int i = 0; i < marks.Length; i++)
        {
            if (i == current)
            {
                marks[i].SetActive(true);
                marks2[i].SetActive(true);
            }
            else
            {
                marks[i].SetActive(false);
                marks2[i].SetActive(false);
            }
        }
    }

  

    public void regame()
    {

        health = 10;
        dif = 0;
  

        Transform[] mark_dif = marks[current].GetComponentsInChildren<Transform>();


        int b = 0;
        foreach (Transform m in mark_dif)
        {
            if (b > 0)
            {
                m.gameObject.GetComponent<SpriteRenderer>().color = m.gameObject.GetComponent<Marks>().color1;
                m.gameObject.GetComponent<Marks>().cheked = false;
            }
            b++;
        }

        Transform[] mark_dif2 = marks2[current].GetComponentsInChildren<Transform>();


       b = 0;
        foreach (Transform m in mark_dif2)
        {
            if (b > 0)
            {
                m.gameObject.GetComponent<SpriteRenderer>().color = m.gameObject.GetComponent<Marks>().color1;
                m.gameObject.GetComponent<Marks>().cheked = false;
            }
            b++;
        }
    }

    public void eqmark()
    {
        Marks[] mark_dif1 = marks[current].GetComponentsInChildren<Marks>();
        Marks[] mark_dif2 = marks2[current].GetComponentsInChildren<Marks>();

        for (int i = 0; i < mark_dif1.Length; i++)
        {
            bool a = mark_dif1[i].opened();
            bool b = mark_dif2[i].opened();
            if (a == false && a != b)
            { mark_dif2[i].makesprite(); }
            if (b == false && a != b)
            { mark_dif1[i].makesprite(); }
        }


    }

    public bool massages_ative()
    {
        bool k = false;
        foreach (GameObject m in massages)
        {
            if (m.active)
            {
                k = true;
            }
        

        }
        return k;
    }
   


    public void click()
    {


        dif += 1;



        




    }

    public void maguse()
    {
        if (levelmanager.mag>0 || levelmanager.coin>10)
        {
            if (levelmanager.mag <= 0)
            { levelmanager.coin -= 10; }
            else
            { levelmanager.mag -= 1; }
      Marks[] mark_dif = marks[current].GetComponentsInChildren<Marks>();
            foreach (Marks m in mark_dif)
            {
                if (m.cheked == false)
                {
                    m.founded();
                    eqmark();
                    if (dif == 10)
                    {
                       
                        if (current < 6)
                        { opennextlevel(); }
                  


                    }
                 
                    return;
                }

               





            }
           
        }
 



    }

    public void opennextlevel()
    {
        levelmanager.levelgone[current] = 1;
        levelmanager.coin += 4;
        levelmanager.mag += 1;
     
        int  t = 0;
        foreach (int b in levelmanager.levelopen)
        {
            if (b == 0)
            {
                levelmanager.levelopen[t] = 1;
              
                continue;
            }

           
            t += 1;
        }
        levelmanager.golevelchoise();
        levelmanager.levelchoise_control.GetComponent<Menu_choise>().stateupdate();
    }

    public void missed()
    {
  
        health -= 1;
        if(health==5)
        { levelmanager.mewarn(0); }
        if (health == 2)
        { levelmanager.mewarn(1); }
        if (health == 1)
        { levelmanager.mewarn(2); }
        if (health == 0)
        { levelmanager.mesok1menu(); }
    }
    
}


