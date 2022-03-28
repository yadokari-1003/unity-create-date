using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoruChage : MonoBehaviour
{
    /*
     このスクリプトは、botoruの入口付近にボール又は、プレーヤ（まだだめ）を入れて、
    噴射のスクリプトに変数を送る。

     */

    //ボールの数値格納
    int ballcahge = 1;

    

    public BotoruShot ss;







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
            Destroy(coll.gameObject);

            ss = GameObject.Find("Botoru Head").GetComponent<BotoruShot>();
            ss.BotoruChageCal(ballcahge);
            

        }
    }
}
