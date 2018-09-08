using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveNameEntry : MonoBehaviour {


    [SerializeField]
    private GameObject placeholder;
    [SerializeField]
    private GameObject textObj;
    [SerializeField]
    private GameObject saveNameBox;
    private int slotNumber;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            SaveManager.Instance.ResetGameSlot(textObj.GetComponent<Text>().text, slotNumber);
        }
	}

    public void EnableSaveNameEntry(int slotNum)
    {
        slotNumber = slotNum;
        saveNameBox.SetActive(true);
    }
}
