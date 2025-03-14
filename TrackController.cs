using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public GameObject enemy;
    float time;
    private int spawns;
    public int limit;
    public int spawnTime;
    public GameObject way1;
    public GameObject way2;
    public GameObject way3;
    public GameObject way4;
    // Start is called before the first frame update
    void Start()
    {
        spawns = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > spawnTime) 
        {
            time = Random.Range(3.0f, 5.0f);
            GameObject newEnemy = Instantiate(enemy, this.transform);
            MoveToWaypoint script = newEnemy.GetComponent<MoveToWaypoint>();
            script.SetWayPoint(0, way1);
            script.SetWayPoint(1, way2);
            script.SetWayPoint(2, way3);
            script.SetWayPoint(3, way4);
            spawns += 1;
        }
        if (spawns > limit)
        {
            Debug.Log("increasing spawn time");
            spawnTime -= 1;
            limit += 6;
            spawns = 0;
        }
    }
}
