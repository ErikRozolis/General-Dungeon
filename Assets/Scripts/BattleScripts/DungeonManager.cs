using System;
using UnityEngine;

public class DungeonManager : MonoBehaviour {

    public static DungeonManager Instance { get; private set; }
    private int aggroLevel;
    [SerializeField]
    private int maxAggroLevel = 100;
    private int battleAggroLevel;

    public event Action<int> OnAggressionLevelChanged;

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
        ResetBattleAggroLevel();
    }

    public void IncreaseAggroLevel(int aggroIncrease)
    {
        if(aggroLevel < maxAggroLevel)
        {
            aggroLevel += aggroIncrease;
            if (OnAggressionLevelChanged != null)
            {
                OnAggressionLevelChanged(aggroLevel);
            }
        }
        else
        {
            aggroLevel = maxAggroLevel;
            OnAggressionLevelChanged(aggroLevel);
        }
        AttemptBattle();
    }

    public void ResetBattleAggroLevel()
    {
        battleAggroLevel = UnityEngine.Random.Range(0, maxAggroLevel);
    }

    private void AttemptBattle()
    {
        if(aggroLevel >= battleAggroLevel)
        {
            BattleManager.Instance.EnterBattle();
        }
    }

    public void Respawn()
    {
        transform.GetChild(0).transform.position = Vector3.zero;
    }

}
