using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadLevelSelectScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1Scene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2Scene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel3Scene()
    {
        SceneManager.LoadScene(3);
    }
}
