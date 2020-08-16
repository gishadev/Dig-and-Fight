using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapEditor : MonoBehaviour
{
    #region Singleton
    public static TilemapEditor Instance { private set; get; }
    #endregion

    public Tilemap blocksTilemap;

    void Awake()
    {
        Instance = this;
    }

    public void RemoveTile(Vector2 pos)
    {
        Vector3Int intPosition = blocksTilemap.WorldToCell(pos);
        Debug.Log(intPosition);
        if (!blocksTilemap.HasTile(intPosition))
        {
            Debug.LogError("Tile wasn't found!");
            return;
        }

        blocksTilemap.SetTile(intPosition, null);
    }


}
