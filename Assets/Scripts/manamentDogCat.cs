using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manamentDogCat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pointer;
    [SerializeField]
    private GameObject[] gbSp = new GameObject[4];
    private float flagTime = 0f;

    private GameObject gbSpawn;
    Vector3[] positionSpawn = new Vector3[5];

    private float currentTime = 0f;
    private float waitingTime = 0f;
    [SerializeField]
    private float timestartMeoDog   ;
    [SerializeField]
    private float timenextMeoDog;

    private bool flag = false;
    int i = 0;
    void Start()
    {
        positionSpawn[0] = new Vector3(pointer.transform.position.x - 5, pointer.transform.position.y - 1, pointer.transform.position.z);
        positionSpawn[1] = new Vector3(pointer.transform.position.x + 5, pointer.transform.position.y - 2, pointer.transform.position.z);
        positionSpawn[2] = new Vector3(pointer.transform.position.x - 5, pointer.transform.position.y - 3, pointer.transform.position.z);
        positionSpawn[3] = new Vector3(pointer.transform.position.x + 5, pointer.transform.position.y - 4, pointer.transform.position.z);
        positionSpawn[4] = new Vector3(pointer.transform.position.x - 5, pointer.transform.position.y - 5, pointer.transform.position.z);
        
    }

    // Update is called once per frame
    private GameObject useToSpawn;
    void Update()
    {
        //ShootPlayer();
        //Debug.Log(Time.time);
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
        if (currentTime >= timestartMeoDog && flag == false)
        {
            timestartMeoDog += Mathf.Max(timenextMeoDog - 1, 10);
            Debug.Log("spawn cat");
            if(Random.Range(1.0f,3.0f) > 2.0f)
            {
                useToSpawn = gbSp[0];
            }else useToSpawn = gbSp[1];
            gbSpawn = Instantiate(useToSpawn, positionSpawn[Random.Range(0, positionSpawn.Length)], Quaternion.identity);
            StartCoroutine(Wait(gbSpawn));
            flag = true;
            waitingTime++;
        }
        
    }
    private IEnumerator Wait(GameObject g)
    {
        Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
        if(g.gameObject.transform.position.x < pointer.transform.position.x)
        rb.AddForce(new Vector3(1, 0, 0) * 1.5f, ForceMode2D.Impulse);
        else
        {
            g.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
            rb.AddForce(new Vector3(-1, 0, 0) * 1.5f, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(7.0f);
        Destroy(g);
        flag = false;
    }
    
    
}
