using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor : MonoBehaviour
{
    public Sprite[] Pics;
    public float Time;
    float PastTime;
    // Start is called before the first frame update
    void Start()
    {
        PastTime = Time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time > 0)
        {
            Time-=.2f;
        }
        else if(Time <=0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Pics[rand()];
            Time = PastTime;
        }

    }
    int rand() {

        int r = Random.Range(0, Pics.Length);
        return r;
    }
}
