using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private string playerName;
    [SerializeField] TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Best Score: \n" + MenuData.Instance.highestPlayerName + " : " + MenuData.Instance.playerScore;
    }

    public void StartNew()
    {
        playerName = transform.GetChild(2).GetComponent<InputField>().text;
        SavePlayerName();
        SceneManager.LoadScene(1);
        Debug.Log(playerName);
    }

    public void Exit()
    {
        MenuData.Instance.SaveHighscore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SavePlayerName()
    {
        if (MenuData.Instance.playerName == "" || playerName != "")
            MenuData.Instance.playerName = playerName;
    }
}
