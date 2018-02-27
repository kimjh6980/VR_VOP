using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T :MonoBehaviour
{
    private static  T instance;
    
    public static T Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType(typeof(T)) as T;//T으로 형변환 형변환후에는 값이null이됌
                if(instance=null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
        
    }
}
