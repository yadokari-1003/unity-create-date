using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTextAnimesc : MonoBehaviour
{
    //public GameObject animeBoss_text;
    public Image animeBoss_texts;

    float posx_text;
    float posxMax_text = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
        for (posx_text = 900; posx_text != posxMax_text; posx_text--) 
        {
            animeBoss_text.gameObject.transform.Translate(posx_text, 0, 0);
        }
       */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            animeBoss_texts.rectTransform.position += new Vector3(-100,0,0);
            if (animeBoss_texts.rectTransform.position.x < 0)
            {
                animeBoss_texts.rectTransform.position = new Vector3(0,0,0);
            }
        }
    }
}
