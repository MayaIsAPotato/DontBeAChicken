using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : AnimalsManager
{
    private NavMeshAgent _cat;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public enum CatMovement
    {
        Idle,
        Walk,
        Run,
        Breathing,
        Eat
    };

    public CatMovement state = CatMovement.Idle;

   public  override void Behaviour()
   {
        switch (state)
        {
            case CatMovement.Idle:

                _animator.Play("CatIdle");

                break;

            case CatMovement.Walk:

                _animator.Play("CatWalk");
                break;

            case CatMovement.Run:


                break;

            case CatMovement.Breathing:


                break;

            case CatMovement.Eat:


                break;

        }
   }
    public override void Sound()
    {

    }
}
