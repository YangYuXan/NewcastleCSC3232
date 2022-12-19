using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Buffer")
        {
            CharacterMovement characterComponent = GetComponent<CharacterMovement>();
            characterComponent.SetSpeedBuffer(1);
            Destroy(collision.gameObject);
        }
        
    }
}
