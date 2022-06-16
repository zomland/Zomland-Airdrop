using System;
using Base.Pattern;
using Cysharp.Threading.Tasks;
using FirebaseWebGL.Scripts.Objects;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class GameMainState : GameState
{
    [SerializeField] private AuthHandler authHandler;
    [SerializeField] private DatabaseHandler databaseHandler;

    private MainScene _mainSceneController;
    public override void EnterStateBehaviour(float dt, GameState fromState)
    {
        if (fromState is GameLoginState state)
        {
            LoadSceneAsync("Game Play", state).Forget();

            RegisterListener();
        }
    }

    public override void UpdateBehaviour(float dt)
    {
        return;
    }

    public override void ExitStateBehaviour(float dt, GameState toState)
    {
        RemoveListener();
    }

    private async UniTask LoadSceneAsync(string sceneName, GameLoginState loginState)
    {
        var clientUser = ClientData.Instance.clientUser;
        if (clientUser.isFirstTime)
        {
            ClientUser save = new ClientUser { address = clientUser.address, isFirstTime = false, uid = clientUser.uid };
            // databaseHandler.PostJson(clientUser.uid, JsonConvert.SerializeObject(save));

            ClientAPI.PostJson("User/" + clientUser.uid, JsonConvert.SerializeObject(save),
                gameObject.name, OnPostDataCallback, OnError);
        }
        else
        {
            ClientAPI.GetJson("User/" + clientUser.uid, gameObject.name, OnGetDataUserCallback, OnError);
        }

        ClientAPI.GetJson("Assets", gameObject.name, OnGetDataSpritesCallback, OnError);
        ClientAPI.ListenForValueChanged("Assets", gameObject.name, OnListenForValueChangeCallback, OnError);

        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene s = SceneManager.GetSceneByBuildIndex(2);
        GameObject[] a = s.GetRootGameObjects();

        for (int i = 0; i < a.Length; i++)
        {
            _mainSceneController = a[i].GetComponent<MainScene>();
            if (_mainSceneController) break;
        }
    }

    private void RegisterListener()
    {
        // databaseHandler.OnUpdatedSuccess += OnUpdateCompleted;
        // databaseHandler.OnGetDataCallback += OnGetDataCallback;
        // databaseHandler.OnErrorHandle += OnError;
        // databaseHandler.OnPostDataCallback += OnPostDataCallback;
        // databaseHandler.OnDataChangedCallback += OnDataChangedCallback;

        _mainSceneController.UpdateData += UpdateData;
        _mainSceneController.Logout += LogOutHandler;
    }

    private void RemoveListener()
    {
        // databaseHandler.OnUpdatedSuccess -= OnUpdateCompleted;
        // databaseHandler.OnGetDataCallback -= OnGetDataCallback;
        // databaseHandler.OnErrorHandle -= OnError;
        // databaseHandler.OnPostDataCallback -= OnPostDataCallback;
        // databaseHandler.OnDataChangedCallback -= OnDataChangedCallback;
        
        _mainSceneController.UpdateData -= UpdateData;
        _mainSceneController.Logout -= LogOutHandler;
    }

    #region Server-side

    private void OnUpdateCompleted(string data)
    {
        
    }
    
    private void OnGetDataUserCallback(string data)
    {
        Console.WriteLine("OnGetDataCallback: " + data);
        try
        {
            var user = JsonConvert.DeserializeObject<ClientUser>(data);
            var authClientUser = authHandler.ClientUser;
            if (user != null)
            {
                // authClientUser.address = user.address;
                // authClientUser.isFirstTime = false;

               ClientData.Instance.clientUser = user;
            }
        }
        catch (JsonSerializationException e)
        {
            Console.WriteLine("Json Convert Exception: " + e.Message);
            throw;
        }
    }

    private void OnGetDataSpritesCallback(string data)
    {
        Console.WriteLine("OnGetDataSpritesCallback" + data);
        try
        {
            var assets = JsonConvert.DeserializeObject<ClientAsset>(data);
            ClientData.Instance.clientAsset = assets;
        }
        catch (JsonSerializationException e)
        {
            Console.WriteLine("Json convert exception : " + e.Message);
            throw;
        }
    }

    private void OnListenForValueChangeCallback(string data)
    {
        Console.WriteLine("OnListenForValueChangeCallback" + data);
        try
        {
            var assets = JsonConvert.DeserializeObject<ClientAsset>(data);
            ClientData.Instance.clientAsset = assets;
            _mainSceneController.Display(data);
        }
        catch(JsonSerializationException e)
        {
            Console.WriteLine("Json convert exception : " + e.Message);
            throw;
        }
    }

    private void OnError(string err)
    {
        
    }

    private void OnPostDataCallback(string data)
    {
        Console.WriteLine("OnPostDataCallback " + data);
    }

    private void OnDataChangedCallback(string data)
    {
        
    }

    #endregion

    #region Client-side

    private void UpdateData(string path, string value)
    {
        databaseHandler.UpdateJson(path, value);
    }

    private void LogOutHandler()
    {
        authHandler.SignOut();
    }

    #endregion
}

