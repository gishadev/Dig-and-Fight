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

    public void DeleteTile(Vector2 pos)
    {
        Vector3Int intPosition = blocksTilemap.WorldToCell(pos);

        if (!blocksTilemap.HasTile(intPosition))
            return;
        
        blocksTilemap.SetTile(intPosition, null);
    }
}
