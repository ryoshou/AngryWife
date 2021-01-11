using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khieng : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject efect;
    public GameObject explosePoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        collision.gameObject.SetActive(false);
        Instantiate(efect,collision.gameObject.transform.position,Quaternion.identity);
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        collision.gameObject.SetActive(false);
        GameObject sm =  Instantiate(efect, explosePoint.transform.position, Quaternion.identity);
        Destroy(sm, 0.4f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
