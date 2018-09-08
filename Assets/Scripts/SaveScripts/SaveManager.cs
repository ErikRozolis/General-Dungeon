using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveManager Instance { get; private set; }

    private SaveData saveData;
    public GameSlot[] GameSlots;
    private SaveNameEntry saveNameEntry;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            saveNameEntry = GetComponent<SaveNameEntry>();
            LoadAllData();
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadAllData()
    {
        string saveFileName = Application.persistentDataPath + "/SaveData.dat";
        if (File.Exists(saveFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(saveFileName, FileMode.Open);
            saveData = (SaveData)bf.Deserialize(fs);
            GameSlots = saveData.GameSlots;
            fs.Close();
        }
        else
        {
            saveData = new SaveData();
            GameSlots = new GameSlot[3];
            saveData.GameSlots = GameSlots;
            SaveAllData();
        }
    }

    public void SaveAllData()
    {
        string saveFileName = Application.persistentDataPath + "/SaveData.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(saveFileName, FileMode.Create);
        bf.Serialize(fs, saveData);
        fs.Close();
    }

    public void ResetGameSlot(string saveName, int slotNum)
    {
        saveData.GameSlots[slotNum - 1] = new GameSlot(saveName);
        SaveAllData();
        GameManager.Instance.LoadGameSlot(saveData.GameSlots[slotNum-1]);
        GameManager.Instance.LoadDungeon();
    }

    public void CreateNewSave(int slotNum)
    {
        saveNameEntry.EnableSaveNameEntry(slotNum);
    }
}
