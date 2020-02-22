using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{ 
    public string Name { get { return _name; } private set { _name = value; } }
    public string Description { get { return _description; } private set { _description = value; } }

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private string[] _messages;
    [SerializeField] private GameObject[] _goals;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            foreach (GameObject g in _goals)
            {
                QuestGoal q = (QuestGoal)g.GetComponent(typeof(QuestGoal));

                if (q == null)
                {
                    Debug.LogError(g.name + " has no quest goals attached!!!");
                }
                else
                {
                    q.Complete();
                }
            }
        }
    }

}
