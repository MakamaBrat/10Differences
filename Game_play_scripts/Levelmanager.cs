using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelmanager : MonoBehaviour
{
  

    [Header("Layouts")]
    public GameObject mainmenu;
    public GameObject levelchoise;
    public GameObject levelchoise_control;
    public GameObject gameplay;
    public GameObject settings;
    public GameObject shop;
    public GameObject aboutus;
    public Ad3 banner;
    int b = 0;
    [Header("Data")]
    public int coin;
    public int mag;
    public int super;
    public int calendar_day;
    public int first_loop_click;
    public int everyday_step;
    public int[] levelopen;
    public int[] levelgone;

    [Header("Messeges")]
    public GameObject exit;
    public GameObject ok1;
    public GameObject ok2;
    public GameObject warn;
    public GraphicRaycaster raycaster;
    public SpriteRenderer spwarn;
    public Sprite[] sprite;


    public GameObject panel;
    public Sound mainsound;


    public Text texts_coin;
    public Text texts_mag;
   
    

    [Header("Settings")]
    public float sound;
    public float music;

    void Start()
    {

        mainsound = gameObject.GetComponent<Sound>();
        levelgone = new int[levelopen.Length];
        
        loadsaves();

        
        levelchoise_control.GetComponent<Menu_choise>().Start();
    }

    public void loadsaves()
    {
        b = 0;
        foreach (int k in levelopen)
        {
            if (PlayerPrefs.HasKey("levelopen" + b))
                levelopen[b] = PlayerPrefs.GetInt("levelopen" + b);
            else
            {
                levelopen[b] = 0;
            }
          ;
            b++;
        }
        b = 0;
        foreach (int k in levelgone)
        {
            if (PlayerPrefs.HasKey("levelgone" + b))
                levelgone[b] = PlayerPrefs.GetInt("levelgone" + b);
            else
            {
                levelgone[b] = 0;
            }
            b++;
        }
        levelopen[0] = 1;
        if (PlayerPrefs.HasKey("coin"))
        { coin = PlayerPrefs.GetInt("coin"); }
        else
        {
            coin = 30;
        }

        if (PlayerPrefs.HasKey("mag"))
        { mag = PlayerPrefs.GetInt("mag"); }
        else
        {
            mag = 10;
        }

        if (PlayerPrefs.HasKey("super"))
            super = PlayerPrefs.GetInt("super");
        else
        {
            super = 0;
        }
        if (PlayerPrefs.HasKey("calendar_day"))
            calendar_day = PlayerPrefs.GetInt("calendar_day");
        else
        {
           calendar_day = 0;
        }

        if (PlayerPrefs.HasKey("first_loop_click"))
            everyday_step = PlayerPrefs.GetInt("first_loop_click");
        else
        {
            everyday_step = 0;
        }

        if (PlayerPrefs.HasKey("first_loop_click"))
            everyday_step = PlayerPrefs.GetInt("first_loop_click");
        else
        {
            everyday_step = 0;
        }
    }
       
    void Update()
    {
        if (texts_coin.text != coin.ToString())
        { texts_coin.text = coin.ToString(); }

        if (texts_mag.text != mag.ToString())
        { texts_mag.text = mag.ToString(); }


    }
    public void golevelchoise()
    {
       

        mainmenu.SetActive(false);
        levelchoise.SetActive(true);
        gameplay.SetActive(false);
            settings.SetActive(false);
        shop.SetActive(false);
        levelchoise_control.GetComponent<Menu_choise>().stateupdate();

    }

    public void gogameplay()
    {

        mainmenu.SetActive(false);
        levelchoise.SetActive(false);
        gameplay.SetActive(true);
        settings.SetActive(false);
        shop.SetActive(false);
        aboutus.SetActive(false);

        
    }

    public void gosettings()
    {
        if (!gameplay.GetComponent<Gameplay>().Lose_and_win[0].activeInHierarchy && !gameplay.GetComponent<Gameplay>().Lose_and_win[1].activeInHierarchy)
        {

            settings.SetActive(true);
            raycaster.enabled = false;
        }

        
    }

    public void exitsettings()
    {


        settings.SetActive(false);
        aboutus.SetActive(false);
        raycaster.enabled = true;



    }

    public void goshop()
    {
       
        mainmenu.SetActive(false);
        levelchoise.SetActive(false);
        gameplay.SetActive(false);
        settings.SetActive(false);
        shop.SetActive(true);
        aboutus.SetActive(false);

    }

    public void goaboutus()
    {
        if (!gameplay.GetComponent<Gameplay>().Lose_and_win[0].activeInHierarchy && !gameplay.GetComponent<Gameplay>().Lose_and_win[1].activeInHierarchy)
        {
            aboutus.SetActive(true);
            raycaster.enabled = false;
        }
    }


    public void gomainmenu()
    {
        if (!gameplay.GetComponent<Gameplay>().Lose_and_win[0].activeInHierarchy && !gameplay.GetComponent<Gameplay>().Lose_and_win[1].activeInHierarchy)
        {
            if (!GameplayActive())
            {
                levelchoise.SetActive(false);
                gameplay.SetActive(false);
                settings.SetActive(false);
                shop.SetActive(false);
                aboutus.SetActive(false);
                mainmenu.SetActive(true);
                raycaster.enabled = true;
            }
            else { mesexit(); }
        }
    }
    public bool GameplayActive()
    { return gameplay.gameObject.active; }

    public void maguse()
    {
        
        if (GameplayActive())
        {
           
            gameplay.GetComponent<Gameplay>().maguse();
        }


    }

    public void magupdate()
    {
        texts_mag.text =mag.ToString();

    }


    public void gameexit()
    { Application.Quit(); }

    public void mesexit()
    {
        if (gameplay.GetComponent<Gameplay>().dif < 10)
        {
            raycaster.enabled = false;
            exit.SetActive(true);
        }


    }

    public void meok1()
    {
        exit.SetActive(false);

        raycaster.enabled = false;
        ok1.SetActive(true);


    }

    public void mesok1menu()
    {
        banner.RequestBanner();
        ok1.SetActive(false);
        levelchoise.SetActive(true);
        gameplay.SetActive(false);
        settings.SetActive(false);
        shop.SetActive(false);
        aboutus.SetActive(false);
        mainmenu.SetActive(false);
        save_game();
        mainsound.makesound(2);
        raycaster.enabled = true;
    }

    public void meok2()
    {
        exit.SetActive(false);
        raycaster.enabled = false;
        ok2.SetActive(true);


    }

    public void mewarn(int i)
    {
        raycaster.enabled = false;
        warn.SetActive(true);
        if (i == 0)
           spwarn.sprite=sprite[0] ;
        if (i == 1)
            spwarn.sprite = sprite[1];
        if (i == 2)
            spwarn.sprite = sprite[2];

    }

    public void reumegame()
    {
        StartCoroutine(i_reumegame());
           
        


    }

    IEnumerator i_reumegame()
    {
        yield return new WaitForSeconds(0.1f);
        raycaster.enabled = true;
        ok2.SetActive(false);
        ok1.SetActive(false);
        warn.SetActive(false);

    }

 



   public void save_game()
    {
        b = 0;
        foreach (int k in levelopen)
        {
            
                PlayerPrefs.SetInt("levelopen" + b,levelopen[b]);
           
            
            b++;
        }
        b = 0;
        foreach (int k in levelgone)
        {
           
               PlayerPrefs.SetInt("levelgone" + b,levelgone[b]);
            
            b++;
        }
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("mag", mag);
        PlayerPrefs.SetInt("super", super);
        PlayerPrefs.SetInt("calendar_day", calendar_day);
        PlayerPrefs.SetInt("everyday_step", everyday_step);
        PlayerPrefs.SetInt("first_loop_click", first_loop_click);
    }


}
