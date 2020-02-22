using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stork : AnimalsManager
{
    private NavMeshAgent _stork;
    private Animator _animator;

    public enum StorkMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public StorkMovement state = StorkMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case StorkMovement.Idle:



                break;

            case StorkMovement.Walk:


                break;

            case StorkMovement.Run:


                break;

            case StorkMovement.Breathing:


                break;

            case StorkMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }

}
