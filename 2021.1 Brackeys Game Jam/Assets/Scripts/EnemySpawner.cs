using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public bool isActive = true;
    public List<Enemy> enemies = null;
    
    [SerializeField] private float speedMultiplier = 1f;
    [SerializeField] private float buffMultiplier = 1.1f;

    [SerializeField] private float timeBetweenBuffs = 15f;
    
    [SerializeField] private float maxTimeBetweenSpawns = 6f;
    [SerializeField] private float minTimeBetweenSpawns = 0.5f;

    private IEnumerator _spawningEnemies = null;
    private void OnEnable()
    {
        _spawningEnemies = WaitAndSpawn();
        StartCoroutine(_spawningEnemies);
        StartCoroutine(WaitAndBuff());
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

    private IEnumerator WaitAndBuff()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(timeBetweenBuffs);
            speedMultiplier *= buffMultiplier;
            if (!(maxTimeBetweenSpawns - 0.5f <= 0))
            {
                maxTimeBetweenSpawns -= 0.5f;
            }
        }
    }

    private void ApplyMultipliers(Enemy enemy)
    {
        enemy.Speed *= speedMultiplier;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
