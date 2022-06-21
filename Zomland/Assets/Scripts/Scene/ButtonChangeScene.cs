using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    [StringValue("Manager Scene")] ManagerScene = 0 ,
    [StringValue("Login Scene")] LoginScene  ,
    [StringValue("Loading Scene")] LoadingScene ,
    [StringValue("GamePlay Scene")] GamePlayScene  ,
    [StringValue("Chest Scene")] ChestScene  ,
    [StringValue("Lab Scene")] LabScene 
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
