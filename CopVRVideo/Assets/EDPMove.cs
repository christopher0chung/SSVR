using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDPMove : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * 10);
        }

    }
}
