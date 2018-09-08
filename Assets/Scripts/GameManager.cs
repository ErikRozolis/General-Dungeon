using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    [SerializeField]
    private GameSlot gameSlot;

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

    public void LoadDungeon()
    {
        StartCoroutine(AsyncLoadDungeon());
    }

    private IEnumerator AsyncLoadDungeon()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Dungeon");
        yield return async;
        DungeonManager.Instance.Respawn();
    }

    private IEnumerator AsyncLoadBattleScreen()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Battle");
        yield return async;
    }

    public void LoadGameSlot(GameSlot slot)
    {
        gameSlot = slot;
    }
}
