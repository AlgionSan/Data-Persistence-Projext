using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public string playerName;

    public InputField nameInput;


    public void OnEndEdit()
    {
        playerName = nameInput.text;
        Debug.Log("Player's Name: " +  playerName);
    
    
    }

    

    public void StartGame() 
    {
        SceneManager.LoadScene(1);

    
    
    }

}
