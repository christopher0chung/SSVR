using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _Time;
    public  float Time
    {
        get
        {
            return _Time;
        }
        set
        {
            if (value != _Time)
            {
                _Time = value;
                myA.speed = _Time;
            }
        }
    }

    public Animator myA;

    void Start()
    {
        Time = 1;
    }

	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            Time *= 1.1f;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            Time *= (1 / 1.1f);
    }
}
