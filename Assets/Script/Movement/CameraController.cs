using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 Offset;
    private Player player;
    private new Camera camera;

    private float zoomSpeed = 0;
    private float zoomGoal = 5f;
    private float zoomCurrent = 5f;
    private const float ZoomAcceleration = 20f;

    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        player = Player.GetComponent<Player>();
        camera.orthographicSize = zoomGoal;
        Offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() //after player moves 
    {
        player.Speed = zoomGoal > 10 ? zoomGoal / 2 : zoomGoal * 2;  

        //if (zoomSize > 10)
        //{ //base speed on zoom
        //    player.Speed = zoomSize / 2;
        //}
        //else 
        //{
        //    player.Speed = zoomSize * 2;
        //}

        float input = Input.GetAxis("Mouse ScrollWheel") * -2f * zoomGoal;
        zoomGoal = Mathf.Clamp(zoomGoal + input, 5, 250); // create a range 
        //setting the zoom to relate to speed 

        //if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //{
        //    if (zoomSize > 5)
        //    {
        //        zoomSize -= 8;
        //    }
        //}
        //if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //{
        //    zoomSize += 8;
        //}

        if (zoomCurrent != zoomGoal) //smoothing 
        {
            zoomSpeed += ZoomAcceleration * Time.deltaTime;
            zoomCurrent = Mathf.MoveTowards(zoomCurrent, zoomGoal, zoomSpeed * Time.deltaTime);
        }
        else
        {
            zoomSpeed = 0;
        }
        camera.orthographicSize = zoomCurrent;

        if (Player != null)
        {
            transform.position = Player.gameObject.transform.position + Offset;
        }

    }
}
