using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    [SerializeField]public GameObject candy;
    [SerializeField] GameObject boom;
    [SerializeField] GameObject Buffer;
    public float time;

    private int count=0;

    public bool _spawnCandy;
    public bool _spawnBoom;
    public bool _spawnBuffer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        count++;

        if (_spawnCandy == true)
        {
            if (time >= 1)
            {
                if (count % 3 == 0)
                {
                    SpawnCandy();
                }
                
            }

        }
            if (_spawnBoom == true)
            {
                if (time >= 1)
                {

                    if (count % 3 == 0)
                    {
                        SpawnBoom();
                    }
                    
                }
            }

            if (_spawnBuffer == true)
            {
                if (time >= 1)
                {

                    if (count % 5 == 0)
                    {
                        SpawnBuffer();
                    }
                    time = 0;
                }
            }

    }

    void SpawnCandy()
    {
        Instantiate(candy);
        candy.transform.position = new Vector3(Random.Range(-5, 5), 2, Random.Range(-5, 5));
    }

    void SpawnBoom()
    {
        Instantiate(boom);
        boom.transform.position = new Vector3(Random.Range(-5, 5), 2, Random.Range(-5, 5));
    }

    void SpawnBuffer()
    {
        Instantiate(Buffer);
        Buffer.transform.position = new Vector3(Random.Range(-5, 5), 2, Random.Range(-5, 5));
    }

}
