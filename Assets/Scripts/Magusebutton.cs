using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magusebutton : MonoBehaviour
{
    public Levelmanager levelmanager;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Console.WriteLine("Privet");
        levelmanager.maguse();
    }
}
