using UnityEngine;

public class HideTrigger : MonoBehaviour
{
    public GameObject trigger;
    public bool trig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (trig) {
            trigger.SetActive(false);
        }

        if (!trig) {
            trigger.SetActive(true);
        }
    }

}
