using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public Tower tower = null;
    [SerializeField] private TowerPickerUI towerPickerUI = null;

    private void OnMouseDown()
    {
        if (tower)
        {
            towerPickerUI.selectedTower = tower;
        }
        else
        {
            towerPickerUI.selectedTower = null;
        }
        
        towerPickerUI.SelectTower(this);
    }
}
