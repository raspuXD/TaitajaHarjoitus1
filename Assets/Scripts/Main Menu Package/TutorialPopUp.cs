using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPopUp : MonoBehaviour
{
    public Button theTutorialButton;
    public GameObject thePopUp, canCountinueNow;
    public TMP_Text theInfoText, howToGetAwayText;

    [Header("Closing options")]
    public KeyCode closeKey = KeyCode.Escape;

    public void AssingCloseKey(KeyCode theNewKey)
    {
        closeKey = theNewKey;
    }

    public void StartThePopUp(string textToShow)
    {
        theTutorialButton.gameObject.SetActive(true);
        theInfoText.text = textToShow;
        theTutorialButton.interactable = false;
        StartCoroutine(ScaleTheButton(true));
    }

    IEnumerator ScaleTheButton(bool scaleUp)
    {
        float duration = 0.33f;
        Vector3 initialScale = thePopUp.transform.localScale;
        Vector3 targetScale = scaleUp ? Vector3.one : Vector3.zero;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            thePopUp.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        thePopUp.transform.localScale = targetScale;

        if (scaleUp)
        {
            Time.timeScale = 1;
            yield return new WaitForSecondsRealtime(1f);
            canCountinueNow.SetActive(true);
            howToGetAwayText.text = "Click to Close or\r\n"+closeKey.ToString();
            theTutorialButton.interactable = true;
        }
        else
        {
            Time.timeScale = 0;
            theInfoText.text = "";
            howToGetAwayText.text = "";
            theTutorialButton.gameObject.SetActive(false);
        }
    }

    public void CloseThePopUp()
    {
        theTutorialButton.interactable = false;
        canCountinueNow.SetActive(false);
        StartCoroutine(ScaleTheButton(false));
    }
    void Update()
    {
        if (canCountinueNow.activeSelf && Input.GetKeyDown(closeKey))
        {
            CloseThePopUp();
        }
    }
}