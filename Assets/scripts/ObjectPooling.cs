using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject carPrefab;
    public int poolSize = 4; // Adjust pool size as needed
    public Transform[] spawnLocations;

    private List<GameObject> carPool;

    void Start()
    {
        InitializeObjectPool();
        ActivatePooledCars(); // Activate cars when the game starts
    }

    void InitializeObjectPool()
    {
        carPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject car = Instantiate(carPrefab);
            car.SetActive(false);
            carPool.Add(car);
        }
    }

    void ActivatePooledCars()
    {
        for (int i = 0; i < poolSize; i++)
        {
            ActivatePooledCar();
        }
    }

    public void ActivatePooledCar()
    {
        Transform randomSpawnLocation = null;

        for (int i = 0; i < carPool.Count; i++)
        {
            if (!carPool[i].activeInHierarchy)
            {
                // Randomly select a spawn location
                randomSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];

                // Set the position and rotation based on the selected spawn location
                carPool[i].transform.position = randomSpawnLocation.position;
                carPool[i].transform.rotation = randomSpawnLocation.rotation;

                carPool[i].SetActive(true);
                return;
            }
        }

        // If all cars are active, create a new one
        GameObject newCar = Instantiate(carPrefab);
        carPool.Add(newCar);

        // Randomly select a spawn location for the new car
        randomSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];

        // Set the position and rotation based on the selected spawn location
        newCar.transform.position = randomSpawnLocation.position;
        newCar.transform.rotation = randomSpawnLocation.rotation;

        newCar.SetActive(true);
    }

    public void DisableCar(GameObject car)
    {
        car.SetActive(false);
    }
}
