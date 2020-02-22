using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverGoal : QuestGoal
{
    public GameObject itemToDeliver 
    { 
        get => _itemToDeliver;
        set => _itemToDeliver = value; 
    }

    [SerializeField] private GameObject _itemToDeliver;

    public GameObject NPCtoDeliver
    {
        get => _npcToDeliver;
        set => _npcToDeliver = value;
    }

    [SerializeField] private GameObject _npcToDeliver;

    public override bool Complete()
    {
        bool status = _itemToDeliver && NPCInteractionManager.GetInstance().CurrentNPC() == _npcToDeliver;
        Debug.Log("Item delivered: " + status);
        return status;
    }
}
