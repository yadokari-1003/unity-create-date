using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTextAnime : MonoBehaviour
{
    public GameObject animeBoss_text;

    float posx_text;
    float posxMax_text = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (posx_text = 900; posx_text != posxMax_text; posx_text--) 
        {
            animeBoss_text.gameObject.transform.Translate(posx_text, 0, 0);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
