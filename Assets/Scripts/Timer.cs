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
    [SerializeField] Text highScoreText;

    void Start()
    {
        //startTime = Time.time;
        UpdateHighScoreText();
        //Set level clear time target
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
            HighScore();
                //Win
                if (levelPassedUI.activeSelf == false) { levelPassedUI.SetActive(true); }
                //Debug.Log("Level Beat");
        }
    }
    void HighScore()
    {
        Debug.Log(PlayerPrefs.GetFloat("HighScore"));
        timePassed = Mathf.Round(timePassed * 100f) / 100f;
        Debug.Log(timePassed);
        if (timePassed < PlayerPrefs.GetFloat("HighScore", 100))
        {
            PlayerPrefs.SetFloat("HighScore", timePassed);
            PlayerPrefs.GetFloat("HighScore");
            UpdateHighScoreText();

            Debug.Log(timePassed);
            Debug.Log(PlayerPrefs.GetFloat("HighScore"));
        }
   
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetFloat("HighScore", 0)}";
    }

}
