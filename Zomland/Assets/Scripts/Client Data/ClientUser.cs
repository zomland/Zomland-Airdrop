using System;
using FirebaseWebGL.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ClientUser
{
    public string uid;
    public bool isFirstTime;
    public string address;
    public int slotLabScene;
    public int slotChestScene;
    public int amountCoin;

    public List<LabItem> listItemLab ;
    public List<ChestItem> listItemChest ;

    public ClientUser()
    {
        uid = String.Empty;
        isFirstTime = false;
        address = String.Empty;
        slotChestScene= 12;
        slotLabScene = 9;
        amountCoin = 0;

        listItemLab =  new List<LabItem>();
        listItemChest = new List<ChestItem>();
    }

    public ClientUser(FirebaseUser firebaseUser)
    {
        uid = firebaseUser.uid;
        isFirstTime = false;
        address = String.Empty;
    }
}

[System.Serializable]
public class LabItem 
{
    public string name;
    public int amount;

    LabItem(){}
}

[System.Serializable]
public class ChestItem 
{
    public string name;
    public int amount;

    ChestItem(){}
}






