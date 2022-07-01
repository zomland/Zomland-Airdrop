using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientGame : Singleton<ClientGame>
{
    public string IDCurrentZombie;

    void Start()
    {
        IDCurrentZombie = "";
    }
}
