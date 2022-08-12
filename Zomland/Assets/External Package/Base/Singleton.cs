// using System;
// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace Base
// {
//     /// <summary>
//     /// Inherit from this base class to create a singleton.
//     /// e.g. public class MyClassName : Singleton<MyClassName> {}
//     /// </summary>
//     public class Singleton<T> : BaseMono where T : BaseMono
//     {
//         // Check to see if we're about to be destroyed.
//         protected static bool m_ShuttingDown = false;

//         private static object m_Lock = new object();
//         private static T m_Instance;

//         /// <summary>
//         /// Access singleton instance through this propriety.
//         /// </summary>
//         public static T Instance
//         {
//             get
//             {
//                 if (m_ShuttingDown)
//                 {
//                     Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
//                                      "' already destroyed. Returning null.");
//                     return null;
//                 }

//                 lock (m_Lock)
//                 {
//                     if (m_Instance == null)
//                     {

//                          if (FindObjectsOfType (typeof(T)).Length > 1) {
//                             return m_Instance;
//                         }
//                         // Search for existing instance.
//                         m_Instance = (T)FindObjectOfType(typeof(T));
                        
//                         if (FindObjectsOfType (typeof(T)).Length == 1) {
//                             DontDestroyOnLoad(m_Instance);
//                         }


//                         // Create new instance if one doesn't already exist.
//                         if (m_Instance == null)
//                         {
//                             // Need to create a new GameObject to attach the singleton to.
//                             var singletonObject = new GameObject();
//                             m_Instance = singletonObject.AddComponent<T>();
//                             singletonObject.name = typeof(T).ToString() + " (Singleton)";

//                             // Make instance persistent.
//                             DontDestroyOnLoad(singletonObject);
//                         }
//                     }

//                     return m_Instance;
//                 }
//             }
//         }

//         protected virtual void OnApplicationQuit()
//         {
//             m_ShuttingDown = true;
//         }

//         protected override void OnDestroy()
//         {
//             base.OnDestroy();
//             m_ShuttingDown = true;
//         }
//     }
// }

    

using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T m_instance;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = GameObject.FindObjectOfType<T>();

                if (m_instance == null)
                {
                    m_instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    DontDestroyOnLoad(m_instance.gameObject);
                }
            }

            return m_instance;
        }
    }

    public static bool Active => m_instance != null;

    protected virtual void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (m_instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (m_instance == this)
        {
            m_instance = null;
        }
    }
}