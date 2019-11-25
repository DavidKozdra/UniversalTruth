using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstical : MonoBehaviour
{
    public static int Amount;
    public Rigidbody2D Rb;
    public float speed=2f;
    private float direction=-1;
    // Start is called before the first frame update
    void Start()
    {
        Amount++;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = direction;

        Vector3 movement = new Vector3(-1, 0.0f);
        Rb.velocity = movement * speed;
    }

}
