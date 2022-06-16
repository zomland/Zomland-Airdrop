using System.Collections;
using System.Collections.Generic;
using Base.Pattern;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadingState : GameState
{
    private AsyncOperation _loadScene;
    public override void EnterStateBehaviour(float dt, GameState fromState)
    {
        LoadSceneAsync("Login Scene").Forget();
    }

    public override void UpdateBehaviour(float dt)
    {
        return;
    }

    public override void CheckExitTransition()
    {
        if (ManagerStateParam.LoadingCompleted) GameStateController.EnqueueTransition<GameLoginState>();
    }

    public override void ExitStateBehaviour(float dt, GameState toState)
    {
        ManagerStateParam.LoadingCompleted = false;
        _loadScene = null;
    }

    private async UniTask LoadSceneAsync(string sceneName)
    {
        _loadScene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => _loadScene.isDone);
        ManagerStateParam.LoadingCompleted = true;
    }
}
