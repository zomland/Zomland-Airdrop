using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FirebaseWebGL.Scripts.FirebaseBridge;
using UnityEngine;

public static class ClientAPI
{
    public static void SignInWithGoogle(string callerName, Action<string> callback,
        Action<string> fallback, Action<string> additionalCallback)
    {
        FirebaseAuth.SignInWithGoogle(callerName, callback.Method.Name,
            fallback.Method.Name, additionalCallback.Method.Name);
    }

    public static void OnAuthStateChanged(string callerName, Action<string> callback, Action<string> fallback)
        => FirebaseAuth.OnAuthStateChanged(callerName, callback.Method.Name, fallback.Method.Name);

    public static void SignOut(string callerName, Action<string> callback, Action<string> fallback)
        => FirebaseAuth.SignOut(callerName, callback.Method.Name, fallback.Method.Name);

    /// <summary>
    /// Get data in a specific path location on firebase database
    /// </summary>
    /// <param name="path"> the path location </param>
    /// <param name="callName"> the unity game object name in the scene to callback </param>
    /// <param name="callback"> the successfully callback function (the param of callback is json of type ClientUser</param>
    /// <param name="fallback"> the fail callback function (the param of fallback is json of type FirebaseError </param>
    public static void GetJson(string path, string callName, Action<string> callback, Action<string> fallback)
        => FirebaseDatabase.GetJSON(path, callName, callback.Method.Name, fallback.Method.Name);

    /// <summary>
    /// Set data in the specific path location
    /// </summary>
    /// <param name="path"></param>
    /// <param name="value"></param>
    /// <param name="callerName"></param>
    /// <param name="callback"></param>
    /// <param name="fallback"></param>
    public static void PostJson(string path, string value, string callerName, Action<string> callback,
        Action<string> fallback)
        => FirebaseDatabase.PostJSON(path, value, callerName, callback.Method.Name, fallback.Method.Name);

    /// <summary>
    /// Update data in the specific path location
    /// </summary>
    /// <param name="path"></param>
    /// <param name="value"></param>
    /// <param name="callerName"></param>
    /// <param name="callback"></param>
    /// <param name="fallback"></param>
    public static void UpdateJson(string path, string value, string callerName, Action<string> callback,
        Action<string> fallback)
        => FirebaseDatabase.UpdateJSON(path, value, callerName, callback.Method.Name, fallback.Method.Name);

    public static void UploadFile(string path, string data, string callerName, Action<string> callback,
        Action<string> fallback)
        => FirebaseStorage.UploadFile(path, Convert.ToBase64String(Encoding.ASCII.GetBytes(data)), callerName, callback.Method.Name, fallback.Method.Name);

    public static void DownloadFile(string path, string callerName, Action<string> callback, Action<string> fallback)
        => FirebaseStorage.DownloadFile(path, callerName, callback.Method.Name, fallback.Method.Name);

    public static void ListenForValueChanged(string path, string callerName, Action<string> callback, Action<string> fallback)
        => FirebaseDatabase.ListenForValueChanged(path, callerName, callback.Method.Name, fallback.Method.Name);

    public static void StopListenForValueChanged(string path, string callerName, Action<string> callback, Action<string> fallback)
        => FirebaseDatabase.StopListeningForValueChanged(path, callerName, callback.Method.Name, fallback.Method.Name);
}
