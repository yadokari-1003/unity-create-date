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

    //�A�j���[�^�[
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
        if (col.gameObject.tag == "Player")�@//�^�O�FPlayer���G�ꂽ�ꍇ
        {

            slider_obj.SetActive(true);
            if (Input.GetKey(KeyCode.C))�@//�@C�{�^�����������ꍇ
            {
                interval = interval - 1;
                if (interval % 3 == 0)�@//�C���^�[�o����3�Ŋ��������̗]�肪�Ȃ��i0�̏ꍇ�j�ꍇ,Slider�̐��l�����炷
                {
                    slider.value --;    //�Q�[�W�����炷
                   

                    if (interval < 0) //�C���^�[�o���̉�
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




    //�D��HP�̐��l�ŃA�j���[�V�����̕ω����s���B
    public void MudHPAnime()
    {


        anime.SetBool("Mud HP20", false);
        anime.SetBool("Mud HP10", false);
        anime.SetBool("Mud HP5", false);

        if (slider.value <= 20 && slider.value > 10)
        {
            print("�A�j���[�V�����P");
            anime.SetBool("Mud HP20",true);
            anime.SetBool("Mud HP10", false);
            anime.SetBool("Mud HP5", false);

        }
        if (slider.value <= 10 && slider.value > 5)
        {
            print("�A�j���[�V�����Q");
            anime.SetBool("Mud HP20", false);
            anime.SetBool("Mud HP10",true);
            anime.SetBool("Mud HP5", false);

        }
        if (slider.value <= 5 && slider.value > 0)
        {
            print("�A�j���[�V�����R");
            anime.SetBool("Mud HP20", false);
            anime.SetBool("Mud HP10",false);
            anime.SetBool("Mud HP5",true);
        }
        if (slider.value == 0)
        {
            
            Destroy(this.gameObject);
        }
        

       
    }
    

  
    //�}�b�h�X���C��A���G�ꂽ��񕜂̌v�Z
    public void MudHeel(int amount)
    {
        slider.value = slider.value + amount;

    }
        



}
