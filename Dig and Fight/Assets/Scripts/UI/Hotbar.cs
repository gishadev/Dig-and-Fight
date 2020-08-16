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
        for (int i = 0; i < hotkeys.Length; i++)
            UpdateHotkeyData(i, hotkeys[i].toolData);

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
                GameManager.Instance.player.ReplaceTool(hotkeys[i].toolData);
            }

            else
                hotkeys[i].bg.color = unselectedColor;
        }
    }

    public void UpdateHotkeyData(int index, ToolData _tool)
    {
        hotkeys[index].UpdateData(_tool);
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