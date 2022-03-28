using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*===================================
 
 ボタンマネージャー
全ボタンの管理を行うスクリプト

 ====================================
 */

public class ButtomManager : MonoBehaviour
{

    //タイトル画面　スタートボタン
    public string Start_scene;


    //各ステージの名前を格納　配列型変数
    public string[] stagename_scene;


    //ゲームオーバー用
    //スレージセレクトへ戻る
    public string select_scene;


    //リトライ用
    //現在のScene　格納
    public string retry_scene;



    
    

    // Start is called before the first frame update
    void Start()
    {
        //変数に代入　
        retry_scene = SceneManager.GetActiveScene().name;
    

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    /*
     ============================================
    
    各ボタンのメソッド
    ・次のステージへ進む
    ・リトライする
    ・セレクト画面に戻る

    ============================================= 
     */


    //NextStageメソッド
    public void Next()
    {
        //要素数から、同じ名前を探し出す
        for (int j = 0; j < 8; j++)
        {
            //分岐で、配列の中のシーン名と現在のシーン名と一致があったら
            if (retry_scene == stagename_scene[j])
            {
                //次のステージに移動
                SceneManager.LoadScene(stagename_scene[j + 1]);
            }

        }

    }


    //リトライメソッド
    public void Retry()
    {
        //リトライ・リスタートを行う
        SceneManager.LoadScene(retry_scene);
    }



    //ステージセレクトメソッド
    public void Select()
    {
        //セレクト画面に戻る
        SceneManager.LoadScene(select_scene);
    }


    /*
     ========================== 
     
    ステージシーン切り替えメソッド

    セレクトメニューで使用する

    1-1　～　1-8　

     
     ==========================
     */

    //1-1ステージ
    public void StageOne_One_Button()
    {
        SceneManager.LoadScene(stagename_scene[0]);
    }


    //1-2ステージ
    public void StageOne_Two_Button()
    {
        SceneManager.LoadScene(stagename_scene[1]);
    }

    //1-3ステージ
    public void StageOne_Three_Button()
    {
        SceneManager.LoadScene(stagename_scene[2]);
    }


    //1-4ステージ
    public void StageOne_For_Button()
    {
        SceneManager.LoadScene(stagename_scene[3]);
    }


    //1-5ステージ
    public void StageOne_Five_Button()
    {
        SceneManager.LoadScene(stagename_scene[4]);
    }


    //1-6ステージ
    public void StageOne_Six_Button()
    {
        SceneManager.LoadScene(stagename_scene[5]);
    }


    //1-7ステージ
    public void StageOne_Seven_Button()
    {
        SceneManager.LoadScene(stagename_scene[6]);
    }



    //1-8ステージ
    public void StageOne_Eight_Button()
    {
        SceneManager.LoadScene(stagename_scene[7]);
    }

}
