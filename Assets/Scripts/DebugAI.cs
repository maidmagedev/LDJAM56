using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class DebugAI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public NavMeshAgent agent;
    // Start is called efore the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = agent.remainingDistance.ToString();
    }
}
