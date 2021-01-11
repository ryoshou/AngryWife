using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet" ){
            GameObject obj = GameObject.FindGameObjectWithTag("canvas");
            obj.GetComponent<Game_Controller_UI>().GameOver();
        }
        if(collision.gameObject.tag == "player" ){
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player" ){
            gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "bullet" ){
            
            GameObject obj = GameObject.FindGameObjectWithTag("canvas");
            obj.GetComponent<Game_Controller_UI>().GameOver();
        }
    }

}
