using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Reticle : MonoBehaviour
{
    RetroController controller;
    bool held;
    public float speed;
    private int direction;
    private bool up;
    private bool down;
    private bool left;
    private bool right;

    // Start is called before the first frame update
    void Awake()
    {
        controller = new RetroController();
        controller.Controller.Up.performed += ctx => up = true;
        controller.Controller.Up.canceled += ctx => up = false;
        controller.Controller.Down.performed += ctx => down = true;
        controller.Controller.Down.canceled += ctx => down = false;
        controller.Controller.Left.performed += ctx => left = true;
        controller.Controller.Left.canceled += ctx => left = false;
        controller.Controller.Right.performed += ctx => right = true;
        controller.Controller.Right.canceled += ctx => right = false;


    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 UDmovement = new Vector3(0, speed * Time.deltaTime, 0);
        Vector3 LRmovement = new Vector3(speed * Time.deltaTime, 0, 0);
        if (up && this.transform.position.y <= 1080)
        {
            this.transform.position += UDmovement;
        }
        if (down && this.transform.position.y >= 0)
        {
            this.transform.position -= UDmovement;
        }
        if (left && this.transform.position.x >= 0)
        {
            this.transform.position -= LRmovement;
        }
        if (right && this.transform.position.x <= 1920)
        {
            this.transform.position += LRmovement;
        }
        //this.gameObject.transform.position = Input.mousePosition;
    }

    void MoveUp()
    {
        up = !up;
    }
    void MoveDown()
    {
        down = !down;
    }
    void MoveLeft()
    {
        left = !left;
    }
    void MoveRight()
    {
        right = !right;
    }

    private void OnEnable()
    {
        controller.Controller.Enable();
    }

    private void OnDisable()
    {
        controller.Controller.Disable();
    }
}
