using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    [SerializeField] private int speed = 4;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().linearVelocityY = Input.GetAxisRaw("Vertical") * speed;
    }
}