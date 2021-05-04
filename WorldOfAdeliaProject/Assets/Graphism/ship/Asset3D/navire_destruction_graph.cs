using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navire_destruction_graph : MonoBehaviour

{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("death",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
