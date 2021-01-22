using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public Rigidbody2D rb2d;
    //create a separate Rigidbody2D
    public Rigidbody2D rb;
    public float moveSpeed = 2f;
    public Vector2 movement;

    void Start()
    {
        GameObject Player = GameObject.Find("Player");
        //this code finds the player based on it's name in the quotes
        rb = this.GetComponent<Rigidbody2D>();
        rb2d = Player.GetComponent<Rigidbody2D>();
        //this attaches the found players RB2D to the premade rb2d
    }

    void Update()
    {
        Vector3 direction = rb2d.position - (Vector2)transform.position;
        //replace player.position with rb2d.position
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f);
        rb.rotation = angle;

        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        moveChar(movement);
    }

    void moveChar(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
