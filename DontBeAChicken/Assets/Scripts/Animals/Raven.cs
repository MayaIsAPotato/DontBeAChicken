using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Raven : AnimalsManager
{
    private NavMeshAgent _raven;
    private Animator _animator;


    public enum RavenMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public RavenMovement state = RavenMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case RavenMovement.Idle:



                break;

            case RavenMovement.Walk:


                break;

            case RavenMovement.Run:


                break;

            case RavenMovement.Breathing:


                break;

            case RavenMovement.Eat:


                break;

        }
    }

    public override void Sound()
    {

    }

}
