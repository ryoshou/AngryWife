using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    bool gameHasEnded = false;
    // public Text gameOverText;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // PlayerPrefs.SetInt("FIRSTTIMEOPENING", 1);
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            Debug.Log("First Time Opening");

            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
            SceneManager.LoadScene("Story");

        }
        else
        {
            Debug.Log("NOT First Time Opening");

        }
    }
    public static GameManager GetInstance()
    {
        return instance;
    }
    public void StartNewGame()
    {
        gameHasEnded = false;
        Debug.Log("NEW GAME !!");
        SceneManager.LoadScene("MainScene");
        // transform.GetComponent<MapGenerator>().GenerateMap();
    }
}
