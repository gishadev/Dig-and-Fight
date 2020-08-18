using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject[] healthInsides;

    public void UpdateHealthUI(int h)
    {
        for (int i = 0; i < healthInsides.Length; i++)
        {
            if (i < h)
                healthInsides[i].SetActive(true);
            else
                healthInsides[i].SetActive(false);
        }
    }
}
