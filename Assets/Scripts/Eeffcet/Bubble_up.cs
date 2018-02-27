using UnityEngine;
using System.Collections;

public class Bubble_up : MonoBehaviour
{
    public float fBubbleUpTime;
    public bool bBubbleUp = false;
    public float fBubbleShowTime;
    public ParticleSystem Bubble;

    // Use this for initialization
    void Start()
    {
        Bubble.Stop();
        fBubbleUpTime = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (bBubbleUp == true)
        {

            if (fBubbleShowTime > 0f)
            {
                fBubbleShowTime -= Time.deltaTime;
            }
            else
            {
                Bubble.Stop();
                bBubbleUp = false;
                fBubbleUpTime = 0.0f;
            }
        }
        else
        {
            fBubbleUpTime += Time.deltaTime;
            if (fBubbleUpTime >= 10f)
            {
                bBubbleUp = true;
                fBubbleShowTime = Random.Range(1, 5);
                fBubbleUpTime = Random.Range(0, 5);
                Bubble.Play();

            }
        }

    }
}
