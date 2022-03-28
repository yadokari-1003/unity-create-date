using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudSuraimDsc : MonoBehaviour
{
    /*       
        �}�b�h�X���C��D�@�X�N���v�g���e
        HP�P�@
        Damge -1
        AP +1
        Drop:����
    ���s����
        ��莞�Ԃ̊��o�ŁA�W�����v����B
        �W�����v���閈�ɁAX���̃v���X/�}�C�i�X��؂�ւ���
        

     */
    //�}�b�h�X���C��D�@HP���l
    public int HP = 1;
    //�_���[�W��
    public int muddamage = 1;
    //AP�񕜗�
    public int APheel = 1;


    //�v���[���[�X�N���v�g
    test ss;

    //�W�����v����܂ł̃C���^�[�o��
    float interval = 2.0f;
    //�W�����v�^�C�}�[
    float timer = 0;

    //�v���X/�}�C�i�X�̐؂�ւ��X�C�b�`
    bool X_R = true;
    bool X_L = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyD_Junp();
        EnemyD_HP();
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
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

    public void EnemyD_HP()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //�W�����v���\�b�h
    public void EnemyD_Junp()
    {
        timer += Time.deltaTime;
        if (interval < timer && X_R == true)//�E�����ɃW�����v
        {
            Transform tf = this.gameObject.transform;
            Rigidbody2D rd = this.gameObject.GetComponent<Rigidbody2D>();
            Vector2 junpforce = new Vector2(20,50) ;
            rd.AddForce(junpforce);
            X_L = true;
            timer = 0;
            X_R = false;

        }
        if (interval < timer && X_L == true) //�������ɃW�����v
        {
            Transform tf = this.gameObject.transform;
            Rigidbody2D rd = this.gameObject.GetComponent<Rigidbody2D>();
            Vector2 junpforce = new Vector2(-20, 50);
            rd.AddForce(junpforce);
            X_R = true;
            timer = 0;
            X_L = false;
        }
    }
}
