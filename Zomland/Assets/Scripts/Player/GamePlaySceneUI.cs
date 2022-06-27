using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GamePlaySceneUI : MonoBehaviour
{
    [Header("Animator")]
    public Animator coinAmountUIAnimator;
    public Animator chestAnimator;
    public Animator bottleAnimator;

    int UILayer;

    private void Start()
    {
        UILayer = LayerMask.NameToLayer("Bottle");
    }
 
    private void Update()
    {
        if(IsPointerOverUIElement())
        {
             bottleAnimator.SetTrigger("Shake");
        }
    }

    public void ItemAnimation(string type)
    {
        if(type =="Coin")
        {
            coinAmountUIAnimator.SetTrigger("Shake");
        }
        else if(type =="Food")
        {
            chestAnimator.SetTrigger("Shake");
        }
        
    }

   
    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }
 
 
    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }

 
    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
