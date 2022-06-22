using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public float followSpeed = 100f;

    public GameObject player;

    private void Update()
    {
        Vector3 camera_pos = player.transform.position + offset;
        Vector3 lerp_pos = Vector3.Lerp(transform.position, camera_pos, followSpeed*Time.deltaTime);
        transform.position = lerp_pos;
        transform.LookAt(player.transform);
    }
}
