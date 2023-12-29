using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround : MonoBehaviour
{
    [SerializeField]
    private Renderer groundRenderer;
    [SerializeField]
    private float parallexSpeed = 10f;

    private GameObject player;
    float offsetX, offsetY;
    // Start is called before the first frame update

    void Start()
    {
        offsetX = 0f;
        offsetY = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        if (player != null)
        {
            scrollBg(player.GetComponent<carController>().Speed, groundRenderer);
        }
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        movement();
    }

    void movement()
    {
        float posX = player.transform.position.x ;
        float posZ = player.transform.position.z ;

        transform.position = new Vector3(posX, transform.position.y, posZ);
    }
    private void scrollBg(float scrollSpeed, Renderer rend)
    {
        if (rend == null)
        {
            Debug.LogError("Renderer is null!");
            return;
        }

        float deltaX = scrollSpeed / parallexSpeed;
        float deltaY = scrollSpeed / parallexSpeed;

        offsetX += deltaX;
        offsetY += deltaY;

        Debug.Log($"OffsetX: {offsetX}, OffsetY: {offsetY}");

        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }


}
