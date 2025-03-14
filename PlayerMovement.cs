using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    RetroController controller;
    public float moveSpeed;
    public float health;
    private bool held;
    private bool left;

    public AudioSource audioSource;
    public AudioClip uuf;
    public Text healthText;
    public Image playerHealth;
    public GameObject particle;
    private float maxhealth;
    float lerpSpeed;

    // for the game over screen
    public bool IsDead;
    public GameObject GameOverScreen;


    // Start is called before the first frame update
    void Awake()
    {
        controller = new RetroController();
        controller.Controller.MoveLeft.performed += ctx => MoveLeft();
        controller.Controller.MoveRight.performed += ctx => MoveRight();
        controller.Controller.MoveLeft.canceled += ctx => MoveLeft();
        controller.Controller.MoveRight.canceled += ctx => MoveRight();
    }

    private void Start()
    {
        maxhealth = health;

        // game over screen variables
        GameOverScreen.SetActive(false);
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();

        if (held)
        {
            Vector3 movement = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            if (left)
            {
                if (this.transform.position.x >= -1.1)
                {
                    this.transform.position -= movement;
                }
            }
            else 
            {
                if (this.transform.position.x <= 1.1)
                {
                    this.transform.position += movement;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("enemyBullet"))
        {
            health -= 1;
            audioSource.PlayOneShot(uuf);
            Instantiate(particle, this.transform.position, Quaternion.identity);
            if (health <= 0)
            {
                Debug.Log("Game Over!");

                GameOverScreen.SetActive(true);
                IsDead = true;
            }

            StartCoroutine (IFrames());
        }
    }

    void MoveLeft()
    {
        held = !held;
        left = !left;
    }

    void MoveRight()
    {
        held = !held;
    }
    private void OnEnable()
    {
        controller.Controller.Enable();
    }

    private void OnDisable()
    {
        controller.Controller.Disable();
    }

    void HealthBarFiller()
    {
        playerHealth.fillAmount = health / maxhealth;
    }

    IEnumerator IFrames()
    {
        yield return new WaitForSeconds(1f);
    }

    public void SetMaxHealth(int num)
    {
        this.maxhealth += num;
        this.health += num;
        Debug.Log(this.maxhealth);
    }

    public void CheckHealth(int hp)
    {
        this.health += hp;
        if(this.health > this.maxhealth)
        {
            health = maxhealth;
            Debug.Log("HP Set to Max because of overflow");
        }
    }

}
