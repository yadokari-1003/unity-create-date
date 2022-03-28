using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasurebox : MonoBehaviour
{
    //宝箱：スクリプト（オブジェクト）



    public Rigidbody2D rd2d;
 


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }



        //ロープ付き宝箱に使用
        //ロープある場合、当たり判定及び物理演算　重力=0

        if (col.gameObject.tag == "Rope")
        {
            GetComponent<BoxCollider2D>().enabled = false;
           // rd2d.gravityScale = 0;
            rd2d.freezeRotation = true;
            rd2d.isKinematic = false ;
        }



    }

    //対象の判定が離れたら
    public void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Rope")
        {
            GetComponent<BoxCollider2D>().enabled = true;
            rd2d.freezeRotation = false;
            rd2d.isKinematic = true;
        }
    }


}
