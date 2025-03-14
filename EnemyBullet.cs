using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBullet : MonoBehaviour
{
    
    public float bulletSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
