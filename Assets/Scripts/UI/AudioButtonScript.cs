using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButtonScript : MonoBehaviour
{
    public TMPro.TMP_Text buttonTextObject;
    bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        SetButtonText();
    }

    public void PressButton()
    {
        ToggleActive();
        SetButtonText();
    }

    void ToggleActive()
    {
        isActive = !isActive;

        if (isActive)
        {
            // set audio to default value
            AudioListener.volume = 1;
        } 
        else
        {
            // set audio to 0
            AudioListener.volume = 0;
        }

        Debug.Log("Audio is now set to: " + isActive);
    }

    void SetButtonText()
    {
        if (isActive)
        {
            buttonTextObject.text = "ON";
        }
        else
        {
            buttonTextObject.text = "OFF";
        }
    }
}
