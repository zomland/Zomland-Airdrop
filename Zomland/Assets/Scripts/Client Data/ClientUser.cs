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

    //Item
    public List<LabItem> listItemLab ;
    public List<ChestItem> listItemChest ;

    //Zombie
    public List<ClientZombie> clientZombies;

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

        clientZombies = new List<ClientZombie>();

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

    private void InitItemLabAndChest(DefaultSprites defaultSprites)
    {
        foreach(var child in defaultSprites.listSpritesLab)
        {
            LabItem tmp ; 
            if(child.name == "Free Bottle")
            {
                tmp = new LabItem(child.name,1);
            }
            else
            {
                tmp =  new LabItem(child.name , 0);
            }
            
            listItemLab.Add(tmp);
        }

        foreach(var child in defaultSprites.listSpriteChest)
        {
            var tmp =  new ChestItem(child.name , 0);
            listItemChest.Add(tmp);
        }
    }

    public void ChangeAmountLabItem(string typeLab ,  int signal)
    {
        foreach(var child in listItemLab)
        {
            if(child.name == typeLab) 
            {
                if(signal == 0)
                {
                     child.amount -= 1;
                }
                else if(signal == 1)
                {
                     child.amount += 1;
                }
                return;
            }
        }
        return ;
    }

     public void ChangeAmountChestItem(string typechest ,  int signal)
    {
        foreach(var child in listItemChest)
        {
            if(child.name == typechest) 
            {
                if(signal == 0)
                {
                     child.amount -= 1;
                }
                else if(signal ==1)
                {
                     child.amount += 1;
                }
                return;
            }
        }
        return ;
    }

    public LabItem GetLabItem(string name)
    {
        foreach(var child in listItemLab)
        {
            if(child.name == name) return child;
        }
        return null;
    }

    public int GetAmountChestItem(string name)
    {
        foreach(var child in listItemChest)
        {
            if(child.name == name) return child.amount;
        }
        return 0;
    }

    public void CreateZombie(string typeCreate)
    {
        ClientZombie newZombie =  new ClientZombie(typeCreate);
        clientZombies.Add(newZombie);

        ChangeAmountLabItem("Zombie",1);
        if(typeCreate == "")
        {
            ChangeAmountLabItem("Bottle",0);
        }
        else
        {
            ChangeAmountLabItem("Free Bottle",0);
        }
        
        ClientGame.Instance.IDCurrentZombie = newZombie.ID;
    }

    public ClientZombie GetZombie(string ID)
    {
        foreach(var child in clientZombies)
        {
            if(child.ID == ID) return child;
        }
        return null;
    }


    void TestLabItem()
    {
        foreach(var child in listItemLab)
        {
            if(child.name == "Bottle")
            {
                child.amount += 3;
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








