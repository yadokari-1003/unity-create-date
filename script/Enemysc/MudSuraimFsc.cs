using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudSuraimFsc : MonoBehaviour
{
    /* 
     マッドスライムF　スクリプト内容
    HP4  slider付き
    damage -1 (触れた場合)
    balldamege -2 (ボールダメージ)
    AP +4

    <行動>
    一定時間でマッドボールを撃つ
    マッドボールは、左右一直線に撃つ。
    プレイヤーの位置を検知
    プレイヤーの位置により左右反転

     */

    //ダメージ変数
    int muddamage = 1;
    //AP回復変数
    int APheel = 4;

    //Slider格納変数　HP設定
    public Slider HPslider;


    //弾（マッドボール）の格納変数
    public GameObject MudballPrefab;
    //ボールスピード変数
    public float ballspeed = 2.0f;
    //攻撃を行うタイマー変数
    float timer_attack = 0;
    //攻撃タイマーのインターバル変数
    float interval_attack = 3.0f;

    //プレイヤーの位置を格納変数
    public Transform player_trans;

    float timer_P = 0;
    float interval_P = 2.0f;


    //プレイヤーのスクリプト変数
    test ss;

    //マッドスライムFのアニメーター
    public Animator anime;

    //右方向のスイッチ
    bool R_swich;
    //左方向のスイッチ
    bool L_swich;


    // Start is called before the first frame update
    void Start()
    {
        HPslider.value = 4;　//ＨＰスライダーを４にする
        anime = GetComponent<Animator>(); //アニメーション取得
    }

    // Update is called once per frame
    void Update()
    {
        EnemyF_HP();
        EnemyF_LR();
        EnemyF_move();
    }

    //当たり判定管理
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")　//プレーヤの場合
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamage);

            HPslider.value--;
           
        }
        
        if (coll.gameObject.tag == "Player" && HPslider.value < 1)　//プレーヤの場合及びＨＰ1より小さい場合
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyAPheelCal(APheel);
        }
        if (coll.gameObject.tag == "Suraim Ball")　//スライムボールが当たった場合
        {
            HPslider.value--;

        }
    }

    //マッドスライムＦのＨＰ管理メソッド
    public void EnemyF_HP()
    {
        if (HPslider.value == 0)
        {
            Destroy(this.gameObject);
        }
    }

    //マッドスライムFの行動 : 弾（マッドボールを撃つ）
    public void EnemyF_move()
    {
        timer_attack += Time.deltaTime;　//攻撃の+タイマー　一定時間で撃たせるため。
        if (interval_attack < timer_attack  && L_swich == true)　//左方向に撃つ　インターバルを上回った場合
        {
            //MudEnemyFの位置を取得
            Transform enemyF_pos = this.gameObject.transform;
            //弾を生成する(Instantiateメソッド)　生成する場所を口の部分からにする 回転の軸はそのまま
            //生成した弾は変数にしまう　⊲　このスクリプトで操作するため。
            GameObject mudball = Instantiate(MudballPrefab, new Vector2(enemyF_pos.position.x -0.2f, enemyF_pos.position.y), Quaternion.identity);
            //生成した弾（プレハブ）のRigidBody（物理演算）を取得する
            Rigidbody2D rd2d = mudball.GetComponent<Rigidbody2D>();
            //Vector２型の変数　位置を変更するための変数　ここでは左に撃つ
            Vector2 ball_froce = new Vector2(-0.1f, 0);
            //Vector型の変数　この変数に撃つ向きの変数とボールのスピードを保持した変数を掛算して、代入を行う。
            Vector2 allforce = ball_froce * ballspeed;
            //Rigidbody（物理演算）にAddForce（力を加えるメソッド）を加える　加える変数は向きとスピードを計算した変数
            rd2d.AddForce(allforce);

            //オブジェクトを2秒後に消す
            Destroy(mudball, 2.0f);
            //タイマーを元に戻す
            timer_attack = 0;

        }

        if (interval_attack < timer_attack  && R_swich == true)//右方向に撃つ
        {
            //MudEnemyFの位置を取得
            Transform enemyF_pos = this.gameObject.transform;
            //弾を生成する(Instantiateメソッド)　生成する場所を口の部分からにする 回転の軸はそのまま
            //生成した弾は変数にしまう　⊲　このスクリプトで操作するため。
            GameObject mudball = Instantiate(MudballPrefab, new Vector2(enemyF_pos.position.x + 0.2f, enemyF_pos.position.y), Quaternion.identity);
            //生成した弾（プレハブ）のRigidBody（物理演算）を取得する
            Rigidbody2D rd2d = mudball.GetComponent<Rigidbody2D>();
            //Vector２型の変数　位置を変更するための変数　ここでは右に撃つ
            Vector2 ball_froce = new Vector2(0.1f, 0);
            //Vector型の変数　この変数に撃つ向きの変数とボールのスピードを保持した変数を掛算して、代入を行う。
            Vector2 allforce = ball_froce * ballspeed;
            //Rigidbody（物理演算）にAddForce（力を加えるメソッド）を加える　加える変数は向きとスピードを計算した変数
            rd2d.AddForce(allforce);

            //オブジェクトを2秒後に消す
            Destroy(mudball, 2.0f);
            //タイマーを元に戻す
            timer_attack = 0;
        }
    }

    //マッドスライムFの向きを変えるメソッド
    public void EnemyF_LR()
    {
        //マッドスライムFの位置を取得Y
        Transform enemyF_pos = this.gameObject.transform;

        if (player_trans.position.x < enemyF_pos.position.x)//左向き
        {
            //アニメ―ションの切り替え
            anime.SetBool("Left", true);
            anime.SetBool("Right", false);


            //左右方向の切り替え検知スイッチ
            R_swich = false;
            L_swich = true;
        }

        if ( enemyF_pos.position.x  < player_trans.position.x )//右向き
        {
            //アニメーションの切り替え
            anime.SetBool("Left", false);
            anime.SetBool("Right", true);

            //左右方向の切り替え検知スイッチ
            R_swich = true;
            L_swich= false;
        }

    }

}
