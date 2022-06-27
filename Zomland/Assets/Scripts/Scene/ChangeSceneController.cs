using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ChangeSceneController
{
    public static void LoadScene(string sceneTo)
    {
        SceneManager.LoadScene(sceneTo);
    }
}
