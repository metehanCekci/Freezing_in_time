using UnityEngine;

public class followScript : MonoBehaviour
{
    public Transform target;  // The object to follow
    public float speed = 5f;  // The movement speed
    public Vector3 offset;  // The offset from the target object

    void Update()
    {
        // Calculate the desired position (target's position + offset)
        Vector3 desiredPosition = target.position + offset;

        // Move the object towards the desired position at a constant speed
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(desiredPosition.x,transform.position.y,0), speed * Time.deltaTime);
    }
}
