using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButtonSlectsc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //テストプレイボタン
    public void TestButton()
    {
        SceneManager.LoadScene("SampleScene");
    }


    //1-1ステージセレクトボタン
    public void OneStage_one_Button()
    {
        SceneManager.LoadScene("Stage1-1");
    }


    //1-2のステージセレクトボタン
    public void OneStage_two_Button()
    {
        SceneManager.LoadScene("Stage1-2");
    }

    //1-3のステージセレクトボタン
    public void OneStage_three_Button()
    {
        SceneManager.LoadScene("Stage1-3");
    }
    //1-4
    public void OneStage_Fore_Button()
    {
        SceneManager.LoadScene("Stage1-4");
    }
    //1-5
    public void OneStage_Five_Button()
    {
        SceneManager.LoadScene("Stage1-5");
    }
    
    //1-6
    public void OneStage_Six_Button()
    {
        SceneManager.LoadScene("Stage1-6");
    }

    //1-7
    public void OneStage_Seven_Button()
    {
        SceneManager.LoadScene("Stage1-7");
    }

    //1-8
    public void OneStage_Eight_Button()
    {
        SceneManager.LoadScene("Stage1-8");
    }
        


}
