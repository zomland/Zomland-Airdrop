using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DefaultSprite")]
public class DefaultSprites : ScriptableObject
{
    public Sprite spriteBottle;
    public List<Sprites> listSpritesLab = new List<Sprites>();
    public List<Sprites> listSpriteChest = new List<Sprites>();
}


[System.Serializable]
public class Sprites{
    public string name;
    public Sprite sprite; 
    public Sprites(){}
}
