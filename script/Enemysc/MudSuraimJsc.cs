using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudSuraimJsc : MonoBehaviour
{
    /*
     マッドスライムJ　スクリプト
    特性　
    HP3
    ダメージ１

    空中に飛ぶ敵
    ランダムで位置を変更する

    colliderでレーダー作成
    レーダーに入ったらプレーヤに近づく

     */

    //タイマー
    float time = 0;
    float interval = 2.0f;

    //切り替えスイッチ
    bool sw = true;
    bool sw2 = false;

    test ss; //プレーヤスクリプト


    //Enemy 体力　ＡＰ回復量　ダメージ量
    int APheel = 3;
    int muddamage = 1;
    int HP = 3;
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyJ_HP();
        MudEnemyJ_Move();
    }

    //マッドスライムJ　動き
    public void MudEnemyJ_Move()
    {
        time += Time.deltaTime;　//プラスタイマー
        if (interval < time && sw == true)//sw trueの時　プラス移動
        {
            float trans_ran = Random.Range(0,10);　//ランダム数値生成
            transform.Translate(trans_ran, 0,0);　//x軸のみ管理
           
            sw = false;　//sw切り替え
            

            time = 0;　//タイマーの初期化
        }
        if (interval < time && sw == false)//sw　falseの時　マイナス移動
        {
            float trans_ran = Random.Range(0, -10);　//ランダム数値生成
            transform.Translate(trans_ran, 0, 0);  //Ｘ軸のみランダム移動　

            sw = true;　//sw切り替え
            

            time = 0;　//タイマーの切り替え
        }

    }



    //当たり判定
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamage);
            ss.EnemyAPheelCal(APheel);
            HP--;
        }


        if (coll.gameObject.tag == "Suraim Ball")
        {
            HP--;
        }
    }

    //HP管理
    public void EnemyJ_HP()
    {
        if (HP == 0)　//ＨＰ０になったら消す
        {
            Destroy(this.gameObject);
        }
    }


}
