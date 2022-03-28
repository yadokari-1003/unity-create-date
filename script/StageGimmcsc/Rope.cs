using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    /*
     ロープ：スクリプト
    機能①：スライムボールに触れたら、消える
     */


    public GameObject rope_destroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Suraim Ball")
        {
            Destroy(rope_destroy);
        }
    }
}
