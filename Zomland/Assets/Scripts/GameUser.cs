using System;
using FirebaseWebGL.Scripts.Objects;

/// <summary>
/// Client User stores data of user in client
/// </summary>
[System.Serializable]
public class ClientUser
{
    public string uid;
    public bool isFirstTime;
    public string address;

    public ClientUser()
    {
        uid = String.Empty;
        isFirstTime = false;
        address = String.Empty;
    }

    public ClientUser(FirebaseUser firebaseUser)
    {
        uid = firebaseUser.uid;
        isFirstTime = false;
        address = String.Empty;
    }
}


/// <summary>
/// 
/// </summary>

[System.Serializable]
public class ClientAsset
{
    public ClientSprites[] Sprites;

    public ClientAsset()
    {
        for (int i = 0; i < Sprites.Length; i++)
        {
            Sprites[i] = new ClientSprites();
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






