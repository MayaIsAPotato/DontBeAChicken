using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveGoal : QuestGoal
{
    
    public GameObject itemToRetrieve
    {
        get { return _itemToRetrieve; }
        set { _itemToRetrieve = value; }
    }

    [SerializeField] private GameObject _itemToRetrieve;

    public override bool Complete()
    {
        bool status = ChickenController.HasItem(itemToRetrieve);

        Debug.Log("Retrieve Status: " + status); 
        return status;
    }
}
