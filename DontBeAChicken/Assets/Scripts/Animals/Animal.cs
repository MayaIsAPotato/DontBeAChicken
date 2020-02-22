using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Animal : MonoBehaviour
{
    [SerializeField] private NavMeshAgent[] _animals;

    private void Update()
    {

        foreach (NavMeshAgent a in _animals)
        {
            
            AnimalsManager animal = (AnimalsManager)a.GetComponent(typeof(AnimalsManager));

            if (animal == null)
            {
                Debug.LogError(a.name + "has no animal attached");
            }
            else
            {
                animal.Behaviour();
                animal.Sound();
            }
        }
    }
}
