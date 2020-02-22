using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : AnimalsManager
{
    private NavMeshAgent _dog;
    private Animator _animator;

    public enum DogMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public DogMovement state = DogMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case DogMovement.Idle:



                break;

            case DogMovement.Walk:


                break;

            case DogMovement.Run:


                break;

            case DogMovement.Breathing:


                break;

            case DogMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
