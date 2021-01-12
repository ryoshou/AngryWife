using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject[] bullets = new GameObject[6];
    private GameObject _bullet1, _bullet2, _bullet3;
    [SerializeField]
    public float currentForce = 2.4f;
    [SerializeField]
    public float endForce = 5f;
    [SerializeField]
    public float addForce = 0.2f;

    [SerializeField]
    private float timeSecondAttack = 15f;
    [SerializeField]
    private float timAddToFindNextAttack = 12f;

    [SerializeField]
    private float timCatDogRandom= 30f;
    [SerializeField]
    private float timeRandomNext = 15f;

    /*[SerializeField]
    private GameObject[] pointersRandomItem = new GameObject[4]; // trên trái, phải,dưới phải trái
    */
    [SerializeField]
    private GameObject []_items = new GameObject[4];

    [SerializeField]
    private GameObject player;

    private float randomvalue;
    private int typeOfBullet;

    public float waitingTime = 1.0f;
    private int lanBan = 0;
    private float currentTime;

    private float timetonextrandomattack;
    public Animator animator;
    public float gravity_bullet_start=0.2f;
    private float gravityScaleTime = 0f;


    [SerializeField]
    private GameObject bigbullet;
    private void Awake()
    {
        typeOfBullet = randomBullet();
        waitingTime = 1.0f;
    }
    void Start()
    {
        currentTime = 0;
        waitingTime = 1.0f;
        InvokeRepeating("Zone", 0.3f,Random.Range(3.0f,4.0f));
        timetonextrandomattack = timeSecondAttack;
        for(int i=0 ;i<bullets.Length;i++)
        {
            bullets[i].GetComponent<Rigidbody2D>().gravityScale=gravity_bullet_start;
        }
    }
    int checktoaddforce = 0;
    int randomBullet()
    {
        return Random.Range(0, 6);
    }
    // Update is called once per frame
    void Update()
    {
        //ShootPlayer();
        //Debug.Log(Time.time);
        GameManager gameManager = GameManager.GetInstance();
        Debug.Log("currentForce: "+currentForce);
        Debug.Log("time find next attack: " +timetonextrandomattack);
        currentTime += Time.deltaTime;
        animator.SetBool("isAttack",false);
        if (currentTime >= waitingTime && gameManager.isSpawnChild==false)
        {
            // gameManager.isShooting=true;
            // Debug.Log("is Shooting");
            animator.SetBool("isAttack",true);
            // 15s add force 0.2
            if (currentTime / 15 > checktoaddforce)
            {
                // Debug.Log("add force--------------------");
                checktoaddforce++;
                currentForce = Mathf.Min(5.0f, currentForce + 0.2f);
            }
            // Debug.Log(currentTime);
            
            if(currentTime >= timetonextrandomattack)
            {
                timetonextrandomattack += Mathf.Max(timAddToFindNextAttack - 0.5f, 9.0f);
                //random attack 
                if (Random.Range(1, 3) > 1.5f)
                {
                    if (Random.Range(1, 3) > 1.5f)
                    {
                        BigBullet();
                    }
                    else
                    {
                        ShootPlayer(2);
                    }
                }
                else
                {
                    if (Random.Range(1, 3) > 1.5f)
                    {
                        ShootPlayer(3);
                    }
                    else
                    {
                        BigBullet();
                    }
                }
            }else
            // ShootPlayer(2);
                Shoot();

            waitingTime+=Random.Range(1.3f,1.6f);
            //gameManager.isShooting=false;
        }
        if (currentTime >= gravityScaleTime)
        {
            gravityScaleTime+=10f;
            for (int i=0;i<bullets.Length;i++)
            {
                bullets[i].GetComponent<Rigidbody2D>().gravityScale+=0.1f;
            }
        }
    }
    private void FixedUpdate()
    {
        //Debug.Log(_bullet1);
        //Shoot();
        
    }
    // 1 bullet
    public void Shoot()
    {
        Vector3 director = (player.transform.position - this.transform.position).normalized;
        //GameObject bullet = bullets[typeOfBullet].Spawn(this.transform.position); //Instantiate(bullets[typeOfBullet], this.transform.position, this.transform.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        GameObject gb = bullets[Random.Range(0, bullets.Length)].Spawn(this.transform.position); ;
        Rigidbody2D rb = gb.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(director.x-Random.Range(-0.6f,0.6f), director.y, director.z) * currentForce, ForceMode2D.Impulse);
    }
    // 3 or 5 bullet
    private void ShootPlayer(int sl)
    {
        // Debug.Log("attack");
        Vector3 director = (player.transform.position- this.transform.position).normalized;
        //GameObject bullet = bullets[typeOfBullet].Spawn(this.transform.position); //Instantiate(bullets[typeOfBullet], this.transform.position, this.transform.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        GameObject[] gb = new GameObject[5];
        for(int i = 0; i < sl; i++)
        {
            gb[i]= bullets[Random.Range(0, bullets.Length)].Spawn(this.transform.position);
            if (gb[i].GetComponent<BoxCollider2D>() != null)
            {
                gb[i].GetComponent<BoxCollider2D>().isTrigger = true;
            }
            if (gb[i].GetComponent<Collider2D>() != null)
            {
                gb[i].GetComponent<Collider2D>().isTrigger = true;
            }
        }
        int _lech = 0;
        if(sl ==3)
        {
            _lech = -1;
        }else if (sl == 2)
        {
            _lech = (int)-0.5f;
        }
        for (int i = 0; i < sl; i++)
        {
            Rigidbody2D rb = gb[0].GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(director.x + _lech, director.y) * currentForce, ForceMode2D.Impulse);
            if (gb[i].GetComponent<BoxCollider2D>() != null)
            {
                gb[i].GetComponent<BoxCollider2D>().isTrigger = false;
            }
            if (gb[i].GetComponent<Collider2D>() != null)
            {
                gb[i].GetComponent<Collider2D>().isTrigger = false;
            }
            _lech++;
        }

        randomvalue = Random.Range(-2.0f, 3.0f);
        
    }
    private void BigBullet()
    {
        Vector3 director = (player.transform.position - this.transform.position).normalized;
        //GameObject bullet = bullets[typeOfBullet].Spawn(this.transform.position); //Instantiate(bullets[typeOfBullet], this.transform.position, this.transform.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        GameObject gb = bigbullet.Spawn(this.transform.position); ;
        Rigidbody2D rb = gb.GetComponent<Rigidbody2D>();
        //new Vector3(director.x - Random.Range(-0.6f, 0.6f), director.y, director.z)
        rb.AddForce(director * currentForce, ForceMode2D.Impulse);
    }
    // red zone 
    private void Zone()
    {
        //random an item after every 2s 
        // 1 heal - 10s
        // 2 slow- 5s ,
        // 3 die - 2s(appear after 10s), 
        //4 buff 10s, 
        //5 coin 2s
        // wall - 2s

        //random position
        float _x = Random.Range(-2f, 2f);
        float _y = Random.Range(-5f, 1f);
        GameObject item = Instantiate(_items[Random.Range(0,_items.Length)], new Vector3(_x, _y, this.transform.position.z), this.transform.rotation);
        StartCoroutine(DisplayItem(item, 3f));
    }

    // display item 
    private IEnumerator DisplayItem(GameObject item, float second)
    {
        yield return new WaitForSeconds(second);
        item.SetActive(false);
    }
}
