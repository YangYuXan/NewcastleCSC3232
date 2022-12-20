using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Direction : MonoBehaviour
{
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * 30f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += transform.forward*0.005f;
        
    }
}
