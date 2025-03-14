using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoint : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float moveSpeed = 2;
    public float rotateSpeed = 2;
    int index = 0;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Setting the destination the script moves to
        Vector3 destination = waypoints[index].transform.position;
        //Sets the direction the script will move to
        Vector3 targetDirection = waypoints[index].transform.position - transform.position;
        //Sets how fast to move to the target rotation
        float nextStep = rotateSpeed * Time.deltaTime;

        //Grabs a Vector3 that will be used to rotate the script towards the target by nextStep
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, nextStep, 0.0f);
        //Grabs a Vector3 that will move towards the target position by moveSpeed*deltaTime
        Vector3 newPosition = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, moveSpeed * Time.deltaTime);

        //Sets the new rotation and rotation
        transform.position = newPosition;
        transform.rotation = Quaternion.LookRotation(newDirection);
  
        //Grabs the distance from the script to the target location
        float distance = Vector3.Distance(transform.position, destination);
     
        //Once the location is reached
        if (distance < 0.5)
        {
            //And there are still more waypoints to reach
            if (index < waypoints.Count - 1)
            {
                //Then increase the index
                index++;
            }
        }
    }

    public void SetWayPoint(int index, GameObject waypoint)
    {
        if (first)
        {
            waypoints[0] = waypoint;
            first = false;
        }
        else
        {
            this.waypoints.Add(waypoint);
        }
    }
}
