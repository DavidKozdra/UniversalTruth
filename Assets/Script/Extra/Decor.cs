using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor : MonoBehaviour
{
    public Sprite[] Pics;
    public float Timer;
    float PastTime;
    // Start is called before the first frame update
    void Start()
    {
        PastTime = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            Timer-=Time.deltaTime;
        }
        else if(Timer <=0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Pics[rand()];
            Timer = PastTime;
        }

    }
    int rand() {

        int r = Random.Range(0, Pics.Length);
        return r;
    }
}
