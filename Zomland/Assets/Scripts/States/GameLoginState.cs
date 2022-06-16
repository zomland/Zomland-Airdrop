using System;
using System.Runtime.CompilerServices;
using Base.MessageSystem;
using Base.Pattern;
using Cysharp.Threading.Tasks;
using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.Objects;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoginState : GameState
{
    [SerializeField] private AuthHandler authHandler;

    private LoginScene _loginSceneController;
    
    public FirebaseUser AuthUser { get; set; }
    
    public override void EnterStateBehaviour(float dt, GameState fromState)
    {
        // if (Application.platform != RuntimePlatform.WebGLPlayer)
        // {
        //     return;
        // }
        
        Scene loginScene = SceneManager.GetSceneAt(1);
        GameObject[] roots = loginScene.GetRootGameObjects();
        for (int i = 0; i < roots.Length; i++)
        {
            _loginSceneController = roots[i].GetComponent<LoginScene>();
            if (_loginSceneController) break;
        }
        
        RegisterListener();
        
        ClientAPI.OnAuthStateChanged(gameObject.name, OnAuthStateSuccess, OnAuthStateFailed);
    }

    public override void UpdateBehaviour(float dt)
    {
        return;
    }

    public override void CheckExitTransition()
    {
        if (ManagerStateParam.LoginCompleted) GameStateController.EnqueueTransition<GameMainState>();
    }

    public override void ExitStateBehaviour(float dt, GameState toState)
    {
        RemoveListener();
        
        SceneManager.UnloadSceneAsync("Login Scene").ToUniTask().Forget();

        ManagerStateParam.LoginCompleted = false;
    }

    private void RegisterListener()
    {
        _loginSceneController.OnLoginClick += OnLoginMessage;
        _loginSceneController.OnSignUpClick += OnSignUpMessage;
    }

    private void RemoveListener()
    {
        _loginSceneController.OnLoginClick -= OnLoginMessage;
        _loginSceneController.OnSignUpClick -= OnSignUpMessage;
    }

    private void OnLoginMessage(LoginType type, string email, string password)
    {
        switch (type)
        {
            case LoginType.Apple:
                //authHandler.SignInWithEmailAndPassword(email, password);
                break;
            case LoginType.Google:
                //authHandler.SignInWithGoogle();
                ClientAPI.SignInWithGoogle(gameObject.name, OnSignInSuccess, OnAuthStateFailed, OnAdditionalCallback);
                break;
            case LoginType.Facebook:
                //authHandler.SignInWithFacebook();
                break;
        }
    }

    private void OnSignUpMessage(string email, string password)
    {
        //authHandler.CreateUserWithEmailAndPassword(email, password);
    }

    private void OnAuthStateSuccess(string user)
    {
        if (GameStateController.CurrentState is GameLoginState)
        {
            try
            {
                var parsedUser = StringSerializationAPI.Deserialize(typeof(FirebaseUser), user) as FirebaseUser;
                AuthUser = parsedUser;
                ClientUser clientUser = ClientData.Instance.clientUser;
                clientUser.uid = AuthUser.uid;
                //Constant.ClientUid = AuthUser.uid;
                ManagerStateParam.LoginCompleted = true;
                Console.WriteLine($"Login Success: Email-{AuthUser?.email} Id-{AuthUser?.uid}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }

    private void OnAuthStateFailed(string error)
    {
        if (GameStateController.CurrentState is GameLoginState)
        {
            Console.WriteLine("Error: " + error);
        }
    }

    private void OnSignInSuccess(string user)
    {
        
    }

    private void OnAdditionalCallback(string additional)
    {
        try
        {
            var parsedInfo = JsonConvert.DeserializeObject<FirebaseAdditionalUserInfo>(additional);
            ClientUser clientUser = ClientData.Instance.clientUser;
            clientUser.isFirstTime = parsedInfo.isNewUser;
            Console.WriteLine("Test Info " + parsedInfo);
        }
        catch (Exception e)
        {
            Console.WriteLine("Test Signin Error" + e.Message);
            throw;
        }
    }
}
