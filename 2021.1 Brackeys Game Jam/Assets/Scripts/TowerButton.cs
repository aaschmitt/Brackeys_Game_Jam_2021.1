using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private Tower tower = null;
    [SerializeField] private TowerPickerUI towerPickerUI = null;

    private void OnMouseDown()
    {
        Debug.Log("UI clicked!");
        towerPickerUI.selectedTower = tower;
        towerPickerUI.SelectTower(this);
    }
}
