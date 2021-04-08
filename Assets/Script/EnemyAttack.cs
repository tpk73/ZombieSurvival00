﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyAttack : MonoBehaviour
{
    NavMeshAgent deathSphere;

    public Transform goHere;

    // Start is called before the first frame update
    void Start()
    {
        deathSphere = GetComponent<NavMeshAgent>();
        SetAttackDestination();
    }

    // Update is called once per frame
    void Update()
    {
        SetAttackDestination();
    }

    void SetAttackDestination()
    {
        Vector3 targetVector = goHere.transform.position;
        deathSphere.SetDestination(targetVector);
    }
}
