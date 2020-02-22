using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goose : AnimalsManager
{
    private NavMeshAgent _goose;
    private Animator _animator;

    public enum GooseMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public GooseMovement state = GooseMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case GooseMovement.Idle:



                break;

            case GooseMovement.Walk:


                break;

            case GooseMovement.Run:


                break;

            case GooseMovement.Breathing:


                break;

            case GooseMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
