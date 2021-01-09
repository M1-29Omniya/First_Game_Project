using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCare : MonoBehaviour
{
    public float speed;
    private Rigidbody health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Rigidbody>();
        health.velocity = new Vector3(0, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("New Dimension of Energy entered");
           Destroy(this.gameObject);
            //Destroy(other.gameObject);
        }
    }

}
