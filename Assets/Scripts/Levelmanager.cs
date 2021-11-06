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
    int b = 0;
    [Header("Data")]
    public int coin;
    public int mag;
    public int[] levelopen= new int[11];
    public int[] levelgone= new int[11];

    [Header("Messeges")]
    public GameObject exit;
    public GameObject ok1;
    public GameObject ok2;
    public GameObject warn;
    public GraphicRaycaster raycaster;
    public SpriteRenderer spwarn;
    public Sprite[] sprite;


    public GameObject panel;
    


    public Text texts_coin;
    public Text texts_mag;
   
    

    [Header("Settings")]
    public float sound;
    public float music;

    void Start()
    {
     
        foreach (int k in levelopen)
        {
            if (PlayerPrefs.HasKey("levelopen" + b))
                levelopen[b] = PlayerPrefs.GetInt("levelopen" + b);
            else {
                levelopen[b] = 0; }
           ;
            b++;
        }
        b = 0;
        foreach(int k in levelgone)
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
        coin = 100;
        mag = 20;
        levelchoise_control.GetComponent<Menu_choise>().Start();
    }

    // Update is called once per frame
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
        
       
        settings.SetActive(true);
        raycaster.enabled = false;
      

        
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

        aboutus.SetActive(true);
        raycaster.enabled = false;

    }


    public void gomainmenu()
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
        raycaster.enabled = false;
        exit.SetActive(true);


    }

    public void meok1()
    {
        exit.SetActive(false);

        raycaster.enabled = false;
        ok1.SetActive(true);


    }

    public void mesok1menu()
    {
        ok1.SetActive(false);
        levelchoise.SetActive(false);
        gameplay.SetActive(false);
        settings.SetActive(false);
        shop.SetActive(false);
        aboutus.SetActive(false);
        mainmenu.SetActive(true);
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


}
