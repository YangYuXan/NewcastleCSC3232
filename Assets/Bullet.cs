using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
        Debug.Log(_rigidbody);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBullet(Vector3 trans)
    {
        Instantiate(bullet);
        _rigidbody = bullet.GetComponent<Rigidbody>();
        bullet.transform.position=new Vector3(trans.x,trans.y,trans.z);
        _rigidbody.AddForce(trans*5);
    }
}
