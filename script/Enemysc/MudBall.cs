using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBall : MonoBehaviour
{
    /*   マッドボールのスクリプト　*/

    //プレーヤースクリプト
    test ss;

    //ダメージ変数
    int muddamage = 1;　

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)　//当たり判定管理
    {
        if (col.gameObject.tag == "Player")　//プレーヤの場合
        {
            Destroy(this.gameObject);
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamage);
        }

        if (col.gameObject.tag == "Suraim Ball")　//スライムボールの場合
        {
            Destroy(this.gameObject);
        }
    }
}
