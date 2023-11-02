using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(PannelsFiller))]
public class JsonReadWriteSystem : MonoBehaviour
{
    public PannelsFiller canvasManager;

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

        if (canvasManager.idInputField.text != "")
        {
            myActiveUser = FindUserById(canvasManager.idInputField.text);
        }
        else
        {
            Debug.Log("Aucun champ rempli");
        }

        canvasManager.UIFillingUser(myActiveUser);
    }
    public User FindUserById(string userId)
    {
        return myUsersList.Find(user => user.id == userId);
    }

    public void SaveIntoJson()
    {
        string json = File.ReadAllText(jsonPath); //modifier pour mettre un persistant datapath
        UsersList usersList = JsonUtility.FromJson<UsersList>(json);
        myUsersList = usersList.users;



        /*
        Cherche l'usager dans la liste Json. 
        Si l'usager existe : le mets à jour avec les nouvelles données, 
        sinon : crée un nouvel usager
        Puis, écris l'ensemble du contenu de ma liste d'usagers dans le fichier json
         */

        User result = FindUserById(myActiveUser.id);
        if (result.id == myActiveUser.id)
        {

        }
        else
        {
            myUsersList.Add(myActiveUser);
        }
        File.WriteAllText(jsonPath, JsonUtility.ToJson(myUsersList, true));
        canvasManager.OpenCloseDocPanel();
    }
}
