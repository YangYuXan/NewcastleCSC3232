using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Vector2 maxMinAngel;

    private Transform cameraTrasform;
    private Vector3 cameraRotation;

    [SerializeField] private Transform characterTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTrasform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        var tmp_MouseX = Input.GetAxis("Mouse X");
        var tmp_MouseY = Input.GetAxis("Mouse Y");

 

        cameraRotation.x -= tmp_MouseY * mouseSensitivity;
        cameraRotation.y += tmp_MouseX * mouseSensitivity;

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, maxMinAngel.x, cameraRotation.y);
        cameraTrasform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
        characterTransform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
    }
}
