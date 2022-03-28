using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronPipeItem : MonoBehaviour
{


    bool sw;
    float sw_timer = 0;
    float sw_interval = 3.0f;
    public GameObject Item_suraimbrock;


    // Start is called before the first frame update
    void Start()
    {
        sw = true;
    }

    // Update is called once per frame
    void Update()
    {
        Itemobj_Prefab();
    }

    //ÉAÉCÉeÉÄê∂ê¨
    public void Itemobj_Prefab()
    {
        sw_timer += Time.deltaTime;
        if (sw_interval < sw_timer  )
        {
            
            GameObject Item_obj = Instantiate(Item_suraimbrock, transform.position, Quaternion.identity);
           
            Destroy(Item_obj, 3f);

            sw_timer = 0;
            
        }
    }
}
