using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasureBoxGreen: MonoBehaviour
{

    /**/

    //配列変数　宝箱（緑）
    GameObject[] Greenboxs;

    public Animator anime;

    float timer = 0;
    float interval = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        anime.SetBool("Box C_green Clear", false);
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > interval)
        {
            T_boxC_GreenCheak("Treasure");
            timer = 0;
        }
        
        
    }


    //宝箱（緑）を計算するメソッド
    public void T_boxC_GreenCheak(string N_greenbox)
    {
        Greenboxs = GameObject.FindGameObjectsWithTag(N_greenbox);
        if (Greenboxs.Length == 0)
        {
            anime.SetBool("Box C_green Clear", true);
        }
        else
        {
            anime.SetBool("Box C_green Clear" , false);
        }

    }

}
