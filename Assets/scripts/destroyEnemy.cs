using UnityEngine;
using UnityEngine.Pool;

public class DestroyEnemy : MonoBehaviour
{
    //public int score;
    private ObjectPooling objectPooler;
    //public GameObject particleEffect;

    void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooling>();
       // particleEffect = transform.Find("ParticleEffect").gameObject; // Adjust the name accordingly
        //particleEffect.SetActive(false);
    }

    private void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("shieldobject"))
        {
            //score++;
            
           // particleEffect.SetActive(true);
            // Disable the collided cars
            objectPooler.DisableCar(gameObject);

            // Activate new cars from the pool at random positions from the array
            objectPooler.ActivatePooledCar();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
