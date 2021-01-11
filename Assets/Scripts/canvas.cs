using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class canvas : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Canvas m_Canvas;
    public bool toch = true;
    public GameObject jontick;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        jontick.SetActive(false);
        if (transform.root.GetComponent<Canvas>() != null)
        {
            m_Canvas = transform.root.GetComponent<Canvas>();
        }
        else if (transform.root.GetComponentInChildren<Canvas>() != null)
        {
            m_Canvas = transform.root.GetComponentInChildren<Canvas>();
        }
        else
        {
            Debug.LogError("Required at lest one canvas for joystick work.!");
            this.enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseButton()
    {
        if (check==false)
            check=true;
        else check=false;
    }

    public void OnDrag(PointerEventData data)
    {
        if (check==true)
        {
            toch = false;

            jontick.GetComponent<bl_Joystick>().isFree = false;
            //Get Position of current touch
            Vector3 position = bl_JoystickUtils.TouchPosition(m_Canvas,0);
            //Rotate into the area circumferential of joystick
            if (Vector2.Distance(jontick.GetComponent<bl_Joystick>().DeathArea, position) < jontick.GetComponent<bl_Joystick>().radio)
            {
                jontick.GetComponent<bl_Joystick>().StickRect.position = position;
            }
            else
            {
                jontick.GetComponent<bl_Joystick>().StickRect.position = jontick.GetComponent<bl_Joystick>().DeathArea + (position - jontick.GetComponent<bl_Joystick>().DeathArea).normalized * jontick.GetComponent<bl_Joystick>().radio;
            }
        }
        
    }
    /// <summary>
    /// When click here event
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerDown(PointerEventData data)
    {
        if (check==true)
        {
        Vector3 position = bl_JoystickUtils.TouchPosition(m_Canvas, 0);
        jontick.transform.position = position;
        jontick.GetComponent<bl_Joystick>().StickRect.transform.position = jontick.GetComponent<bl_Joystick>().CenterReference.transform.position;
        jontick.SetActive(true);

            jontick.GetComponent<bl_Joystick>().lastId = data.pointerId;
            StopAllCoroutines();
            StartCoroutine(jontick.GetComponent<bl_Joystick>().ScaleJoysctick(true));
            if (jontick.GetComponent<bl_Joystick>().backImage != null)
            {
                jontick.GetComponent<bl_Joystick>().backImage.CrossFadeColor(jontick.GetComponent<bl_Joystick>().PressColor, jontick.GetComponent<bl_Joystick>().Duration, true, true);
                jontick.GetComponent<bl_Joystick>().stickImage.CrossFadeColor(jontick.GetComponent<bl_Joystick>().PressColor, jontick.GetComponent<bl_Joystick>().Duration, true, true);
            }
        }
       
    }

    public void OnPointerUp(PointerEventData data)
    {
        toch = true;
        jontick.GetComponent<bl_Joystick>().isFree = true;
        jontick.GetComponent<bl_Joystick>().to = false;
        jontick.SetActive(false);
        jontick.GetComponent<bl_Joystick>().currentVelocity = Vector3.zero;
        //leave the default id again
    
            //-2 due -1 is the first touch id
            jontick.GetComponent<bl_Joystick>().lastId = -2;
            StopAllCoroutines();
            StartCoroutine(jontick.GetComponent<bl_Joystick>().ScaleJoysctick(false));
            if (jontick.GetComponent<bl_Joystick>().backImage != null)
            {
                jontick.GetComponent<bl_Joystick>().backImage.CrossFadeColor(jontick.GetComponent<bl_Joystick>().NormalColor, jontick.GetComponent<bl_Joystick>().Duration, true, true);
                jontick.GetComponent<bl_Joystick>().stickImage.CrossFadeColor(jontick.GetComponent<bl_Joystick>().NormalColor, jontick.GetComponent<bl_Joystick>().Duration, true, true);
            }
        
    }
}
