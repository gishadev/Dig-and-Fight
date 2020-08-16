using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Scriptable Objects/Tool")]
public class ToolData : ScriptableObject
{
    public GameObject prefab;
    public float zOffset = -45f;
}