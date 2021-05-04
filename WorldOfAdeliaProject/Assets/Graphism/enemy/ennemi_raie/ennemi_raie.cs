using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi_raie : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("is_attack",false);

        
//		if(Input.GetKeyDown("9"))
//		{
//			anim.SetBool("is_attack",true);
//		}
//		if(Input.GetKeyDown("8"))
//		{
//			anim.SetBool("is_dead",true);
//		}
    }
}
