using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colours : MonoBehaviour
{
    public Material material;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Blue":
                material.color = Color.blue; break;
            default: break;
        }
    }
}
