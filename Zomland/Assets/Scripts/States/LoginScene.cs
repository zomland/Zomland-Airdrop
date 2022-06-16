using System;
using System.IO;
using System.Text;
using Base;
using Base.MessageSystem;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityGLTF;

public class LoginScene : BaseMono
{
    [SerializeField] private TMP_InputField emailField;
    [SerializeField] private TMP_InputField passwordField;

    public event Action<LoginType, string, string> OnLoginClick;
    public event Action<string, string> OnSignUpClick;
    public void SignInClick(int type)
    {
        switch ((LoginType) type)
        {
            case LoginType.Facebook:
            case LoginType.Google:
                //Messenger.RaiseMessage(ServerMessage.LoginMessage, (LoginType) type, String.Empty, String.Empty);
                OnLoginClick?.Invoke((LoginType) type, String.Empty, String.Empty);
                break;
            case LoginType.Apple:
                //Messenger.RaiseMessage(ServerMessage.LoginMessage, (LoginType) type, emailField.text, passwordField.text);
                OnLoginClick?.Invoke((LoginType)type, emailField.text, passwordField.text);
                break;
        }
    }

    public void SignUpClick()
    {
        //Messenger.RaiseMessage(ServerMessage.SignUpMessage, emailField.text, passwordField.text);
        OnSignUpClick?.Invoke(emailField.text, passwordField.text);
    }

    public void SignOutClick()
    {
        
    }

    public void ExportGltf(GameObject target)
    {
        GLTFSceneExporter exporter = new GLTFSceneExporter(new[] {target.transform}, new ExportOptions());

        var appPath = Path.Combine(Application.persistentDataPath, "TestObject");
        var fileName = "test";
        exporter.SaveGLTFandBin(appPath, fileName);
    }
}
