using System;
using UnityEngine;
using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using Newtonsoft.Json;

public class AuthHandler : MonoBehaviour
{
    public event Action<FirebaseUser> OnSignInSuccess;
    public event Action<FirebaseError> OnSignInFailed;

    public event Action OnSignOutSuccess;
    public event Action OnSignOutFail;
    
    public FirebaseUser AuthUser { get; set; }
    
    private ClientUser _clientUser;

    public ClientUser ClientUser => _clientUser;

    private void Start()
    {
        _clientUser = new ClientUser();
    }

    public void OnAuthStateChanged()
        => FirebaseAuth.OnAuthStateChanged(gameObject.name, "OnUserSignIn", "OnUserSignOut");

    public void CreateUserWithEmailAndPassword(string email, string password) =>
        FirebaseAuth.CreateUserWithEmailAndPassword(email, password, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void SignInWithEmailAndPassword(string email, string password) =>
        FirebaseAuth.SignInWithEmailAndPassword(email, password, gameObject.name, "SignInSuccess", "SignInFailed");
        
    public void SignInWithGoogle() =>
        FirebaseAuth.SignInWithGoogle(gameObject.name, "SignInSuccess", "SignInFailed", "TestSignIn");
        
    public void SignInWithFacebook() =>
        FirebaseAuth.SignInWithFacebook(gameObject.name, "SignInSuccess", "SignInFailed");

    public void SignOut() => FirebaseAuth.SignOut(gameObject.name, "OnUserSignOut", "OnUserSignOut");

    public void SignInSuccess(string user)
    {
        // do something
    }

    private void OnUserSignIn(string user)
    {
        try
        {
            var parsedUser = StringSerializationAPI.Deserialize(typeof(FirebaseUser), user) as FirebaseUser;
            AuthUser = parsedUser;
            _clientUser.uid = AuthUser.uid;
            OnSignInSuccess?.Invoke(parsedUser);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("Error: " + e.Message);
            _clientUser = new ClientUser();
        }
    }

    public void TestSignIn(string additional)
    {
        try
        {
            var parsedInfo = JsonConvert.DeserializeObject<FirebaseAdditionalUserInfo>(additional);
            _clientUser.isFirstTime = parsedInfo.isNewUser;
            Console.WriteLine("Test Info " + parsedInfo);
        }
        catch (Exception e)
        {
            Console.WriteLine("Test Signin Error" + e.Message);
            throw;
        }
    }

    public void OnUserSignOut(string error)
    {
        
    }
}
