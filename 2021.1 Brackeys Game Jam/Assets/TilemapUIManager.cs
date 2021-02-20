using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapUIManager : MonoBehaviour
{
    [SerializeField] private GameObject tileMapUI = null;

    public void EnableTilemapUI()
    {
        tileMapUI.SetActive(true);
    }

    public void DisableTilemapUI()
    {
        tileMapUI.SetActive(false);
    }
}
