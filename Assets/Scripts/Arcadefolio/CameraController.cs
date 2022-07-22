using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 defaultPositionOffset = new Vector3(0,10,-10);
    private Quaternion defaultXRotation = Quaternion.Euler(45, 0, 0);
    public bool attachedToPlayer = true;
    public float cameraSpeed = 10;
    private Transform cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (attachedToPlayer)
        {
            transform.position = player.transform.position + defaultPositionOffset;
            transform.rotation = defaultXRotation;
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraPos.position, cameraSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, cameraPos.rotation, cameraSpeed * Time.deltaTime * 3);
        }
    }

    public void ChangeCameraPos(Transform newPos)
    {
        attachedToPlayer = false;
        cameraPos = newPos;
    }

    public void AttachToPlayer()
    {
        attachedToPlayer = true;
    }

}
