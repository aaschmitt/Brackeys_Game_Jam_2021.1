using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 10;
    public float Speed = 0f;
    public float Damage = 0;
    public int Gold = 0;
    
    public GameObject aimPoint = null;

    [SerializeField] private GoldManager goldManager = null;
    
    private Waypoints Wpoints = null;
    private int waypointIndex;

    private void Start()
    {
        InitializeVariables();
    }

    private void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, Speed * Time.deltaTime);

        Vector3 dir = Wpoints.waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void DamageEnemy(float damage)
    {
        if (Damage - damage <= 0)
        {
            Destroy(gameObject);
        }
        Damage -= damage;
    }

    private void InitializeVariables()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        goldManager = FindObjectOfType<GoldManager>();
    }

    private void OnDestroy()
    {
        if (goldManager) goldManager.AddGold(Gold);
    }
}
