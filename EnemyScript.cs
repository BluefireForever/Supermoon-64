using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject firePoint;
    public int health;
    public float fireSpeed;
    public float bulletSpeed;
    public GameObject death;
    Rigidbody body;
    private float time;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        time = Random.Range(0f, 2.0f);
        Destroy(this.gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= fireSpeed)
        {
            FireBullet();
            //Resets the time since last shot
            time = Random.Range(0f, 2.0f);
        }
    }

    private void FireBullet()
    {
        //Creates the new bullet. Used the bullet prefab, then ray for the origin and Quaternion for the rotation
        GameObject bulletFired = Instantiate(enemyBullet, firePoint.transform.position, Quaternion.identity);
        //Gets the ridgid body of the bullet
        Rigidbody rb = bulletFired.GetComponent<Rigidbody>();
        GameObject player = GameObject.FindWithTag("player");
        Vector3 move = (player.transform.position - transform.position).normalized * bulletSpeed;
        //Adds direction * force to the rb. direction was gotten through the ray, and force through bullet speed
        rb.velocity = new Vector3(move.x, move.y, move.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("bullet"))
        {
            health -= 1;
            if (health < 0)
            {
                Instantiate(death, this.gameObject.transform.position, Quaternion.identity);
                audioSource.Play();
                GameObject tmp = GameObject.FindWithTag("score");
                ScoreCounter script = tmp.GetComponent<ScoreCounter>();
                script.EnemyKilled();
                Destroy(this.gameObject);
            }
        }
    }
}
