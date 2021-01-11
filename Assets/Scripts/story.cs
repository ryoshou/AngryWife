using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class story : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] mang = new string[20];
    private string[] people = new string[20];
    public Text peo, sto;
    private AudioSource au;
    public GameObject man,human;
    public Animator animator,animator_man;
    private int i;
    bool okay = false;
    bool checkkk= false;
    void Start()
    {
        au = human.GetComponent<AudioSource>();
        animator = human.GetComponent<Animator>();
        animator_man = man.GetComponent<Animator>();
        i = -1;
        mang[0] = "Where did you go???";
        mang[1] = "I hang out with my friends.";
        mang[2] = "Don't you know how dangerous COVID-19 is?";
        mang[3] = "Don't worry, just trust me, I'm OK!";
        mang[5] = "I don't want to see your face!You piss me off. grr grr";
        mang[4] = "All the stuffs and animals are mine, the rest is yours.";
        mang[6] = "Get out of my face.";

        people[0] = "wife:";
        people[1] = "husband:";
        people[2] = "wife:";
        people[3] = "husband:";
        people[4] = "wife:";
        people[5] = "wife:";
        people[6] = "wife:";
        next();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (i >= 6 && checkkk==false)
        {
            checkkk=true;
            peo.text = people[6];
            sto.text = mang[6];
                StartCoroutine(set_slow(0.7f));
        }
    }
    public void ClickNext()
    {
        if(i<6)
            next(); 
    }
    public void next()
    {
        i++;
        peo.text = people[i];
        sto.text = mang[i]; 
    }    
    public void over()
    {
        i = 6;
    }
    private IEnumerator lose(float second)
    {
        yield return new WaitForSeconds(second);
        Time.timeScale = 0;
        StartCoroutine(set_slow(2.0f));
    }
    private IEnumerator set_slow( float second)
    {
        Time.timeScale=1;
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene("MainScene");
    }
}
