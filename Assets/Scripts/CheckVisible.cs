using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVisible : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer m_Renderer;
    // Use this for initialization
    Coroutine coroutine;
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.WorldToScreenPoint(transform.position).x > Camera.main.pixelWidth)
        {
            this.gameObject.Despawn();
        }
        else if(Camera.main.WorldToScreenPoint(transform.position).x < 0)
        {
            this.gameObject.Despawn();
        }
        else if (Camera.main.WorldToScreenPoint(transform.position).x >= Camera.main.pixelHeight)
        {
            this.gameObject.Despawn();
        }
        else if (Camera.main.WorldToScreenPoint(transform.position).x <0)
        {
            this.gameObject.Despawn();
        }
    }

}
