using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed;
    private float X;
    private float Y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(cameraSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-cameraSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -cameraSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, cameraSpeed * Time.deltaTime));
        }

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * cameraSpeed/2, Input.GetAxis("Mouse X") * cameraSpeed/2, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(new Vector3(0, -cameraSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(0, cameraSpeed * Time.deltaTime, 0));
        }
    }
}

