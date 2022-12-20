using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    public int value=10;
    PlayerState playerstate;


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

        if (collision.gameObject.tag=="player")
        {
            playerstate = collision.gameObject.GetComponent<PlayerState>();
            playerstate.UpdateScore(value);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Ground")
        {
          // Destroy(this.gameObject);
        }
    }

}
