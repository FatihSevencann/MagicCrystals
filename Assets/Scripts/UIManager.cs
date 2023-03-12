using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables

    public static UIManager instance;

    [SerializeField] GameObject GameOverText, YouWonPanel, GameOverPanel, GamePanel,Homepanel,SettingsPanel;
    
    [SerializeField] AudioSource MainMusic,Voice;
    
    [SerializeField]  AudioClip mergeVoice,voice;
    
    #endregion

    private void Awake()
    {
        if(instance)
            return;
        instance = this;
    }

    public void  YouWon(){
  
        GameOverText.SetActive(false);
        GameOverPanel.SetActive(false);
        GamePanel.SetActive(false);
        YouWonPanel.SetActive(true);
       
    }
    
    public void GameOver(){
        YouWonPanel.SetActive(false); 
        GameOverPanel.SetActive(true);
    }
    
    public void musicStop(){

        Voice.mute=true;
        MainMusic.mute=true;
    
    } 
    
    public void VoiceController()
    {
        Voice.PlayOneShot(mergeVoice);
        Voice.Pause();
    }
  
    public void PlayGame()=> SceneManager.LoadScene(2);
    public void Training()=> SceneManager.LoadScene(1);
    public void Restart()=> SceneManager.LoadScene(2);
    public void Close()=> SceneManager.LoadScene(2);
    public void MainMenu() => SceneManager.LoadScene(0);
    public void Exit()=> Application.Quit();
    
    public void Settings(){

        Homepanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }


   
}
