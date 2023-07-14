using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public string playerName;
    public string bestPlayer;
    public int bestScore;
    public int score;

    private void Awake() {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    [System.Serializable]
    public class BestScore
    {
        public int bestScore = 0;
        public string name;
    }
    

    public void SaveData()
    {
        if(score > bestScore)
        {
        BestScore best = new BestScore();
        best.bestScore = score;
        best.name = playerName;

        string json = JsonUtility.ToJson(best);
        string path = Application.persistentDataPath + "/savefile.json";

        File.WriteAllText(path,json);
        }
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            BestScore best = JsonUtility.FromJson<BestScore>(json);

            //nameAndScoreText.text = $"Best Score: {best.bestScore}  Name: {best.name}";
            bestPlayer = best.name;
            bestScore = best.bestScore;
        }

    }
    
}
