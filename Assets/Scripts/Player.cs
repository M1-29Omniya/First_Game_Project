using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Rigidbody plane;
    private float speed = 60f;
    private float tiltValue=0.5f;
    public float Health = 10;
    public Slider _slide;
    private float currentHealth;

    public Gradient grad;
    public Image colour;

    //Shotting ammo
    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotSpawn;
    [SerializeField] private float fireRate;

    private float nextFire;
    void Start()
    {
        plane = GetComponent<Rigidbody>();
        currentHealth = Health;
        _slide.maxValue = Health;
        _slide.value = Health;

        colour.color = grad.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        tilt();
        Fire();
       
    }

    void move()
    {
        float mHorizontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(mHorizontal, 0.0f, mVertical);
        plane.velocity = movement * speed;
    }

    void tilt()
    {
        plane.rotation = Quaternion.Euler(0.0f, 0.0f, plane.velocity.x * -tiltValue);
    }

    void Fire()
    {
        if(Input.GetKey("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RockInSpace")
        {
            Debug.Log("GOT HIY, MAN DOWN");
            TakeDamage(20.0f);
            //Destroy(this.gameObject);
            //Destroy(other.gameObject);
        }
        switch(other.gameObject.tag)
        {
            case "EnemyBullet":
                TakeDamage(10.0f);
                Debug.Log("Health reduced by EnBullet" + Health);break;
            case "EnemyShip":
                TakeDamage(30.0f);
                Debug.Log("Health reduced by EnemyShip" + Health);break;
            case "Health":
                currentHealth += 10.0f;
               _slide.value = currentHealth;
                Debug.Log("Health increased " + Health);break;
            case "EnemyShip2":
                TakeDamage(50.0f);break;
            default: break;
        }

        if(_slide.value <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("DEAD!");
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        _slide.value = currentHealth;
        colour.color = grad.Evaluate(_slide.normalizedValue);
    }
}
