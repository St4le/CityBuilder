using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void OnButtonQuit()
    {
        Application.Quit();
    }

    public string _sceneName = string.Empty;
    public void OnButtonPressed()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
