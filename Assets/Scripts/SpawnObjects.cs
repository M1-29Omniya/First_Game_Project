using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Transform enemy;
    public float time;
    
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(time < Time.time)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            time = Time.time + 15;
        }
    }
}
