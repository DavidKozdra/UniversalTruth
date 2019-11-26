using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int Count,YRange,XRange,SpawnedMax;
    public GameObject[] Spawnables;
    public float Buffer = 2f;
     float OB;
    

    // Start is called before the first frame update
    void Start()
    {
        OB = Buffer;
    }

    // Update is called once per frame
    void Update()
    {
        bool stop=false;
        if (SpawnedMax!=0) {
            if (Count >= SpawnedMax)
            {
                stop = true;
            }
            else {
                stop =false;
            }
        }
        if (Buffer <= 0 && !stop)
        {
                Count++;

            Instantiate(Spawnables[rand(0,Spawnables.Length)], new Vector3(gameObject.transform.position.x + rand(-XRange, XRange), gameObject.transform.position.y+rand(-YRange, YRange), -1), Quaternion.identity);
            Buffer = rand2(0,OB);
        }
        else {
            Buffer -= .1f;
        }
    }
    float rand2(float Min,float Max) {
        return Random.Range(Min, Max);
    }
    int rand(int Min, int Max)
    {
        return Random.Range(Min, Max); ;
    }
}

