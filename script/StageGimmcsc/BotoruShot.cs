using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoruShot : MonoBehaviour
{

    /*
     
     botoruChageから変数受け取り、
    それをボールの弾数にする
    0になったら撃てなくなる

    キャップ部分のブロックにプレーヤが上から押した場合
    強化ボールを発射する

    攻撃力は+2で計算する

     */

    //プレーヤーが使用するタンク
    int botorutank;

    //敵が使用するタンク
    public int mudbotorutank;

    //プレーヤーが使用するスイッチ
    bool psw = false;
    //敵が使用するスイッチ
    bool esw = false;


    //ボールスピード
    public float ballspeed = 75f;

    //スライムボールのプレハブ格納庫
    public GameObject BallPrefab;

    //マッドボールのプレハブ格納庫
    public GameObject EnemyBallPrefab;


    public float dirchange = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(esw);
        print(psw);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //スイッチの切り替え　プレーヤーが使用する場合
            esw = false;
            psw = true;

            if (botorutank > 0  && psw == true)
            {
                //空のobjを探す　変数に保管
                //GameObject shotobj = GameObject.Find("ShotPos");
                GameObject shotobj = this.gameObject;
                //そオブジェクトの位置を保管
                Transform shotpos = shotobj.transform;
                //プレハブ生成
                GameObject shotball= Instantiate(BallPrefab, new Vector2(shotpos.position.x - 0.15f, shotpos.position.y), Quaternion.identity);
                GameObject shotball2 = Instantiate(BallPrefab, new Vector2(shotpos.position.x - 0.15f, shotpos.position.y), Quaternion.identity);
                //rigidbody2Dを取得
                Rigidbody2D rd2d = shotball.GetComponent<Rigidbody2D>();
                Rigidbody2D rd2d2 = shotball2.GetComponent<Rigidbody2D>();
                //Vector変数で。プレハブの生成位置を決定
                Vector2 forcedir = new Vector2(2,0);
                //Vector変数に位置のVector変数とスピードfloat変数を計算、代入する
                Vector2 force = forcedir * ballspeed;
                //Addforceメソッドで、力を加える
                rd2d.AddForce(force);
                rd2d2.AddForce(force);

                botorutank--;
                        
            }
        }


        //敵が触れた場合
        if (coll.gameObject.tag == "Enemy")
        {
            //スイッチの切り替え　敵が使用できるようにする
            psw = false;
            esw = true;

            //敵が使用する場合
            if (esw == true)
            {
                EnemyBototuShot();
            }
            
        }



    }


    
    public void EnemyBototuShot()
    {
       
            //敵がが使用するマッドショット

            //空のobjを探す　変数に保管
            //GameObject shotobj = GameObject.Find("ShotPos");
            GameObject shotobj = this.gameObject;
            //そオブジェクトの位置を保管
            Transform shotpos = shotobj.transform;
            //プレハブ生成
            GameObject enemyshotball1 = Instantiate(EnemyBallPrefab, new Vector2(shotpos.position.x - 0.15f, shotpos.position.y), Quaternion.identity);
            GameObject enemyshotball2 = Instantiate(EnemyBallPrefab, new Vector2(shotpos.position.x  -0.15f, shotpos.position.y), Quaternion.identity);
            //rigidbody2Dを取得
            Rigidbody2D rd2d = enemyshotball1.GetComponent<Rigidbody2D>();
            Rigidbody2D rd2d2 = enemyshotball2.GetComponent<Rigidbody2D>();
            //Vector変数で。プレハブの生成位置を決定
            Vector2 forcedir = new Vector2(dirchange, 0);
            //Vector変数に位置のVector変数とスピードfloat変数を計算、代入する
            Vector2 force = forcedir * ballspeed;
            //Addforceメソッドで、力を加える
            rd2d.AddForce(force);
            rd2d2.AddForce(force);

        Destroy(enemyshotball1, 10.0f);
        Destroy(enemyshotball2, 10.0f);
        
        
    }

    

    //botoruchageからの受け取るメソッド
    public void BotoruChageCal(int amount)
    {
        botorutank += amount;
    }
}
