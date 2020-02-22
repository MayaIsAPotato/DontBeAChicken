using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : AnimalsManager
{
    private NavMeshAgent _chicken;
    private Animator _animator;
    public enum ChickenMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public ChickenMovement state = ChickenMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case ChickenMovement.Idle:



                break;

            case ChickenMovement.Walk:


                break;

            case ChickenMovement.Run:


                break;

            case ChickenMovement.Breathing:


                break;

            case ChickenMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
