using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Currency, EarningRate;
    public float Timer = 10f, Speed = 5f;
    public bool Timed, Paused; //needed for life
    public List<Transform> OwnedPlanets = new List<Transform>();
    private float oringinalValue;

    void Start()
    {
        oringinalValue = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Timed = true;
            Currency += EarningRate;
            Timer = oringinalValue;
        }
        else
        {
            Timed = false;
        }

        if (!Paused)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            transform.position += input * Speed * Time.deltaTime;
        }
    }
}

