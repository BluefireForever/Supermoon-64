using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
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
        GameObject player = GameObject.FindWithTag("player");
        PlayerMovement script = player.GetComponent<PlayerMovement>();
        script.CheckHealth(3);
        GameObject trigger = GameObject.FindWithTag("gainhealth");
        FireUpTrigger script2 = trigger.GetComponent<FireUpTrigger>();
        script2.PowerUpGained();
        Destroy(this.gameObject);
    }
}
