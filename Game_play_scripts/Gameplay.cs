using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tests;

public class Gameplay : MonoBehaviour
{
    public Ad1 ad1;
    public Ad2 ad2;
    public Animator loop;
    public Sprite[] loop_sprites;
    public Sprite[] sprites_up;
    public Sprite[] sprites_down;
    public Transform[] l;
    public int current = 0;
    public GameObject upimage;
    public GameObject downimage;
    public GameObject[] marks;
    public GameObject[] marks2;
    public bool miss;
    int reklamacount = 0;
    public Levelmanager levelmanager;
    public int amount = 0;
    public int health;
    public int dif;
    public GameObject[] massages;
    public GameObject[] Lose_and_win;
    public GameObject rehealth_button;
    public Miss[] misses;
    public Sound sound;
   

    public Transform[] mark_dif;
 


    void Start()
    {

      
        l = gameObject.GetComponent<Transform>().GetComponentsInChildren<Transform>();

        int b = 0;

        Allmarkactive all = new Allmarkactive();
        all.Marks_active(marks);


    }
    private void Awake()
    {
        List<GameObject> m1 = new List<GameObject>();
        List<GameObject> m2 = new List<GameObject>();
        Transform[] game = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform l in game)
        {
            if (l.gameObject.tag == "levelup")
            { m1.Add(l.gameObject); }
            if (l.gameObject.tag == "leveldown")
            { m2.Add(l.gameObject); }
            marks = m1.ToArray();
            marks2 = m2.ToArray();

        }
        misses[0].make_start();
        misses[1].make_start();
        syn_content();
        
    }
    public void syn_content()
    {
        
        Sprite[] spr1 = new Sprite[100];
        Sprite[] spr2 = new Sprite[100];
        sprites_up = Resources.LoadAll<Sprite>("levels_up");
        sprites_down = Resources.LoadAll<Sprite>("levels_down");

        int k = 0;
        foreach (Sprite sp in sprites_up)
        {
       
            spr1[int.Parse(sp.name.Substring(0, sp.name.Length - 2)) - 1] = sprites_up[k];


            k++;

        }
        k = 0;
        foreach (Sprite sp in sprites_down)
        {
          
            spr2[int.Parse(sp.name.Substring(0, sp.name.Length - 2)) - 1] = sprites_down[k];


            k++;

        }


        sprites_up = spr1;
        sprites_down = spr2;

    }
    private void OnEnable()
    {
        imageupdate();
        if (levelmanager.mag > 0 || levelmanager.coin>=10)
         StartCoroutine(no_mark()); 
        if (levelmanager.first_loop_click == 0)
        { make_loop_anim(false);
            levelmanager.first_loop_click = 0;
            levelmanager.save_game();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0) && miss == true && !massages_ative())
        {missed();
            
        }




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

        if (levelmanager.super == 0)
        { health = 10; }
        else { health = 999; }
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

    public void rehealth()
    {
        ad2.rek_id = 4;
        sound.stop_sound();
        ad2.UserChoseToWatchAd();
        rehealth_button.SetActive(false);

    }

    public void eqmark()
    {
        Marks[] mark_dif1 = marks[current].GetComponentsInChildren<Marks>();
        Marks[] mark_dif2 = marks2[current].GetComponentsInChildren<Marks>();
        levelmanager.mainsound.makesound(0);
        for (int i = 0; i < mark_dif1.Length; i++)
        {
            bool a = mark_dif1[i].opened();
            bool b = mark_dif2[i].opened();
            if (a == false && a != b)
            { mark_dif2[i].makesprite(); }
            if (b == false && a != b)
            { mark_dif1[i].makesprite(); }
        }

        StopCoroutine(no_mark());
        StartCoroutine(no_mark());

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
        StopCoroutine(no_mark());
        StartCoroutine(no_mark());

       var k = loop.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if(k=="mag_act")
        {
            make_loop_anim(true);
            if (levelmanager.first_loop_click==0)
            { levelmanager.first_loop_click = 1;
                levelmanager.save_game();
            }
            
        }


        if (dif <=10)
        {
            
                if (levelmanager.mag > 0)
                { levelmanager.mag -= 1; }
                else if (levelmanager.coin >=10 )
                 { levelmanager.coin -= 10; }
                else if(levelmanager.coin<10 && levelmanager.mag<=0)
                { return; }
             
                Marks[] mark_dif = marks[current].GetComponentsInChildren<Marks>();
                foreach (Marks m in mark_dif)
                {
                    if (m.cheked == false)
                    {
                        m.founded();
                        eqmark();
                        levelmanager.mainsound.makesound(0);
                        if (dif == 10)
                        {


                            opennextlevel();



                        }

                        return;
                    }







                

                }
        }



    }

    public void opennextlevel()
    {
       
     
    
        if (current <levelmanager.levelopen.Length)
        {
           
                levelmanager.levelopen[current+1] = 1;
           

           
            
        }
        
        levelmanager.save_game();
        StartCoroutine(after_last_mark());

    }

    public void missed()
    {
      
  
        health -= 1;
        if(health==5)
        { levelmanager.mewarn(0);
            levelmanager.mainsound.makesound(1);
        }
        if (health == 2)
        { levelmanager.mewarn(1);
            levelmanager.mainsound.makesound(1);
        }
        if (health == 1)
        { levelmanager.mewarn(2);
            levelmanager.mainsound.makesound(1);
        }
        if (health == 0)
        {
            if (reklamacount == 0)
            { 
                reklamacount = 2;
            }
            else
            {
                reklamacount -= 1;
            }
            Lose_and_win[0].SetActive(true);
            sound.makesound(3);
            if (ad2.rewardedAd.IsLoaded())
            {
                rehealth_button.SetActive(true);
               
            }
            else { rehealth_button.SetActive(false); }


        }
    }

    public IEnumerator after_last_mark()
    {
        yield return new WaitForSeconds(0.7f);
        sound.makesound(4);
        Lose_and_win[1].SetActive(true);
    }
    
    public void after_win_exit()
    {
        Lose_and_win[1].SetActive(false);
        levelmanager.levelgone[current] = 1;
        levelmanager.coin += 4;
        gameObject.SetActive(false);
        levelmanager.golevelchoise();
        levelmanager.levelchoise_control.GetComponent<Menu_choise>().stateupdate();
        sound.stop_sound();

    }

    public void after_lose_exit()
    {
       
        Lose_and_win[0].SetActive(false);
        make_loop_anim(true);
            levelmanager.mesok1menu();
        sound.stop_sound();
        ad1.GameOver();
        reklamacount = 2;
    }


    public void make_loop_anim(bool state)
    {
        if(state)
        {
            loop.Play("mag_state");
            loop.GetComponent<Image>().sprite = loop_sprites[0];
        }
        else {
            loop.Play("mag_act");
            loop.GetComponent<Image>().sprite = loop_sprites[1];
        }

    }


    IEnumerator no_mark()
    {
        yield return new WaitForSeconds(10f);
        make_loop_anim(false);
        if(dif<10)
        { StartCoroutine(no_mark()); }
    }
}


