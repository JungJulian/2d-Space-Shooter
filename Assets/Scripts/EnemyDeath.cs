using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name == "Bullet(Clone)")
        {
            ScoreScript.scoreValue += 10;
            Destroy(gameObject);
        }
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            HealthScript.healthValue -= 10;
            Destroy(gameObject);
        }
    }
}
