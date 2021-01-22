using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineExplosion : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }

}