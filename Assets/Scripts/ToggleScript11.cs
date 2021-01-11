using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Camera.main.GetComponent<AudioListener> ().enabled  =  true;
            Debug.Log("TURN ON AUDIO");
        }
        else
        {
            off.gameObject.SetActive(true);
            on.gameObject.SetActive(false);
            Camera.main.GetComponent<AudioListener> ().enabled  =  false;
        }
    }
    public void Turn()
    {
        if (on.gameObject.activeInHierarchy)
        {
            on.gameObject.SetActive(false);
            off.gameObject.SetActive(true);
            Camera.main.GetComponent<AudioListener> ().enabled  =  false;
            PlayerPrefs.SetInt("AudioOn",0);
        }
        else
        {
            off.gameObject.SetActive(false);
            on.gameObject.SetActive(true);
            Camera.main.GetComponent<AudioListener> ().enabled  =  true;
            PlayerPrefs.SetInt("AudioOn",1);
        }
    }

}
