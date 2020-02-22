using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoGoal : QuestGoal
{
    
    public GameObject destination 
    { 
        get => _destination;
        set => _destination = value; 
    }

    [SerializeField] private GameObject _destination;

    public override bool Complete()
    {
        bool status = _destination ? true : false;
        Debug.Log("Reached destination: " + status);
        return status;
    }
}
