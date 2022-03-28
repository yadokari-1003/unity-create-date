using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronPipe_Mud : MonoBehaviour
{
    /*
     ・鉄パイプ　汚れ
      用途１：obj + 汚れ　として配置
    　用途２：ギミック１　敵の生成を行う

     */

    //アニメーターの取得
    public Animator anime = null;

    //HP　格納庫
    public int ironpipe_HP = 5;

    public Slider HPslider;

    //Clean　タイマー
    public float timer_clean = 0;

    //Clean インターバル
    public float interval_clean = 3.0f;


    //Enemy（敵の）prehab の格納庫
    public GameObject enemy_prehab;

    public float enemy_timer = 0;

    public float  enemy_interval = 5.0f;

    public int enemy_count = 3;


    float find_timer = 0;
    float find_interval = 20.0f;



    // Start is called before the first frame update
    void Start()
    {
        //アニメーターの取得
        anime = GetComponent<Animator>();
        HPslider.value = 5;

    }

    // Update is called once per frame
    void Update()
    {
        IronPipe_anime();
        
        IronPipe_Mud_gimmick();
        //IronPipe_EnemyCountrecovery();
    }


   

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IronPipe_Clean();
        }
    }




    //汚れのアニメ―ション
    public void IronPipe_anime()
    {
        if (HPslider.value > 1)
        {
            anime.SetBool("Clean",false);
        }

        if (HPslider.value == 0)
        {
            anime.SetBool("Clean", true);
        }
        if (HPslider.value < 0)
        {
            ironpipe_HP = 0;
        }


    }

    //汚れのHPコントローラー
    public void IronPipe_Clean()
    {
        if (Input.GetKey(KeyCode.C))
        {
            timer_clean += Time.deltaTime;
            if (timer_clean > interval_clean)
            {
                HPslider.value--;
                timer_clean = 0;
            }
        }
    }

    //汚れ状態の時のギミック
    public void IronPipe_Mud_gimmick()
    {
        if (HPslider.value > 1 && enemy_count > 0)
        {
            enemy_timer += Time.deltaTime;
            if (enemy_timer > enemy_interval && enemy_count > 0)
            {
                GameObject Enemy_ironpipe = Instantiate(enemy_prehab, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                enemy_count--;
                enemy_timer = 0;

            }
        }
    }

    public void IronPipe_EnemyCountrecovery()
    {
       

        find_timer += Time.deltaTime;
        if (find_timer > find_interval)
        {
            enemy_count += 3;

            find_timer = 0;
        }
    }

}
