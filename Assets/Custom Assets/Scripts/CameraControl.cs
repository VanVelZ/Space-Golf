using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //-----Privates variables-----\\
    private Vector3 offset;

    //-----Publics variables-----\\
    [Header("Variables")]
    public Transform player;

    public Transform cam;

    [SerializeField]
    public Transform guide;


    [Space]
    [Range(0f, 10f)]
    public float turnSpeed;

    //-----Privates functions-----\\
    private void Start()
    {
        cam = GetComponent<Transform>();
        offset = new Vector3(player.position.x + cam.position.x, player.position.y + cam.position.y, player.position.z + cam.position.z);
        transform.rotation = cam.rotation;
        transform.LookAt(player.position);
    }


    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        }
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}
