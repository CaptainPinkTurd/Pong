using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerAnnouncement : MonoBehaviour
{
    public TMP_Text gameOverText;

    internal void ChangeText(string playerName)
    {
        gameOverText.SetText("You Suck " + playerName, true);
    }
}
