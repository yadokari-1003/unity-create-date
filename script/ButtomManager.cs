using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*===================================
 
 �{�^���}�l�[�W���[
�S�{�^���̊Ǘ����s���X�N���v�g

 ====================================
 */

public class ButtomManager : MonoBehaviour
{

    //�^�C�g����ʁ@�X�^�[�g�{�^��
    public string Start_scene;


    //�e�X�e�[�W�̖��O���i�[�@�z��^�ϐ�
    public string[] stagename_scene;


    //�Q�[���I�[�o�[�p
    //�X���[�W�Z���N�g�֖߂�
    public string select_scene;


    //���g���C�p
    //���݂�Scene�@�i�[
    public string retry_scene;



    
    

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ��ɑ���@
        retry_scene = SceneManager.GetActiveScene().name;
    

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    /*
     ============================================
    
    �e�{�^���̃��\�b�h
    �E���̃X�e�[�W�֐i��
    �E���g���C����
    �E�Z���N�g��ʂɖ߂�

    ============================================= 
     */


    //NextStage���\�b�h
    public void Next()
    {
        //�v�f������A�������O��T���o��
        for (int j = 0; j < 8; j++)
        {
            //����ŁA�z��̒��̃V�[�����ƌ��݂̃V�[�����ƈ�v����������
            if (retry_scene == stagename_scene[j])
            {
                //���̃X�e�[�W�Ɉړ�
                SceneManager.LoadScene(stagename_scene[j + 1]);
            }

        }

    }


    //���g���C���\�b�h
    public void Retry()
    {
        //���g���C�E���X�^�[�g���s��
        SceneManager.LoadScene(retry_scene);
    }



    //�X�e�[�W�Z���N�g���\�b�h
    public void Select()
    {
        //�Z���N�g��ʂɖ߂�
        SceneManager.LoadScene(select_scene);
    }


    /*
     ========================== 
     
    �X�e�[�W�V�[���؂�ւ����\�b�h

    �Z���N�g���j���[�Ŏg�p����

    1-1�@�`�@1-8�@

     
     ==========================
     */

    //1-1�X�e�[�W
    public void StageOne_One_Button()
    {
        SceneManager.LoadScene(stagename_scene[0]);
    }


    //1-2�X�e�[�W
    public void StageOne_Two_Button()
    {
        SceneManager.LoadScene(stagename_scene[1]);
    }

    //1-3�X�e�[�W
    public void StageOne_Three_Button()
    {
        SceneManager.LoadScene(stagename_scene[2]);
    }


    //1-4�X�e�[�W
    public void StageOne_For_Button()
    {
        SceneManager.LoadScene(stagename_scene[3]);
    }


    //1-5�X�e�[�W
    public void StageOne_Five_Button()
    {
        SceneManager.LoadScene(stagename_scene[4]);
    }


    //1-6�X�e�[�W
    public void StageOne_Six_Button()
    {
        SceneManager.LoadScene(stagename_scene[5]);
    }


    //1-7�X�e�[�W
    public void StageOne_Seven_Button()
    {
        SceneManager.LoadScene(stagename_scene[6]);
    }



    //1-8�X�e�[�W
    public void StageOne_Eight_Button()
    {
        SceneManager.LoadScene(stagename_scene[7]);
    }

}
