using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //1
    public static GameManager Instance;
    //2
    public int gold;
    //3
    public int waveNumber;
    //4
    public int escapedEnemies;
    //5
    public int maxAllowedEscapedEnemies = 5;
    //6
    public bool enemySpawningOver;
    //7
    public AudioClip gameWinSound;
    public AudioClip gameLoseSound;
    //8
    private bool gameOver;

    //1
    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        //2
        if (!gameOver && enemySpawningOver)
        {
            // Check if no enemies left, if so win game
            //3
            if (EnemyManager.Instance.Enemies.Count == 0)
            {
                OnGameWin();
            }
        }
        // When ESC is pressed, quit to the title screen
        //4
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitToTitleScreen();
        }
    }
    //5
    private void OnGameWin()
    {
        AudioSource.PlayClipAtPoint(gameWinSound,
        Camera.main.transform.position);
        gameOver = true;
    }
    //6
    public void QuitToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    //1
    public void OnEnemyEscape()
    {
        escapedEnemies++;

        if (escapedEnemies == maxAllowedEscapedEnemies)
        {
            // Too many enemies escaped, you lose the game
            OnGameLose();
        }
    }
    //2
    private void OnGameLose()
    {
        gameOver = true;
        AudioSource.PlayClipAtPoint(gameLoseSound,
        Camera.main.transform.position);
        EnemyManager.Instance.DestroyAllEnemies();
        WaveManager.Instance.StopSpawning();
    }
    //3
    public void RetryLevel()
    {
        SceneManager.LoadScene("Game");
    }


}
