using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Movement();
    }
    void Movement()
    {
        float posX = player.transform.position.x;
        float posZ = player.transform.position.z - 25;

        transform.position = new Vector3(posX, transform.position.y, posZ);
    }
}
