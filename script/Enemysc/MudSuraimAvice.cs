using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudSuraimAvice : MonoBehaviour
{
    //�}�b�h�X���C��A�@���{�X��g�p
    /*
     �}�b�h�X���C��A�@����
    HP�S
    damage1

    ����
    �㉺�ɓ���

     */
    //HP�X���C�_�[
    public Slider HPslider;

    //�W�����v�^�C�}�[
    float jtimer = 0;
    float jinterval = 2.0f;
    
    //�}�b�h�X���C���̓����̑���
    public float movespeed = 0.01f;

    //�����́{/-�@�̃X�C�b�`�؂�ւ�
    private bool moveswith;

    //�}�b�h�X���C��A�@�A�j���[�^�[
    private Animator anime;

    //object:mud script
    public FiledMudController mm;

    //Player : script
    public test ss;

    //�}�b�h�X���C���F�^����_���[�W��
    public int muddamege = 1;

    //�D�̉񕜗�
    public int mudheel = 5;

    //�}�b�h�X���C���̃Q�[�W
    public Slider slider;

    //�X���C���{�[���f�ނ̐���
    public GameObject SuraimBallMPrefab;

    //�v���C���[��AP��
    public int APheel = 1;



    // Start is called before the first frame update
    void Start()
    {
        HPslider.value = 4;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyA_vice_move();
        EnemyA_vice_HP();

    }



    //�����蔻��
    public void OnCollisionEnter2D(Collision2D col)
    {
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

    //���� �W�����v���s���B
    public void EnemyA_vice_move()
    {
        jtimer += Time.deltaTime;
        if (jinterval < jtimer)
        {
            //�}�b�h�X���C��D�̃W�����v���\�b�h�����ρ@������ɃW�����v���s�����߁AY���݂̂ɗ͂�������
            Transform tf = this.gameObject.transform;
            Rigidbody2D rd = this.gameObject.GetComponent<Rigidbody2D>();
            Vector2 junpforce = new Vector2(0, 300);
            rd.AddForce(junpforce);
            jtimer = 0;
        }

    }

    public void EnemyA_vice_HP()
    {
        if (HPslider.value <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    
}
