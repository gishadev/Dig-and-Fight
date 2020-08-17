using UnityEngine;
public class Hotbar : MonoBehaviour
{
    #region Singleton
    public static Hotbar Instance { private set; get; }
    #endregion

    public Hotkey[] hotkeys;

    public Color selectedColor, unselectedColor;

    [HideInInspector] public int selectedKey = 0;

    private KeyCode[] keyCodes = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitHotkeysData();

        SelectKey();
    }

    void Update()
    {
        MouseInput();
        KeyboardInput();
    }

    void SelectKey()
    {
        for (int i = 0; i < hotkeys.Length; i++)
        {
            if (i == selectedKey)
            {
                hotkeys[i].bg.color = selectedColor;
                GameManager.Instance.player.ChangeTool(i);
            }

            else
                hotkeys[i].bg.color = unselectedColor;
        }
    }

    public void AddNewToolData(int index, ToolData newData)
    {
        hotkeys[index].UpdateData(newData);
    }

    public void RemoveToolData(int index)
    {
        hotkeys[index].UpdateData(null);
    }

    void InitHotkeysData()
    {
        for (int i = 0; i < hotkeys.Length; i++)
            hotkeys[i].UpdateData(hotkeys[i].toolData);
    }

    #region Input
    void MouseInput()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            selectedKey--;

            if (selectedKey < 0)
                selectedKey = 2;

            SelectKey();
        }

        else if (Input.mouseScrollDelta.y < 0)
        {
            selectedKey++;

            if (selectedKey > 2)
                selectedKey = 0;

            SelectKey();
        }
    }
    void KeyboardInput()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                selectedKey = i;
                SelectKey();
            }

        }
    }
    #endregion Input
}