using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
