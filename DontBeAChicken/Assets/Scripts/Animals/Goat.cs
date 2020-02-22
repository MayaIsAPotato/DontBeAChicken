using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goat : AnimalsManager
{
    private NavMeshAgent _goat;
    private Animator _animator;

    public enum GoatMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public GoatMovement state = GoatMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case GoatMovement.Idle:



                break;

            case GoatMovement.Walk:


                break;

            case GoatMovement.Run:


                break;

            case GoatMovement.Breathing:


                break;

            case GoatMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
