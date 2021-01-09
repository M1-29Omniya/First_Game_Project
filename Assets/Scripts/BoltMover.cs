using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody b;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Rigidbody>();
        b.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
