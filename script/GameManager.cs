using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 ==============================

   GameManager：実行すること

・ゲームクリア
パネル表示
・ゲームオーバー
パネル表示


プレイヤーの　HP/AP管理

 
 ==============================
 */



public class GameManager : MonoBehaviour
{
    //=======================================
    //ゲーム演出：
    //ゲームクリア　ゲームオーバー
    //=======================================

    //ゲームクリア　パネル
    public GameObject clearpanel;

    //ゲームオーバー　パネル
    public GameObject overpanel;




    //============================================
    //プレイヤー　HP　AP　ボールの所持数表示
    //============================================
    　
    //プレイヤー　HPスライダー　格納
    public Slider player_HPslider;

    //プレイヤー　HPスライダー　管理
    public static Slider player_hp;


    //プレイヤー　APスライダー　格納
    public Slider player_APslider;

    //プレイヤー　APスライダー　管理
    public static Slider player_ap;


    //スライムボールの所持数
    public static int suraimball_num = 10;

    public GameObject suraimball_text_obj = null;
    


    // Start is called before the first frame update
    void Start()
    {

        //非表示　クリア・オーバーパネル
        clearpanel.SetActive(false);
        overpanel.SetActive(false);



        //HP格納　⊳　HP管理
        player_hp = player_HPslider;
        //AP格納　⊳　AP管理
        player_ap = player_APslider;

        //プレイヤーHP　最大値・最小値　設定
        player_hp.maxValue = 10;
        player_hp.minValue = 0;

        //プレイヤーAP　最大値・最小値　設定
        player_ap.maxValue = 10;
        player_ap.minValue = 0;
        


    }




    //メイン
    // Update is called once per frame
    void Update()
    {


        //ボール所持数表示
        BallText();



        //ゲームクリアメソッド
        GameClear();

        //ゲームオーバーメソッド
        GameOver();
    }









    //スライムボールテキスト表示メソッド
    public void BallText()
    {

        //テキストオブジェ　⊳　変数代入・管理　Text取得
        Text suraimball_text = suraimball_text_obj.GetComponent<Text>();
        //テキスト変更
        suraimball_text.text = "x" + suraimball_num;
    }

    //ボールの所持管理　０以下は生成不可　1以上必要
    public void BallHaveNum()
    {

    }


    //ゲームクリアメソッド
    public void GameClear()
    {
        if (GameClearCl.gamestate == "gameclear")
        {
            //表示
            clearpanel.SetActive(true);
        }
    }


    //ゲームオーバーメソッド
    public void GameOver()
    {
        if (player_hp.value <= 0)
        {
            //表示
            overpanel.SetActive(true);
        }

    }


}
