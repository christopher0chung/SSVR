using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluctuatingDimmer : MonoBehaviour {

    public bool startOn;
    private float timer;
    private Light myLight;

    public MeshRenderer myMR;
    private Material myMat;

    private float eMult;

    public float switchTime;

	// Use this for initialization
	void Start () {
        myLight = GetComponent<Light>();
        myMat = myMR.material;
        eMult = 1.25f;	
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer >= switchTime)
        {
            timer -= switchTime;
            startOn = !startOn;
        }

        if (startOn)
        {
            myLight.range = Mathf.Lerp(myLight.range, 5, .08f);
            eMult = Mathf.Lerp(eMult, .75f, .08f);
        }

        else
        {
            myLight.range = Mathf.Lerp(myLight.range, 15, .08f);
            eMult = Mathf.Lerp(eMult, 2, .08f);
        }
        myMat.SetFloat("_EmissionMultiplier", eMult);

    }
}
