using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pig : AnimalsManager
{
    private NavMeshAgent _pig;
    private Animator _animator;

    public enum PigMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public PigMovement state = PigMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case PigMovement.Idle:



                break;

            case PigMovement.Walk:


                break;

            case PigMovement.Run:


                break;

            case PigMovement.Breathing:


                break;

            case PigMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
