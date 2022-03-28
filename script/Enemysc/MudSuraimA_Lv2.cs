using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudSuraimA_Lv2 : MonoBehaviour
{

    /*
     マッドスライムA Lv2（Mud Suraim A Lv2）の設定スクリプト
    ・基本動作
        左右移動　もし壁にぶつかったら、左右反転（アニメーション追加）


    ・特性 (Lv2特有のスキル)
        もし泥のオブジェクトに触れた場合、Valueの数値増加
     
     */

    //マッドスライムの動きの速さ
    public float movespeed = 0.02f;

    //動きの＋/-　のスイッチ切り替え
    private bool moveswith;

    //マッドスライムA　アニメーター
    private Animator anime;

    //object:mud script
    public FiledMudController mm;

    //Player : script
    public test ss;

    //マッドスライム：与えるダメージ量
    public int muddamege = 2;

    //泥の回復量
    public int mudheel = 7;

    //マッドスライムのゲージ
    public Slider slider;

    //スライムボール素材の生成
    public GameObject SuraimBallMPrefab;

    //プレイヤーのAP回復
    public int APheel = 3;


    // Start is called before the first frame update
    void Start()
    {
        //最初は-の方向　：false
        moveswith = false;

        //変数anime にAnimatorを取得
        anime = GetComponent<Animator>();

        //slider数値２に設定
        slider.value = 5;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        MudSuraimAHP();

    }

    //マッドスライムAの動き
    public void Movement()
    {

        //左向き
        if (moveswith == false)
        {
            transform.Translate(-movespeed, 0, 0);
            anime.SetBool("Right", false);
            anime.SetBool("Left", true);
        }
        //右向き
        if (moveswith == true)
        {
            transform.Translate(movespeed, 0, 0);
            anime.SetBool("Right", true);
            anime.SetBool("Left", false);
        }

    }



    //マッドスライム　HP操作
    public void MudSuraimAHP()
    {
        if (slider.value <= 0)
        {

            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {

        //タグオブジェクト：Mudに触れた場合、bool変数moveswithのtrue/falseを切り替え
        if (col.gameObject.tag == "Brock")
        {
            moveswith = !moveswith;
        }

        //泥に触れたら
        if (col.gameObject.tag == "Mud")
        {
            //触れたオブジェクトの名前取得
            string objname = col.gameObject.name;
            //取得したオブジェクトのスクリプトに変数を送る
            mm = GameObject.Find(objname).GetComponent<FiledMudController>();
            mm.MudHeel(mudheel);

        }

        //プレーヤーに触れたら
        if (col.gameObject.tag == "Player")
        {
            //プレイヤーにダメージを与える。
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamege);


            //自分にダメージ
            slider.value -= 1;

        }

        if (slider.value == 1 && col.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyAPheelCal(APheel);
        }

        //スライムボールによるダメージ
        if (col.gameObject.tag == "Suraim Ball")
        {
            slider.value -= 1;

        }

    }

}
