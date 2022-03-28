using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraimItemBrock : MonoBehaviour
{


    test ss;

    public int APheel = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.ItemAPheelCal(APheel);
            Destroy(this.gameObject);
        }
    }

}
