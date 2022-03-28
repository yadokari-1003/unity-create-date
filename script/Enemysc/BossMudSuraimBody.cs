using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMudSuraimBody : MonoBehaviour
{
    /*
     BOSS　マッドスライムA　スクリプト

     */

    //アニメーター
    Animator anime;

    //動きの速さ
    float movespeed;

    float movespeed_defalt = 0.015f;

    float movespeed_stop = 0;

    
    //左右方向の切り替え
    bool dirsw = true;

    //ボスの頭部分の位置を取得
    public Transform BossHead;

    public GameObject BossBullet;

    public GameObject MudPrefab;



    float timer_attack = 0;
    float inteval_attack = 5.0f;

    float timer_bulletanime = 0;
    float Interval_bullettime = 1.1f;
    
    //bool形　アニメ切り替えスイッチ
    bool animesw = false;



    //Boss　HP　スライダー　
    public Slider HPslider;

    float timer_damage_anime = 0;
    float interval_damege_anime = 1.0f;
    bool damagesw = false;




    test ss;

    int muddamege = 1;

    // Start is called before the first frame update
    void Start()
    {
        movespeed = movespeed_defalt;
        anime = GetComponent<Animator>();
        anime.SetBool("Right Damege", false) ;
    }

    // Update is called once per frame
    void Update()
    {
       BodyMove();
        BossRightAttack();
        BossLeftAttack();
        BossHP();
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        //右　→　左　切り替え
        if (col.gameObject.tag == "Brock")
        {
            dirsw =! dirsw;
            

        }

        if (col.gameObject.tag == "Player")
        {
            //プレイヤーにダメージを与える。
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamege);
        }

        //スライムボールによるダメージ
        if (col.gameObject.tag == "Suraim Ball")
        {
          

            //右
            if (dirsw == true)
            {
                movespeed = 0;
                HPslider.value -= 1;
                damagesw = true;

                


            }

            //左
            if (dirsw == false)
            {

                movespeed = 0;
                HPslider.value -= 1;
                damagesw = true;

                
            }

        }


        // gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);




    }


    public void BossHP()
    {
        if (HPslider.value == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damege()
    {
        if (damagesw == true)
        {

          
            anime.SetBool("Right Damege", true);
            anime.SetBool("Right Damege", false);
            movespeed = 0.05f;
            damagesw = false;


        }


        if (damagesw == true)
        {
            anime.SetBool("Left Damege", true);
            anime.SetBool("Left Damege", false);
            movespeed = 0.05f;
            damagesw = false;

        }
    }

    public void BodyMove()
    {
        //右方向
        if (dirsw == true)
        {
          
            this.gameObject.transform.Translate(movespeed, 0, 0);
            anime.SetBool("Right",true);
            //gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);

        }

        //左方向
        if (dirsw == false)
        {
           
            this.gameObject.transform.Translate(-movespeed, 0, 0);
            anime.SetBool("Right",false);
            
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        } 

    }


    /*
     タイマーで行動を切りかえる
    アニメーション開始　⊳　攻撃待機　⊳　アニメーション終了　⊳　攻撃開始　⊳　タイマー：アニメ：リセット
     
     汚れ弾　３発発射　⊳　汚れ弾が地面に付いたら、汚れに変換
     */
    public void BossRightAttack()
    {

        if (dirsw == true)
        {

            //プラスタイマー
            timer_attack += Time.deltaTime;
            //条件：インターバルを越した場合
            if (timer_attack > inteval_attack)
            {
                //動きを止める
                movespeed = movespeed_stop;
                //アニメ：攻撃モーション
                anime.SetBool("Bullet Right", true);
                //アニメ用のタイマー
                timer_bulletanime += Time.deltaTime;
                //アニメのインターバル：アニメーションまでの待機
                if (timer_bulletanime > Interval_bullettime)
                {
                    //攻撃を行う
                    animesw = true;
                }
            }

            //攻撃scブロック
            if (animesw == true)
            {
                //3つの弾を生成する。
                GameObject bullet_attack1 = Instantiate(BossBullet, new Vector2(BossHead.position.x, BossHead.position.y), Quaternion.identity);
                GameObject bullet_attack2 = Instantiate(BossBullet, new Vector2(BossHead.position.x, BossHead.position.y), Quaternion.identity);
                GameObject bullet_attack3 = Instantiate(BossBullet, new Vector2(BossHead.position.x, BossHead.position.y), Quaternion.identity);

                //弾それぞれに物理演算追加
                Rigidbody2D rd2d_attack1 = bullet_attack1.GetComponent<Rigidbody2D>();
                Rigidbody2D rd2d_attack2 = bullet_attack2.GetComponent<Rigidbody2D>();
                Rigidbody2D rd2d_attack3 = bullet_attack3.GetComponent<Rigidbody2D>();

                //弾の方向決定　弾それぞれ異なる方向に変更
                Vector2 bullet_attack1_v2 = new Vector2(5f, 0f);
                Vector2 bullet_attack2_v2 = new Vector2(3f, 3f);
                Vector2 bullet_attack3_v2 = new Vector2(0, 5f);

                //弾のスピード　決定
                float bullet_attack_speed = 30.0f;

                //総合計算　スピード　×　向き
                Vector2 bullet_attack1_allforce = bullet_attack1_v2 * bullet_attack_speed;
                Vector2 bullet_attack2_allforce = bullet_attack2_v2 * bullet_attack_speed;
                Vector2 bullet_attack3_allforce = bullet_attack3_v2 * bullet_attack_speed;

                //弾それぞれに力を加える
                rd2d_attack1.AddForce(bullet_attack1_allforce);
                rd2d_attack2.AddForce(bullet_attack2_allforce);
                rd2d_attack3.AddForce(bullet_attack3_allforce);

                //アニメ―ション終了
                anime.SetBool("Bullet Right", false);

                //動きを戻す
                movespeed = movespeed_defalt;

                //スイッチ切り替え
                animesw = false;

                //タイマーのリセット
                timer_bulletanime = 0;

                //タイマーリセット
                timer_attack = 0;


            }
        }
    }


    public void BossLeftAttack()
    {
        if (dirsw == false)
        {

            //プラスタイマー
            timer_attack += Time.deltaTime;
            //条件：インターバルを越した場合
            if (timer_attack > inteval_attack)
            {
                //動きを止める
                movespeed = movespeed_stop;
                //アニメ：攻撃モーション
                anime.SetBool("Bullet Left", true);
                //アニメ用のタイマー
                timer_bulletanime += Time.deltaTime;
                //アニメのインターバル：アニメーションまでの待機
                if (timer_bulletanime > Interval_bullettime)
                {
                    //攻撃を行う
                    animesw = true;
                }
            }

            //攻撃scブロック
            if (animesw == true)
            {
                //3つの弾を生成する。
                GameObject bullet_attack1 = Instantiate(BossBullet, new Vector2(BossHead.position.x, BossHead.position.y), Quaternion.identity);
                GameObject bullet_attack2 = Instantiate(BossBullet, new Vector2(BossHead.position.x, BossHead.position.y), Quaternion.identity);
                GameObject bullet_attack3 = Instantiate(BossBullet, new Vector2(BossHead.position.x, BossHead.position.y), Quaternion.identity);

                //弾それぞれに物理演算追加
                Rigidbody2D rd2d_attack1 = bullet_attack1.GetComponent<Rigidbody2D>();
                Rigidbody2D rd2d_attack2 = bullet_attack2.GetComponent<Rigidbody2D>();
                Rigidbody2D rd2d_attack3 = bullet_attack3.GetComponent<Rigidbody2D>();

                //弾の方向決定　弾それぞれ異なる方向に変更
                Vector2 bullet_attack1_v2 = new Vector2(5f, 0f);
                Vector2 bullet_attack2_v2 = new Vector2(3f, 3f);
                Vector2 bullet_attack3_v2 = new Vector2(0, 5f);

                //弾のスピード　決定
                float bullet_attack_speed = -30.0f;

                //総合計算　スピード　×　向き
                Vector2 bullet_attack1_allforce = bullet_attack1_v2 * bullet_attack_speed;
                Vector2 bullet_attack2_allforce = bullet_attack2_v2 * bullet_attack_speed;
                Vector2 bullet_attack3_allforce = bullet_attack3_v2 * bullet_attack_speed;

                //弾それぞれに力を加える
                rd2d_attack1.AddForce(bullet_attack1_allforce);
                rd2d_attack2.AddForce(bullet_attack2_allforce);
                rd2d_attack3.AddForce(bullet_attack3_allforce);

                //アニメ―ション終了
                anime.SetBool("Bullet Left", false);

                //動きを戻す
                movespeed = movespeed_defalt;

                //スイッチ切り替え
                animesw = false;

                //タイマーのリセット
                timer_bulletanime = 0;

                //タイマーリセット
                timer_attack = 0;


            }
        }
    }




}
