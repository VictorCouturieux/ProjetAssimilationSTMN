using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int damage = 1;
    public float speed;
    public bool isEnemyShot = false;

    private Transform player;
    private Vector3 target;

    public float timeToDestroyLayer = 3f;
    
    private double m_CreationTime;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship(Clone)").transform;

        target = new Vector3(player.position.x,player.position.y, player.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        timer += Time.deltaTime;

        if( player)
        {
            if (timer >= 20 || transform.position.y <= player.transform.position.y + 0.05)
            {

                Destroy(this.gameObject);

            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
