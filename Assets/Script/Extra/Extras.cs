using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Extras : MonoBehaviour
{
    public float time,destructiontime = .01f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        time -= destructiontime;

        if (time<=0) {
            Destroy(gameObject);
        }
    }
}
