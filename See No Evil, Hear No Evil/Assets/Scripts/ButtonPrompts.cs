using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPrompts : MonoBehaviour
{
    public TextMeshProUGUI promptLetter;
    public TextMeshProUGUI promptText;

    public void PromptUser(bool isLetter, string prompt)
    {
        if (isLetter)
        {
            promptLetter.enabled = true;
            promptText.enabled = false;

            promptLetter.text = prompt;
        }
        else
        {
            promptLetter.enabled = false;
            promptText.enabled = true;

            promptText.text = prompt;
        }
    }
}
