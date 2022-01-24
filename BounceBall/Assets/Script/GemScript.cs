using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GemScript : MonoBehaviour
{
    public Tilemap tilemap;
    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }
    public void DestroyGem(Vector3 pos)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(pos);
        tilemap.SetTile(cellPosition, null);
        StageManager.GemCount--;
        Debug.Log(StageManager.GemCount);
    }

}
