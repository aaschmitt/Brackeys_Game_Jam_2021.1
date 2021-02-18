using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText = null;

    public void UpdateText(int gold)
    {
        goldText.text = "Gold: " + gold;
    }
}
