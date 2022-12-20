using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physical : MonoBehaviour
{
    Rigidbody _rigidbody;
    BoxCollider _collider;
    
    private float _leaveGroundTime=0;
    private bool _isfalling;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
       // _rigidbody.AddForce(new Vector3(2, 0, 0),ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Speed(_rigidbody);
        Debug.Log("G: " + _rigidbody.velocity.y);
    }

    /*
     * @Parm component: Use Rigibody's function 
     */
    void SetGravity(Rigidbody component)
    {
        component.AddForce(-Physics.gravity);
    }

    //物体下落的速度
    void Speed(Rigidbody component)
    {
        component.velocity = new Vector3(0, -2, component.velocity.z);
    }

}
