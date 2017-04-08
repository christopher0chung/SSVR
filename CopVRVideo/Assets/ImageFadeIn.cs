using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeIn : MonoBehaviour
{
    private delegate void fadeIn();
    private fadeIn fadeInFunc;

    public float delayTime;
    public float fadeTime;

    public Color startColor;
    public Color finalColor;

    private Image myI;
    private float fadeTimer;

    // Use this for initialization
    void Start()
    {
        myI = GetComponent<Image>();
        myI.color = startColor;
        fadeTimer -= delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInFunc != null)
            fadeInFunc();

        if (Input.GetMouseButtonDown(0))
            fadeInFunc = DoFadeIn;
    }

    void DoFadeIn()
    {
        fadeTimer += Time.deltaTime / fadeTime;
        myI.color = Color.Lerp(startColor, finalColor, fadeTimer);       
    }
}
