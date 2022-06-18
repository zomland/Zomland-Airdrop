using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class ClientAsset
{
    public List<ClientSprites> Sprites = new List<ClientSprites>();

    public ClientAsset()
    {
        for (int i = 0; i < 5; i++)
        {
            ClientSprites tmp =  new ClientSprites();
            Sprites.Add(tmp);
        }
    }
}

[System.Serializable]
public class ClientSprites
{
    public string path;
    public string tag;

    public ClientSprites()
    {
        path = String.Empty;
        tag = String.Empty;
    }
}

