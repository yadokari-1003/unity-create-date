using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{

    //====================================
    //プレイヤー；　ゲーム状態
    //====================================

    //現在のゲーム状態
    public static string gamestate = "playing";



    /*
     ========================
    プレイヤー；　動き（物理）　
     ========================
     */
    //動きのスピード
    public float moveSpeed = 0.1f;

    //ジャンプスピード
    public float JunpSpeed = 0.01f;

    //物理演算２D
    Rigidbody2D rd_player;

    //地面のレイヤー
    public LayerMask ground_layer;

    //ジャンプ開始判定
    bool jump_sw = false;

    //地面に立っている判定
    bool ground_sw = false; 



    //============================
    //プレイヤー；　アニメーター アニメ―ション
    //============================

    //プレイヤーアニメーター
    private Animator anim = null;

    //再生アニメ　格納
    public string nowanime = ""; 　//更新後
    public string oldanime = "";　 //更新前

    //======================
    //アニメクリップ
    //======================

  
    //アニメクリップ　デフォルト状態

    //正面絵
    public string HPanime_defalt_stand = "Player Suraim Stand";
    //右ジャンプ
    public string HPanime_defalt_RightJump = "Player Suraim janp";
    //左ジャンプ
    public string HPanime_defalt_LeftJump = "Player Suraim Left Junp";
    //右歩き
    public string HPanime_defalt_RightWalk = "Player Suraim Right Walk";
    //左歩き
    public string HPanime_defalt_LeftWalk = "Player Suraim Left Walk";



    //アニメクリップ　Cボタン　そうじモーション
    public string HPanime_Clean = "Player Suraim Clean Mothion";

    //アニメクリップ 汚れ状態Lv1

    //正面絵
    public string HPanime_MudLv1_stand = "Player Suraim Stand MudLv1";
    //右歩き
    public string HPanime_MudLv1_RightWalk = "Player Suraim Right Walk Mud Lv1";
    //左歩き
    public string HPanime_MudLv1_LeftWalk = "Player Suraim LeftWalk Mud Lv1";
    //ジャンプ
    public string HPanime_MudLv1_Janp = "Player Suraim Janp Mud Lv1";



   

    
    // ================================
    //プレイヤー；　ステータス　HP(体力)　AP（面積）
    //=================================


    //HP（体力）用のスライダー
    public Slider HPslider;

    //スライムボールの所持数変数
    public int suraimballnum = 5;

    //スライムボールの所持数テキスト
    public GameObject balltext = null;



    //APスライダー（エリアポイント）スライムボール生成用のスライダー
    public Slider APslider;
    //プレイヤー大きさ変更
    public Vector3 APscare;



    //===================================================
    //プレイヤー；　ボール　角度　向きの角度　
    //===================================================

    //スライムボールのプレハブ格納庫
    public GameObject suraimballpreafb;

    //float型　変数名ballspeed　ボールのスピードを設定　　
    public float ballspeed = 0.05f;

    //持ち上げる位置の取得
    public Transform have_obj_trans;



    //矢印のプラス/マイナスを切り替えるスイッチ
    public bool tswicth = true;
    public bool tswicth2 = false;



    //左右方向の検知  矢印キーで向いている方向を保存する
    bool Rightdir = false;　//右方向
    bool Leftdir = false;  //左方向



    //矢印UI
    //ボールの角度を決めるためのオブジェクト格納
    public GameObject Target;


    //角度調整の変数　targetz Z軸を操作　
    public float targetz;
    //角度調節　Ｘ軸を操作
    public float xdir = 0f;
    float xdirMax = 2f;
    float xdirMin = 0;
    //-X軸
    float LxdirMax = -2f;
    //角度調節　Ｙ軸を操作
    public float ydir = 1.5f;
    float ydirMax = 2f;
    float ydirMin = 0f;





    
    public float timer = 10.0f;

    public int  interval = 30;







    


    // Start is called before the first frame update
    void Start()
    {

        //ゲームプレイ中
        gamestate = "playing";

        //アニメーター　取得
        anim = GetComponent<Animator>();

        anim.SetBool("Stand", true);

        //正面アニメを代入
       //nowanime = HPanime_defalt_stand;
       //oldanime = HPanime_defalt_stand;




        //RigidBody２D　取得
        rd_player = GetComponent<Rigidbody2D>();

        //HP　スライダー　設定
        HPslider.value = 10;
        //APスライダー　設定
        APslider.value = 4;


       
        //矢印UI非表示
        Target.SetActive(false);

        targetz = 1;

    }　　

    // Update is called once per frame
    void Update()
    {
        //プレイ中じゃない場合
        if (gamestate != "playing")
        {
            return;
        }


        //レイヤー判定関数
        LayerTrigger();

        //プレイヤーの動きの関数
        Movemennt();

        //ジャンプ関数
        Jump();

        //ボール投げの関数
        SuraimBallThrow();



        SuraimBallConbine();

        CleanMode();

    
        
        PlayerAPscare(); //AP：プレイヤー大きさ変更メソッド






        
       

        //  PlayerHP_Animathion();

        //MudLv1();


        //オイラー角の表示
        // print("角度：" + Target.transform.eulerAngles.z ) ;

    }




    //当たり判定の関数：
    public void OnCollisionEnter2D(Collision2D coll)
    {

        //タグ：Gomiに触れた場合
        if (coll.gameObject.tag == "Gomi")
        {
            //触れたオブジェクトを管理
            GameObject have_obj = coll.gameObject;
            //触れたオブジェクトを子オブジェクトにする
            have_obj.transform.parent = this.gameObject.transform;
            //プレイヤーに追従させる
            have_obj.transform.position = new Vector2(have_obj_trans.transform.position.x, have_obj_trans.position.y);

        }
    }



    //レイヤー判定関数：
    public void LayerTrigger()
    {
        //地面の判定を行う　地面のレイヤーに触れていたら　True　触れていない場合　False　を代入する
        ground_sw = Physics2D.Linecast(this.transform.position, this.transform.position - (this.transform.up * 0.5f), ground_layer);

    }




    //掃除モード　Cボタン操作
    public void CleanMode()
    {
        //Cボタン
        if (Input.GetKey(KeyCode.C))
        {
            //そうじアニメーションを代入
            nowanime = HPanime_Clean;
            //そうじアニメON
            anim.Play(nowanime);
            
        }
        else　// そうじアニメOFF
        {
           
        }
    }



    /*    ボールの方向を決める     */



    //左右の検知を行う
    public void DirRLchange()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rightdir = true;
            Debug.Log(Rightdir + "右を向いています");
            Leftdir = false;
            Debug.Log(Leftdir);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Rightdir = false;
            Debug.Log(Rightdir);
            Leftdir = true;
            Debug.Log(Leftdir + "左を向いています");
        }
    }

   　//矢印の角度を決める
    public void TargetUI()
    {

        //左向き　動いていい角度は、0度から90度
        //右向き　動いて良い角度は、270度から360度
        //オイラー角が90度以下の場合、90度まで増加させる　90以上いかせない

        //左方向　0度から90度　オイラー角を増加
        if (tswicth == true  && Input.GetKey(KeyCode.DownArrow))
        {
            //矢印のオイラー角（ｚ軸）を増加させる
            Target.transform.eulerAngles += new Vector3(0, 0, targetz);

            if (45 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z  > 0)
            {
                ydir = 1;
            }
            if (90 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z > 45)
            {
                ydir -= 0.02f;
                if (ydir < ydirMin)
                {
                    ydir = ydirMin;
                }
            }

            xdir += 0.04f;
            if (xdirMax < xdir)
            {
                xdir = xdirMax;
            }


        }


        //左方向　オイラー角　UpButton
        if (tswicth == true && Input.GetKey(KeyCode.UpArrow))
        {
            //矢印のオイラー角（ｚ軸）を増加させる
            Target.transform.eulerAngles -= new Vector3(0, 0, targetz);

            if (45 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z > 0)
            {
                ydir = 1;
            }
            if (90 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z > 45)
            {
                ydir += 0.02f;
                if (ydirMax < ydir)
                {
                    ydir = ydirMax;
                }
            }

            xdir -= 0.02f;
            if (xdir < xdirMin)
            {
                xdir = xdirMin;
            }
          

        }


        //右方向
        if (tswicth2 == true && Input.GetKey(KeyCode.DownArrow))
        {
            //矢印のオイラー角を減少させる。
            Target.transform.eulerAngles -= new Vector3(0, 0, targetz);

            if (359 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z > 315)
            {
                ydir = 1;
            }
            if (315 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z > 270)
            {
                ydir -= 0.02f;
                if (ydir < ydirMin)
                {
                    ydir = ydirMin;
                }
            }
            xdir += 0.02f;
            if (xdirMax < xdir)
            {
                xdir = xdirMax;
            }


        }


        //右方向
        if (tswicth2 == true && Input.GetKey(KeyCode.UpArrow))
        {
            //矢印のオイラー角を減少させる。
            Target.transform.eulerAngles += new Vector3(0, 0, targetz);

            if (359 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z > 315)
            {
                ydir = 1;
            }
            if (315 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z > 270)
            {
                ydir += 0.02f;
                if (ydirMax < ydir)
                {
                    ydir = ydirMax;
                }
            }
            xdir -= 0.02f;
            if (xdir < xdirMin)
            {
                xdir = xdirMin;
            }


        }
    }
 
    //tswich　tswich2　矢印の左右を決める：矢印の管理
    public void tsright() 
    {

        //左方向の時
        if (Leftdir == true) 
        {

            //矢印の初期化
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Target.transform.eulerAngles = new Vector3(0, 0, 45);
                xdir = 1;
                ydir = 1;
            }
            
            if ( 90 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z >0)
            {
                //スイッチの切り替え
                tswicth = true;
                tswicth2 = false;

            }
            //Zが０より小さい場合　マイナスの軸
            if (Target.transform.eulerAngles.z > 90)
            {

                tswicth = false;
                tswicth2 = true;

            }
        }

        if (Rightdir == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Target.transform.eulerAngles = new Vector3(0, 0, 315);
                xdir = 1;
                ydir = 1;
            }
            
            if (359 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z > 270)
            {
                tswicth = false;
                tswicth2 = true;
            }
            if (270 > Target.transform.eulerAngles.z)
            {
                tswicth = true;
                tswicth2 = false;
            }
        }
        
    }


