using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockInSpace : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rock;

    // Start is called before the first frame update
    void Start()
    {
        rock = this.GetComponent<Rigidbody>();
        rock.velocity = new Vector3(0, 0, -speed);

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Destroy(this.gameObject);
                Debug.Log("rock got hit");
                break;
            case "PlayerBullet":
                Destroy(this.gameObject);
                Debug.Log("rock got hit by a player bullet");
                break;
            default:break;
        }
    }
}
/*
 * if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("rock got hit");
        }*/