using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{
    public GameObject FlareE;   
    
    // Start is called before the first frame update

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET")
        {
            GameObject temp = Instantiate(FlareE, coll.transform.position, Quaternion.identity); 
            Destroy(temp, 0.3f);
            Destroy(coll.gameObject);
        }
    }
}
