using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float speed;
    private Rigidbody colour;
    // Start is called before the first frame update
    void Start()
    {
        colour = GetComponent<Rigidbody>();
        colour.velocity = new Vector3(0, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Destroy(this.gameObject);
        }
    }
}
