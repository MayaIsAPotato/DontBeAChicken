using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ostrich : AnimalsManager
{
    private NavMeshAgent _ostrich;
    private Animator _animator;

    public enum OstrichMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public OstrichMovement state = OstrichMovement.Idle;

    public override void Behaviour()
    {
        switch (state)
        {
            case OstrichMovement.Idle:



                break;

            case OstrichMovement.Walk:


                break;

            case OstrichMovement.Run:


                break;

            case OstrichMovement.Breathing:


                break;

            case OstrichMovement.Eat:


                break;

        }
    }
    public override void Sound()
    {

    }
}
