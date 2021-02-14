using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public bool isActive = true;
    public List<Enemy> enemies = null;
    
    [SerializeField] private float damageMultiplier = 1f;
    [SerializeField] private float speedMultiplier = 1f;
    [SerializeField] private float healthMultiplier = 1f;
    
    [SerializeField] private float maxTimeBetweenSpawns = 10f;
    [SerializeField] private float minTimeBetweenSpawns = 2f;

    private IEnumerator _spawningEnemies = null;
    private void Start()
    {
        _spawningEnemies = WaitAndSpawn();
        StartCoroutine(_spawningEnemies);
    }

    private IEnumerator WaitAndSpawn()
    {
        while (isActive)
        {
            var enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position, Quaternion.identity);
            ApplyMultipliers(enemy);

            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));   
        }
    }

    private void ApplyMultipliers(Enemy enemy)
    {
        enemy.Damage *= damageMultiplier;
        enemy.Health *= healthMultiplier;
        enemy.Speed *= speedMultiplier;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
