using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnButtonPressed(int screenID)
    {
        SceneManager.LoadScene(screenID);
    }
}
