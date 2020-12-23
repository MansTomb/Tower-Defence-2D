using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelMenu : MonoBehaviour
{
    [SerializeField] private GameStateController gameState = null;
    [SerializeField] private TMP_Text text = null;
    
    private void Awake()
    {
        gameState.HealthChanged += CheckIfLose;
        gameState.LevelEnded += LevelPassed;
        
        gameObject.SetActive(false);
    }

    private void CheckIfLose(int amount)
    {
        if (amount <= 0)
        {
            GameStateController.PauseGame();
            gameObject.SetActive(true);
            text.SetText("You lose!");
        }
    }

    private void LevelPassed()
    {
        GameStateController.PauseGame();
        gameObject.SetActive(true);
        text.SetText("You win!");
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameState.HealthChanged -= CheckIfLose;
        gameState.LevelEnded -= LevelPassed;
        GameStateController.UnpauseGame();
    }
}
