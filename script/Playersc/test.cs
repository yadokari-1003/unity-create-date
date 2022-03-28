using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{

    //====================================
    //�v���C���[�G�@�Q�[�����
    //====================================

    //���݂̃Q�[�����
    public static string gamestate = "playing";



    /*
     ========================
    �v���C���[�G�@�����i�����j�@
     ========================
     */
    //�����̃X�s�[�h
    public float moveSpeed = 0.1f;

    //�W�����v�X�s�[�h
    public float JunpSpeed = 0.01f;

    //�������Z�QD
    Rigidbody2D rd_player;

    //�n�ʂ̃��C���[
    public LayerMask ground_layer;

    //�W�����v�J�n����
    bool jump_sw = false;

    //�n�ʂɗ����Ă��锻��
    bool ground_sw = false; 



    //============================
    //�v���C���[�G�@�A�j���[�^�[ �A�j���\�V����
    //============================

    //�v���C���[�A�j���[�^�[
    private Animator anim = null;

    //�Đ��A�j���@�i�[
    public string nowanime = ""; �@//�X�V��
    public string oldanime = "";�@ //�X�V�O

    //======================
    //�A�j���N���b�v
    //======================

  
    //�A�j���N���b�v�@�f�t�H���g���

    //���ʊG
    public string HPanime_defalt_stand = "Player Suraim Stand";
    //�E�W�����v
    public string HPanime_defalt_RightJump = "Player Suraim janp";
    //���W�����v
    public string HPanime_defalt_LeftJump = "Player Suraim Left Junp";
    //�E����
    public string HPanime_defalt_RightWalk = "Player Suraim Right Walk";
    //������
    public string HPanime_defalt_LeftWalk = "Player Suraim Left Walk";



    //�A�j���N���b�v�@C�{�^���@���������[�V����
    public string HPanime_Clean = "Player Suraim Clean Mothion";

    //�A�j���N���b�v ������Lv1

    //���ʊG
    public string HPanime_MudLv1_stand = "Player Suraim Stand MudLv1";
    //�E����
    public string HPanime_MudLv1_RightWalk = "Player Suraim Right Walk Mud Lv1";
    //������
    public string HPanime_MudLv1_LeftWalk = "Player Suraim LeftWalk Mud Lv1";
    //�W�����v
    public string HPanime_MudLv1_Janp = "Player Suraim Janp Mud Lv1";



   

    
    // ================================
    //�v���C���[�G�@�X�e�[�^�X�@HP(�̗�)�@AP�i�ʐρj
    //=================================


    //HP�i�̗́j�p�̃X���C�_�[
    public Slider HPslider;

    //�X���C���{�[���̏������ϐ�
    public int suraimballnum = 5;

    //�X���C���{�[���̏������e�L�X�g
    public GameObject balltext = null;



    //AP�X���C�_�[�i�G���A�|�C���g�j�X���C���{�[�������p�̃X���C�_�[
    public Slider APslider;
    //�v���C���[�傫���ύX
    public Vector3 APscare;



    //===================================================
    //�v���C���[�G�@�{�[���@�p�x�@�����̊p�x�@
    //===================================================

    //�X���C���{�[���̃v���n�u�i�[��
    public GameObject suraimballpreafb;

    //float�^�@�ϐ���ballspeed�@�{�[���̃X�s�[�h��ݒ�@�@
    public float ballspeed = 0.05f;

    //�����グ��ʒu�̎擾
    public Transform have_obj_trans;



    //���̃v���X/�}�C�i�X��؂�ւ���X�C�b�`
    public bool tswicth = true;
    public bool tswicth2 = false;



    //���E�����̌��m  ���L�[�Ō����Ă��������ۑ�����
    bool Rightdir = false;�@//�E����
    bool Leftdir = false;  //������



    //���UI
    //�{�[���̊p�x�����߂邽�߂̃I�u�W�F�N�g�i�[
    public GameObject Target;


    //�p�x�����̕ϐ��@targetz Z���𑀍�@
    public float targetz;
    //�p�x���߁@�w���𑀍�
    public float xdir = 0f;
    float xdirMax = 2f;
    float xdirMin = 0;
    //-X��
    float LxdirMax = -2f;
    //�p�x���߁@�x���𑀍�
    public float ydir = 1.5f;
    float ydirMax = 2f;
    float ydirMin = 0f;





    
    public float timer = 10.0f;

    public int  interval = 30;







    


    // Start is called before the first frame update
    void Start()
    {

        //�Q�[���v���C��
        gamestate = "playing";

        //�A�j���[�^�[�@�擾
        anim = GetComponent<Animator>();

        anim.SetBool("Stand", true);

        //���ʃA�j������
       //nowanime = HPanime_defalt_stand;
       //oldanime = HPanime_defalt_stand;




        //RigidBody�QD�@�擾
        rd_player = GetComponent<Rigidbody2D>();

        //HP�@�X���C�_�[�@�ݒ�
        HPslider.value = 10;
        //AP�X���C�_�[�@�ݒ�
        APslider.value = 4;


       
        //���UI��\��
        Target.SetActive(false);

        targetz = 1;

    }�@�@

    // Update is called once per frame
    void Update()
    {
        //�v���C������Ȃ��ꍇ
        if (gamestate != "playing")
        {
            return;
        }


        //���C���[����֐�
        LayerTrigger();

        //�v���C���[�̓����̊֐�
        Movemennt();

        //�W�����v�֐�
        Jump();

        //�{�[�������̊֐�
        SuraimBallThrow();



        SuraimBallConbine();

        CleanMode();

    
        
        PlayerAPscare(); //AP�F�v���C���[�傫���ύX���\�b�h






        
       

        //  PlayerHP_Animathion();

        //MudLv1();


        //�I�C���[�p�̕\��
        // print("�p�x�F" + Target.transform.eulerAngles.z ) ;

    }




    //�����蔻��̊֐��F
    public void OnCollisionEnter2D(Collision2D coll)
    {

        //�^�O�FGomi�ɐG�ꂽ�ꍇ
        if (coll.gameObject.tag == "Gomi")
        {
            //�G�ꂽ�I�u�W�F�N�g���Ǘ�
            GameObject have_obj = coll.gameObject;
            //�G�ꂽ�I�u�W�F�N�g���q�I�u�W�F�N�g�ɂ���
            have_obj.transform.parent = this.gameObject.transform;
            //�v���C���[�ɒǏ]������
            have_obj.transform.position = new Vector2(have_obj_trans.transform.position.x, have_obj_trans.position.y);

        }
    }



    //���C���[����֐��F
    public void LayerTrigger()
    {
        //�n�ʂ̔�����s���@�n�ʂ̃��C���[�ɐG��Ă�����@True�@�G��Ă��Ȃ��ꍇ�@False�@��������
        ground_sw = Physics2D.Linecast(this.transform.position, this.transform.position - (this.transform.up * 0.5f), ground_layer);

    }




    //�|�����[�h�@C�{�^������
    public void CleanMode()
    {
        //C�{�^��
        if (Input.GetKey(KeyCode.C))
        {
            //�������A�j���[�V��������
            nowanime = HPanime_Clean;
            //�������A�j��ON
            anim.Play(nowanime);
            
        }
        else�@// �������A�j��OFF
        {
           
        }
    }



    /*    �{�[���̕��������߂�     */



    //���E�̌��m���s��
    public void DirRLchange()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rightdir = true;
            Debug.Log(Rightdir + "�E�������Ă��܂�");
            Leftdir = false;
            Debug.Log(Leftdir);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Rightdir = false;
            Debug.Log(Rightdir);
            Leftdir = true;
            Debug.Log(Leftdir + "���������Ă��܂�");
        }
    }

   �@//���̊p�x�����߂�
    public void TargetUI()
    {

        //�������@�����Ă����p�x�́A0�x����90�x
        //�E�����@�����ėǂ��p�x�́A270�x����360�x
        //�I�C���[�p��90�x�ȉ��̏ꍇ�A90�x�܂ő���������@90�ȏア�����Ȃ�

        //�������@0�x����90�x�@�I�C���[�p�𑝉�
        if (tswicth == true  && Input.GetKey(KeyCode.DownArrow))
        {
            //���̃I�C���[�p�i�����j�𑝉�������
            Target.transform.eulerAngles += new Vector3(0, 0, targetz);

            if (45 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z  > 0)
            {
                ydir = 1;
            }
            if (90 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z > 45)
            {
                ydir -= 0.02f;
                if (ydir < ydirMin)
                {
                    ydir = ydirMin;
                }
            }

            xdir += 0.04f;
            if (xdirMax < xdir)
            {
                xdir = xdirMax;
            }


        }


        //�������@�I�C���[�p�@UpButton
        if (tswicth == true && Input.GetKey(KeyCode.UpArrow))
        {
            //���̃I�C���[�p�i�����j�𑝉�������
            Target.transform.eulerAngles -= new Vector3(0, 0, targetz);

            if (45 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z > 0)
            {
                ydir = 1;
            }
            if (90 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z > 45)
            {
                ydir += 0.02f;
                if (ydirMax < ydir)
                {
                    ydir = ydirMax;
                }
            }

            xdir -= 0.02f;
            if (xdir < xdirMin)
            {
                xdir = xdirMin;
            }
          

        }


        //�E����
        if (tswicth2 == true && Input.GetKey(KeyCode.DownArrow))
        {
            //���̃I�C���[�p������������B
            Target.transform.eulerAngles -= new Vector3(0, 0, targetz);

            if (359 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z > 315)
            {
                ydir = 1;
            }
            if (315 > Target.transform.eulerAngles.z  && Target.transform.eulerAngles.z > 270)
            {
                ydir -= 0.02f;
                if (ydir < ydirMin)
                {
                    ydir = ydirMin;
                }
            }
            xdir += 0.02f;
            if (xdirMax < xdir)
            {
                xdir = xdirMax;
            }


        }


        //�E����
        if (tswicth2 == true && Input.GetKey(KeyCode.UpArrow))
        {
            //���̃I�C���[�p������������B
            Target.transform.eulerAngles += new Vector3(0, 0, targetz);

            if (359 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z > 315)
            {
                ydir = 1;
            }
            if (315 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z > 270)
            {
                ydir += 0.02f;
                if (ydirMax < ydir)
                {
                    ydir = ydirMax;
                }
            }
            xdir -= 0.02f;
            if (xdir < xdirMin)
            {
                xdir = xdirMin;
            }


        }
    }
 
    //tswich�@tswich2�@���̍��E�����߂�F���̊Ǘ�
    public void tsright() 
    {

        //�������̎�
        if (Leftdir == true) 
        {

            //���̏�����
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Target.transform.eulerAngles = new Vector3(0, 0, 45);
                xdir = 1;
                ydir = 1;
            }
            
            if ( 90 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z >0)
            {
                //�X�C�b�`�̐؂�ւ�
                tswicth = true;
                tswicth2 = false;

            }
            //Z���O��菬�����ꍇ�@�}�C�i�X�̎�
            if (Target.transform.eulerAngles.z > 90)
            {

                tswicth = false;
                tswicth2 = true;

            }
        }

        if (Rightdir == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Target.transform.eulerAngles = new Vector3(0, 0, 315);
                xdir = 1;
                ydir = 1;
            }
            
            if (359 > Target.transform.eulerAngles.z && Target.transform.eulerAngles.z > 270)
            {
                tswicth = false;
                tswicth2 = true;
            }
            if (270 > Target.transform.eulerAngles.z)
            {
                tswicth = true;
                tswicth2 = false;
            }
        }
        
    }


