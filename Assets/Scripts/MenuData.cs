using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuData : MonoBehaviour
{
    public static MenuData Instance;
    public string playerName;
    public string highestPlayerName;
    public int playerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadHighscore();
    }

    [System.Serializable]
    class SaveData
    {
        public string highestPlayerName;
        public int playerScore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highestPlayerName = highestPlayerName;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestPlayerName = data.highestPlayerName;
            playerScore = data.playerScore;
        }
    }
}
