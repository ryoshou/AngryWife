using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtorial : MonoBehaviour
{
    public GameObject a, b, c;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        b.SetActive(false);
        c.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(i==0)
        {
            a.SetActive(true);
            b.SetActive(false);
            c.SetActive(false);
        }    
        if(i==1)
        {
            b.SetActive(true);
            a.SetActive(false);
        }    
        if(i==2)
        {
            b.SetActive(false);
            c.SetActive(true);
        }   
        if(i==3)
        {
            c.SetActive(false);
            gameObject.SetActive(false);
            i = 0;
        }    
    }
    public void next()
    {
        if (i <=2)
            i++;
    }    
}
