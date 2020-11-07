using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GameObject Atractor;
    public float maxGravity,maxGravityDist;
    public Rigidbody2D RGB;
    // Start is called before the first frame update
    void Start()
    {
        RGB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(Atractor.transform.position, transform.position);
        Vector3 v = Atractor.transform.position - transform.position;
        RGB.AddForce(v.normalized * (1f *dist/maxGravityDist) *maxGravity);
    }
}
