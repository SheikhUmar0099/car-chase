using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    private float speed = 10;
    [SerializeField]
    private float rotspeed = 10;
    private Rigidbody mybody;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pointtarget = transform.position - target.transform.position;
        pointtarget.Normalize();
        float value = Vector3.Cross(pointtarget, transform.forward).y;
        mybody.angularVelocity = rotspeed * value * new Vector3(0, 1, 0);

        mybody.velocity = transform.forward * speed;

    }
}

