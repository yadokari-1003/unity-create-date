using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    /*
     �X�e�[�W�Z���N�g�{�^���ȊO�̃{�^���̃X�N���v�g�R���g���[���[

    �X�e�[�W�Z���N�g�{�^���c�@StageSelect_Buton
     */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StageSelect_Buton()
    {
        SceneManager.LoadScene("StageSlect");
    }
}
