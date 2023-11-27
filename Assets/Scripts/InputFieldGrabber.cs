using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class InputFieldGrabber : MonoBehaviour
{
    public TMP_Text playerNameChanged;

    private string[] savedName;
    private int userCount;

    private void Start()
    {
        userCount = PlayerPrefs.GetInt("UserCount", 0);
        Debug.Log("Initial user count: " + userCount);
        if (userCount > 0)
        {
            savedName = new string[userCount];
            for (int i = 0; i < userCount; i++)
            {
                savedName[i] = PlayerPrefs.GetString("User" + i);
                Debug.Log($"savedName[{i}]: {savedName[i]}");
                Debug.Log("Getting string from the file: " + PlayerPrefs.GetString("User" + i)); 
                //EACH BUTTON HAVE THEIR OWN USER COUNT VALUE, THIS IS WHY THE FIRST VALUE KEEP GETTING OVERWRITE TO NULL
            }
        }
    }
    public void OnNameChanged(TMP_Text input)
    {
        playerNameChanged.SetText(input.text, true);
    }
    public void RefreshCount()
    {
        PlayerPrefs.SetInt("UserCount", 0);
    }

    public void SaveNames() //not the best name register system but whatever i give up
    {
        if (playerNameChanged.gameObject.name == "P1Name")
        {
            PlayerPrefs.SetString("User" + userCount, playerNameChanged.text);
            userCount++;
            PlayerPrefs.SetString("User" + userCount, PlayerPrefs.GetString("User" + (userCount - 2)));
        }
        else if (playerNameChanged.gameObject.name == "P2Name" && userCount < 2)
        {
            PlayerPrefs.SetString("User" + (userCount + 2), PlayerPrefs.GetString("User" + (userCount - 2))); //WTF index bs
            userCount++;
            PlayerPrefs.SetString("User" + userCount, playerNameChanged.text);
        } else if(playerNameChanged.gameObject.name == "P2Name" && userCount >= 2)
        {
            PlayerPrefs.SetString("User" + userCount, PlayerPrefs.GetString("User" + (userCount - 2)));
            userCount++;
            PlayerPrefs.SetString("User" + userCount, playerNameChanged.text);
        }
        //Debug.Log("Player" + userCount + " name saved");
        userCount++;
        PlayerPrefs.SetInt("UserCount", userCount);
    }
    public void LoadNameP1(TMP_Text loadedName) //unity won't allow 2 parameters in an event apparently
    {
        loadedName.text = savedName[userCount - 2];
    }
    public void LoadNameP2(TMP_Text loadedName) //unity won't allow 2 parameters in an event apparently
    {
        loadedName.text = savedName[userCount - 1];
    }
}
