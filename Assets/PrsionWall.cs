using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrsionWall : MonoBehaviour
{
    private Transform meshes;
    public bool up;
    // Start is called before the first frame update
    void Start()
    {
        meshes = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPrison(up);
    }

    public void SetPrison(bool appear)
    {
        up = appear;

        if (up == true)
        {

            meshes.transform.position = new Vector3(meshes.transform.position.x, 0f, meshes.transform.position.z);

        }
        else
        {
            meshes.transform.position = new Vector3(meshes.transform.position.x, -1f, meshes.transform.position.z);
        }
    }
}
