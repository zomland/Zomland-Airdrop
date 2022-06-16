using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Zomland/Zombie Config")]
public class ZombieConfig : ScriptableObject
{
    [SerializeField] float speed;

    public float GetSpeed()
    {
        if (speed <= 0) return 0;
        return speed;
    }
}
