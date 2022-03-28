using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    /*
     ステージセレクトボタン以外のボタンのスクリプトコントローラー

    ステージセレクトボタン…　StageSelect_Buton
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
