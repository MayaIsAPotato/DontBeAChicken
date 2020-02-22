using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sheep : AnimalsManager
{
    private NavMeshAgent _sheep;
    private Animator _animator;



    public enum SheepMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public SheepMovement state = SheepMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case SheepMovement.Idle:



                break;

            case SheepMovement.Walk:


                break;

            case SheepMovement.Run:


                break;

            case SheepMovement.Breathing:


                break;

            case SheepMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
