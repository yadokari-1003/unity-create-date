using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudSuraimB : MonoBehaviour
{
    /*
     �}�b�h�X���C��B�̐ݒ�
    �E�ړ�
        ���E�ړ�
    �E����
        �n�ʂɓD�𐶐�����B
        */


    //�}�b�h�X���C���̑���
    public float movespeed = 0.01f;

    public float junpspeed = 0.1f;

    //�}�b�h�X���C���̍��E���]�X�C�b�`
    public  bool moveswith;

    //�}�b�h�X���C��B�@�A�j���[�^�[
    private Animator anime;

    //Player : script
    public test ss;

    //�}�b�h�X���C��B�F�^����_���[�W��
    public int muddamege = 1;

    //�v���C���[��AP��
    public int APheel = 1;

    //�}�b�h�X���C��B�̃Q�[�W
    public Slider slider;

    //�D�̃I�u�W�F�N�g�i�[��
    public GameObject MudPrefab;

    //�}�b�h�v���n�u�J�E���g�@1�ȏ�L��@0����
    private int mudcount = 0;

    //�u����v�I�u�W�F�N�g�����C���^�[�o��
    public float intrerval = 30.0f;

    //�X���C���{�[���̃v���n�u�i�[��
    public GameObject suraimballMPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //�A�j���[�^�[�擾
        anime = gameObject.GetComponent<Animator>();
        //���Ɉړ�
        moveswith = false;
        //HP�ݒ�
        slider.value = 2;


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        MudSeed();
        MudSuraimBHP();
     
    }



    //�}�b�h�X���C������
    public void Movement()
    {
        if (moveswith == false) //���ړ�
        {
            transform.Translate(-movespeed,0,0);
        }

        if (moveswith == true)�@//�E�ړ�
        {
            transform.Translate(movespeed,0,0);
        }
    }


    public void OnCollisionEnter2D(Collision2D coll)
    {


        transform.Translate(0,0.01f,0);
        
        if (coll.gameObject.tag == "Brock")
        {
            moveswith =! moveswith;
        }

        if (coll.gameObject.tag != "Brock")
        {
            transform.Translate(0, junpspeed, 0);

        }

        if (coll.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamege);
            

            //�����Ƀ_���[�W
            slider.value -= 1;
        }

        if (slider.value == 1 && coll.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyAPheelCal(APheel);
        }
        if (coll.gameObject.tag == "Suraim Ball")
        {
            slider.value--;

        }
    }


    //�u����v����
    public void MudSeed()
    {
        intrerval -= Time.deltaTime;
        if (intrerval < 0)
        {
            mudcount++;
            intrerval += 30;
        }
        if (mudcount == 1)
        {

            Transform obj = this.gameObject.transform;
            GameObject Mud = Instantiate(MudPrefab, new Vector3(obj.position.x, obj.position.y -0.7f ,obj.position.z), Quaternion.identity); 
            mudcount--;
        }
       
    }

    //�}�b�h�X���C��B�@HP����
    public void MudSuraimBHP()
    {
        if (slider.value <= 0)
        {
            Destroy(this.gameObject);
        }
    }

   

}
