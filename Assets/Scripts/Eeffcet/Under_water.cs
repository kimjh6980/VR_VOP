using UnityEngine;
using System.Collections;

public class Under_water : MonoBehaviour
{

    
    Color underwaterColor;
    // Use this for initialization
    void Start()
    {
        RenderSettings.fog = false;
        RenderSettings.fogColor = new Color(0.2f, 0.4f, 0.8f, 0.5f);
        RenderSettings.fogDensity = 0.01f;//안개밀도

    }
    bool IsUnderWater()
    {
        return gameObject.transform.position.y > 0&&gameObject.transform.position.y<25;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fog = IsUnderWater();
    }
        
}
