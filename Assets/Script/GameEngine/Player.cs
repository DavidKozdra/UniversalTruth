using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public int Currency, EarningRate;
    public float Timer = 10f, Speed = 5f;
    public Planet P = null;
    public bool Timed; //needed for life
    public List<Transform> OwnedPlanets = new List<Transform>();
    float o;
    void Start()
    {
        P = null;
        o = Timer;
    }



    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Timed = true;
            Currency += EarningRate;
            Timer = o;
        }
        else {
            Timed = false;
        }

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

           transform.position += input * Speed * Time.deltaTime;
      
    }

}

