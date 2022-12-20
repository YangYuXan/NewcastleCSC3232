using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravity : MonoBehaviour
{
    CharacterMovement characterMovement;
    Rigidbody rigidbody;

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Low")
        {
            rigidbody.AddForce(new Vector3(0, 9, 0));
        }
    }
}
