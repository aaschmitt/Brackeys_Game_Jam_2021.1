using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int Cost = 0;
    
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float timeBetweenEnemyChecks = 0.1f;
    [SerializeField] private float timeBetweenShots = 1f;
    
    [SerializeField] private LookAt lookAt = null;

    [SerializeField] private GameObject bulletPrefab = null;

    private IEnumerator _checkForEnemiesCoroutine = null;
    private IEnumerator _waitAndShoot = null;
    private bool isShooting = false;
    
    private GameObject _enemyTargetted = null;

    // Start is called before the first frame update
    void Start()
    {
        _checkForEnemiesCoroutine = CheckForEnemiesInSight();
        _waitAndShoot = WaitAndShoot();
        
        StartCoroutine(_checkForEnemiesCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        ShootEnemies();
    }

    private void ShootEnemies()
    {
        if (_enemyTargetted && !isShooting)
        {
            StartCoroutine(_waitAndShoot);
            isShooting = true;
        }
        
        if (!_enemyTargetted && isShooting) 
        {
            StopCoroutine(_waitAndShoot);
            isShooting = false;
        }
    }

    private IEnumerator WaitAndShoot()
    {
        while (true)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.Direction = lookAt.Direction.normalized;
            yield return new WaitForSeconds(timeBetweenShots);
        } 
    }
    
    private IEnumerator CheckForEnemiesInSight()
    {
        while (true)
        {
            LookAtEnemy(Physics2D.OverlapCircleAll(transform.position, radius, enemyLayers));
            yield return new WaitForSeconds(timeBetweenEnemyChecks);
        }
    }

    private void LookAtEnemy(Collider2D[] enemies)
    {
        if (enemies.Length == 0)
        {
            _enemyTargetted = null;
            return;
        }

        foreach (Collider2D enemy in enemies)
        {
            if (_enemyTargetted == enemy.gameObject)
            {
                return;
            }
        }
        
        _enemyTargetted = enemies[0].gameObject;
        lookAt.Target = _enemyTargetted;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
