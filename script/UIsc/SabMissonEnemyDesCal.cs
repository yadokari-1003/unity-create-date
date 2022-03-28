using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
    �T�u�~�b�V���� : ����̓G��|���i�t�B�[���h����������j

*/


public class SabMissonEnemyDesCal : MonoBehaviour
{
    //�z�� : �G�@
    GameObject[] enemys;

    float  timer = 0;
    float interval = 1.0f;

    Animator anime;
   
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        anime.SetBool("Clear",false);
    }

    // Update is called once per frame
    void Update()
    {

        
        timer += Time.deltaTime;
        if (timer > interval)
        {
            EnemyCal("Enemy");
            timer = 0;
        }
    }



    public void EnemyCal(string tagEnemy)
    {
        enemys = GameObject.FindGameObjectsWithTag(tagEnemy);
        if (enemys.Length == 0)
        {
            anime.SetBool("Clear",true);
        }
        else
        {
            anime.SetBool("Clear", false);
        }
    }


}
