using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudSuraimJsc : MonoBehaviour
{
    /*
     �}�b�h�X���C��J�@�X�N���v�g
    �����@
    HP3
    �_���[�W�P

    �󒆂ɔ�ԓG
    �����_���ňʒu��ύX����

    collider�Ń��[�_�[�쐬
    ���[�_�[�ɓ�������v���[���ɋ߂Â�

     */

    //�^�C�}�[
    float time = 0;
    float interval = 2.0f;

    //�؂�ւ��X�C�b�`
    bool sw = true;
    bool sw2 = false;

    test ss; //�v���[���X�N���v�g


    //Enemy �̗́@�`�o�񕜗ʁ@�_���[�W��
    int APheel = 3;
    int muddamage = 1;
    int HP = 3;
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyJ_HP();
        MudEnemyJ_Move();
    }

    //�}�b�h�X���C��J�@����
    public void MudEnemyJ_Move()
    {
        time += Time.deltaTime;�@//�v���X�^�C�}�[
        if (interval < time && sw == true)//sw true�̎��@�v���X�ړ�
        {
            float trans_ran = Random.Range(0,10);�@//�����_�����l����
            transform.Translate(trans_ran, 0,0);�@//x���̂݊Ǘ�
           
            sw = false;�@//sw�؂�ւ�
            

            time = 0;�@//�^�C�}�[�̏�����
        }
        if (interval < time && sw == false)//sw�@false�̎��@�}�C�i�X�ړ�
        {
            float trans_ran = Random.Range(0, -10);�@//�����_�����l����
            transform.Translate(trans_ran, 0, 0);  //�w���̂݃����_���ړ��@

            sw = true;�@//sw�؂�ւ�
            

            time = 0;�@//�^�C�}�[�̐؂�ւ�
        }

    }



    //�����蔻��
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamage);
            ss.EnemyAPheelCal(APheel);
            HP--;
        }


        if (coll.gameObject.tag == "Suraim Ball")
        {
            HP--;
        }
    }

    //HP�Ǘ�
    public void EnemyJ_HP()
    {
        if (HP == 0)�@//�g�o�O�ɂȂ��������
        {
            Destroy(this.gameObject);
        }
    }


}
