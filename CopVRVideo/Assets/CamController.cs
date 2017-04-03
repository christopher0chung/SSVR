using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    private Vector3 moveInput;
    private Vector3 moveDir;

    private Vector3 camInput;
    private Vector3 camDir;
    private Vector3 camRot;

    private Vector3 startPos;
    private Vector3 startRot;
    private bool resetPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        startRot = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

        ToggleReset();

        //Look();
        if (resetPos)
            ResetPos();
        else 
            Move();

        if (Vector3.Distance(transform.position, startPos) <= .01f && resetPos)
            resetPos = false;

    }

    //void Look ()
    //{
    //    camInput = Vector3.zero;

    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        camInput -= Vector3.right;
    //    }
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        camInput += Vector3.right;
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        camInput -= Vector3.up;
    //    }
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        camInput += Vector3.up;
    //    }

    //    camDir = Vector3.Lerp(camDir, camInput, Time.deltaTime);
    //    camRot += camDir;

    //    Camera.main.transform.rotation = Quaternion.Euler(camRot);
    //}

    void Move ()
    {
        Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        Camera.main.transform.rotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);

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

    private void ToggleReset()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moveDir = Vector3.zero;
            moveInput = Vector3.zero;
            resetPos = !resetPos;
        }
    }

    private void ResetPos()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(startRot), Time.deltaTime);
    }
}
