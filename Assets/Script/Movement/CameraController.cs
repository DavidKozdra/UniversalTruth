using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
     
        Offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Player !=null) {
            transform.position = Player.gameObject.transform.position + Offset;
        }
    }
}
