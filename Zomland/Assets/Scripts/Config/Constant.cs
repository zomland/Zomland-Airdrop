using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    public static string DatabaseUserPath = "User/";
    public static string DatabaseWalletPath = "Wallet/";
    public static string ClientUid;
    public static string WalletAddress;
}

public enum ServerMessage
{
    LogOutMessage = 0,
    OnGetData, OnPostData, OnDataChanged,
    UpdateData
}

public enum LoginType {Google = 0, Facebook, Apple}