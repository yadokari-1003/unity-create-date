using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{

    public GameObject chasetarget;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - chasetarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = chasetarget.transform.position + offset;
    }
}
