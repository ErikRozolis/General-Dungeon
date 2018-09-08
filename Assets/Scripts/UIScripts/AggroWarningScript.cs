using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AggroWarningScript : MonoBehaviour
{
    private TextMeshProUGUI aggroText;

    private void Awake()
    {
        aggroText = GetComponent<TextMeshProUGUI>();
    }

    // Use this for initialization
    void Start()
    {
        DungeonManager.Instance.OnAggressionLevelChanged += AggroLevelChanged;
    }

    private void AggroLevelChanged(int aggroLevel)
    {
        aggroText.text = "Aggro Level: " + aggroLevel.ToString();
    }
}
