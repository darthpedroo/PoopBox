using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTestState : EntityBaseState
{
    Animator animator;

    public float moveSpeed = 0.2f;    // Speed at which the entity moves
    private Vector3 stopPosition;     // Position to stop at after walking

    private float walkTime;           // Time entity will walk
    public float walkCounter;         // Counter for walking time
    private float waitTime;           // Time entity will wait before walking again
    public float waitCounter;         // Counter for wait time

    private int WalkDirection;        // Direction the entity will walk in (0-3)

    public bool isWalking;            // Whether the entity is currently walking

    // This method is now called during EnterState to initialize all values
    public override void EnterState(EntityStateManager entity)
    {
        Debug.Log("Entering Test State");

        // Initialize Animator if needed (optional)
        animator = entity.GetComponent<Animator>();

        // So that all the entities don't move/stop at the same time
        walkTime = Random.Range(3f, 6f);  // Random walking time between 3 and 6 seconds
        waitTime = Random.Range(5f, 7f);  // Random waiting time between 5 and 7 seconds

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection(); // Start the first walking direction
    }

    // UpdateState will be called every frame
    public override void UpdateState(EntityStateManager entity)
    {
        if (isWalking)
        {
            // If you have an animator, uncomment this to trigger walking animations
            // animator.SetBool("isRunning", true);

            // Decrease walk counter over time
            walkCounter -= Time.deltaTime;

            // Perform movement based on the WalkDirection (0-3)
            switch (WalkDirection)
            {
                case 0:
                    entity.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    break;
                case 1:
                    entity.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    break;
                case 2:
                    entity.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
                    break;
                case 3:
                  entity.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                   break;
            }

            // Move the entity forward based on the set direction and speed
            entity.transform.position += entity.transform.forward * moveSpeed * Time.deltaTime;

            // Stop walking if walkCounter hits 0
            if (walkCounter <= 0)
            {
                stopPosition = entity.transform.position;
                isWalking = false;  // Stop walking

                // Reset the entity position (this may be redundant, consider removing it)
                //entity.transform.position = stopPosition;

                // If you have an animator, uncomment this to stop running animations
                // animator.SetBool("isRunning", false);

                // Reset waitCounter
                waitCounter = waitTime;
            }
        }
        else
        {
            // Decrease wait counter over time
            waitCounter -= Time.deltaTime;

            // If wait counter hits 0, choose a new direction to walk
            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }

    // Randomly choose a direction (0-3) and set walking state
    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);  // Random direction (0 = forward, 1 = right, 2 = left, 3 = backward)
        isWalking = true;                    // Start walking
        walkCounter = walkTime;              // Reset walk time counter
    }
}
