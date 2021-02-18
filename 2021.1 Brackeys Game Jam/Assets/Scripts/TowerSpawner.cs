using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private List<Tower> spawnableTowers = null;
    [SerializeField] private Tilemap tileMap = null;
    [SerializeField] private List<TileData> tileDatas = null;
    [SerializeField] private GoldManager goldManager = null;

    private Tower selectedTower = null;
    private Dictionary<TileBase, TileData> dataFromTiles = null;
    private HashSet<Vector3Int> tilesWithTowers = null;

    private void Awake()
    {
        tilesWithTowers = new HashSet<Vector3Int>();
        
        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }
    
    private void SpawnTower(Tower tower, Vector3 position)
    {
        Instantiate(tower, position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnTower();
        }
    }

    private void Start()
    {
        selectedTower = spawnableTowers[0];
    }

    private void SpawnTower()
    {
        if (BuyTower())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = tileMap.WorldToCell(mousePosition);
            Vector3 spawnPosition = tileMap.GetCellCenterWorld(gridPosition);
            TileBase clickedTile = tileMap.GetTile(gridPosition);
            
            if (selectedTower)
            {
                if (dataFromTiles[clickedTile].isBuildable && !tilesWithTowers.Contains(gridPosition))
                {
                    SpawnTower(selectedTower, spawnPosition);
                    tilesWithTowers.Add(gridPosition);
                }
            }
        }
    }

    private bool BuyTower()
    {
        if (goldManager.RemoveGold(selectedTower.Cost))
        {
            return true;
        }

        return false;
    }
}
