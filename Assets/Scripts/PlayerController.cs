using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject item,move;
    [SerializeField]
    public GameObject khieng;
    //[SerializeField]
    //public GameObject dau;
    bool on_khieng = false;
    [SerializeField]
    public float Time_khieng=3;
    public float Time_slow = 3;
    public float Time_sca = 3;
    public float speed_slow = 0.3f;
    public float speed = 0.6f;
    public GameObject canvas,viengach,vo,pool,efect,playerdie;
    Vector3 sca,position_viengach;
    public bool quang = false;

    void Start()
    {
        speed = move.GetComponent<bl_ControllerExample>().Speed;
        speed_slow = speed / 2;
        viengach.SetActive(false);
        position_viengach = viengach.transform.position;
        sca = transform.localScale;
        khieng.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(quang == true)
        {
            viengach.transform.position = Vector3.Lerp(viengach.transform.position, vo.transform.position, 3 * Time.deltaTime);
        }  
        else
        {
            viengach.transform.position = transform.position;
        }
        if(Vector3.Distance(viengach.transform.position,vo.transform.position)<=0.5)
        {
            pool.GetComponent<fire1>().waitingTime += 3;
            quang = false;
            viengach.SetActive(false);
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag.Equals("bullet"))
        {
            this.gameObject.SetActive(false);
            canvas.GetComponent<Game_Controller_UI>().GameOver();
            GameObject smp = Instantiate(playerdie, transform.position, Quaternion.identity);
           
            GameObject sm = Instantiate(efect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(sm, 0.4f);
        }
        if (collision.gameObject.tag.Equals("animal"))
        {
            this.gameObject.SetActive(false);
           canvas.GetComponent<Game_Controller_UI>().GameOver();
            GameObject smp = Instantiate(playerdie, transform.position, Quaternion.identity);
            GameObject sm = Instantiate(efect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(sm, 0.4f);
        }
        if (collision.gameObject.CompareTag("item"))
        {
            //random an item after every 2s 
            // 
            // 2 slow- 5s ,
            // 3 die - 2s(appear after 10s), 
            //4 buff 10s, 
            //5 coin 2s
            // wall - 2s
            //
           
            Debug.Log("trigger item");
            /*GameObject _item = Instantiate(item, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z), collision.gameObject.transform.rotation);
            _item.GetComponent<BoxCollider2D>().isTrigger = false;
            
            StartCoroutine(DisplayItem(_item, 10.0f));
*/
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            this.gameObject.SetActive(false);
            canvas.GetComponent<Game_Controller_UI>().GameOver();
            GameObject smp = Instantiate(playerdie, transform.position, Quaternion.identity);
           
            GameObject sm = Instantiate(efect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(sm, 0.4f);
        }
        if (collision.gameObject.tag.Equals("animal"))
        {
            this.gameObject.SetActive(false);
            canvas.GetComponent<Game_Controller_UI>().GameOver();
            GameObject smp = Instantiate(playerdie, transform.position, Quaternion.identity);
            GameObject sm = Instantiate(efect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(sm, 0.4f);
        }
        // khieng
        if (collision.gameObject.tag.Equals("itemkhieng"))
        {
            khieng.SetActive(true);
            StartCoroutine(set_khieng(khieng, Time_khieng));
            collision.gameObject.SetActive(false);
        }
        // slow
        if (collision.gameObject.tag.Equals("itemslow"))
        {
            move.GetComponent<bl_ControllerExample>().Speed = speed_slow;
            StartCoroutine(set_slow(Time_slow));
            collision.gameObject.SetActive(false);
        }
        // sca Small
        if (collision.gameObject.tag.Equals("itemScaSmall"))
        {
            Vector3 small = new Vector3(0.6f,0.6f,1);
            transform.localScale = small;
            collision.gameObject.SetActive(false);
            StartCoroutine(set_sca(Time_sca));
        }
        if (collision.gameObject.tag.Equals("itemnem"))
        {
            quang = true;
            viengach.SetActive(true);
            collision.gameObject.SetActive(false);
            StartCoroutine(set_viengach(2.5f));
        }
    }
    private IEnumerator DisplayItem(GameObject item, float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(item);
    }
    private IEnumerator set_khieng(GameObject item, float second)
    {
        yield return new WaitForSeconds(second);
        khieng.SetActive(false);
    }
    private IEnumerator set_slow( float second)
    {
        yield return new WaitForSeconds(second);
        move.GetComponent<bl_ControllerExample>().Speed = speed;
    }
    private IEnumerator set_sca(float second)
    {
        yield return new WaitForSeconds(second);
        transform.localScale = sca;
    }
    private IEnumerator set_viengach(float second)
    {
       
        yield return new WaitForSeconds(second);
        
    }
}
