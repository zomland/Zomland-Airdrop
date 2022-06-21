using System;
using Base;

public class ClientData : Singleton<ClientData>
{
    public ClientUser clientUser;
    public ClientAsset clientAsset;

    private void Awake()
    {
        clientUser = new ClientUser();
        clientAsset = new ClientAsset();
    }
}
