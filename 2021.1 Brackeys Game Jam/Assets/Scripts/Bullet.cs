﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Direction { get; set; }

    [SerializeField] private float speed = 1f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float lifetime = 1f;
    [SerializeField] private ParticleSystem onHitPS = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBulletAfterSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        transform.position += Time.deltaTime * speed * Direction;
    }
    
    private IEnumerator DestroyBulletAfterSeconds()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            if (onHitPS) Instantiate(onHitPS, transform.position, Quaternion.identity);
            enemy.DamageEnemy(damage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
