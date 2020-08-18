using UnityEngine;
using TMPro;
public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

    public void Disable()
    {
        txt.gameObject.SetActive(false);
    }
    public void UpdateAmmoUI(int ammo)
    {
        txt.text = ammo.ToString();
        txt.gameObject.SetActive(true);
    }
}
