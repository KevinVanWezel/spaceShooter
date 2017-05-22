using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // -1 is left, 0 is no direction, 1 is right
    public void Move(Vector3 direction)
    {
        Vector3 velocity = direction * speed * Time.deltaTime;
        rb.MovePosition(rb.position + velocity);
    }

    public void LookAt(Vector3 point)
    {
        Vector3 heightCorrectedPoint = new Vector3(point.x,
                                                    transform.position.y,
                                                    point.z);
        transform.LookAt(heightCorrectedPoint);
    }
}

