using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPickerUI : MonoBehaviour
{
    public List<TowerButton> towerButtons = null;
    public Tower selectedTower = null;

    [SerializeField] private TowerSpawner towerSpawner = null;
    [SerializeField] private SpriteRenderer towerCursor = null;
    [SerializeField] private TilemapUIManager tilemapUIManager = null;

    private const float SELECTED = 1f;
    private const float UNSELECTED = 0.5f;

    private void Start()
    {
        SelectTower(towerButtons[0]);
    }
    
    public void SelectTower(TowerButton towerButton)
    {
        selectedTower = towerButton.tower;
        towerSpawner.selectedTower = selectedTower;

        foreach (var tb in towerButtons)
        {
            var sprite = tb.GetComponent<SpriteRenderer>();
            
            if (tb.tower != selectedTower)
            {
                SetImageAlpha(sprite, UNSELECTED);
            }
            else
            {
                SetImageAlpha(sprite, SELECTED);
                SetCursorImage(sprite);
                tilemapUIManager.EnableTilemapUI();
            }
        }

        if (!selectedTower)
        {
            tilemapUIManager.DisableTilemapUI();
            SetCursorImage(null);
        }
    }

    private void SetCursorImage(SpriteRenderer sprite)
    {
        if (sprite)
        {
            towerCursor.sprite = sprite.sprite;
        }
        else
        {
            towerCursor.sprite = null;
        }
    }

    private void SetImageAlpha(SpriteRenderer sprite, float alpha)
    {
        var tempColor = sprite.color;
        tempColor.a = alpha;
        sprite.color = tempColor;
    }
}
