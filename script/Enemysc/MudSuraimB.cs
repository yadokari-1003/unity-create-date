using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudSuraimB : MonoBehaviour
{
    /*
     マッドスライムBの設定
    ・移動
        左右移動
    ・特性
        地面に泥を生成する。
        */


    //マッドスライムの速さ
    public float movespeed = 0.01f;

    public float junpspeed = 0.1f;

    //マッドスライムの左右反転スイッチ
    public  bool moveswith;

    //マッドスライムB　アニメーター
    private Animator anime;

    //Player : script
    public test ss;

    //マッドスライムB：与えるダメージ量
    public int muddamege = 1;

    //プレイヤーのAP回復
    public int APheel = 1;

    //マッドスライムBのゲージ
    public Slider slider;

    //泥のオブジェクト格納庫
    public GameObject MudPrefab;

    //マッドプレハブカウント　1以上有り　0無し
    private int mudcount = 0;

    //「汚れ」オブジェクト生成インターバル
    public float intrerval = 30.0f;

    //スライムボールのプレハブ格納庫
    public GameObject suraimballMPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //アニメーター取得
        anime = gameObject.GetComponent<Animator>();
        //左に移動
        moveswith = false;
        //HP設定
        slider.value = 2;


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        MudSeed();
        MudSuraimBHP();
     
    }



    //マッドスライム動き
    public void Movement()
    {
        if (moveswith == false) //左移動
        {
            transform.Translate(-movespeed,0,0);
        }

        if (moveswith == true)　//右移動
        {
            transform.Translate(movespeed,0,0);
        }
    }


    public void OnCollisionEnter2D(Collision2D coll)
    {


        transform.Translate(0,0.01f,0);
        
        if (coll.gameObject.tag == "Brock")
        {
            moveswith =! moveswith;
        }

        if (coll.gameObject.tag != "Brock")
        {
            transform.Translate(0, junpspeed, 0);

        }

        if (coll.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamege);
            

            //自分にダメージ
            slider.value -= 1;
        }

        if (slider.value == 1 && coll.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyAPheelCal(APheel);
        }
        if (coll.gameObject.tag == "Suraim Ball")
        {
            slider.value--;

        }
    }


    //「汚れ」生成
    public void MudSeed()
    {
        intrerval -= Time.deltaTime;
        if (intrerval < 0)
        {
            mudcount++;
            intrerval += 30;
        }
        if (mudcount == 1)
        {

            Transform obj = this.gameObject.transform;
            GameObject Mud = Instantiate(MudPrefab, new Vector3(obj.position.x, obj.position.y -0.7f ,obj.position.z), Quaternion.identity); 
            mudcount--;
        }
       
    }

    //マッドスライムB　HP操作
    public void MudSuraimBHP()
    {
        if (slider.value <= 0)
        {
            Destroy(this.gameObject);
        }
    }

   

}
