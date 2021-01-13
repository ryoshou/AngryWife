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
    public GameObject caydu,player;
    void Awake()
    {
      
    }
    void Start()
    {
        currentTime = 0;
        waitingTime =0;
        player = GameObject.FindGameObjectWithTag("player");
       // rb2D = children.GetComponent<Rigidbody2D>();   

    }


    private Vector3 move;
    // bool checkSpawn = false;
    void Update()
    {
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
        if (currentTime >= timeChildappear)
        {
            GameManager gameManager = GameManager.GetInstance();
                // Debug.Log("Spawn child after 1.5s");
                gameManager.isSpawnChild = true;
                StartCoroutine(SpawnChild(1.0f));
                // checkSpawn=true;
                timeChildappear =currentTime+ 20f;
                // gameManager.isShooting=false;
            // gbSpawn = Instantiate(children, transform.position, Quaternion.identity);
            // gbSpawn.SetActive(true);
            // move = RandomDirection();
            // StartCoroutine(Go(gbSpawn));
            // Zone();
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
    private IEnumerator SpawnChild(float s){
        yield return new WaitForSeconds(s);
        Zone();
        gbSpawn = Instantiate(children, transform.position, Quaternion.identity);
        gbSpawn.SetActive(true);
        move = RandomDirection();
        StartCoroutine(Go(gbSpawn));
        yield return new WaitForSeconds(s);
        GameManager gameManager = GameManager.GetInstance();
        gameManager.isSpawnChild = false;    
        // checkSpawn=false;
      }
    
    private void Zone()
    {
        //random position
        float _x = Random.Range(player.transform.position.x-1f,player.transform.position.x+1f);
        float _y = Random.Range(player.transform.position.y-1f,player.transform.position.y+1f);
        GameObject item = Instantiate(caydu, new Vector3(_x, _y, player.transform.position.z), player.transform.rotation);
        item.SetActive(true);
        StartCoroutine(DisplayItem(item, 3f));
    }

    // display item 
    private IEnumerator DisplayItem(GameObject item, float second)
    {
        yield return new WaitForSeconds(second);
        item.SetActive(false);
    }
}
