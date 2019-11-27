using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{

    public int Currency, EarningRate,Karma;
    public float Timer = 20f, AddTimer = 4f, Speed = 5f;
    public Text Money, AddText;
    public Planet P = null;
    public GameObject Display;
    public List<GameObject> OwnedPlanets = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        P = null;
    }


    public void Define()
    {

        if (Planet.Selected)
        {
            if (P != null)
            {
            }
        }
        else
        {
            P = null;
        }
    }
    // Update is called once per frame
    void Update()
    {

        Define();
        if (AddText.gameObject.activeSelf)
        {
            AddTimer -= .1f;
            if (AddTimer <= 0)
            {
                AddText.gameObject.SetActive(false);
                AddTimer = 4f;
            }
        }
        Money.text = "ӫ:" + Currency;
        Timer -= .1f;
        if (Timer <= 0f)
        {
            Currency += EarningRate;
            Timer = 20f;
        }
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += Speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= Speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += Speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= Speed * Time.deltaTime;
        }
        transform.position = pos;
    }

    public void CheckDistance()
    {
        if (P != null)
        {

            float dist = Vector3.Distance(P.transform.position, transform.position);
            if (dist >= 15)
            {
                Planet.Selected = false;
                Display.SetActive(false);
            }
        }
    }
}

