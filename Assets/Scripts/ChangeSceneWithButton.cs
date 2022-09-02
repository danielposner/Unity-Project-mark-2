using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=9lPCv9kkbSI&ab_channel=JimmyVegas
//https://www.youtube.com/watch?v=05OfmBIf5os&ab_channel=GameDevTraum

public class ChangeSceneWithButton : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
