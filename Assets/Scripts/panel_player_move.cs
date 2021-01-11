using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class panel_player_move : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject player;
    Vector3 position;
    public GameObject point_y;
    private Canvas m_Canvas;
    private float khoang_cach_x=0;
    private float khoang_cach_y = 0;
    public float speed = 0.5f;
    private float temp = 0;
    private Animator animator;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    // Update is called once per frame
    public void OnDrag(PointerEventData eventData)
    {
        temp = speed;
        position = bl_JoystickUtils.TouchPosition(m_Canvas, 0);
        if (Camera.main.WorldToScreenPoint(new Vector3(position.x - khoang_cach_x, position.y - khoang_cach_y, 0)).x > Camera.main.pixelWidth)
            temp = 0;
        if (Camera.main.WorldToScreenPoint(new Vector3(position.x - khoang_cach_x, position.y - khoang_cach_y, 0)).x < 0)
            temp = 0;
        if (Camera.main.WorldToScreenPoint(new Vector3(position.x - khoang_cach_x, position.y - khoang_cach_y, 0)).y > Camera.main.WorldToScreenPoint(point_y.transform.position).y+10)
            temp = 0;
        if (Camera.main.WorldToScreenPoint(new Vector3(position.x - khoang_cach_x, position.y - khoang_cach_y, 0)).y < 0)
            temp = 0;
            if(temp !=0)
               {
                    animator.SetBool("isWalk",true);
               }

        player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(position.x - khoang_cach_x, position.y - khoang_cach_y, 0), temp );

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        position = bl_JoystickUtils.TouchPosition(m_Canvas, 0);
        khoang_cach_x = position.x - player.transform.position.x;
        khoang_cach_y = position.y - player.transform.position.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
         }

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
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
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
        {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        Debug.Log("Swipe UP");
    }

    void OnSwipeDown()
    {
        Debug.Log("Swipe Down");
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");
    }

    void OnSwipeRight()
    {
        Debug.Log("Swipe Right");
    }
}
