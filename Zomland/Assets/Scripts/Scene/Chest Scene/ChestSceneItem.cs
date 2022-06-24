using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChestItemType
{
    Apple,
    Chicken ,
    Meat,
    Energy,
}
public class ChestSceneItem : MonoBehaviour
{
    public Button button;

    ChestItemType type;

    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        FindObjectOfType<ChestSceneController>().OnClickItem(type);
    }

    public void SetType( string name)
    {
        switch(name)
        {
            case "Apple" :
                type = ChestItemType.Apple;
                break;
            case "Meat" :
                type = ChestItemType.Meat;
                break;
            case "Chicken" :
                type = ChestItemType.Chicken;
                break;
            case "Energy" :
                type = ChestItemType.Energy;
                break;
        }
    }
}
