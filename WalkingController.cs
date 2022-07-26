using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingController : Controller
{
    //movement info
    Vector3 walkVelocity;
    float adjVertVelocity;
    float jumpPressTime;

    //settings
    public float walkSpeed = 3f;
    public float jumpSpeed = 6f;
    public override void ReadInput(InputData data)
    {
        ResetMovementToZero();

        //set vertical movement
        if (data.axes[0] != 0f)
        {
            walkVelocity += Vector3.forward * data.axes[0] * walkSpeed;
        }
        //set horizontal movement
        if (data.axes[1] != 0f)
        {
            walkVelocity += Vector3.right * data.axes[1] * walkSpeed;
        }

        //set verticalJump
        if (data.buttons[0] == true)
        {
            if (jumpPressTime == 0f)
            {
                if (Grounded())
                {
                    adjVertVelocity = jumpSpeed;

                }
                jumpPressTime += Time.deltaTime;

            }
            else
            {
                jumpPressTime = 0f;
            }
            newInput = true;

        }
    }
        //method that will look our under character and see if there is a collider
        bool Grounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);

        }

        void LateUpdate()
        {
            if (!newInput)
            {
                ResetMovementToZero();
                jumpPressTime = 0f;
            }
            rb.velocity = new Vector3(walkVelocity.x, rb.velocity.y + adjVertVelocity, walkVelocity.z);
            newInput = false;
        }

        void ResetMovementToZero()
        {
            adjVertVelocity = 0f;
            walkVelocity = Vector3.zero;

        }
    }

