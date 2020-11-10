using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUN : MonoBehaviour
{
    public string[] Names;


    int rand(int Min, int Max)
    {
        return UnityEngine.Random.Range(Min, Max);
    }
    // Use this for initialization
    void Start()
    {

        gameObject.name = Names[rand(0, Names.Length)]; //find name for solar system
    }

    // Update is called once per frame
    void Update()
    {

    }

}
