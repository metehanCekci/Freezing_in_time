using UnityEngine;

public class DropTextScript : MonoBehaviour
{
    public float hop;
private void Awake() {
    this.gameObject.GetComponent<Rigidbody2D>().linearVelocity = transform.up * hop;
    Destroy(this.gameObject,2);
}
}
