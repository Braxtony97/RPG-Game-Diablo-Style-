using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player;
    public Vector3 camOffset;
    void Start()
    {
        camOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.TransformPoint(camOffset);
        //transform.LookAt(player);
        transform.position = camOffset + player.position;
    }
}
