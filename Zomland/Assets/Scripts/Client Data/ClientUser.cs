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

    public ClientUser(DefaultSprites defaultSprites)
    {
        uid = String.Empty;
        isFirstTime = false;
        address = String.Empty;
        slotChestScene= 12;
        slotLabScene = 9;
        amountCoin = 0;

        listItemLab =  new List<LabItem>();
        listItemChest = new List<ChestItem>();
        InitItemLabAndChest(defaultSprites);

        //Fake data
        TestLabItem();
        TestChestItem();
    }

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

    private void InitItemLabAndChest(DefaultSprites defaultSprites)
    {
        foreach(var child in defaultSprites.listSpritesLab)
        {
            var tmp =  new LabItem(child.name , 0);
            listItemLab.Add(tmp);
        }

        foreach(var child in defaultSprites.listSpriteChest)
        {
            var tmp =  new ChestItem(child.name , 0);
            listItemChest.Add(tmp);
        }
    }

    void TestLabItem()
    {
        foreach(var child in listItemLab)
        {
            if(child.name == "Bottle Icon")
            {
                child.amount += 2;
            }
            else if(child.name =="Zombie Icon")
            {
                child.amount +=3;
            }
        }
    }
    void TestChestItem()
    {
        foreach(var child in listItemChest)
        {
            child.amount   += 2 ;
        }
    }
}

[System.Serializable]
public class LabItem 
{
    public string name;
    public int amount;

    public LabItem(){}

    public LabItem(string _name , int _amount){
        name = _name;
        amount = _amount;
    }
}

[System.Serializable]
public class ChestItem 
{
    public string name;
    public int amount;

    public ChestItem(){}
    public ChestItem(string _name ,  int _amount)
    {
        name= _name ;
        amount = _amount;
    }
}






