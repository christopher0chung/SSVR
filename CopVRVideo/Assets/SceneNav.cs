using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNav : MonoBehaviour {
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene(3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SceneManager.LoadScene(4);
    }
}
