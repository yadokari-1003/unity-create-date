using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraimBall : MonoBehaviour
{
    /*
     �X���C���{�[���̃X�N���v�g
    �A�C�e���Ƃ��Ďg�p
    �G��u����v�I�u�W�F�N�g�Ƀ_���[�W��^����B
    �_���[�W��^�����������B
     */

    //�_���[�W��
    public int Damege = 1;

    private FiledMudController mm;

    private mudsuraimA ma;

    private MudSuraimB mb;

    private MudSuraimC mc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Mud")
        {
            Destroy(this.gameObject);
        }
    }
}
