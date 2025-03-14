using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Camera camera;
    public GameObject bullet;
    public float bulletSpeed;
    public RawImage pointer;
    public float fireSpeed;
    


    private float lastShot;
    private RetroController controller;
    bool held = false;

    // Start is called before the first frame update
    void Awake()
    {
        controller = new RetroController();
        controller.Controller.Shoot.performed += ctx => Fire();
        controller.Controller.Shoot.canceled += ctx => Fire();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the time since the last shot
        lastShot += Time.deltaTime;

        if (held)
        {
            //If the mouse button is being held down, AND the last shot is greater than the firing speed
            if (lastShot >= fireSpeed)
            {
                //Vector3 pos = new Vector3(pointer.transform.position.x, pointer.transform.position.y, pointer.transform.position.z);
                //Creates a ray on the camera that has the origin of the mouse
                Ray mouseRay = camera.ScreenPointToRay(pointer.rectTransform.position);
                //Creates the new bullet. Used the bullet prefab, then ray for the origin and Quaternion for the rotation
                GameObject bulletFired = Instantiate(bullet, mouseRay.origin, Quaternion.identity);
                //Gets the ridgid body of the bullet
                Rigidbody rb = bulletFired.GetComponent<Rigidbody>();
                //Adds direction * force to the rb. direction was gotten through the ray, and force through bullet speed
                rb.velocity = mouseRay.direction * bulletSpeed;
                //Resets the time since last shot
                lastShot = 0;
            }
        }
    }

    void Fire()
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
}
