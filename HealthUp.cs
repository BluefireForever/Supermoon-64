using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public bool despawn = true;
    // Start is called before the first frame update
    void Start()
    {
        if (despawn)
        {
            Destroy(this.gameObject, 20f);
        }
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Fire UP");
        GameObject player = GameObject.FindWithTag("player");
        PlayerMovement script = player.GetComponent<PlayerMovement>();
        script.SetMaxHealth(2);
        GameObject trigger = GameObject.FindWithTag("healthup");
        FireUpTrigger script2 = trigger.GetComponent<FireUpTrigger>();
        script2.PowerUpGained();
        Destroy(this.gameObject);
    }
}