//�X���C���{�[���𐶐�����@�\�@B�{�^������
�@�@public void SuraimBallButton()
    {

        //GeyKeyDown�@Up�@��if����else�Ōq����Ə�肭����



        if (Input.GetKey(KeyCode.B))�@�@ //B�{�^���ŃX���C���{�[���̐��� ����
        {
            // ���I�u�W�F�N�g��\���itrue�j�ɂ���B
            Target.SetActive(true);


        }
        else if (Input.GetKeyUp(KeyCode.B) && Rightdir == true && GameManager.suraimball_num > 0)�@//�{�^���𗣂�����{�[�����@�E�����@�ɔ���
        {

            //���I�u�W�F�N�g���\���ifalse�j�ɂ���
            Target.SetActive(false);

            //���݂̃v���[���[�̈ʒu�����擾
            Transform playertrans = this.gameObject.transform;

            //�{�[���𐶐�����A�@�ʒu���v���[���[�̎΂ߏ�ɐݒ���s���B
            GameObject ball = Instantiate(suraimballpreafb, new Vector2(playertrans.position.x + 0.1f, playertrans.position.y + 0.1f), Quaternion.identity);

            //�{�[����Rigidbody(�������Z)���擾
            Rigidbody2D rd2d = ball.GetComponent<Rigidbody2D>();
            //Vector�ϐ��ŁA������p�x��ύX����B
            Vector2 forcedirecthion = new Vector2(xdir, ydir);
            //Vector�ϐ��@�Ɂ@�p�x�@�~�@�{�[���X�s�[�h�@����
            Vector2 force = forcedirecthion * ballspeed;
            //rigidbpdy�ɕϐ��Fforce(�p�x�@*�@�X�s�[�h)��͂Ƃ��đ������B
            rd2d.AddForce(force);



            //�{�[���̏����������炷
            GameManager.suraimball_num--;

        }
        else if (Input.GetKeyUp(KeyCode.B) && Leftdir == true && GameManager.suraimball_num > 0)�@//�{�^���𗣂�����{�[�����@�������@�ɔ���
        {

            //���I�u�W�F�N�g���\���ifalse�j�ɂ���
            Target.SetActive(false);

            //���݂̃v���[���[�̈ʒu�����擾
            Transform playertrans = this.gameObject.transform;

            //�{�[���𐶐�����A�@�ʒu���v���[���[�̎΂ߏ�ɐݒ���s���B
            GameObject ball = Instantiate(suraimballpreafb, new Vector2(playertrans.position.x - 0.1f, playertrans.position.y + 0.1f), Quaternion.identity);

            //�{�[����Rigidbody(�������Z)���擾
            Rigidbody2D rd2d = ball.GetComponent<Rigidbody2D>();
            //Vector�ϐ��ŁA������p�x��ύX����B
            Vector2 forcedirecthion = new Vector2(-xdir, ydir);
            //Vector�ϐ��@�Ɂ@�p�x�@�~�@�{�[���X�s�[�h�@����
            Vector2 force = forcedirecthion * ballspeed;
            //rigidbpdy�ɕϐ��Fforce(�p�x�@*�@�X�s�[�h)��͂Ƃ��đ������B
            rd2d.AddForce(force);



            //�{�[���̏����������炷
            GameManager.suraimball_num--;
        }

        else if (GameManager.suraimball_num <= 0)
        {
            print("�X���C���{�[���̏������͂O�ł�");
        }
    }

   
   //�{�[�������֐�
    public void SuraimBallThrow()
    {
        DirRLchange();

        TargetUI();

        tsright();

        SuraimBallButton();
    }




    //�X���C���{�[���̍���
    public void SuraimBallConbine()
    {
        // C�@������ + M �Ń{�[������
        if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
               
                if (GameManager.player_ap.value > 0 )
                {
                    //AP -1
                    GameManager.player_ap.value--;

                    //�{�[�������� +1
                    GameManager.suraimball_num++;

                    
                    suraimballnum++;
                }

            }

        }
    }

    //�v���C���[����
    public void Movemennt()
    {

        //moveH �c�@X���@moveV �c�@Y��
        float moveH = Input.GetAxis("Horizontal"); //���E�ړ�
        if (moveH < 0)�@//�@���ړ��̃A�j��
        {

            anim.SetBool("Right Walk", false);

            anim.SetBool("Left Walk", true);
            //nowanime = HPanime_defalt_RightWalk;
            //anim.Play(nowanime);
            

           
            
           
        }
        else if (moveH > 0)�@// �E�ړ��̃A�j��
        {

            anim.SetBool("Left Walk", false);

            
            anim.SetBool("Right Walk",true);
           // nowanime = HPanime_defalt_LeftWalk;
            //anim.Play(nowanime);
          
            
        }
        else //�~�܂��Ă���Ƃ��@�A�j��
        {
            anim.SetBool("Right Walk", false);
            anim.SetBool("Left Walk", false);


        }


        //�@�㉺�ړ�
        float moveV = Input.GetAxis("Vertical");
        if (moveV > 0)
        {
            

        }
        else
        {
          
            

        }

        if (moveV > 0 && moveH < 0)
        {
        }
        else
        {
            
            
        }

        if (moveV < 0 )
        {
           
        }
        else
        {
           


        }
       
        transform.Translate(moveH * moveSpeed, 0, 0);
        
    }



    //�W�����v�{�^��
    public void JumpButton()
    {

        //�X�y�[�X�L�[
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�X�C�b�`�n�m
            jump_sw = true;

        }


        
    }

    //�W�����v�́F�n�ʔ���@�X�y�[�X�L�[����@��
    public void JumpPower()
    {

        //�W�����v���e
        if (jump_sw == true &&  ground_sw == true)
        {

            //Y���𓮂������l
            Vector2 jump_dir = new Vector2(0, 8f);
            //�u�ԓI�ȗ͂�������
            rd_player.AddForce(jump_dir, ForceMode2D.Impulse);
            //�X�C�b�`�n�e�e
            jump_sw = false;


            
        }
       
    }

    //�W�����v�֐��F
    public void Jump()
    {
        JumpButton();

        JumpPower();
    }


   


    //HP����@�A�j���[�V�����̐؂�ւ�
    public void MudLv1()
    {
        
        if (HPslider.value < 5)
        {
            anim.SetBool("Stand", false);
            anim.SetBool("Stand Mud Lv1", true);
        }
       
    }


    //�v���C���[HP�@�A�j���Ǘ��@���\�b�h
    public void PlayerHP_Animathion()
    {


       
        if (GameManager.player_hp.value > 6) //�f�t�H���g��ԁ@ HP10�`7
        {

           
            

        }

        
        if (7 > GameManager.player_hp.value && GameManager.player_hp.value > 3) // ������Lv1�@HP6�`4
        {
           
        }


        if (GameManager.player_hp.value  < 3) //������ Lv2�@HP�R�`1
        {

        }


        if (GameManager.player_hp.value < 0) //�Q�[���I�[�o�[�@HP0
        {

        }




    }


        �@ /* �@�@�X���C���{�[��    */

    //�X���C���{�[���̃e�L�X�g�\��
    public void SuraimBalltext()
    {
        Text suraimball = balltext.GetComponent<Text>();
        suraimball.text = "�~" + suraimballnum;�@
    }

    //�X���C���{�[���̏����v�Z�@
    public void SuraimBallHave(int suraimballamount)
    {
        suraimballnum += suraimballamount;
    }



            /*       �v���C���[HP     */

    //[����]�I�u�W�F�N�g�̃_���[�W
    public void MudLv1(int mudClean)
    {
        HPslider.value -=  mudClean;
    }

    //�G����̃_���[�W�v�Z
    public void EnemyDamegeCal(int damege)
    {
        HPslider.value -= damege;
    }

    //�o�P�c�̉񕜌v�Z
    public void BaketuHeel(int Heel)
    {
        GameManager.player_hp.value += Heel;
    }

   


    /*   �v���C���[AP   */

    //�v���C���[�傫���ύX�@���\�b�h�@
    public void PlayerAPscare()
    {
        //Vector3�Ɍ��݂̑傫�����
        APscare = gameObject.transform.localScale;

        //AP�̐��l�Ńv���C���[�̑咆���̃T�C�Y�ύX
        if (GameManager.player_ap.value > 5) // �T�C�Y�F��
        {
            APscare.x = 4;
            APscare.y = 4;
            APscare.z = 4;
            gameObject.transform.localScale = APscare;
        }
        if (5 >= GameManager.player_ap.value && GameManager.player_ap.value > 2)�@// �T�C�Y�F��
        {
            APscare.x = 3;
            APscare.y = 3;
            APscare.z = 3;
            gameObject.transform.localScale = APscare;
        }
        if (2 >= GameManager.player_ap.value)�@//�T�C�Y�F��
        {
            APscare.x = 2;
            APscare.y = 2;
            APscare.z = 2;
            gameObject.transform.localScale = APscare;
        }
    }

    //����̃I�u�W�F�N�g�����AP�񕜌v�Z
    public void MudobjAPheelcal(int mudobjamount)
    {
        APslider.value += mudobjamount;
    }

    //�G�����AP�񕜌v�Z
    public void EnemyAPheelCal(int enemyamount)
    {
        APslider.value += enemyamount;
    }

    //�A�C�e�����g�p����AP�񕜌v�Z
   public void ItemAPheelCal(int itemapamount)
    {
        APslider.value += itemapamount;
    }


   


}
