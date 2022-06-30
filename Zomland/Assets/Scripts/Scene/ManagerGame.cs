using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ChangeSceneController
{
    public static void LoadScene(string sceneTo)
    {
        SceneManager.LoadScene(sceneTo);
    }
}

public static class RandomGame
{
    public static string  RandomString()
    {
        string store = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string myString ="";
        for(int i = 0;i<8;i++)
        {
            myString += store[Random.Range(0,store.Length)];
        }
        return myString;
    }
    
    public static int RandomPercentage()
    {
        float[] percent = {0.00005f, 0.0005f, 0.005f, 0.03f, 0.05f , 0.1f, 0.81445f};
        float random =  Random.value;

        if(percent[0] >= random) return 0;
        if(percent[percent.Length-1] <= random) return percent.Length-1;

        for(int i = 0;i< percent.Length -1 ;i++)
        {
            if(percent[i] <=  random && percent[i+1] > random) 
            {
                return i+1;
            }
        }
        return percent.Length-1;
    } 
}
