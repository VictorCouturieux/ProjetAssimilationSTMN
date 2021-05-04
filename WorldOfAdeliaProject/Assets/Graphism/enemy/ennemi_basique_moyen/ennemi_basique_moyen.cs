using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi_basique_moyen : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	/*void Update ()
	{
		anim.SetBool("is_attack",false);

		if(Input.GetKeyDown("1"))
		{
			anim.SetBool("is_attack",true);
		}
		if(Input.GetKeyDown("2"))
		{
            anim.SetBool("is_dead",true);
		}
	}*/
}
