using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewPlayerCreator : MonoBehaviour
{
    [Header("New Players Modifiers")]
    public TMP_InputField newIdInputfield;
    public TMP_InputField newPseudoInputField;
    public Toggle newRoiToggle;
    public Toggle newArToggle;
    public Toggle newIndependantToggle;

    public User newPlayer()
    {
        User myNewPlayer = new User();

        myNewPlayer.id = newIdInputfield.text;
        myNewPlayer.pseudo = newPseudoInputField.text;
        myNewPlayer.documents.ROI = newRoiToggle.isOn;
        myNewPlayer.documents.AR = newArToggle.isOn;
        myNewPlayer.documents.Independant = newIndependantToggle.isOn;

        myNewPlayer.level = 0;
        myNewPlayer.lifepoints = 10;

        myNewPlayer.warning_And_Sanctions = "";
        myNewPlayer.banned = false;

        return myNewPlayer;
    }
}
