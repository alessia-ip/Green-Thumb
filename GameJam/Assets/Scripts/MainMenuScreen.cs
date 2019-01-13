using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public string sceneNameObj;

    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected");
            SceneManager.LoadScene(sceneName: sceneNameObj);

        }
    }
}