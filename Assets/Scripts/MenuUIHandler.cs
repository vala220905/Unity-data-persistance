using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{

    //[SerializeField] private TextMeshProUGUI inputName;
    //[SerializeField]public InputField inputName;
    [SerializeField]private TMP_InputField inputName;
    [SerializeField]private TextMeshProUGUI bestScore;


    private void Start() {
        GameManager.Instance.LoadData();
        bestScore.text = "Best Score: " + GameManager.Instance.bestScore.ToString();
    }

    public void StartNewGame()
    {
        if(!string.IsNullOrEmpty(inputName.text))
        {
            SceneManager.LoadScene(1);
            GameManager.Instance.playerName = inputName.text;
        }
    
    
    }
}
