using System.Collections.Generic;
using UnityEngine;

public enum AgentType
{
    Carnivorous,
    herbivorous,
    scavenger
}

public class Agent : MonoBehaviour
{
    //AgentType
    [Header("AgentType")]
    [SerializeField] private AgentType agentType;

    //Movement
    [Header("Movement")]
    [SerializeField] private float speed = 3;
    [SerializeField] private float reachDistance = 0.01f;
    [SerializeField] private bool isTargetReach = false;
}
