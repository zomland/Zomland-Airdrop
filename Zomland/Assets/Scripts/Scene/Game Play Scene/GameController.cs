// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Newtonsoft.Json;
// using System;
// using TMPro;

// public class GameController : MonoBehaviour
// {
//     public TextMeshProUGUI jsonSprites;
//     public TextMeshProUGUI jsonUser;
//     public TextMeshProUGUI inventoryText;
//     public TextMeshProUGUI labsText;
//     public TextMeshProUGUI marketPlaceText;

//     [Header("Zombie Prefab")]
//     [SerializeField] GameObject zom1; // default Zombie
//     [SerializeField] GameObject zom2;
//     [SerializeField] GameObject zom3;


//     private void Start()
//     {
//         //if (!ClientData.Instance.clientUser.isFirstTime)
//         //{
//         //    uiController.ChangeStatusFirstPlayUI(true);
//         //}
       
//     }

//     public void DisplayUI()
//     {
//         string assets = JsonConvert.SerializeObject(ClientData.Instance.clientAsset);
//         string user = JsonConvert.SerializeObject(ClientData.Instance.clientUser);
//         jsonSprites.text = assets;
//         jsonUser.text = user;
//         inventoryText.text = ClientData.Instance.clientAsset.Sprites[0].path;
//         labsText.text = ClientData.Instance.clientAsset.Sprites[5].tag;
//         marketPlaceText.text = ClientData.Instance.clientAsset.Sprites[5].path;
//     }

//     public void SetDataFromFirebaseToClient(string address)
//     {
//         ClientData.Instance.clientUser.address = address;
//             UpdateJson();
//     }

//     public void UpdateJson()
//     {
//         var clientUser = ClientData.Instance.clientUser;
//         ClientUser save = new ClientUser { address = clientUser.address, isFirstTime = false, uid = clientUser.uid };
        
//         ClientAPI.UpdateJson("User/" + clientUser.uid, JsonConvert.SerializeObject(save), 
//             gameObject.name, OnPostDataCallback, OnError);
//     }

//     private void OnError(string err)
//     {

//     }

//     private void OnPostDataCallback(string data)
//     {
//         Console.WriteLine("OnPostDataCallback " + data);
//     }

//     private void SpawnZombie(int type)
//     {
//         if (type == 0)
//         {
//             Instantiate(zom1);
//         }
//         else if (type == 1)
//         {
//             Instantiate(zom2);
//         }
//         else if (type == 2)
//         {
//             Instantiate(zom2);
//         }
//         else if (type == 3)
//         {
//             Instantiate(zom3);
//         }
//     }
// }
