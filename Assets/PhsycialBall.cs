using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhsycialBall : MonoBehaviour
{
    Rigidbody rigidbody;
    Rigidbody self_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        self_rigidbody = GetComponent<Rigidbody>();
        self_rigidbody.velocity=(new Vector3(1, 0, 0));
        //self_rigidbody.AddForce(new Vector3(1, 0, 0) * 800);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("Hit");
            rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward.x*1000,0, transform.forward.z * 1000);

        }
    }
}
