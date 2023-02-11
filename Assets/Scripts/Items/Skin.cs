using System;
using TMPro;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public bool locked;
    public int coinsCost;
    public string skinName;

    public GameObject costContainer;
    public TextMeshProUGUI skinCostText;

    private void Awake()
    {
        locked = GetBool(skinName);
    }

    private void Start()
    {

        if (this.locked)
        {
           skinCostText.text = coinsCost.ToString();
        }
        else
        {
            costContainer.SetActive(false);
        }
        
    }

    public void Unlocking()
    {
        if (!this.locked)
        {
            return;
        }

        if (this.locked)
        {
            if (coinsCost <= GameManager.coins)
            {
                costContainer.SetActive(false);
                locked = false;
                SetBool(skinName, false);
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
