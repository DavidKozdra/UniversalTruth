using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public int Currency, EarningRate,Karma;
    public float Timer = 10f, AddTimer = 4f, Speed = 5f;
    public Planet P = null;
    public List<Transform> OwnedPlanets = new List<Transform>();
    float o;
    public bool Timed;
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

