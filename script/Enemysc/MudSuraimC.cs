using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudSuraimC : MonoBehaviour
{
    /*
    �@�}�b�h�X���C��C
    �@��{�����Ȃ�
    HP�͍���
    �X���C���{�[�������Ȃ�o���{�[�i�X�G
    �A�j���\�V�����Ńv���[���[�̈ʒu�Ŗڂ̈ʒu��ύX����B
     */

    //�v���[���Ƀ_���[�W
    public int muddamage = 1;

    public int APheel = 3;

    public test ss;

    public Transform player;

    public Slider slider;

    public GameObject suraimballMPrefab;




    // Start is called before the first frame update
    void Start()
    {
        slider.value = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        MudSuraimCHP();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamage);
          

            slider.value--;
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


    //�}�b�h�X���C��C�@HP����
    public void MudSuraimCHP()
    {
        if (slider.value <=0)
        {

           
            Destroy(this.gameObject);
        }
    }
}
