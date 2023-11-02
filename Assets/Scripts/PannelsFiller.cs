using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(JsonReadWriteSystem))]
public class PannelsFiller : MonoBehaviour
{
    [Header("Main Menu UI")]
    public TMP_InputField idInputField;
    public Image backgroungImage;
    public Color normalColor;
    public Color bannedColor;
    [Space]
    [Header("Player Pannels")]
    public GameObject currentPlayerPannel;
    public GameObject newPlayerPannel;
    [Space]
    [Header("Current Player Modifiers")]
    [Header("Hero Pannel")]
    public GameObject heroPannel;
    public TMP_Text playerPseudo;
    public TMP_Text level;
    public Slider lifepointsSlider;
    [Space]
    [Header("Documents Pannel")]
    public GameObject documentsPanel;
    public Toggle roiToggle;
    public Toggle arToggle;
    public Toggle independantToggle;
    public Toggle banToggle;
    [Space]
    [Header("Warnings Pannel")]
    public GameObject warningPanel;
    public TMP_InputField warningInputField;
    [Space]
    [Header("New Players Modifiers")]
    public TMP_InputField newIdInputfield;
    public TMP_InputField newPseudoInputField;
    public Toggle newRoiToggle;
    public Toggle newArToggle;
    public Toggle newIndependantToggle;






    public void UIFillingUser(User userSend)
    {
        Debug.Log(userSend.id);
        playerPseudo.text = userSend.pseudo;

        roiToggle.isOn = userSend.documents.ROI;
        arToggle.isOn = userSend.documents.AR;
        independantToggle.isOn = userSend.documents.Independant;

        warningInputField.text = userSend.warning_And_Sanctions;
        banToggle.isOn = userSend.banned;
        BanColoration();
       
        level.text = userSend.level.ToString();
        lifepointsSlider.value = userSend.lifepoints;
    }

    public User ReturnInfos(User userSend)
    {
        userSend.documents.ROI = roiToggle.isOn;
        userSend.documents.AR = arToggle.isOn;
        userSend.documents.Independant = independantToggle.isOn;
        int resultLevel;
        int.TryParse(level.text, out resultLevel);
        userSend.level = resultLevel;
        userSend.lifepoints = (int)lifepointsSlider.value;
        return userSend;
    }

    public void BanColoration()
    {
        if (banToggle.isOn)
        {
            backgroungImage.color = bannedColor;
        }
        else
        {
            backgroungImage.color = normalColor;
        }
    }

    public void OpenCloseDocPanel()
    {
        if(documentsPanel.activeInHierarchy == true)
        {
            documentsPanel.SetActive(false);
        }
        else
        {
            documentsPanel.SetActive(true);
        }
    }

    public void OpencloseWarningPanel()
    {
        if(warningPanel.activeInHierarchy == true)
        {
            warningPanel.SetActive(false);
        }
        else
        {
            warningPanel.SetActive(true);
        }
    }
}
