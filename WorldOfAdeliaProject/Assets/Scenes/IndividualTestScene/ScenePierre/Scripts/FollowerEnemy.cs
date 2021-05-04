using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MoveTowards() has to be in a positive global position
 */

public class FollowerEnemy : Photon.MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public Animator anim;
    public bool triggerAnimAttack = true;

    private GameObject target;
    private Transform targetTransform;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Ship(Clone)");
        if(target == null)
        {
            Destroy(this.gameObject);
        }
        targetTransform = target.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {

            if (Vector2.Distance(transform.position, targetTransform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, targetTransform.position) < 2.5 && triggerAnimAttack)
            {
                Debug.Log("attack");
                anim.SetBool("is_attack", true);
                triggerAnimAttack = false;
            }

                Vector3 v3Dir = transform.position - targetTransform.position;
            float angle = Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle-90);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
