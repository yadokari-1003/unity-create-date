using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraimBall : MonoBehaviour
{
    /*
     スライムボールのスクリプト
    アイテムとして使用
    敵や「汚れ」オブジェクトにダメージを与える。
    ダメージを与えたら消える。
     */

    //ダメージ量
    public int Damege = 1;

    private FiledMudController mm;

    private mudsuraimA ma;

    private MudSuraimB mb;

    private MudSuraimC mc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Mud")
        {
            Destroy(this.gameObject);
        }
    }
}
