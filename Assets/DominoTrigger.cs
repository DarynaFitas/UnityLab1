using UnityEngine;

public class DominoTrigger : MonoBehaviour
{
    public Rigidbody ball;
    public float force = 5f;

    void Start()
    {
        ball.linearVelocity = new Vector3(force, 0, 0);
    }
}
