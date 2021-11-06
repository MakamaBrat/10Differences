using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{ public Ad2 ad2;
 public Levelmanager levelmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buymag()
    { ad2.rek_id =1;
        ad2.UserChoseToWatchAd(); }
    public void buycoin()
    {
        ad2.rek_id = 0;
        ad2.UserChoseToWatchAd();
    }


}
