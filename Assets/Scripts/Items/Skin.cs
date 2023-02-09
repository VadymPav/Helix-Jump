using TMPro;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public bool locked;
    public int coinsCost;

    public GameObject costContainer;
    public TextMeshProUGUI skinCostText;

    private void Start()
    {

        if (locked)
        {
            SetBool("locked", true);
            skinCostText.text = coinsCost.ToString();
        }
        else
        {
            SetBool("locked", false);
            costContainer.SetActive(false);
        }
        locked = GetBool("locked");
    }

    public void Unlocking()
    {
        if (!locked)
        {
            return;
        }

        if (locked)
        {
            if (coinsCost <= GameManager.coins)
            {
                costContainer.SetActive(false);
                locked = false;
                SetBool("locked", false);
            }
            else if(coinsCost > GameManager.coins)
            {
                return;
            }
        }
    }

    private void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    private bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1;
    }
}
