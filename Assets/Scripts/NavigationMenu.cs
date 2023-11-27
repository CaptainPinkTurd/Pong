using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class NavigationMenu : MonoBehaviour
{
    public TMP_Text textButton;
    public AudioSource selectSound;
    public void OnSelect(BaseEventData eventData)
    {
        textButton.color = Color.black;
        this.selectSound.Play();
    }
    public void OnDeselect(BaseEventData eventData)
    {
        textButton.color = Color.white;
    }
    public void OnClickBack()
    {
        textButton.color = Color.white;
    }
}
