using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonshomme_animation : MonoBehaviour {


	public Animator anim;
	private bool walking;
	private bool dash;
	private bool push;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		walking = false;
		dash = false;
		push = false;
	}
	
	// Update is called once per frame


	void Update ()
	{

		// Inputs control test (A supprimer) ____________________________
//		if(Input.GetKeyDown(KeyCode.UpArrow))
//		{
//            walking = true;
//		}
//		
//		if(Input.GetKeyUp(KeyCode.UpArrow))
//		{
//			walking = false;
//		}
//		if(Input.GetKeyDown(KeyCode.Space))
//		{
//            dash = true;
//		}
//		else
//		{
//			dash = false;
//		}
//		if(Input.GetKeyDown(KeyCode.RightControl))
//		{
//            push = true;
//		}
//		if(Input.GetKeyUp(KeyCode.RightControl))
//		{
//			push = false;
//		}

		//________________________________________________________________



//		anim.SetBool("is_walking", walking);
//		anim.SetBool("is_pushing",push);
//		anim.SetBool("is_dashing",dash);
//
//		if (dash = true)
//		{
//			dash = false;
//		}
//		else
//		{
//			anim.SetBool("is_dashing",false);
//		}


		//x += ((Input.GetKeyDown(KeyCode.RightControl))-(Input.GetKeyDown(KeyCode.LeftControl)));
		//z += ((Input.GetKeyDown(KeyCode.UpControl))-(Input.GetKeyDown(KeyCode.DownControl)));
	
	}
	




}
