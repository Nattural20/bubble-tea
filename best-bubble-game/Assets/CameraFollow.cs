using UnityEngine;
using UnityEngine.Rendering;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;

    //public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;

        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cam1.transform.position = new Vector3(-7, player.transform.position.y, -10);
        cam2.transform.position = new Vector3(12, player.transform.position.y, -10);
        cam3.transform.position = new Vector3(31, player.transform.position.y, -10);
        cam4.transform.position = new Vector3(50, player.transform.position.y, -10);
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("triggered: " + trigger);
        if (trigger.gameObject.CompareTag("trigger_1"))
        {
            CheckActive(cam1, cam2);
            Debug.Log("Checking cam");
            cam1.enabled = false;
            cam2.enabled = true;
        }
        if (trigger.gameObject.CompareTag("trigger_2"))
        {
            CheckActive(cam2, cam3);
        }
        if (trigger.gameObject.CompareTag("trigger_3"))
        {
            CheckActive(cam3, cam4);
        }
    }

    public void CheckActive(Camera camA, Camera camB)
    {
        if (camA.enabled)
        {
            camB.enabled = true;
            camA.enabled = false;
            Debug.Log("tried switching");
        }
        else
        {
            camA.enabled = true;
            camB.enabled = false;
            
        }
    }
}
