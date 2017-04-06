using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoPilot : MonoBehaviour {

    public AnimationCurve myAC;

    public Vector3[] wayPoints;
    public Vector3[] lookPoints;
    public float[] approachStartTime;
    public float[] transitTime;

    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        //int theIndex = GetIndex();
        //Debug.Log(theIndex);
        if (GetIndex() >= 1 && GetIndex() <= approachStartTime.Length)
        {
            transform.position = Vector3.Lerp(
                wayPoints[GetIndex() - 1], 
                wayPoints[GetIndex()], 
                myAC.Evaluate((timer - approachStartTime[GetIndex()]) / transitTime[GetIndex()]));
            transform.rotation = Quaternion.Slerp(
                Quaternion.LookRotation(lookPoints[GetIndex() - 1] - transform.position), 
                Quaternion.LookRotation(lookPoints[GetIndex()] - transform.position),
                myAC.Evaluate((timer - approachStartTime[GetIndex()]) / transitTime[GetIndex()]));
        }

        if (timer >= 23)
        {
            GetComponent<CamController>().autoPilotOff = true;
            Destroy(this);
        }

	}

    int GetIndex()
    {
        Debug.Log("GetIndex called");

        for (int j = approachStartTime.Length - 1; j >= 0; j--)
        {
            if (timer >= approachStartTime[j])
            {
                return j;
            }
        }
        return 0;
    }
}
