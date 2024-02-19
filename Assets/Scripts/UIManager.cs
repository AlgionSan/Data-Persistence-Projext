using System.Collections;
using System.Collections.Generic;

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

    private int score = 0;

    private void Awake()
    { 
        if(Instance !=null)
        {
            Destroy(gameObject);
            return;


        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //im not sure why i put this here on awake hmmm...
        bestScoreMenu.text = "Best Score : " + playerName + " : " + score;
        bestScoreMain.text = "Best Score : " + playerName + " : " + score;



    }

    void Update()
    {

    
    
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
        
    
    }


}
