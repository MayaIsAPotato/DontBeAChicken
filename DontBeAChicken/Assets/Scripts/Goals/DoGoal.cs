using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoGoal :QuestGoal
{
    public GameObject ActionToDo
    {
        get => _action;
        set => _action = value;
    }

    [SerializeField] private GameObject _action;

    public override bool Complete()
    {
        bool status = _action ? true : false;
        Debug.Log("Done: " + status);
        return status;
    }
}
