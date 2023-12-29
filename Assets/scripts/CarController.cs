using System.Collections;
using UnityEngine;

public class carController : MonoBehaviour
{
    private PowerUpManager powerUpManager;
    private coinsManager coinsManager;
    //private CoinsUpdate coinsUpdate;
    [SerializeField]
    private float forwardSpeed = 5f;

    public float sideSpeed = 3f;

    private Rigidbody rb;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;

    public float Speed { get { return forwardSpeed; } }

    public GameObject shield;

    private void Start()
    {
        powerUpManager = FindAnyObjectByType<PowerUpManager>();
        coinsManager = FindAnyObjectByType<coinsManager>();
        //coinsUpdate = FindAnyObjectByType<CoinsUpdate>();
        shield.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the car forward automatically
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Update the position of the shield to follow the player
        shield.transform.position = transform.position;

        // Check for screen tap
        if (Input.GetMouseButtonDown(0))
        {
            // Get the tap position
            float tapPosition = Input.mousePosition.x;

            // Check if tap is on the right or left side of the screen
            if (tapPosition > Screen.width / 2 && tapPosition < Screen.width)
            {
                // Start moving the car to the right
                isMovingRight = true;
            }
            else if (tapPosition < Screen.width / 2 && tapPosition > 0)
            {
                // Start moving the car to the left
                isMovingLeft = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Stop moving the car when the mouse button is released
            isMovingRight = false;
            isMovingLeft = false;
        }

        // Rotate the car based on the input
        if (isMovingRight)
        {
            moveRight();
        }
        else if (isMovingLeft)
        {
            moveLeft();
        }
    }

    private void moveRight()
    {
        transform.Rotate(Vector3.up * sideSpeed * Time.deltaTime);
    }

    private void moveLeft()
    {
        transform.Rotate(-Vector3.up * sideSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("booster"))
        {
            forwardSpeed = 60f;
            StartCoroutine(powerUpTime());
            // Deactivate the booster power-up instead of destroying it
            other.gameObject.SetActive(false);

            // Call a method in the PowerUpManager to reset the booster power-up's position
            powerUpManager.ResetPowerUpPosition(other.gameObject);
        }

        if (other.CompareTag("shield"))
        {
            // Activate the shield effect
            shield.SetActive(true);
            StartCoroutine(shieldPowerUpTime());
            // Deactivate the shield power-up instead of destroying it
            other.gameObject.SetActive(false);

            // Call a method in the PowerUpManager to reset the shield power-up's position
            powerUpManager.ResetPowerUpPosition(other.gameObject);
        }

        if (other.CompareTag("coin"))
        {
            //coinsUpdate.AddCoin();
            SaveManager.instance.money += 1;
            SaveManager.instance.Save();
            other.gameObject.SetActive(false);
            coinsManager.ResetCoinsPosition(other.gameObject);
        }

        if (other.CompareTag("multicoin"))
        {
            //coinsUpdate.AddMultipleCoins();
            SaveManager.instance.money += 10;
            SaveManager.instance.Save();
            other.gameObject.SetActive(false);
            coinsManager.ResetCoinsPosition(other.gameObject);
        }
    }

    IEnumerator powerUpTime()
    {
        yield return new WaitForSecondsRealtime(30f);
        forwardSpeed = 30f;
    }

    IEnumerator shieldPowerUpTime()
    {
        yield return new WaitForSecondsRealtime(30f); // Adjust the duration as needed
        shield.SetActive(false);
    }
}
