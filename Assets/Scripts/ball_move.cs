using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_move : MonoBehaviour
{
    public float timer = 0;
    public float huong = 1;
    public float angle;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if (timer < Time.time)
             timer = Time.time + 2;
         Vector3 trs = new Vector3();
         transform.Translate(trs, Space.World);*/
        timer += Time.deltaTime;
        angle = timer;
        this.transform.position = new Vector3((player.transform.position.x - Mathf.Sin(angle)*huong * 1.5f), ((player.transform.position.y - Mathf.Cos(angle)*huong * 1.5f)), 0);
    }



}
