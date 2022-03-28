using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronPipe_Mud : MonoBehaviour
{
    /*
     �E�S�p�C�v�@����
      �p�r�P�Fobj + ����@�Ƃ��Ĕz�u
    �@�p�r�Q�F�M�~�b�N�P�@�G�̐������s��

     */

    //�A�j���[�^�[�̎擾
    public Animator anime = null;

    //HP�@�i�[��
    public int ironpipe_HP = 5;

    public Slider HPslider;

    //Clean�@�^�C�}�[
    public float timer_clean = 0;

    //Clean �C���^�[�o��
    public float interval_clean = 3.0f;


    //Enemy�i�G�́jprehab �̊i�[��
    public GameObject enemy_prehab;

    public float enemy_timer = 0;

    public float  enemy_interval = 5.0f;

    public int enemy_count = 3;


    float find_timer = 0;
    float find_interval = 20.0f;



    // Start is called before the first frame update
    void Start()
    {
        //�A�j���[�^�[�̎擾
        anime = GetComponent<Animator>();
        HPslider.value = 5;

    }

    // Update is called once per frame
    void Update()
    {
        IronPipe_anime();
        
        IronPipe_Mud_gimmick();
        //IronPipe_EnemyCountrecovery();
    }


   

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IronPipe_Clean();
        }
    }




    //����̃A�j���\�V����
    public void IronPipe_anime()
    {
        if (HPslider.value > 1)
        {
            anime.SetBool("Clean",false);
        }

        if (HPslider.value == 0)
        {
            anime.SetBool("Clean", true);
        }
        if (HPslider.value < 0)
        {
            ironpipe_HP = 0;
        }


    }

    //�����HP�R���g���[���[
    public void IronPipe_Clean()
    {
        if (Input.GetKey(KeyCode.C))
        {
            timer_clean += Time.deltaTime;
            if (timer_clean > interval_clean)
            {
                HPslider.value--;
                timer_clean = 0;
            }
        }
    }

    //�����Ԃ̎��̃M�~�b�N
    public void IronPipe_Mud_gimmick()
    {
        if (HPslider.value > 1 && enemy_count > 0)
        {
            enemy_timer += Time.deltaTime;
            if (enemy_timer > enemy_interval && enemy_count > 0)
            {
                GameObject Enemy_ironpipe = Instantiate(enemy_prehab, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                enemy_count--;
                enemy_timer = 0;

            }
        }
    }

    public void IronPipe_EnemyCountrecovery()
    {
       

        find_timer += Time.deltaTime;
        if (find_timer > find_interval)
        {
            enemy_count += 3;

            find_timer = 0;
        }
    }

}
