using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCanban : MonoBehaviour
{

    SpriteRenderer sprite;

    //アニメーター格納
    Animator anime;

    //ボタンの格納
    public GameObject Buttom;

    //キャンバスのスイッチ
    bool canvas_sw = false;


    //Canvas＿UI　格納
    public GameObject Canban_Canvas;
    

    // Start is called before the first frame update
    void Start()
    {
        canvas_sw = false;
        //Canvas＿UIを非表示を行う
        Canban_Canvas.gameObject.SetActive(false);

        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //表示・非常時メソッド
        TextUP();
    }

    //トリガー付き　侵入した場合
    public void OnTriggerEnter2D(Collider2D coll)
    {
        //プレイヤーが触れた場合
        if (coll.gameObject.tag == "Player")
        {

            //プレーヤーが入ったら、開始
            anime.SetBool("Push", true);
           

           
        }



    }


    //トリガー付き　判定が離れた場合
    public void OnTriggerExit2D(Collider2D coll)
    {

        //プレーヤーが離れたらアニメをストップ
        if (coll.gameObject.tag == "Player")
        {

            //アニメストップ
            anime.SetBool("Push", false);

            //説明がもし表示されていて、プレイヤーが離れた場合
            if (canvas_sw == true)
            {
                //非表示を行う
                Canban_Canvas.gameObject.SetActive(false);
            }
        }
    }
   

    //表示・非表示を行うメソッド
    public void TextUP()
    {
        //表示を行う
        //条件：Ｔボタンを押したら　且つ　bool変数 textswがfalseの時
        if (Input.GetKeyDown(KeyCode.T)  && canvas_sw == false)
        {
            //キャンバスのスイッチ切り替え:true
            canvas_sw = true;
            //ボタンを押したら表示を行う
            Canban_Canvas.gameObject.SetActive(true);

          
        }
        //非表示を行う　条件： Tボタンを押したら　且つ　bool変数がtrueの時
        else if (Input.GetKeyDown(KeyCode.T)  && canvas_sw  == true)
        {
            //キャンバスのスイッチ切り替え： false
            canvas_sw = false;
            //非表示を行う
            Canban_Canvas.gameObject.SetActive(false);
        }
    }


 

}
