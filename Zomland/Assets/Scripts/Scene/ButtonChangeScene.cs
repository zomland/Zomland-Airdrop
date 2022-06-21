using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    ManagerScene = 0 ,
     LoginScene  ,
     LoadingScene ,
    GamePlayScene  ,
    ChestScene  ,
    LabScene ,
    ConnectScene,
}
public class ButtonChangeScene : MonoBehaviour
{
    public Scenes fromScene;
    public Scenes toScene;
    
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickChangeScene);
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(OnClickChangeScene);
    }

    private void OnClickChangeScene()
    {
        if(fromScene == toScene) return;
        ChangeSceneController.LoadScene(toScene.ToString());
    }
}
