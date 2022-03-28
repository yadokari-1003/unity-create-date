using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearCl : MonoBehaviour
{

    /*
     ==============================================================
        ゲームクリア　スクリプト　
    ノーマルゲームクリア条件　フィールドの汚れを掃除（消す）したらクリア
    サブミッション追加
    ===============================================================
     */

    //ゲームクリアを知らせる
    public static string gamestate = "";

    //スライダー　格納
    public Slider noslider;
    　
    

    //GameObject配列　敵の格納
    GameObject[] EnemyObjects;

    //GameObject配列　汚れの格納
    GameObject[] MudObjects;

    //int配列　数値の格納
    int[] tagobjnum;


    //クリアタイマー
    float timer = 0.0f;
    float interval = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        

        //敵の数 最大値を設定　スライダーに代入
        noslider.maxValue += GameObject.FindGameObjectsWithTag("Enemy").Length;

        //汚れの数　最大値を設定　スライダーに代入
        noslider.maxValue += GameObject.FindGameObjectsWithTag("Mud").Length;
    }


    //メイン関数
    // Update is called once per frame
    void Update()
    {

        //時間経過でフィールド内を調べる
        timer += Time.deltaTime;
        
        if (timer > interval)
        {
            //Check関数：
            Check("Enemy" , "Mud");
            //タイマーリセット
            timer = 0;
        }


       
    }


    //Check関数 : 対象のオブジェクトを探す
    public void Check(string tagname, string tagname2)
    {
        //タグが付いた 敵・汚れ を調べる
        EnemyObjects = GameObject.FindGameObjectsWithTag(tagname);
        MudObjects = GameObject.FindGameObjectsWithTag(tagname2);

        //集計を行う　
        int allnum = EnemyObjects.Length + MudObjects.Length;
        //現在の数：表示
        Debug.Log("汚れの数："+ allnum);
        //スライダーに代入
        noslider.value = allnum;

        //クリア条件
        if (allnum == 0)
        {
            gamestate = "gameclear";


        }

    }
        
  

    
}
