using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogoMove : MonoBehaviour
{
    public GameObject vo,chong;
    bool den = true;
    Animator vo_animator,chong_animator;
    // Start is called before the first frame update
    void Start()
    {
        vo_animator = vo.GetComponent<Animator>();
        chong_animator = chong.GetComponent<Animator>();
        StartCoroutine(Go());
    }

    // Update is called once per frame
    void Update()
    {
    
        if(den == false)
        {
            vo.transform.position = Vector3.Lerp(vo.transform.position,chong.transform.position,1.3f*Time.deltaTime);
        }
        if(Vector3.Distance(vo.transform.position,chong.transform.position)<=1f)
        {
            den=true;
            chong_animator.SetBool("bay",true);
        }

    }
    public IEnumerator Go ()
    {
        yield return new WaitForSeconds(1.2f);
        den=false;
        vo_animator.SetBool("isAttack",true);
    }

}
