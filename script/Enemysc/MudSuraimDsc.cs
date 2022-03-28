using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudSuraimDsc : MonoBehaviour
{
    /*       
        マッドスライムD　スクリプト内容
        HP１　
        Damge -1
        AP +1
        Drop:未定
    ＜行動＞
        一定時間の感覚で、ジャンプする。
        ジャンプする毎に、X軸のプラス/マイナスを切り替える
        

     */
    //マッドスライムD　HP数値
    public int HP = 1;
    //ダメージ量
    public int muddamage = 1;
    //AP回復量
    public int APheel = 1;


    //プレーヤースクリプト
    test ss;

    //ジャンプするまでのインターバル
    float interval = 2.0f;
    //ジャンプタイマー
    float timer = 0;

    //プラス/マイナスの切り替えスイッチ
    bool X_R = true;
    bool X_L = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyD_Junp();
        EnemyD_HP();
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
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

    public void EnemyD_HP()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //ジャンプメソッド
    public void EnemyD_Junp()
    {
        timer += Time.deltaTime;
        if (interval < timer && X_R == true)//右方向にジャンプ
        {
            Transform tf = this.gameObject.transform;
            Rigidbody2D rd = this.gameObject.GetComponent<Rigidbody2D>();
            Vector2 junpforce = new Vector2(20,50) ;
            rd.AddForce(junpforce);
            X_L = true;
            timer = 0;
            X_R = false;

        }
        if (interval < timer && X_L == true) //左方向にジャンプ
        {
            Transform tf = this.gameObject.transform;
            Rigidbody2D rd = this.gameObject.GetComponent<Rigidbody2D>();
            Vector2 junpforce = new Vector2(-20, 50);
            rd.AddForce(junpforce);
            X_R = true;
            timer = 0;
            X_L = false;
        }
    }
}
