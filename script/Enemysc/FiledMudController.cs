using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiledMudController : MonoBehaviour
{


    public Slider slider;


    public Slider[] sliders;

    public GameObject[] uisliders;


    public int interval = 30;

    //アニメーター
    public Animator anime = null;


    test ss;

    public int muddamega = 1;
  
    public GameObject slider_obj ;
    public float active_timer = 0;
    public float active_interval = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = 30;
        uisliders = GameObject.FindGameObjectsWithTag("Mud");
        slider_obj = slider.gameObject;
        slider_obj.SetActive(false);
       
    

    }

    // Update is called once per frame
    void Update()
    {
        anime = GetComponent<Animator>();   
        MudHPAnime();
        


        active_timer += Time.deltaTime;
        if (active_interval < active_timer)
        {
            slider_obj.SetActive(false);
            active_timer = 0;
        }
        
        
    }


    public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")　//タグ：Playerが触れた場合
        {

            slider_obj.SetActive(true);
            if (Input.GetKey(KeyCode.C))　//　Cボタンを押した場合
            {
                interval = interval - 1;
                if (interval % 3 == 0)　//インターバルを3で割った商の余りがない（0の場合）場合,Sliderの数値を減らす
                {
                    slider.value --;    //ゲージを減らす
                   

                    if (interval < 0) //インターバルの回復
                    {
                        interval =+30;
                    }
                }
            }
        }


        if (slider.value < 1 && col.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.MudLv1(muddamega);
        }
    }


    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Suraim Ball")
        {
            slider.value -= 10;

        }
    }




    //泥のHPの数値でアニメーションの変化を行う。
    public void MudHPAnime()
    {


        anime.SetBool("Mud HP20", false);
        anime.SetBool("Mud HP10", false);
        anime.SetBool("Mud HP5", false);

        if (slider.value <= 20 && slider.value > 10)
        {
            print("アニメーション１");
            anime.SetBool("Mud HP20",true);
            anime.SetBool("Mud HP10", false);
            anime.SetBool("Mud HP5", false);

        }
        if (slider.value <= 10 && slider.value > 5)
        {
            print("アニメーション２");
            anime.SetBool("Mud HP20", false);
            anime.SetBool("Mud HP10",true);
            anime.SetBool("Mud HP5", false);

        }
        if (slider.value <= 5 && slider.value > 0)
        {
            print("アニメーション３");
            anime.SetBool("Mud HP20", false);
            anime.SetBool("Mud HP10",false);
            anime.SetBool("Mud HP5",true);
        }
        if (slider.value == 0)
        {
            
            Destroy(this.gameObject);
        }
        

       
    }
    

  
    //マッドスライムAが触れたら回復の計算
    public void MudHeel(int amount)
    {
        slider.value = slider.value + amount;

    }
        



}
