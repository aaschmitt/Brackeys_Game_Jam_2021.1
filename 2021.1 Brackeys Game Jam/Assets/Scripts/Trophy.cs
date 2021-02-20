using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    public float Health = 100;
    [SerializeField] private TrophyHealthUI trophyHealthUI = null;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                Health -= enemy.Damage;
                trophyHealthUI.UpdateText();
                enemy.Gold = 0;
            }
        }
    }
}
