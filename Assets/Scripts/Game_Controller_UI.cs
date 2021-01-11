using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playgame,conti,setting,PanelSetting,audio_off,audio_on,MenuPanel,highScoreObj,joystickPanel;
    public Text point,GameOverText,highScore,currentScore;
    float time = 0;
    bool opensetting = false;
    bool startgame = false;
    void Start()
    {
        Time.timeScale = 0;
        point.text = "0";
        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        PanelSetting.SetActive(false);
        joystickPanel.SetActive(false);
//        audio_on.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > time+1 && startgame == true)
        {
            int diem = Int32.Parse(point.text);
            diem++;
            point.text = diem.ToString();
            time = Time.time;
        //    Debug.LogError("asd");
        }    
    }
    public void play()
    {
        point.text = "0";
        startgame = true;
        MenuPanel.SetActive(false);
        playgame.SetActive(false);
        highScoreObj.SetActive(false);
        Time.timeScale = 1;
        joystickPanel.SetActive(true);
       
    }
    public void continiu()
    {
        if (startgame==true)
        {
            Time.timeScale = 1;
            MenuPanel.SetActive(false);
        }
        opensetting = false;
        PanelSetting.SetActive(false);
    }
    public void seting()
    {
        if (opensetting == false)
        {
            Time.timeScale = 0;
            // MenuPanel.SetActive(true);
            PanelSetting.SetActive(true);
            opensetting = true;
        }
        else
        {
            if (startgame == true)
                {
                    Time.timeScale = 1;
                    MenuPanel.SetActive(false);
                }
            PanelSetting.SetActive(false);
            opensetting = false;
        }    
    }
    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        // currentScore.text = point.text;
        Invoke("RestartGame",2f);
    }
    public void RestartGame()
    {
        GameOverText.gameObject.SetActive(false);
        highScoreObj.SetActive(true);
        if (Int32.Parse(point.text) > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",Int32.Parse(point.text));
            highScore.text = Int32.Parse(point.text).ToString();
        }
        GameManager gm = GameManager.GetInstance();
        gm.StartNewGame();
    }
    public void onaudio()
    {
        audio_on.SetActive(true);
        audio_off.SetActive(false);
    }
    public void offaudio()
    {
        audio_on.SetActive(false);
        audio_off.SetActive(true);
    }
}