//スライムボールを生成する機能　Bボタン操作
　　public void SuraimBallButton()
    {

        //GeyKeyDown　Up　はif文でelseで繋げると上手くいく



        if (Input.GetKey(KeyCode.B))　　 //Bボタンでスライムボールの生成 発射
        {
            // 矢印オブジェクトを表示（true）にする。
            Target.SetActive(true);


        }
        else if (Input.GetKeyUp(KeyCode.B) && Rightdir == true && GameManager.suraimball_num > 0)　//ボタンを離したらボールを　右方向　に発射
        {

            //矢印オブジェクトを非表示（false）にする
            Target.SetActive(false);

            //現在のプレーヤーの位置情報を取得
            Transform playertrans = this.gameObject.transform;

            //ボールを生成する、　位置をプレーヤーの斜め上に設定を行う。
            GameObject ball = Instantiate(suraimballpreafb, new Vector2(playertrans.position.x + 0.1f, playertrans.position.y + 0.1f), Quaternion.identity);

            //ボールのRigidbody(物理演算)を取得
            Rigidbody2D rd2d = ball.GetComponent<Rigidbody2D>();
            //Vector変数で、投げる角度を変更する。
            Vector2 forcedirecthion = new Vector2(xdir, ydir);
            //Vector変数　に　角度　×　ボールスピード　を代入
            Vector2 force = forcedirecthion * ballspeed;
            //rigidbpdyに変数：force(角度　*　スピード)を力として代入する。
            rd2d.AddForce(force);



            //ボールの所持数を減らす
            GameManager.suraimball_num--;

        }
        else if (Input.GetKeyUp(KeyCode.B) && Leftdir == true && GameManager.suraimball_num > 0)　//ボタンを離したらボールを　左方向　に発射
        {

            //矢印オブジェクトを非表示（false）にする
            Target.SetActive(false);

            //現在のプレーヤーの位置情報を取得
            Transform playertrans = this.gameObject.transform;

            //ボールを生成する、　位置をプレーヤーの斜め上に設定を行う。
            GameObject ball = Instantiate(suraimballpreafb, new Vector2(playertrans.position.x - 0.1f, playertrans.position.y + 0.1f), Quaternion.identity);

            //ボールのRigidbody(物理演算)を取得
            Rigidbody2D rd2d = ball.GetComponent<Rigidbody2D>();
            //Vector変数で、投げる角度を変更する。
            Vector2 forcedirecthion = new Vector2(-xdir, ydir);
            //Vector変数　に　角度　×　ボールスピード　を代入
            Vector2 force = forcedirecthion * ballspeed;
            //rigidbpdyに変数：force(角度　*　スピード)を力として代入する。
            rd2d.AddForce(force);



            //ボールの所持数を減らす
            GameManager.suraimball_num--;
        }

        else if (GameManager.suraimball_num <= 0)
        {
            print("スライムボールの所持数は０です");
        }
    }

   
   //ボール投げ関数
    public void SuraimBallThrow()
    {
        DirRLchange();

        TargetUI();

        tsright();

        SuraimBallButton();
    }




    //スライムボールの合成
    public void SuraimBallConbine()
    {
        // C　長押し + M でボール生成
        if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
               
                if (GameManager.player_ap.value > 0 )
                {
                    //AP -1
                    GameManager.player_ap.value--;

                    //ボール所持数 +1
                    GameManager.suraimball_num++;

                    
                    suraimballnum++;
                }

            }

        }
    }

    //プレイヤー動作
    public void Movemennt()
    {

        //moveH …　X軸　moveV …　Y軸
        float moveH = Input.GetAxis("Horizontal"); //左右移動
        if (moveH < 0)　//　左移動のアニメ
        {

            anim.SetBool("Right Walk", false);

            anim.SetBool("Left Walk", true);
            //nowanime = HPanime_defalt_RightWalk;
            //anim.Play(nowanime);
            

           
            
           
        }
        else if (moveH > 0)　// 右移動のアニメ
        {

            anim.SetBool("Left Walk", false);

            
            anim.SetBool("Right Walk",true);
           // nowanime = HPanime_defalt_LeftWalk;
            //anim.Play(nowanime);
          
            
        }
        else //止まっているとき　アニメ
        {
            anim.SetBool("Right Walk", false);
            anim.SetBool("Left Walk", false);


        }


        //　上下移動
        float moveV = Input.GetAxis("Vertical");
        if (moveV > 0)
        {
            

        }
        else
        {
          
            

        }

        if (moveV > 0 && moveH < 0)
        {
        }
        else
        {
            
            
        }

        if (moveV < 0 )
        {
           
        }
        else
        {
           


        }
       
        transform.Translate(moveH * moveSpeed, 0, 0);
        
    }



    //ジャンプボタン
    public void JumpButton()
    {

        //スペースキー
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //スイッチＯＮ
            jump_sw = true;

        }


        
    }

    //ジャンプ力：地面判定　スペースキー判定　＝
    public void JumpPower()
    {

        //ジャンプ内容
        if (jump_sw == true &&  ground_sw == true)
        {

            //Y軸を動かす数値
            Vector2 jump_dir = new Vector2(0, 8f);
            //瞬間的な力を加える
            rd_player.AddForce(jump_dir, ForceMode2D.Impulse);
            //スイッチＯＦＦ
            jump_sw = false;


            
        }
       
    }

    //ジャンプ関数：
    public void Jump()
    {
        JumpButton();

        JumpPower();
    }


   


    //HP操作　アニメーションの切り替え
    public void MudLv1()
    {
        
        if (HPslider.value < 5)
        {
            anim.SetBool("Stand", false);
            anim.SetBool("Stand Mud Lv1", true);
        }
       
    }


    //プレイヤーHP　アニメ管理　メソッド
    public void PlayerHP_Animathion()
    {


       
        if (GameManager.player_hp.value > 6) //デフォルト状態　 HP10～7
        {

           
            

        }

        
        if (7 > GameManager.player_hp.value && GameManager.player_hp.value > 3) // 汚れ状態Lv1　HP6～4
        {
           
        }


        if (GameManager.player_hp.value  < 3) //汚れ状態 Lv2　HP３～1
        {

        }


        if (GameManager.player_hp.value < 0) //ゲームオーバー　HP0
        {

        }




    }


        　 /* 　　スライムボール    */

    //スライムボールのテキスト表示
    public void SuraimBalltext()
    {
        Text suraimball = balltext.GetComponent<Text>();
        suraimball.text = "×" + suraimballnum;　
    }

    //スライムボールの所持計算機
    public void SuraimBallHave(int suraimballamount)
    {
        suraimballnum += suraimballamount;
    }



            /*       プレイヤーHP     */

    //[汚れ]オブジェクトのダメージ
    public void MudLv1(int mudClean)
    {
        HPslider.value -=  mudClean;
    }

    //敵からのダメージ計算
    public void EnemyDamegeCal(int damege)
    {
        HPslider.value -= damege;
    }

    //バケツの回復計算
    public void BaketuHeel(int Heel)
    {
        GameManager.player_hp.value += Heel;
    }

   


    /*   プレイヤーAP   */

    //プレイヤー大きさ変更　メソッド　
    public void PlayerAPscare()
    {
        //Vector3に現在の大きさ代入
        APscare = gameObject.transform.localScale;

        //APの数値でプレイヤーの大中小のサイズ変更
        if (GameManager.player_ap.value > 5) // サイズ：大
        {
            APscare.x = 4;
            APscare.y = 4;
            APscare.z = 4;
            gameObject.transform.localScale = APscare;
        }
        if (5 >= GameManager.player_ap.value && GameManager.player_ap.value > 2)　// サイズ：中
        {
            APscare.x = 3;
            APscare.y = 3;
            APscare.z = 3;
            gameObject.transform.localScale = APscare;
        }
        if (2 >= GameManager.player_ap.value)　//サイズ：小
        {
            APscare.x = 2;
            APscare.y = 2;
            APscare.z = 2;
            gameObject.transform.localScale = APscare;
        }
    }

    //汚れのオブジェクトからのAP回復計算
    public void MudobjAPheelcal(int mudobjamount)
    {
        APslider.value += mudobjamount;
    }

    //敵からのAP回復計算
    public void EnemyAPheelCal(int enemyamount)
    {
        APslider.value += enemyamount;
    }

    //アイテムを使用してAP回復計算
   public void ItemAPheelCal(int itemapamount)
    {
        APslider.value += itemapamount;
    }


   


}
