using System;
using UnityEngine;

public class ScaleFromMicrophone : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;
    private Vector3 scaleChange;

    public SpringJoint2D[] springs;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    /*
    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0;
        }
//        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness); // change scale based on loudness
//        transform.localScale += new Vector3(0.1f, 0.1f, 0);
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        transform.transform.localScale += scaleChange;
    }
    */

    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        if (loudness > threshold)
        {
            //if ()
            //{
            transform.transform.localScale += new Vector3(+0.001f, +0.001f, 0);

            foreach (var spring in springs)
            {
                spring.distance += .01f;
            }
            //}
            //else
            //{
                // play sound
            //}
        }
        else
        {
            loudness = 0;
        }
    }
}