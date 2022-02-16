using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvent : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Mute)
        {
            soundsText.text = "/";
        }
        else
        {
            soundsText.text = ""; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMute()
    {
        if (GameManager.Mute)
        {
            GameManager.Mute = false;

            soundsText.text = "";
        }
        else
        {
            GameManager.Mute = true;
            soundsText.text = "/";
        }
    }

    
}
