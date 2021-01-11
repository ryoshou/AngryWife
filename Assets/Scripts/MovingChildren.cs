using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChildren : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float currentTime = 0f;
    private float waitingTime = 0f;
    [SerializeField] GameObject children;

    [SerializeField]
    private float timeChildappear = 3f;
    //
    private Rigidbody2D rb2D;
    private GameObject gbSpawn = null;
    private float speed = 2.2f;
    private float speedtmp = 2.2f;
    void Awake()
    {
      
    }
    void Start()
    {
       // rb2D = children.GetComponent<Rigidbody2D>();   
    }


    private Vector3 move;
    void Update()
    {
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
        if (currentTime >= timeChildappear)
        {
            timeChildappear += 20f;
            gbSpawn = Instantiate(children, transform.position, Quaternion.identity);
            gbSpawn.SetActive(true);
            move = RandomDirection();
            StartCoroutine(Go(gbSpawn));
        }
        if (gbSpawn != null)
        {
            rb2D = gbSpawn.GetComponent<Rigidbody2D>();
            rb2D.velocity = move * speedtmp;
        }
    }
    private IEnumerator Go(GameObject g)
    {
        
        yield return new WaitForSeconds(Random.Range(1f,2f));
        speedtmp = 0f;
        StartCoroutine(DestroyChild(g));
    }
    private IEnumerator DestroyChild(GameObject gb)
    {

        yield return new WaitForSeconds(2f);
        Destroy(gb);
        gbSpawn = null;
        speedtmp = speed;
    }
    private Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(children.transform.position.x - 0.5f, children.transform.position.x + 0.5f), -1, 0);
    }
}
