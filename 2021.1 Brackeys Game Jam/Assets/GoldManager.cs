using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private GoldManagerUI goldManagerUI = null;
    [SerializeField] private int goldCount = 10;

    private void Start()
    {
        goldManagerUI.UpdateText(goldCount);
    }
    
    public bool AddGold(int amount)
    {
        if (goldCount + amount < 0) return false;
        
        goldCount += amount;
        goldManagerUI.UpdateText(goldCount);
        return true;
    }

    public bool RemoveGold(int amount)
    {
        if (goldCount - amount < 0) return false;
        
        goldCount -= amount;
        goldManagerUI.UpdateText(goldCount);
        return true;
    }
}
