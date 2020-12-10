using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator Circular_Path;
    public float speed = 10;
    float distanceTravelled;

    private void Update()
    {
        
        
            distanceTravelled += speed * Time.deltaTime;
            transform.position = Circular_Path.path.GetPointAtDistance(distanceTravelled);
            
        
    }
}
