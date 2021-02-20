using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrophyHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI towerHealthText = null;
    [SerializeField] private Trophy trophy = null;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        towerHealthText.text = "Health: " + trophy.Health;
    }
}
