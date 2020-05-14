using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    public Vector2 MoveVec2 { get; set; }
    public bool TackingButton { get; set; }

    [SerializeField] Rigidbody rb;
    [SerializeField] float torque = 10f;
    [SerializeField] float forwardForce = 10f;
    [SerializeField] Transform wind;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (TackingButton)
        {
            rb.AddRelativeTorque(Vector3.up * torque * 2 * rb.velocity.magnitude * MoveVec2.x);
        }
        else
        {
            rb.AddRelativeTorque(Vector3.up * torque * rb.velocity.magnitude * MoveVec2.x);
        }
        
        rb.AddForce(transform.forward * MoveVec2.y * forwardForce);

        if (Vector3.Angle(wind.forward, transform.forward) < 135f)
        {
            float windBoost = 1 + Vector3.Dot(transform.forward, wind.forward);

            rb.AddForce(transform.forward * forwardForce * windBoost);

            float rightSeilBoost = Vector3.Dot(transform.forward, wind.right);
            if (rightSeilBoost < 0) rightSeilBoost = 0;

            float leftSeilBoost = Vector3.Dot(transform.forward, -wind.right);
            if (leftSeilBoost < 0) leftSeilBoost = 0;

            rb.AddForce(transform.forward * (rightSeilBoost + leftSeilBoost) * forwardForce);
        }
    }
}
