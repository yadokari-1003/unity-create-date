using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketuItem : MonoBehaviour
{
    /*
     �A�C�e���F�o�P�c�@�v���[���[�񕜃A�C�e��
     
    C�{�^�����������ꍇ�A�������ŉ�
    �񕜗ʂ͂��ƂŐݒ�
    3��g�p�Ŏg�p�s�ƂȂ�B

     
     
     */

    //�v���[���X�N���v�g
    public test ss;

    //�񕜗�
    public int heel = 1;

    //�o�P�c�̃C���^�[�o��
    public float interval = 3.0f;

    //�o�P�c�̎g�p��
    public int usagecount = 9;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(usagecount);
    }


    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.C))
            {
                interval -= Time.deltaTime;
                if (interval < 0 && usagecount > 0)
                {
                    ss = ss = GameObject.Find("Suraim Player").GetComponent<test>();
                    ss.BaketuHeel(heel);

                    usagecount--;
                    interval = 3;
                }

                if (usagecount == 0)
                {
                    print("�o�P�c�͂��Ȃ������ς��ł��B");
                }

               
            }
        }
    }
}
