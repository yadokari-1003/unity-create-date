using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liftscript : MonoBehaviour
{
    /*
     ���E�ړ�
    �㉺�ړ�
    �㉺���E�ړ�
    �΂߈ړ�

    �����̃��\�b�h��bool �̐؂�ւ��ōs���B
     */
    public bool distans_sw = true;



    public bool RL_Lift_sw = false;
    public bool UD_Lift_sw = false;


    //���E�̐؂�ւ��X�C�b�`
    public bool rightleft_sw = true;
    //�㉺�̐؂�ւ��X�C�b�`
    public bool updown_sw = true;

    //���t�g�X�s�[�h�@
    public float lift_speed  = 0.01f;

    public float distans_x = 5;


    float lift_timer = 0;
    public float lift_inteval = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        LiftSwichController();



        //TestPlay();
        //TestPlay2();



    }


    public void TestPlay()
    {



        if (distans_sw ==  true)
        {
            distans_x -= 0.01f;
            this.gameObject.transform.Translate(lift_speed, 0, 0);
            if (distans_x < 0 && distans_sw == true)
            {
               // distans_x = 0;
                distans_sw =! distans_sw;
            }
        }

        if (distans_sw == false)
        {
            distans_x += 0.01f;
            this.gameObject.transform.Translate(-lift_speed,0,0);
            if (distans_x < 5)
            {
                //distans_x = 5;
                distans_sw = !distans_sw;
            }
        }
          

    }

    
    public void TestPlay2()
    {
        //�^�C�}�[�ŃX�C�b�`�؂�ւ�
        lift_timer += Time.deltaTime;
        if (lift_timer > lift_inteval)
        {
            distans_sw = !distans_sw;
            lift_timer = 0;
        }

        //�v���X�ړ�
        if (distans_sw == true)
        {
            this.gameObject.transform.Translate(lift_speed, 0, 0);
            
        }

        //�}�C�i�X�ړ�
        if (distans_sw == false)
        {
            this.gameObject.transform.Translate(-lift_speed, 0, 0);
        }


    }
    


    //�`���t�g�̈ړ����@�͊O���Ō��߂�悤�ɍs���`


    //�g�p���郁�\�b�h�̐؂�ւ����s��
    public void LiftSwichController()
    {
        //���E�ړ��̃��t�g
        if (RL_Lift_sw == true)
        {
            UD_Lift_sw = false;
            RightLeftLift();
        }


        //�㉺�ړ��̃��t�g
        if (UD_Lift_sw == true)
        {
            RL_Lift_sw = false;
            UpDownLift();
        }
    }





    //���E�ړ��̃��\�b�h
    public void RightLeftLift()
    {
        //�^�C�}�[�ŃX�C�b�`�؂�ւ�
        lift_timer += Time.deltaTime;
        if (lift_timer > lift_inteval)
        {
            //�X�C�b�`�̐؂�ւ��@
            rightleft_sw = !rightleft_sw;
            //�^�C�}�[�̃��Z�b�g���s��
            lift_timer = 0;
        }

        //�v���X�ړ�
        if (rightleft_sw == true)
        {
            this.gameObject.transform.Translate(lift_speed, 0, 0);

        }

        //�}�C�i�X�ړ�
        if (rightleft_sw == false)
        {
            this.gameObject.transform.Translate(-lift_speed, 0, 0);
        }
    }

    //�㉺�ړ��̃��\�b�h
    public void UpDownLift()
    {
        //�^�C�}�[�ŃX�C�b�`�؂�ւ�
        lift_timer += Time.deltaTime;
        if (lift_timer > lift_inteval)
        {
            //�X�C�b�`�̐؂�ւ��@
            updown_sw =! updown_sw;
            //�^�C�}�[�̃��Z�b�g���s��
            lift_timer = 0;
        }

        //�v���X�ړ�
        if (updown_sw == true)
        {
            this.gameObject.transform.Translate(0, lift_speed, 0);

        }

        //�}�C�i�X�ړ�
        if (updown_sw == false)
        {
            this.gameObject.transform.Translate(0, -lift_speed, 0);
        }
    }

    

   

}
