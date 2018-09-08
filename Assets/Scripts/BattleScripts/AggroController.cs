using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private float aggroChance;

    private void Start()
    {
        aggroChance = 0.1f;
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(playerRB.velocity.magnitude > 0)
        {
            if(Random.Range(0f, 1f) < aggroChance)
                DungeonManager.Instance.IncreaseAggroLevel(1);
        }
    }
}
