using System;
using Base;
using FirebaseWebGL.Scripts.FirebaseBridge;

public class MainScene : BaseMono
{
    public event Action<string, string> UpdateData;
    public event Action Logout;

    public void UpdateDataClick(string path, string value)
    {
        UpdateData?.Invoke(path, value);
    }

    public void Display(string data)
    {
        FindObjectOfType<GameController>().DisplayUI();
    }

    public void LogOut()
    {
        //Messenger.RaiseMessage(ServerMessage.LogOutMessage);
        
        Logout?.Invoke();
    }
}
