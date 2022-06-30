using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ClientZombie
{
    public string ID;
    public ZombieRare zombieRare;

    public ClientZombie()
    {
        ID = "#" + RandomGame.RandomString();
        RandomRareZombie();
    }

    private void RandomRareZombie()
    {
        int rnd =  RandomGame.RandomPercentage();
        switch(rnd)
        {
            case 0 : 
                zombieRare =  ZombieRare.Unique;
                break;
            case 1 : 
                zombieRare =  ZombieRare.Mythical;
                break;
            case 2 : 
                zombieRare =  ZombieRare.Legendary;
                break;
            case 3 : 
                zombieRare =  ZombieRare.Epic;
                break;
            case 4 : 
                zombieRare =  ZombieRare.Rare;
                break;
            case 5 : 
                zombieRare =  ZombieRare.Uncommon;
                break;
            case 6 : 
                zombieRare =  ZombieRare.Common;
                break;    
        }
    }

    
}

public enum ZombieRare
{
    Common ,
    Uncommon ,
    Rare ,
    Epic ,
    Legendary,
    Mythical,
    Unique
}
