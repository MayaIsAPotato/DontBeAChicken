using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bull : AnimalsManager
{
    private NavMeshAgent _bull;
    private Animator _animator;

    public enum BullMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public BullMovement state = BullMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case BullMovement.Idle:



                break;

            case BullMovement.Walk:


                break;

            case BullMovement.Run:


                break;

            case BullMovement.Breathing:


                break;

            case BullMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
