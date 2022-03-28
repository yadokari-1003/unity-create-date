using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudSuraimAvice : MonoBehaviour
{
    //マッドスライムA　中ボス戦使用
    /*
     マッドスライムA　特性
    HP４
    damage1

    動き
    上下に動く

     */
    //HPスライダー
    public Slider HPslider;

    //ジャンプタイマー
    float jtimer = 0;
    float jinterval = 2.0f;
    
    //マッドスライムの動きの速さ
    public float movespeed = 0.01f;

    //動きの＋/-　のスイッチ切り替え
    private bool moveswith;

    //マッドスライムA　アニメーター
    private Animator anime;

    //object:mud script
    public FiledMudController mm;

    //Player : script
    public test ss;

    //マッドスライム：与えるダメージ量
    public int muddamege = 1;

    //泥の回復量
    public int mudheel = 5;

    //マッドスライムのゲージ
    public Slider slider;

    //スライムボール素材の生成
    public GameObject SuraimBallMPrefab;

    //プレイヤーのAP回復
    public int APheel = 1;



    // Start is called before the first frame update
    void Start()
    {
        HPslider.value = 4;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyA_vice_move();
        EnemyA_vice_HP();

    }



    //当たり判定
    public void OnCollisionEnter2D(Collision2D col)
    {
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

    //動き ジャンプを行う。
    public void EnemyA_vice_move()
    {
        jtimer += Time.deltaTime;
        if (jinterval < jtimer)
        {
            //マッドスライムDのジャンプメソッドを改変　上方向にジャンプを行うため、Y軸のみに力を加える
            Transform tf = this.gameObject.transform;
            Rigidbody2D rd = this.gameObject.GetComponent<Rigidbody2D>();
            Vector2 junpforce = new Vector2(0, 300);
            rd.AddForce(junpforce);
            jtimer = 0;
        }

    }

    public void EnemyA_vice_HP()
    {
        if (HPslider.value <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    
}
