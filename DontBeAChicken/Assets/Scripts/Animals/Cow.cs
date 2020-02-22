using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cow : AnimalsManager
{
    private NavMeshAgent _cow;
    private Animator _animator;

    public enum CowMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public CowMovement state = CowMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case CowMovement.Idle:



                break;

            case CowMovement.Walk:


                break;

            case CowMovement.Run:


                break;

            case CowMovement.Breathing:


                break;

            case CowMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
