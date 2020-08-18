using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public void UpdateTimerUI(float value,float maxValue)
    {
        transform.localScale = new Vector3(value / maxValue, 1f, 1f);
    }
}
