using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketuItem : MonoBehaviour
{
    /*
     アイテム：バケツ　プレーヤー回復アイテム
     
    Cボタンを押した場合、長押しで回復
    回復量はあとで設定
    3回使用で使用不可となる。

     
     
     */

    //プレーヤスクリプト
    public test ss;

    //回復量
    public int heel = 1;

    //バケツのインターバル
    public float interval = 3.0f;

    //バケツの使用回数
    public int usagecount = 9;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(usagecount);
    }


    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.C))
            {
                interval -= Time.deltaTime;
                if (interval < 0 && usagecount > 0)
                {
                    ss = ss = GameObject.Find("Suraim Player").GetComponent<test>();
                    ss.BaketuHeel(heel);

                    usagecount--;
                    interval = 3;
                }

                if (usagecount == 0)
                {
                    print("バケツはおなかいっぱいです。");
                }

               
            }
        }
    }
}
