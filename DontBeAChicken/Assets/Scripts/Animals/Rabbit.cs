using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : AnimalsManager
{
    private NavMeshAgent _rabbit;
    private Animator _animator;
    public enum RabbitMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public RabbitMovement state = RabbitMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case RabbitMovement.Idle:



                break;

            case RabbitMovement.Walk:


                break;

            case RabbitMovement.Run:


                break;

            case RabbitMovement.Breathing:


                break;

            case RabbitMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }

}
