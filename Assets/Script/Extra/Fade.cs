using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + Time.deltaTime, gameObject.transform.position.y + Time.deltaTime);
        gameObject.GetComponent<SpriteRenderer>().size -= new Vector2(Time.deltaTime,Time.deltaTime);
    }
}
