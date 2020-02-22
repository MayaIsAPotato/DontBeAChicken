using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType { Retrieve, Deliver, Goto, Do }

public abstract class QuestGoal : MonoBehaviour
{
    public QuestType questType;

    //public Transform Target { get { return _target; } set { _target = value; } }

    //[SerializeField] private Transform _target;

    public abstract bool Complete();
}

