using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCursor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = null;
    public Tower currentTower = null;

    private void Start()
    {
        InitializeVariables();
    }

    private void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

    private void InitializeVariables()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
