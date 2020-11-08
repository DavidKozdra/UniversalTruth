using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandom : MonoBehaviour
{
    public Sprite[] Images;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Images[Random.Range(0,Images.Length)];
    }

}
