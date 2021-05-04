using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovingScript : MonoBehaviour
{
    public Rigidbody rigid;

    // Vitesse de déplacement
    public Vector2 speed = new Vector2(1, 3);

    // Direction
    public Vector2 direction = new Vector2(0, -1);

    private Vector2 movement;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }
    void Update()
    {
        // 2 - Calcul du mouvement
        movement = new Vector2(
          speed.x * direction.x*(ScrollingScript.instance.speed.x/20),
          speed.y * direction.y*(ScrollingScript.instance.speed.y/20));
    }

    void setSpeedWithSpeedBackground()
    {

    }

    void FixedUpdate()
    {
        // Application du mouvement
        rigid.velocity = movement;
    }
}
