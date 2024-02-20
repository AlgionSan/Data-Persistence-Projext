using System.Collections;
using System.Collections.Generic;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject menuPanel;
    public GameObject mainUI;
    public GameObject gameOverText;
    public Text bestScoreMain;
    public Text bestScoreMenu;



    public string playerName;

    public InputField nameInput;



    public int score = 0;

    private void Awake()
    { 
        if(Instance !=null)
        {
            Destroy(gameObject);
            return;


        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        


        LoadScore();
        //im not sure why i put this here on awake hmmm...
        bestScoreMenu.text = "Best Score : " + playerName + " : " + score;
        bestScoreMain.text = "Best Score : " + playerName + " : " + score;

    }



    public void setGameOverActive()
    {

        gameOverText.SetActive(true);

    }

    public void setGameOverInactive()
    {

        gameOverText.SetActive(false);

    }

    public void OnEndEdit()
    {
        playerName = nameInput.text;
        Debug.Log("Player's Name: " +  playerName);
        bestScoreMenu.text = "Best Score : " + playerName + " : " + score;
        
    }

    

    public void StartGame() 
    {
        SceneManager.LoadScene(1);

        menuPanel.SetActive(false);
        mainUI.SetActive(true);
        bestScoreMain.text = "Best Score : " + playerName + " : " + score;

    }

    public void UpdateBestScore()
    {
        bestScoreMain.text = "Best Score : " + playerName + " : " + score;

    }

    public void ExitGame()
    {


        //using conditional compiling... '#' are not exactly code but rather instructions for the compiler
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif


    }

    //why is class SaveData not SaveData(){} but rather SaveData{}.. is it because its a class and not a method? 
    //if so im not sure but in OOP if i recall correctly, some classes takes on parameters? or not? damn i forgor
    [System.Serializable]
    class SaveData
    {
  
        public int score;
        public string name;

    
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.score = score;
        data.name = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);



    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.score;
        
        }


    }


}
