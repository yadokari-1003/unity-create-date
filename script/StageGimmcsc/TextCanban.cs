using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCanban : MonoBehaviour
{

    SpriteRenderer sprite;

    //�A�j���[�^�[�i�[
    Animator anime;

    //�{�^���̊i�[
    public GameObject Buttom;

    //�L�����o�X�̃X�C�b�`
    bool canvas_sw = false;


    //Canvas�QUI�@�i�[
    public GameObject Canban_Canvas;
    

    // Start is called before the first frame update
    void Start()
    {
        canvas_sw = false;
        //Canvas�QUI���\�����s��
        Canban_Canvas.gameObject.SetActive(false);

        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //�\���E��펞���\�b�h
        TextUP();
    }

    //�g���K�[�t���@�N�������ꍇ
    public void OnTriggerEnter2D(Collider2D coll)
    {
        //�v���C���[���G�ꂽ�ꍇ
        if (coll.gameObject.tag == "Player")
        {

            //�v���[���[����������A�J�n
            anime.SetBool("Push", true);
           

           
        }



    }


    //�g���K�[�t���@���肪���ꂽ�ꍇ
    public void OnTriggerExit2D(Collider2D coll)
    {

        //�v���[���[�����ꂽ��A�j�����X�g�b�v
        if (coll.gameObject.tag == "Player")
        {

            //�A�j���X�g�b�v
            anime.SetBool("Push", false);

            //�����������\������Ă��āA�v���C���[�����ꂽ�ꍇ
            if (canvas_sw == true)
            {
                //��\�����s��
                Canban_Canvas.gameObject.SetActive(false);
            }
        }
    }
   

    //�\���E��\�����s�����\�b�h
    public void TextUP()
    {
        //�\�����s��
        //�����F�s�{�^������������@���@bool�ϐ� textsw��false�̎�
        if (Input.GetKeyDown(KeyCode.T)  && canvas_sw == false)
        {
            //�L�����o�X�̃X�C�b�`�؂�ւ�:true
            canvas_sw = true;
            //�{�^������������\�����s��
            Canban_Canvas.gameObject.SetActive(true);

          
        }
        //��\�����s���@�����F T�{�^������������@���@bool�ϐ���true�̎�
        else if (Input.GetKeyDown(KeyCode.T)  && canvas_sw  == true)
        {
            //�L�����o�X�̃X�C�b�`�؂�ւ��F false
            canvas_sw = false;
            //��\�����s��
            Canban_Canvas.gameObject.SetActive(false);
        }
    }


 

}
