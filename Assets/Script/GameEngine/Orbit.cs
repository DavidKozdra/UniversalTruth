using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {


    public float OrbitSpeed = .01f;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    public SUN Sun => FindObjectOfType<SUN>();
    // Use this for initialization
    void Start () {

        if (Sun !=null) {
            float dist = Vector3.Distance(Sun.gameObject.transform.position, transform.position);
            if (dist >= 100)
            {
                // find new sun some how
            }
            if (dist <= 2)
            {
                Destroy(gameObject);
                //  Sun = null;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Sun!=null) {
            transform.RotateAround(Sun.gameObject.transform.position, zAxis, OrbitSpeed);
        }
    }
}
