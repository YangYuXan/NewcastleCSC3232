using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Transform characterTransform;
    private Rigidbody characterRigidBody;
    public float jumpHeight;
    public float walkSpeed;
    public float sprintSpeed;
    public float gravity;
    public float crouchHeight;
    public float duration;
    public float punishSpeed;
    //public float bufferDuration;
    float tmp_CurrentSpeed;

    private bool isGround;
    private bool isCrouch;
    private float originHeight;
    private CapsuleCollider capsule;
    private float time;
    

    int isBuff;

    private void Start()
    {
        characterTransform = transform;
        characterRigidBody = GetComponent<Rigidbody>();
        capsule=GetComponent<CapsuleCollider>();
        originHeight = capsule.height;
        isBuff = 0;
        //punishSpeed = 2;
        time = duration;
    }

    private void FixedUpdate() {

        //tmp_CurrentSpeed = walkSpeed;


        if (isGround)
        {
            var tmp_Horizontal = Input.GetAxis("Horizontal");
            var tmp_Vertical = Input.GetAxis("Vertical");

            var tmp_CurrentDirection = new Vector3(tmp_Horizontal, 0, tmp_Vertical);

            if (isBuff==1)
            {

                tmp_CurrentSpeed = sprintSpeed;
                
            }
            else if(isBuff ==0)
            {
                tmp_CurrentSpeed = walkSpeed;

            }else
            {
                tmp_CurrentSpeed = punishSpeed;

            }


            tmp_CurrentDirection = characterTransform.TransformDirection(tmp_CurrentDirection);
            tmp_CurrentDirection *= tmp_CurrentSpeed;

            var tmp_CurrentVelocity = characterRigidBody.velocity;
            var tmp_VelocityChange = tmp_CurrentDirection - tmp_CurrentVelocity;
            tmp_VelocityChange.y = 0;

            characterRigidBody.AddForce(tmp_VelocityChange, ForceMode.VelocityChange);

            if (Input.GetButtonDown("Jump"))
            {
                characterRigidBody.velocity = new Vector3(tmp_CurrentVelocity.x, CalcJump(), tmp_CurrentVelocity.z);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                var tmp_CurrentHeight = isCrouch ? originHeight : crouchHeight;
                StartCoroutine( DoCrouch(capsule,tmp_CurrentHeight));
                isCrouch = !isCrouch;
                Debug.Log(capsule.height);
            }

        }
        //Set Gravity
        characterRigidBody.AddForce(new Vector3(0, -gravity*characterRigidBody.mass, 0));

    }

    private float CalcJump()
    {
        return Mathf.Sqrt(2 * gravity * jumpHeight);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }

    private IEnumerator DoCrouch(CapsuleCollider capsule,float _taget)
    {
        float tmp_CurrentHeight = 0;
        while (Mathf.Abs(capsule.height - _taget) >0.1f)
        {
            yield return null;
            capsule.height = Mathf.SmoothDamp(capsule.height, _taget, ref tmp_CurrentHeight, Time.deltaTime*5);
        }
    }

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
        isBuff = 0;
        //tmp_CurrentSpeed = walkSpeed; ;
    }

    //Get Speed Buffer
    public void SetSpeedBuffer(int type)
    {
        if (type == 1)
        {
            isBuff = 1;

            StartCoroutine(Delay(3));
        }
        else if(type ==0) {
            tmp_CurrentSpeed = walkSpeed;
        }
        else
        {
            isBuff = -1;
            StartCoroutine(Delay(2));

        }

    }
}
