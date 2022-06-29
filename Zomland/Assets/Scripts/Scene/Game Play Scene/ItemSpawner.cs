using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Time")]
    public float timeSpawnCoin;
    public float timeSpawnFood;

    [Header("Spawner")]
    public GameObject coinSpawner;
    public GameObject foodSpawner;

    [Header("Item")]
    public CoinController coin;
    public List<FoodController> listFood ;

    bool canSpawn;
    float countTime;
    int indexCoin;
    int indexFood;
    bool spawnFood;
    bool spawnCoin;

    void Start()
    {
        canSpawn = false;
        countTime =0;
        indexCoin = 0;
        indexFood =0;
        spawnFood = true;
        spawnCoin = true;
    }

    void Update()
    {
        if(GetComponent<GameplaySceneController>().isPlaying == false) return;
        countTime += Time.deltaTime;
        Spawn();
    }

    public void ChangeStatusSpawn(bool status)
    {
        canSpawn = status;
    }

    private void Spawn()
    {
        if(!canSpawn) return;
        if(countTime >= timeSpawnFood && spawnFood == true)
        {
            int rnd;
            if(indexFood == 2|| indexFood == 4)
            {
                rnd = Random.Range(0,2);
            }
            else
            {
                rnd = Random.Range(2,4);
            }
            Instantiate(listFood[rnd],foodSpawner.transform.GetChild(indexFood));
            indexFood ++;
            if(indexFood == foodSpawner.transform.childCount)
            {
                indexFood = 0;
            }
            spawnFood = false;
            spawnCoin = true;
        }
        else if(countTime  >= timeSpawnCoin && spawnCoin == true)
        {
            Instantiate(coin,coinSpawner.transform.GetChild(indexCoin));
            indexCoin ++;
            if(indexCoin == coinSpawner.transform.childCount)
            {
                indexCoin = 0;
            }
            countTime = 0;
            spawnCoin = false;
            spawnFood = true;
        }
    }
}
