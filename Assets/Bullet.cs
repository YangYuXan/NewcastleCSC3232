using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SpawnBullet(Vector3 trans,Vector3 Target)
    {
        Instantiate(bullet);

        //_rigidbody = bullet.GetComponent<Rigidbody>();
        bullet.transform.localPosition=trans;
        this.transform.LookAt(Target);
        //_rigidbody.AddForce(0f,0f,trans.z*10);
    }
}
