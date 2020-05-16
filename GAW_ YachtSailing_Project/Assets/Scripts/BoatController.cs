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

    [Header("セール")]
    [SerializeField] Transform seil;
    [Range(0f,1f)][SerializeField] float turnSpeed = 10;
    [SerializeField] Cloth cloth;

    [Header("旗")]
    [SerializeField] Transform flag;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        float angle = Vector3.SignedAngle(transform.forward, -wind.forward, transform.up);
        Debug.Log("angle" + angle);
        angle = angle / 2f;

        float rad = angle * Mathf.Deg2Rad;
        Vector3 seilDirection = new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad));

        seil.localRotation = Quaternion.Slerp(
                seil.localRotation,
                Quaternion.LookRotation(seilDirection),
                turnSpeed
            );

        cloth.externalAcceleration = cloth.transform.InverseTransformDirection(wind.forward) * 60f;

        flag.rotation = Quaternion.LookRotation(wind.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
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

        float windBoost = 1 + Vector3.Dot(transform.forward, wind.forward);

        rb.AddForce(transform.forward * forwardForce * windBoost);

        float rightSeilBoost = Vector3.Dot(transform.forward, wind.right);
        if (rightSeilBoost < 0) rightSeilBoost = 0;

        float leftSeilBoost = Vector3.Dot(transform.forward, -wind.right);
        if (leftSeilBoost < 0) leftSeilBoost = 0;

        rb.AddForce(transform.forward * (rightSeilBoost + leftSeilBoost) * forwardForce);
    }
}
