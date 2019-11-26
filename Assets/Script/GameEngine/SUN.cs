using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUN : Planet {

	// Use this for initialization
	void Start () {
        if (Owned)
        {
            Buy();
        }
    }
	
	// Update is called once per frame
	void Update () {
        CalculateMass();
    }
}
