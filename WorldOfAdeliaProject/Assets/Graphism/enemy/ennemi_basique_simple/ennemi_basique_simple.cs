using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi_basique_simple : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		anim.SetFloat("start_random",Random.Range(0, 14));
	}

	// Update is called once per frame
	void Update ()
	{
		anim.SetBool("is_attack",false);
		
//		if(Input.GetKeyDown("1"))
//		{
//			anim.SetBool("is_attack",true);
//		}
//		if(Input.GetKeyDown("2"))
//		{
//            anim.SetBool("is_dead",true);
//		}
	}
}