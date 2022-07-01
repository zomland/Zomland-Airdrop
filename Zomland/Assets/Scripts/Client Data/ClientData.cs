using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientData : Singleton<ClientData>
{
    public DefaultSprites defaultSprites;
    public ClientUser clientUser;
    public ClientAsset clientAsset;

    private void Start()
    {
        clientUser = new ClientUser(defaultSprites);
        clientAsset = new ClientAsset();
    }

    public Sprite GetSpriteLab(string name)
    {
        foreach(var child  in defaultSprites.listSpritesLab)
        {
            if(child.name == name) return child.sprite;
        }
        return null;
    }

    public Sprite GetSpriteChest(string name)
    {
        foreach(var child in defaultSprites.listSpriteChest)
        {
            if(child.name == name ) return child.sprite;
        }
        return null;
    }
}
