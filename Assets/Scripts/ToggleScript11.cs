using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript11 : MonoBehaviour
{
    [SerializeField]
    public GameObject on;
    [SerializeField]
    public GameObject off;
    void Start()
    {
        if (PlayerPrefs.GetInt("AudioOn",1)==1)
        {
            on.gameObject.SetActive(true);
            off.gameObject.SetActive(false);
            AudioListener.volume = 1.0f;
            Debug.Log("TURN ON AUDIO");
        }
        else
        {
            off.gameObject.SetActive(true);
            on.gameObject.SetActive(false);
            AudioListener.volume = 0f;
        }
    }
    public void Turn()
    {
        if (on.gameObject.activeInHierarchy)
        {
            on.gameObject.SetActive(false);
            off.gameObject.SetActive(true);
            AudioListener.volume = 0f;
            PlayerPrefs.SetInt("AudioOn",0);
        }
        else
        {
            off.gameObject.SetActive(false);
            on.gameObject.SetActive(true);
            AudioListener.volume = 1.0f;
            PlayerPrefs.SetInt("AudioOn",1);
        }
    }

}
