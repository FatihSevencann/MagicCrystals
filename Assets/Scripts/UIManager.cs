using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Image ObjMsc;
    public AudioSource MainMusic,Voice;
    public  AudioClip mergeVoice;
    public GameObject GameOverText,YouWonPanel,GameOverPanel,SettingsPanel,HomePanel;
    

    public static UIManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    #endregion
    
    public void  YouWon(){
  
        GameOverText.SetActive(false);
        GameOverPanel.SetActive(false);
        YouWonPanel.SetActive(true);
       
    }
    public void MainMenu()=>
        SceneManager.LoadScene(0);
    
    public void GameOver(){
        YouWonPanel.SetActive(false); 
        GameOverPanel.SetActive(true);
    }

    public void Settings()
    {
        HomePanel.SetActive(false);
        SettingsPanel.SetActive(true);
        
    }
    
    public void VoiceController()
    {
        Voice.PlayOneShot(mergeVoice);
        Voice.Pause();
    }
   
    public void musicStop(){

        Voice.mute=true;
        MainMusic.mute=true;
    } 
    
    public void PlayGame()=> SceneManager.LoadScene(2);
    public void Training()=> SceneManager.LoadScene(1);
    public void Restart()=> SceneManager.LoadScene(2);
    public void Close()=> SceneManager.LoadScene(2);
    public void Exit()=> Application.Quit();
    
}
