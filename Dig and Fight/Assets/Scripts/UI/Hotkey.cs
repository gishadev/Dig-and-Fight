using UnityEngine;
using UnityEngine.UI;
public class Hotkey : MonoBehaviour
{
    public ToolData toolData;

    [HideInInspector] public Image bg;
    [HideInInspector] public Image gearImg;

    // Changing of tool on certain tool data //
    public void UpdateData(ToolData newTool)
    {
        bg = GetComponent<Image>();

        if (newTool == null)
        {
            if (toolData != null)
                gearImg.gameObject.SetActive(false);

            toolData = null;
            return;
        }

        gearImg = transform.GetChild(0).GetComponent<Image>();
        gearImg.gameObject.SetActive(true);

        toolData = newTool;

        if (toolData != null)
        {
            gearImg.enabled = true;
            gearImg.sprite = toolData.prefab.GetComponent<SpriteRenderer>().sprite;
        }
        else gearImg.enabled = false;
    }
}