using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(JsonReadWriteSystem))]
public class CanvasManager : MonoBehaviour
{
    public GameObject documentsPanel;
    public GameObject warningPanel;

    public TMP_InputField idInputField;
    public TMP_InputField pseudoInputField;
    public TMP_InputField warningInputField;

    public Toggle roiToggle;
    public Toggle arToggle;
    public Toggle independantToggle;
    public Toggle banToggle;

    public TMP_Text level;

    public Slider lifepointsSlider;

    public Image backgroungImage;
    public Color normalColor;
    public Color bannedColor;


    public void UIFillingUser(User userSend)
    {
        idInputField.text = userSend.id;
        pseudoInputField.text = userSend.pseudo;
        warningInputField.text = userSend.warning_And_Sanctions;

        roiToggle.isOn = userSend.documents.ROI;
        arToggle.isOn = userSend.documents.AR;
        independantToggle.isOn = userSend.documents.Independant;
        banToggle.isOn = userSend.banned;
        BanColoration();
       
        level.text = userSend.level.ToString();
        lifepointsSlider.value = userSend.lifepoints;
    }

    public Documents ReturnDocumentsInfos(User userSend)
    {
        userSend.documents.ROI = roiToggle.isOn;
        userSend.documents.AR = arToggle.isOn;
        userSend.documents.Independant = independantToggle.isOn;
        return userSend.documents;
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

    public void ClearInputField()
    {
        if(idInputField.text != "" || pseudoInputField.text != "")
        {
        idInputField.text = "";
        pseudoInputField.text = "";
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
