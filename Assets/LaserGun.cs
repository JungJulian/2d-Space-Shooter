using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    private GameObject go;
    public float Point;
    public GameObject hitEffect;


    void Start()
    {

    }
    private void Awake()
    {
            m_transform = GetComponent<Transform>();
    }

 void Update()
    {
        ShootLaser();
        go = GameObject.FindWithTag("Enemy(Clone)");
        Point = ScoreScript.scoreValue;
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.up))
            {
                RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.up);
                Draw2DRay(laserFirePoint.position, _hit.point);

            if (_hit.collider.tag == "Enemy(Clone)")
            {
                if (Input.GetMouseButton(1))
                {
                    Debug.Log("Working!!");
                    Destroy(_hit.transform.gameObject);
                    ScoreScript.scoreValue += 10;

                }
            }
        }

        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.up * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos )
    {
        if (Input.GetMouseButton(1))
        {
            m_lineRenderer.enabled = true;
            m_lineRenderer.SetPosition(0, startPos);
            m_lineRenderer.SetPosition(1, endPos);
        }
        else
        {
            m_lineRenderer.enabled = false;
        }
    }
}
