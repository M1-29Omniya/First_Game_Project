using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBolt : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody enemy;
    Player target;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        enemy.velocity = new Vector3(0.0f, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit By the enemy bullet!");
           // Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
