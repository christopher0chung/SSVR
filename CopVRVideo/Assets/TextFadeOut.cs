using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFadeOut : MonoBehaviour {

    public float delayTime;
    public float fadeTime;

    public Color startColor;
    public Color finalColor;

    private TextMesh myTM;
    private float timer;
    private float fadeTimer;

    private bool done;

	// Use this for initialization
	void Start () {
        myTM = GetComponent<TextMesh>();
        myTM.color = startColor;
	}
	
	// Update is called once per frame
	void Update () {
        if (done)
            return;

        timer += Time.deltaTime;

        if (timer >= delayTime)
        {
            fadeTimer += Time.deltaTime / fadeTime;
            myTM.color = Color.Lerp(startColor, finalColor, fadeTimer);

            if (fadeTimer >= 1)
                done = true;
        }
	}
}
