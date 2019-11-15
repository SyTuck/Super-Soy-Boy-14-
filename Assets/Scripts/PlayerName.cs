using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    private InputField input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent <InputField>();
        input.onValueChanged.AddListener(SavePlayerName);

        var savedName = PlayerPrefs.GetString("PlayerName");
        if (!string.IsNullOrEmpty(savedName))
        {
            input.text = savedName;
            GameManager.instance.playerName = savedName;
        }
        else
        {
            GameManager.instance.playerName = input.text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SavePlayerName(string playerName)
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        GameManager.instance.playerName = playerName;
    }
}
