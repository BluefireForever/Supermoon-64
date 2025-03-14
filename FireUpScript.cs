using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUpScript : MonoBehaviour
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

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Fire UP");
        GameObject player = GameObject.FindWithTag("player");
        Shoot script = player.GetComponent<Shoot>();
        if (script.fireSpeed >= 0.02f)
        {
            script.fireSpeed -= 0.008f;
        }
        script.bulletSpeed += 2;
        GameObject trigger = GameObject.FindWithTag("fireup");
        FireUpTrigger script2 = trigger.GetComponent<FireUpTrigger>();
        script2.PowerUpGained();
        Destroy(this.gameObject);
    }
}
