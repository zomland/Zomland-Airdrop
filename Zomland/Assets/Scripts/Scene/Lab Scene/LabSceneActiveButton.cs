using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LabSceneActiveButton : MonoBehaviour
{
    public Button button;
    public LabItemType labItemType;
    // Start is called before the first frame update
    void OnEnable()
    {
        button.onClick.AddListener(ActiveZombie);
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(ActiveZombie);
    }
    private void ActiveZombie()
    {
        FindObjectOfType<LabSceneUIController>().OpenPopup(labItemType);
    }
}
