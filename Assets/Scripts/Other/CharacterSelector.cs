using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;

    public Skin[] _Skin;
    private int selectedCharacter;
    
    // Start is called before the first frame update
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("Current", 0);
        foreach (GameObject ch in characters)
        {
            ch.SetActive(false);
        }
        characters[selectedCharacter].SetActive(true);
    }

    // Update is called once per frame
    public void ChangeCharacter(int newCharacter)
    {
        if (_Skin[newCharacter].locked)
            return;
        characters[selectedCharacter].SetActive(false);
        characters[newCharacter].SetActive(true);
        selectedCharacter = newCharacter;
        PlayerPrefs.SetInt("Current", selectedCharacter);
    }
}
