using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionManager : MonoBehaviour
{
    private static NPCInteractionManager _instance;

    private GameObject _currentNPC; //the NPC we're currently interacting with; null if none.

    private void Awake()
    {
        if (!_instance)
            _instance = this;
    }

    public static NPCInteractionManager GetInstance() { return _instance; }

    public GameObject CurrentNPC() { return _currentNPC; }
}
