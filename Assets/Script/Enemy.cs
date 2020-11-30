using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 vel = new Vector3(0, -5, 0);
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = vel;
        if (this.transform.position.y < 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 20, this.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Floor")
            vel = Vector3.zero;
    }
}
