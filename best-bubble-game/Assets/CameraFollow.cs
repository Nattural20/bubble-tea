using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(0, player.transform.position.y, -10);
    }
}
