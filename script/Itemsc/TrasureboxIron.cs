using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasureboxIron : MonoBehaviour
{

    GameObject[] ironbox;

    public Animator anime;

    float timer = 0;
    float interval = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        anime.SetBool("Clear", false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (interval < timer)
        {
            IronBoxCheck("Tbox_Iron");
            timer = 0;
        }
    }

    public void IronBoxCheck(string box_iron)
    {
        ironbox = GameObject.FindGameObjectsWithTag(box_iron);
        if (ironbox.Length == 0)
        {
            anime.SetBool("Clear", true);

        }
        else
        {
            anime.SetBool("Clear", false);
        }
        
    }

}
