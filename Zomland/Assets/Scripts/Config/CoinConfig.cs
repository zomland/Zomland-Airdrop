using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Zomland/Coin Config")]
public class CoinConfig : ScriptableObject
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float speedDrop;
    [SerializeField] int coin;
    [SerializeField] float timeDestroy;

    public GameObject GetCoinPrefab()
    {
        return coinPrefab;
    }
    public float GetSpeedDrop()
    {
        if (speedDrop <= 0) return 0;
        return speedDrop;
    }

    public int GetCoin()
    {
        if(coin <= 0) return 0;
        return coin;
    }

    public float GetTimeDestroy()
    {
        if(timeDestroy <= 0) return 0;
        return timeDestroy;
    }
}
