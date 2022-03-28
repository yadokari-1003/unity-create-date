using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudSuraimA_Lv2 : MonoBehaviour
{

    /*
     �}�b�h�X���C��A Lv2�iMud Suraim A Lv2�j�̐ݒ�X�N���v�g
    �E��{����
        ���E�ړ��@�����ǂɂԂ�������A���E���]�i�A�j���[�V�����ǉ��j


    �E���� (Lv2���L�̃X�L��)
        �����D�̃I�u�W�F�N�g�ɐG�ꂽ�ꍇ�AValue�̐��l����
     
     */

    //�}�b�h�X���C���̓����̑���
    public float movespeed = 0.02f;

    //�����́{/-�@�̃X�C�b�`�؂�ւ�
    private bool moveswith;

    //�}�b�h�X���C��A�@�A�j���[�^�[
    private Animator anime;

    //object:mud script
    public FiledMudController mm;

    //Player : script
    public test ss;

    //�}�b�h�X���C���F�^����_���[�W��
    public int muddamege = 2;

    //�D�̉񕜗�
    public int mudheel = 7;

    //�}�b�h�X���C���̃Q�[�W
    public Slider slider;

    //�X���C���{�[���f�ނ̐���
    public GameObject SuraimBallMPrefab;

    //�v���C���[��AP��
    public int APheel = 3;


    // Start is called before the first frame update
    void Start()
    {
        //�ŏ���-�̕����@�Ffalse
        moveswith = false;

        //�ϐ�anime ��Animator���擾
        anime = GetComponent<Animator>();

        //slider���l�Q�ɐݒ�
        slider.value = 5;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        MudSuraimAHP();

    }

    //�}�b�h�X���C��A�̓���
    public void Movement()
    {

        //������
        if (moveswith == false)
        {
            transform.Translate(-movespeed, 0, 0);
            anime.SetBool("Right", false);
            anime.SetBool("Left", true);
        }
        //�E����
        if (moveswith == true)
        {
            transform.Translate(movespeed, 0, 0);
            anime.SetBool("Right", true);
            anime.SetBool("Left", false);
        }

    }



    //�}�b�h�X���C���@HP����
    public void MudSuraimAHP()
    {
        if (slider.value <= 0)
        {

            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {

        //�^�O�I�u�W�F�N�g�FMud�ɐG�ꂽ�ꍇ�Abool�ϐ�moveswith��true/false��؂�ւ�
        if (col.gameObject.tag == "Brock")
        {
            moveswith = !moveswith;
        }

        //�D�ɐG�ꂽ��
        if (col.gameObject.tag == "Mud")
        {
            //�G�ꂽ�I�u�W�F�N�g�̖��O�擾
            string objname = col.gameObject.name;
            //�擾�����I�u�W�F�N�g�̃X�N���v�g�ɕϐ��𑗂�
            mm = GameObject.Find(objname).GetComponent<FiledMudController>();
            mm.MudHeel(mudheel);

        }

        //�v���[���[�ɐG�ꂽ��
        if (col.gameObject.tag == "Player")
        {
            //�v���C���[�Ƀ_���[�W��^����B
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamege);


            //�����Ƀ_���[�W
            slider.value -= 1;

        }

        if (slider.value == 1 && col.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyAPheelCal(APheel);
        }

        //�X���C���{�[���ɂ��_���[�W
        if (col.gameObject.tag == "Suraim Ball")
        {
            slider.value -= 1;

        }

    }

}
