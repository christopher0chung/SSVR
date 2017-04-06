using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadOut : MonoBehaviour {

    public float delayTime;
    public float fadeTime;

    public Color startColor;
    public Color finalColor;

    private Image myI;
    private float timer;
    private float fadeTimer;

    private bool done;

    // Use this for initialization
    void Start()
    {
        myI = GetComponent<Image>();
        myI.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
            return;

        timer += Time.deltaTime;

        if (timer >= delayTime)
        {
            fadeTimer += Time.deltaTime / fadeTime;
            myI.color = Color.Lerp(startColor, finalColor, fadeTimer);

            if (fadeTimer >= 1)
                done = true;
        }
    }
}
