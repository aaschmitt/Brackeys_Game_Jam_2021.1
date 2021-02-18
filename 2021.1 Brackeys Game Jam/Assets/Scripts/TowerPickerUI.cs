using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPickerUI : MonoBehaviour
{
    public List<TowerButton> towerButtons = null;
    public Tower selectedTower = null;

    private const float SELECTED = 1f;
    private const float UNSELECTED = 0.5f;

    public void SelectTower(TowerButton towerButton)
    {
        var image = towerButton.GetComponent<Image>();
        SetImageAlpha(image, SELECTED);

        foreach (var tb in towerButtons)
        {
            if (tb != towerButton)
            {
                SetImageAlpha(tb.GetComponent<Image>(), UNSELECTED);
            }
        }
    }
    
    private void SetImageAlpha(Image image, float alpha)
    {
        var tempColor = image.color;
        tempColor.a = alpha;
        image.color = tempColor;
    }
}
