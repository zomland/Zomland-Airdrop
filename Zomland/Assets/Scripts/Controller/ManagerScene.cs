using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class ManagerScene : Singleton<ManagerScene>
{
    public ClientData clientData;
}

/// <summary>
/// Store boolean value for GameStateMachine
/// </summary>
public static class ManagerStateParam
{
    public static bool LoadingCompleted = false;
    public static bool LoginCompleted = false;
}
