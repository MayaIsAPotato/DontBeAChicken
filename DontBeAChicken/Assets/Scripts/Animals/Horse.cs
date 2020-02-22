using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Horse : AnimalsManager
{
    private NavMeshAgent _horse;
    private Animator _animator;

    public enum HorseMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public HorseMovement state = HorseMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case HorseMovement.Idle:



                break;

            case HorseMovement.Walk:


                break;

            case HorseMovement.Run:


                break;

            case HorseMovement.Breathing:


                break;

            case HorseMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
