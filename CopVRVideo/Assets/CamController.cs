using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    private Vector3 moveInput;
    private Vector3 moveDir;

    private Vector3 camInput;
    private Vector3 camDir;
    private Vector3 camRot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        Camera.main.transform.rotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);

        //Look();
        Move();
    }

    void Look ()
    {
        camInput = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            camInput -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            camInput += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            camInput -= Vector3.up;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camInput += Vector3.up;
        }

        camDir = Vector3.Lerp(camDir, camInput, Time.deltaTime);
        camRot += camDir;

        Camera.main.transform.rotation = Quaternion.Euler(camRot);
    }

    void Move ()
    {
        moveInput = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveInput += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveInput -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveInput += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveInput -= transform.right;
        }
        if (Input.GetKey(KeyCode.E))
        {
            moveInput += transform.up;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            moveInput -= transform.up;
        }

        moveInput = Vector3.Normalize(moveInput);
        moveDir = Vector3.Lerp(moveDir, moveInput, Time.deltaTime);

        transform.position += moveDir * Time.deltaTime;
    }
}
