using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public int damage = 1;
    public float speed = 200.0f;

    public GameObject Blood;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        Destroy(gameObject, 5.0f);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "MONSTER")
        {
            ContactPoint contact = coll.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
            Instantiate(Blood, contact.point, rot);  
        }
    }

        // Update is called once per frame
        void Update()
    {

    }
}
