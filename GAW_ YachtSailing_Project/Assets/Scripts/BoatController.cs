using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    public Vector2 MoveVec2 { get; set; }
    [SerializeField] Rigidbody rb;
    [SerializeField] float torque = 10f;
    [SerializeField] float forwardForce = 10f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rb.AddRelativeTorque(Vector3.up * torque * rb.velocity.magnitude* MoveVec2.x);
        rb.AddForce(transform.forward * MoveVec2.y * forwardForce);

        
    }
}
