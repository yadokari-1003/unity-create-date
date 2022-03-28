using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraimBallMaterial : MonoBehaviour
{
    /*
     スライムボールのマテリアル

    プレイヤースライムが触れた場合、ボールM増加 マテリアルを消す
     */

    public test ss;

    public int ballMheel = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.SuraimBallMHave(ballMheel);

            Destroy(this.gameObject);
        }
    }*/
        
}
