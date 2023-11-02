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

        Documents newDoc = new Documents();
        newDoc.ROI = newRoiToggle.isOn;
        newDoc.AR = newArToggle.isOn;
        newDoc.Independant = newIndependantToggle.isOn;
        myNewPlayer.documents = newDoc;

        myNewPlayer.level = 0;
        myNewPlayer.lifepoints = 10;

        myNewPlayer.warning_And_Sanctions = "";
        myNewPlayer.banned = false;

        return myNewPlayer;
    }
}
