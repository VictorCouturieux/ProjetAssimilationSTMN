using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navire : MonoBehaviour {

	public Animator anim;
	private int speed_mod; // 0 = Stop ; 1 = Slow ; 2 = Normal ; 3 = Fast
	private bool begin_dash; // run dash anim'
	private bool dead; // destruction anim'

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		speed_mod = 0;
		begin_dash = false;
		dead = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		// Input Keyboard ______________________ ( A supprimer )
		if(Input.GetKeyDown("3"))
		{
            speed_mod = 0;
		}
		if(Input.GetKeyDown("4"))
		{
            speed_mod = 1;
		}
		if(Input.GetKeyDown("5"))
		{
            speed_mod = 2;
		}
		if(Input.GetKeyDown("6"))
		{
            speed_mod = 3;
		}
		if(Input.GetKeyDown("7"))
		{
            dead = true;
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
            begin_dash = true;
		}
		//_________________________________________


		// Anim + FX affectation

		anim.SetInteger("speed", speed_mod);
		anim.SetBool("dash",begin_dash);
		anim.SetBool("death",dead);

		

		if (begin_dash = true)
		{
			begin_dash = false;
		}
		else
		{
			anim.SetBool("dash",false);
		}
	}
}
