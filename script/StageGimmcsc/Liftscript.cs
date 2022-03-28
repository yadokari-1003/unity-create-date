using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liftscript : MonoBehaviour
{
    /*
     左右移動
    上下移動
    上下左右移動
    斜め移動

    これらのメソッドをbool の切り替えで行う。
     */
    public bool distans_sw = true;



    public bool RL_Lift_sw = false;
    public bool UD_Lift_sw = false;


    //左右の切り替えスイッチ
    public bool rightleft_sw = true;
    //上下の切り替えスイッチ
    public bool updown_sw = true;

    //リフトスピード　
    public float lift_speed  = 0.01f;

    public float distans_x = 5;


    float lift_timer = 0;
    public float lift_inteval = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        LiftSwichController();



        //TestPlay();
        //TestPlay2();



    }


    public void TestPlay()
    {



        if (distans_sw ==  true)
        {
            distans_x -= 0.01f;
            this.gameObject.transform.Translate(lift_speed, 0, 0);
            if (distans_x < 0 && distans_sw == true)
            {
               // distans_x = 0;
                distans_sw =! distans_sw;
            }
        }

        if (distans_sw == false)
        {
            distans_x += 0.01f;
            this.gameObject.transform.Translate(-lift_speed,0,0);
            if (distans_x < 5)
            {
                //distans_x = 5;
                distans_sw = !distans_sw;
            }
        }
          

    }

    
    public void TestPlay2()
    {
        //タイマーでスイッチ切り替え
        lift_timer += Time.deltaTime;
        if (lift_timer > lift_inteval)
        {
            distans_sw = !distans_sw;
            lift_timer = 0;
        }

        //プラス移動
        if (distans_sw == true)
        {
            this.gameObject.transform.Translate(lift_speed, 0, 0);
            
        }

        //マイナス移動
        if (distans_sw == false)
        {
            this.gameObject.transform.Translate(-lift_speed, 0, 0);
        }


    }
    


    //～リフトの移動方法は外部で決めるように行う～


    //使用するメソッドの切り替えを行う
    public void LiftSwichController()
    {
        //左右移動のリフト
        if (RL_Lift_sw == true)
        {
            UD_Lift_sw = false;
            RightLeftLift();
        }


        //上下移動のリフト
        if (UD_Lift_sw == true)
        {
            RL_Lift_sw = false;
            UpDownLift();
        }
    }





    //左右移動のメソッド
    public void RightLeftLift()
    {
        //タイマーでスイッチ切り替え
        lift_timer += Time.deltaTime;
        if (lift_timer > lift_inteval)
        {
            //スイッチの切り替え　
            rightleft_sw = !rightleft_sw;
            //タイマーのリセットを行う
            lift_timer = 0;
        }

        //プラス移動
        if (rightleft_sw == true)
        {
            this.gameObject.transform.Translate(lift_speed, 0, 0);

        }

        //マイナス移動
        if (rightleft_sw == false)
        {
            this.gameObject.transform.Translate(-lift_speed, 0, 0);
        }
    }

    //上下移動のメソッド
    public void UpDownLift()
    {
        //タイマーでスイッチ切り替え
        lift_timer += Time.deltaTime;
        if (lift_timer > lift_inteval)
        {
            //スイッチの切り替え　
            updown_sw =! updown_sw;
            //タイマーのリセットを行う
            lift_timer = 0;
        }

        //プラス移動
        if (updown_sw == true)
        {
            this.gameObject.transform.Translate(0, lift_speed, 0);

        }

        //マイナス移動
        if (updown_sw == false)
        {
            this.gameObject.transform.Translate(0, -lift_speed, 0);
        }
    }

    

   

}
