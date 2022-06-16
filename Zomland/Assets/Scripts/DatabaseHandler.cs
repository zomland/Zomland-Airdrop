using System;
using Base;
using Base.MessageSystem;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using Newtonsoft.Json;

public class DatabaseHandler : BaseMono
{
    /// <summary>
    /// Event call when successfully update data on firebase
    /// </summary>
    public event Action<string> OnUpdatedSuccess;
    /// <summary>
    /// Event call when failed
    /// </summary>
    public event Action<FirebaseError> OnErrorHandle;
    
    /// <summary>
    /// Event fired when successfully get data on firebase
    /// </summary>
    public event Action<string> OnGetDataCallback;
    
    /// <summary>
    /// Event fired when successfully set data on firebase
    /// </summary>
    public event Action<string> OnPostDataCallback;
    
    /// <summary>
    /// Event fired when data is changed on firebase
    /// </summary>
    public event Action<string> OnDataChangedCallback;
    public void GetJson(string path)
        => FirebaseDatabase.GetJSON(path, gameObject.name, "OnGetData", "OnErrorHandler");
    public void PostJson(string path, string value)
        => FirebaseDatabase.PostJSON(path, value, gameObject.name, "OnPostCompleted", "OnPostFailed");

    public void PushJson(string path, string value)
        => FirebaseDatabase.PushJSON(path, value, gameObject.name, "OnPostCompleted", "OnPostFailed");

    public void UpdateJson(string path, string value)
        => FirebaseDatabase.UpdateJSON(path, value, gameObject.name, "OnUpdateCompleted", "OnErrorHandler");
    
    public void DeleteJson(string path, string value) =>
        FirebaseDatabase.DeleteJSON(path, value, "DisplayInfo", "DisplayErrorObject");
    
    public void ListenForValueChanged(string path) =>
        FirebaseDatabase.ListenForValueChanged(path, gameObject.name, "OnDataChanged", "OnErrorHandler");

    public void StopListeningForValueChanged(string path) => 
        FirebaseDatabase.StopListeningForValueChanged(path, gameObject.name, "OnDataChanged", "OnErrorHandler");

    public void OnGetData(string data)
    {
        Console.WriteLine("DataBaseHandler OnGetData: " + data);

        OnGetDataCallback?.Invoke(data);
    }

    public void OnErrorHandler(string error)
    {
        Console.WriteLine("DatabaseHandler Error: " + error);
        FirebaseError er = new FirebaseError {message = error};
        OnErrorHandle?.Invoke(er);
    }

    public void OnPostCompleted(string data)
    {
        Console.WriteLine(data);
        OnPostDataCallback?.Invoke(data);
    }

    public void OnPostFailed(string error)
    {
        Console.WriteLine(error);
        FirebaseError er = new FirebaseError {message = error};
        OnErrorHandle?.Invoke(er);
    }

    public void OnUpdateCompleted(string data)
    {
        Console.WriteLine(data);
        OnUpdatedSuccess?.Invoke(data);
    }

    public void OnDataChanged(string data)
    {
        Console.WriteLine(data);
        OnDataChangedCallback?.Invoke(data);
    }
}