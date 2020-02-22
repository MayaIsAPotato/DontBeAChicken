using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pidgeon : AnimalsManager
{
    private NavMeshAgent _pidgeon;
    private Animator _animator;

    public enum PidgeonMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public PidgeonMovement state = PidgeonMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case PidgeonMovement.Idle:



                break;

            case PidgeonMovement.Walk:


                break;

            case PidgeonMovement.Run:


                break;

            case PidgeonMovement.Breathing:


                break;

            case PidgeonMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
