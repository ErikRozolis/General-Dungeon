using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSlotController : MonoBehaviour
{

    private TextMeshPro SaveName;
    private TextMeshPro PlayerLevel;
    [SerializeField]
    private int slotNumber;
    private GameSlot slot;

    private void Awake()
    {
        TextMeshPro[] textList = GetComponentsInChildren<TextMeshPro>();
        foreach (var child in textList)
        {
            if (child.name == "SaveName")
            {
                SaveName = child;
            }
            else if (child.name == "PlayerLevel")
            {
                PlayerLevel = child;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        LoadSlotNames();
    }

    private void LoadSlotNames()
    {
        slot = SaveManager.Instance.GameSlots[slotNumber - 1];
        if (slot != null)
        {
            SaveName.text = slot.SaveName;
            PlayerLevel.text = slot.PlayerData.Stats.Level.ToString();
        }
        else
        {
            SaveName.text = "New Game";
            PlayerLevel.text = "Level 1";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.FromPlayer())
        {
            if (slot == null)
            {
                SaveManager.Instance.CreateNewSave(slotNumber);
            }
            else
            {
                GameManager.Instance.LoadGameSlot(SaveManager.Instance.GameSlots[slotNumber - 1]);
                GameManager.Instance.LoadDungeon();
            }
        }
    }
}
