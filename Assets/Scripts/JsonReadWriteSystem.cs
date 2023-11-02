using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(PannelsFiller))]
public class JsonReadWriteSystem : MonoBehaviour
{
    public PannelsFiller pannelFiller;
    public NewPlayerCreator newPlayerCreator;

    public string jsonPath = "D:/Unity Projects/ProjetSucces/Assets/Scripts/JSON_Files/Users.json"; //modifier pour mettre un persistant path

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

        if (pannelFiller.idInputField.text != "")
        {
            myActiveUser = FindUserById(pannelFiller.idInputField.text);
        }
        else
        {
            Debug.Log("Aucun champ rempli");
        }

        pannelFiller.UIFillingUser(myActiveUser);
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
        Si l'usager n'existe pas existe : crée un nouvel usager  
        sinon : le mets à jour avec les nouvelles données,
        Puis, écris l'ensemble du contenu de ma liste d'usagers dans le fichier json
         */

        User result = FindUserById(myActiveUser.id);
        if (result == null)
        {
            myActiveUser = newPlayerCreator.newPlayer();
            myUsersList.Add(myActiveUser);
            Debug.Log("J'ai mis à jour un joueur");
        }
        else
        {
            Debug.Log("J'essaye de mettre à jour un joueur");
        }
        File.WriteAllText(jsonPath, JsonUtility.ToJson(myUsersList, true));
    }
}
