using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharaAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform HandTransform;
    [SerializeField] BoatController boatController;
    [SerializeField] GameObject Paddle;
    [SerializeField] Transform Rudder;
    [SerializeField] float rudderAngle = 45f;
    [SerializeField] float rudderSpeed = 0.1f;
    [SerializeField] float tackingSpeed = 1f;
    [SerializeField] ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Padding", boatController.MoveVec2.y > 0);
        Paddle.SetActive(boatController.MoveVec2.y > 0);

        float spped;

        if (boatController.TackingButton)
        {
            spped = tackingSpeed;
        }
        else
        {
            spped = rudderSpeed;
        }

        Rudder.localRotation = Quaternion.Lerp(
            Rudder.localRotation,
            Quaternion.Euler(Rudder.eulerAngles.x, -boatController.MoveVec2.x * rudderAngle, Rudder.eulerAngles.z),
            spped * Time.deltaTime
        );
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if(boatController.MoveVec2.y <= 0)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);

            animator.SetIKPosition(AvatarIKGoal.RightHand, HandTransform.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, HandTransform.rotation);
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
        }
    }
}
