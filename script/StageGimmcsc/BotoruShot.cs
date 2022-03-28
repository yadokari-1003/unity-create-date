using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoruShot : MonoBehaviour
{

    /*
     
     botoruChage����ϐ��󂯎��A
    ������{�[���̒e���ɂ���
    0�ɂȂ����猂�ĂȂ��Ȃ�

    �L���b�v�����̃u���b�N�Ƀv���[�����ォ�牟�����ꍇ
    �����{�[���𔭎˂���

    �U���͂�+2�Ōv�Z����

     */

    //�v���[���[���g�p����^���N
    int botorutank;

    //�G���g�p����^���N
    public int mudbotorutank;

    //�v���[���[���g�p����X�C�b�`
    bool psw = false;
    //�G���g�p����X�C�b�`
    bool esw = false;


    //�{�[���X�s�[�h
    public float ballspeed = 75f;

    //�X���C���{�[���̃v���n�u�i�[��
    public GameObject BallPrefab;

    //�}�b�h�{�[���̃v���n�u�i�[��
    public GameObject EnemyBallPrefab;


    public float dirchange = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(esw);
        print(psw);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //�X�C�b�`�̐؂�ւ��@�v���[���[���g�p����ꍇ
            esw = false;
            psw = true;

            if (botorutank > 0  && psw == true)
            {
                //���obj��T���@�ϐ��ɕۊ�
                //GameObject shotobj = GameObject.Find("ShotPos");
                GameObject shotobj = this.gameObject;
                //���I�u�W�F�N�g�̈ʒu��ۊ�
                Transform shotpos = shotobj.transform;
                //�v���n�u����
                GameObject shotball= Instantiate(BallPrefab, new Vector2(shotpos.position.x - 0.15f, shotpos.position.y), Quaternion.identity);
                GameObject shotball2 = Instantiate(BallPrefab, new Vector2(shotpos.position.x - 0.15f, shotpos.position.y), Quaternion.identity);
                //rigidbody2D���擾
                Rigidbody2D rd2d = shotball.GetComponent<Rigidbody2D>();
                Rigidbody2D rd2d2 = shotball2.GetComponent<Rigidbody2D>();
                //Vector�ϐ��ŁB�v���n�u�̐����ʒu������
                Vector2 forcedir = new Vector2(2,0);
                //Vector�ϐ��Ɉʒu��Vector�ϐ��ƃX�s�[�hfloat�ϐ����v�Z�A�������
                Vector2 force = forcedir * ballspeed;
                //Addforce���\�b�h�ŁA�͂�������
                rd2d.AddForce(force);
                rd2d2.AddForce(force);

                botorutank--;
                        
            }
        }


        //�G���G�ꂽ�ꍇ
        if (coll.gameObject.tag == "Enemy")
        {
            //�X�C�b�`�̐؂�ւ��@�G���g�p�ł���悤�ɂ���
            psw = false;
            esw = true;

            //�G���g�p����ꍇ
            if (esw == true)
            {
                EnemyBototuShot();
            }
            
        }



    }


    
    public void EnemyBototuShot()
    {
       
            //�G�����g�p����}�b�h�V���b�g

            //���obj��T���@�ϐ��ɕۊ�
            //GameObject shotobj = GameObject.Find("ShotPos");
            GameObject shotobj = this.gameObject;
            //���I�u�W�F�N�g�̈ʒu��ۊ�
            Transform shotpos = shotobj.transform;
            //�v���n�u����
            GameObject enemyshotball1 = Instantiate(EnemyBallPrefab, new Vector2(shotpos.position.x - 0.15f, shotpos.position.y), Quaternion.identity);
            GameObject enemyshotball2 = Instantiate(EnemyBallPrefab, new Vector2(shotpos.position.x  -0.15f, shotpos.position.y), Quaternion.identity);
            //rigidbody2D���擾
            Rigidbody2D rd2d = enemyshotball1.GetComponent<Rigidbody2D>();
            Rigidbody2D rd2d2 = enemyshotball2.GetComponent<Rigidbody2D>();
            //Vector�ϐ��ŁB�v���n�u�̐����ʒu������
            Vector2 forcedir = new Vector2(dirchange, 0);
            //Vector�ϐ��Ɉʒu��Vector�ϐ��ƃX�s�[�hfloat�ϐ����v�Z�A�������
            Vector2 force = forcedir * ballspeed;
            //Addforce���\�b�h�ŁA�͂�������
            rd2d.AddForce(force);
            rd2d2.AddForce(force);

        Destroy(enemyshotball1, 10.0f);
        Destroy(enemyshotball2, 10.0f);
        
        
    }

    

    //botoruchage����̎󂯎�郁�\�b�h
    public void BotoruChageCal(int amount)
    {
        botorutank += amount;
    }
}
