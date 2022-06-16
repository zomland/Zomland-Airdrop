using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    UIController uiController;

    private void Start()
    {
        uiController = FindObjectOfType<UIController>();        
    }

    /// <summary>
    /// active and exit setting Pop Up
    /// </summary>
    public void OnClickActiveSettingPopUp()
    {
        uiController.ChangeStatusSettingPopUp(true);
    }

    public void OnClickExitSettingPopUp()
    {
        uiController.ChangeStatusSettingPopUp(false);
    }

    /// <summary>
    /// active and exit setting Pop Up
    /// </summary>
    public void OnClickActiveCoinPopUp()
    {
        uiController.ChangeStatusCoinPopUp(true);
    }

    public void OnClickExitCoinPopUp()
    {
        uiController.ChangeStatusCoinPopUp(false);
    }

    /// <summary>
    /// active and exit zombie stats Pop Up
    /// </summary>
    public void OnClickActiveZombieStatsPopUp()
    {
        uiController.ChangeStatusZombieStatPopUp(true);
    }

    public void OnClickExitZombieStatsPopUp()
    {
        uiController.ChangeStatusZombieStatPopUp(false);
    }
}
