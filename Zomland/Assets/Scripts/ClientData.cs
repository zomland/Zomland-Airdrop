using System;
using Base;

public class ClientData : Singleton<ClientData>
{
    [NonSerialized] public ClientUser clientUser;
    [NonSerialized] public ClientAsset clientAsset;

    private void Start()
    {
        clientUser = new ClientUser();
        clientAsset = new ClientAsset();
    }
}
