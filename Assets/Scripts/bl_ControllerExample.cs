using UnityEngine;

public class bl_ControllerExample : MonoBehaviour {

    /// <summary>
    /// Step #1
    /// We need a simple reference of joystick in the script
    /// that we need add it.
    /// </summary>
	[SerializeField]private bl_Joystick Joystick;//Joystick reference for assign in inspector
    Rigidbody2D m_Rigidbody;
    public float h, v;
    public float temp = 0;
    public GameObject panel;
    [SerializeField]public float Speed = 3;
    public Animator animator;
    [SerializeField] GameObject raochan;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

         v = Joystick.Vertical; //get the vertical value of joystick
         h = Joystick.Horizontal;//get the horizontal value of joystick
        
        /** Time.deltaTime) * Speed;*/
        //transform.Translate(translate);

         temp = 0;
        if (Joystick.isFree == true)
        {
            h=0;
            v=0;
        }
        if((h!=0 || v !=0) && Joystick.isFree == false)
        {
            float yraochan = raochan.transform.position.y;
            temp = Speed;
            if (Camera.main.WorldToScreenPoint(transform.position).x >= Camera.main.pixelWidth-3 && h > 0)
                temp = 0;
            if (Camera.main.WorldToScreenPoint(transform.position).x <= 3 && h < 0)
                temp = 0;
            if (Camera.main.WorldToScreenPoint(transform.position).y >= Camera.main.WorldToScreenPoint(raochan.transform.position).y && v > 0)
                temp = 0;
            if (Camera.main.WorldToScreenPoint(transform.position).y <= 3 && v < 0)
                temp = 0;
        //    transform.up = translate;
        Vector3 sca = transform.localScale;
            if (h<0)
            {
                sca.x = -1;
                transform.localScale = sca;
            }
            if(h>0)
            {
                sca.x = 1;
                transform.localScale = sca;
            }
        }
        
         //m_Rigidbody.velocity = transform.do * temp;
        Vector3 translate = (new Vector3(h, v, 0) * Time.deltaTime) * temp;
        transform.Translate(translate);
        //Set animator
        if (h>0.1 || h<-0.1 || v>0.1 || v<-0.1)
        {
            animator.SetBool("isWalk",true);
        }
        else
        {
            animator.SetBool("isWalk",false);
        }
    }
}