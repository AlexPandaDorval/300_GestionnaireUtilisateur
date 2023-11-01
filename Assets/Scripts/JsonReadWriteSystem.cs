using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(CanvasManager))]
public class JsonReadWriteSystem : MonoBehaviour
{
    private bool isNew;

    public CanvasManager canvasManager;

    public string jsonPath = "D:/Unity Projects/ProjetSucces/Assets/Scripts/JSON_Files/Users.json";

    [HideInInspector]
    public List<User> myUsersList;
    [HideInInspector]
    public User myActiveUser;
    [HideInInspector]
    public Documents documents;

    public void LoadFromJson()
    {
        string json = File.ReadAllText(jsonPath); //modifier pour mettre un persistant datapath
        UsersList usersList = JsonUtility.FromJson<UsersList>(json);

        myUsersList = usersList.users;

        if (canvasManager.idInputField.text != "" && canvasManager.pseudoInputField.text == "")
        {
            myActiveUser = FindUserById(canvasManager.idInputField.text);
        }
        else if (canvasManager.idInputField.text == "" && canvasManager.pseudoInputField.text != "")
        {
            myActiveUser = FindUserByPseudo(canvasManager.pseudoInputField.text);
        }
        else
        {
            Debug.Log("Aucun champ rempli");
        }

        isNew = false;
        canvasManager.UIFillingUser(myActiveUser);
    }
    public User FindUserById(string userId)
    {
        return myUsersList.Find(user => user.id == userId);
    }
    public User FindUserByPseudo(string userPseudo)
    {
        return myUsersList.Find(user => user.pseudo == userPseudo);
    }

    public void CreateNewUser()
    {
        isNew = true;
        //checker si l'utilisateur existe avant de lancer
        myActiveUser = null;
        canvasManager.ClearInputField();
        canvasManager.documentsPanel.SetActive(true);
        User newUser = new User();

        newUser.id = canvasManager.idInputField.text;
        newUser.pseudo = canvasManager.pseudoInputField.text;

        newUser.level = 0;
        newUser.lifepoints = 3;
        newUser.warning_And_Sanctions = "";
        newUser.banned = false;

        myActiveUser = newUser;
    }

    public void SaveIntoJson()
    {
        string json = File.ReadAllText(jsonPath); //modifier pour mettre un persistant datapath
        UsersList usersList = JsonUtility.FromJson<UsersList>(json);
        myUsersList = usersList.users;

        myActiveUser.documents = canvasManager.ReturnDocumentsInfos(myActiveUser);
        Debug.Log(myActiveUser.documents.AR);


        User result = FindUserById(myActiveUser.id);
        if (result == null)
        {
            myUsersList.Add(myActiveUser);
        }
        else
        {
            result.id = myActiveUser.id;
            result.pseudo = myActiveUser.pseudo;
        }
        File.WriteAllText(jsonPath, JsonUtility.ToJson(myActiveUser, true));
        canvasManager.OpenCloseDocPanel();
    }
}
