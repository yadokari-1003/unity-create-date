using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoruChage : MonoBehaviour
{
    /*
     ���̃X�N���v�g�́Abotoru�̓����t�߂Ƀ{�[�����́A�v���[���i�܂����߁j�����āA
    ���˂̃X�N���v�g�ɕϐ��𑗂�B

     */

    //�{�[���̐��l�i�[
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
