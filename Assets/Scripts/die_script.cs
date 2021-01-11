using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die_script : MonoBehaviour
{
    public float time_die = 2;
    public GameObject efect,point_ex;
    GameObject canvas;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        canvas = GameObject.FindGameObjectWithTag("canvas");
        StartCoroutine(efectt(1.2f));
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas == null)
            canvas = GameObject.FindGameObjectWithTag("canvas");
    }
    private IEnumerator efectt(float second)
    {
        animator.SetBool("die", true);
        yield return new WaitForSeconds(second);
        GameObject sm = Instantiate(efect, point_ex.transform.position, Quaternion.identity);
        Destroy(sm, 0.3f);
        StartCoroutine(over(0.3f));
    }
    private IEnumerator over(float second)
    {
        yield return new WaitForSeconds(second);
        canvas.GetComponent<Game_Controller_UI>().GameOver();
    }
}
