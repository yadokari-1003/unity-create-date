using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canban : MonoBehaviour
{


    public GameObject button;


    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            button.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            button.SetActive(false);
        }
    }
}
