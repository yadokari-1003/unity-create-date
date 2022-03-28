using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasurebox : MonoBehaviour
{
    //�󔠁F�X�N���v�g�i�I�u�W�F�N�g�j



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



        //���[�v�t���󔠂Ɏg�p
        //���[�v����ꍇ�A�����蔻��y�ѕ������Z�@�d��=0

        if (col.gameObject.tag == "Rope")
        {
            GetComponent<BoxCollider2D>().enabled = false;
           // rd2d.gravityScale = 0;
            rd2d.freezeRotation = true;
            rd2d.isKinematic = false ;
        }



    }

    //�Ώۂ̔��肪���ꂽ��
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
