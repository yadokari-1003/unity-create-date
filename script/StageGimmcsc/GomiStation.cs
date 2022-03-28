using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GomiStation : MonoBehaviour
{
    /*
     ゴミ捨て場のスクリプト
     */

    public GameObject ScoreText = null;

    int GomiScore = 0;
    int gomiscore_point = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score_test();
    }


    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Gomi")
        {
            GameObject Gomi = coll.gameObject;
            GomiScore += gomiscore_point;
            Destroy(coll.gameObject);
        }
    }


    //テストプレイ
    public void Score_test()
    {
        Text score_text = ScoreText.GetComponent<Text>();
        score_text.text = "SCORE : " + GomiScore;
    }
}
