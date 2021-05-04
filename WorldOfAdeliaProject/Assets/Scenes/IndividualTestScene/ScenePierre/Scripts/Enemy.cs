using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;
    public GameObject projectilePrefab;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship(Clone)").transform;

        timeBtwShots = startTimeBtwShots;
    }
    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            Vector3 v3Dir = transform.position - player.position;
            float angle = Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(this.transform.rotation.x, this.transform.rotation.y, angle - 90);

            if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector3.Distance(transform.position, player.position) < stoppingDistance &&
                    Vector3.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                if (PhotonNetwork.isMasterClient)
                {
                    StartCoroutine(shoot());
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

    }

    private IEnumerator shoot()
    {
        anim.SetBool("is_attack", true);
        timeBtwShots = startTimeBtwShots;
        yield return new WaitForSeconds(1);
        timeBtwShots = startTimeBtwShots;
        GameObject projectile = PhotonNetwork.InstantiateSceneObject(projectilePrefab.name, transform.position, Quaternion.identity, 0, null);
        anim.SetBool("is_attack", false);
    }
}
