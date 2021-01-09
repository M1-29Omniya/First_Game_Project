using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody Eplane;
    private float time =2;
    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Eplane = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (time < Time.time)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            time = Time.time + 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Destroy(this.gameObject);
                Debug.Log("Enemy ship got hit");
                break;
            case "PlayerBullet":
                Destroy(this.gameObject);
                Destroy(this.shot);
                Debug.Log("Enemy Ship got hit by a player bullet");
                break;
            default: break;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Boundary":
                Destroy(this.gameObject);
                Debug.Log("Enemy ship got hit by boundary");
                break;
            default: break;
        }

    }

}
