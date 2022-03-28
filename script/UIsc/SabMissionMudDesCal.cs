using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabMissionMudDesCal : MonoBehaviour
{

    GameObject[] muds;

    float timer = 0;
    float intarval = 2.0f;

    Animator anime;




    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        anime.SetBool("Clear" ,false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > intarval)
        {
            Mudcal("Mud");
        }
    }


    public void Mudcal(string tagmud)
    {
        muds = GameObject.FindGameObjectsWithTag(tagmud);
        if (muds.Length == 0)
        {
            anime.SetBool("Clear", true);
        }
        else
        {
            anime.SetBool("Clear",false);
        }
    }

}
