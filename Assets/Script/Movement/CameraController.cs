using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    public Vector3 Offset;
    public float zoomSize = 5f;
    void Start()
    {
        gameObject.GetComponent<Camera>().orthographicSize = zoomSize;
        Offset = transform.position - Player.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoomSize > 5)
            {
                zoomSize -= 8;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomSize += 8;
        }
        gameObject.GetComponent<Camera>().orthographicSize = zoomSize;

        if (Player != null)
        {
            transform.position = Player.gameObject.transform.position + Offset;
        }
    }
}
