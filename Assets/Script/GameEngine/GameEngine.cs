using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GameEngine
    : MonoBehaviour {

    public int Currency, EarningRate;
    public float Timer = 20f, Speed=5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer -= .1f;
        if (Timer <=0f) {
            Currency += EarningRate;
        }
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += Speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= Speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += Speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= Speed * Time.deltaTime;
        }


        transform.position = pos;
    }
}

