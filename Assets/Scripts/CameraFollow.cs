﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xMargin = -1f; // Distance in the x axis the player can move before the camera follows.
    public float yMargin = -1f; // Distance in the y axis the player can move before the camera follows.
    public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
    public float ySmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
    public Vector2 maxXAndY; // The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY; // The minimum x and y coordinates the camera can have.
    float targetX;
    float targetY;

    public GameObject target;//player
    private Transform targetPosition;//posicion de player
    public float _camerSpeed;//velocidad de camara
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //almacenar la posicion de objetivo, en este caso es la posicion del jugador
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
            TrackPlayer();
        } else
        {
            targetPosition = GameObject.FindGameObjectWithTag("ActiveSewer").transform; // last pos before teleport
        }
    }

    /*private void LateUpdate()
    {
        //movemos la camara de un aposicio a otra de modo suavisado, sin saltos
        //cambiarle la posicion a la camara_ Lerp Linear interpolation, interpolacion lineal entre dos vectores
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * _camerSpeed);
        //                                      posicion actual, posicion a la que quieras ir, tiempo  que vas a utilizar   
    }*/

    private bool CheckXMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - targetPosition.position.x) >= xMargin;
    }


    private bool CheckYMargin()
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y - targetPosition.position.y) >= yMargin;
    }

    private void TrackPlayer()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        targetX = transform.position.x;
        targetY = transform.position.y;

        // If the player has moved beyond the x margin...
        if (CheckXMargin())
        {
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            //targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth * Time.deltaTime);
            targetX = targetPosition.position.x;
        }
        else
            targetX = transform.position.x;

        // If the player has moved beyond the y margin...
        if (CheckYMargin())
        {
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            //targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth * Time.deltaTime);
            targetY = targetPosition.position.y;
        }
        else
            targetY = transform.position.y;

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
