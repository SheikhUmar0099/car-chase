using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject boosterPrefab;
    public GameObject shieldPrefab;
    public Transform playerTransform;
    public float minRespawnTime = 20f;
    public float maxRespawnTime = 30f;
    public float initialSpawnDelay = 5f;
    public int maxPowerUps = 3;

    private GameObject[] powerUpPool;
    private int currentPowerUpIndex = 0;

    private void Start()
    {
        powerUpPool = new GameObject[maxPowerUps];

        for (int i = 0; i < maxPowerUps; i++)
        {
            // Alternate between boosterPrefab and shieldPrefab in the pool
            GameObject powerUpPrefab = (i % 2 == 0) ? boosterPrefab : shieldPrefab;
            GameObject powerUp = Instantiate(powerUpPrefab, Vector3.zero, Quaternion.identity);
            powerUp.SetActive(false);
            powerUpPool[i] = powerUp;
        }

        Invoke("SpawnPowerUp", initialSpawnDelay);
    }

    private void SpawnPowerUp()
    {
        Vector3 randomSpawnPoint = playerTransform.position + Random.insideUnitSphere * 100f;
        randomSpawnPoint.y = 0f;

        GameObject powerUp = powerUpPool[currentPowerUpIndex];
        powerUp.transform.position = randomSpawnPoint;
        powerUp.SetActive(true);

        // Move to the next index in the pool, reset if reaching the end
        currentPowerUpIndex = (currentPowerUpIndex + 1) % maxPowerUps;

        // Schedule the next power-up spawn
        float respawnTime = Random.Range(minRespawnTime, maxRespawnTime);
        Invoke("SpawnPowerUp", respawnTime);
    }
    public void ResetPowerUpPosition(GameObject powerUp)
    {
        Vector3 randomSpawnPoint = playerTransform.position + Random.insideUnitSphere * 100f;
        randomSpawnPoint.y = 0f;

        // Set the power-up's position to the new random spawn point
        powerUp.transform.position = randomSpawnPoint;

        // Optionally, you may want to disable the power-up until it's next activated
        powerUp.SetActive(false);
    }
}

