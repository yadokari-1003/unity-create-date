using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronPipe : MonoBehaviour
{
    /*
    �S�p�C�v�X�N���v�g
    �ړ����@
    �P�����Əo���̖��O�ƈʒu���擾���Ĉړ�����B
    */

    GameObject ironpipe_enter_obj;
    public GameObject ironpipe_exit_obj;



    private  Animator anime = null;



    public float posx = 0;
    public float posy = 0;


    float warptimer = 0;
    float warpinterval = 2.0f;
    bool warpsw = true;

    // Start is called before the first frame update
    void Start()
    {
        ironpipe_enter_obj = this.gameObject;
        //ironpipe_exit_obj =gameObject.transform.Find("Iron Pipe Exit").gameObject;

        //アニメーター取得
        anime = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Warpsw();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && warpsw == true)
        {

            Transform player_pos = coll.gameObject.transform; 
            Transform ironpipe_enter_pos = this.gameObject.transform;
            Transform ironpipe_exit_pos = ironpipe_exit_obj.transform;

            player_pos.position =  new Vector2(ironpipe_exit_pos.position.x +posx, ironpipe_exit_pos.position.y+posy);

            warpsw = false;
            
        }
    }


    public void Warpsw()
    {
        if (warpsw == false)
        {
            warptimer += Time.deltaTime;
            if (warpinterval < warptimer)
            {
                warpsw = true;
                warptimer = 0;
            }
        }
       
    }



　public void IronPipe_anime()
    {

    }

    public void IronPipe_MudHP()
    {

    }


}







