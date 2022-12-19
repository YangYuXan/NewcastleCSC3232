using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public int value = -20;
    PlayerState playerstate;
    CharacterMovement characterMovement;
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

        if (collision.gameObject.tag == "player")
        {


            //Loss Point
            playerstate = collision.gameObject.GetComponent<PlayerState>();
            playerstate.UpdateScore(value);

            //Debuff Loss Speed
            characterMovement = collision.gameObject.GetComponent<CharacterMovement>();
            characterMovement.SetSpeedBuffer(-1);

            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("collision.gameObject.tag");
           // Destroy(this.gameObject);
        }
    }
}
