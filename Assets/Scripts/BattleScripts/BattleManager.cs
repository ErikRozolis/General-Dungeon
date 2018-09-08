using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public static BattleManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
    }

    public void EnterBattle()
    {
        DungeonManager.Instance.gameObject.SetActive(false);
    }

    public void EndBattle()
    {
        DungeonManager.Instance.gameObject.SetActive(true);
        DungeonManager.Instance.ResetBattleAggroLevel();
    }
}
