using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text timerText;
    //private float startTime;
    float timePassed;
    float levelTargetTime;
    public GameObject levelPassedUI;
    public GameObject levelFailedUI;

    void Start()
    {
        //startTime = Time.time;

        //Set level clear time target
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level1Scene") { levelTargetTime = 1f; }
        if (currentScene.name == "Level2Scene") { levelTargetTime = 15f; }
        if (currentScene.name == "Level3Scene") { levelTargetTime = 20f; }
    }

    void Update()
    {
        if ((GameObject.FindGameObjectsWithTag("Human").Length > 0) && (GameObject.FindGameObjectsWithTag("Zombie").Length > 0))
        {
            //Timer
            //float t = Time.time - startTime;

            //string minutes = ((int)t / 60).ToString();
            //string seconds = (t % 60).ToString("f2");

            //timerText.text = minutes + ":" + seconds;

            //Timer
            timePassed += Time.deltaTime;

            if (timePassed >= 60f)
            {
                float seconds = timePassed % 60;
                int minutes = (int)timePassed / 60;
                timerText.text = minutes.ToString() + ":" + seconds.ToString("f2");
            }
            else
            {
                float seconds = timePassed;
                int minutes = 0;
                timerText.text = minutes.ToString() + ":" + seconds.ToString("f2");
            }
        }

        if (GameObject.FindGameObjectsWithTag("Human").Length <= 0)
        {
            if (timePassed <= levelTargetTime)
            {
                //Win
                if (levelPassedUI.activeSelf == false) { levelPassedUI.SetActive(true); }
                Debug.Log("Level Beat");
            }
            else
            {
                //Lose
                if (levelFailedUI.activeSelf == false) { levelFailedUI.SetActive(true); }
                Debug.Log("Level Not Beat, Target Time: 00:" + levelTargetTime.ToString());
            }
        }
    }
}
