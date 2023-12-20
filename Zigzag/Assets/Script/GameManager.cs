using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerGO;
    private Transform playerTF;
    private Player player;
    public GameObject GameOverUI;
    public Text MoveSpeedText;

    private const float gameOverHeight = 0.7f;

    private void Start()
    {
        playerTF = playerGO.transform;
        player = playerGO.GetComponent<Player>();
        GameOverUI.SetActive(false);
    }

    private void Update()
    {
        UpdateMoveSpeed();
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (playerTF.position.y < gameOverHeight)
            GameOver();
    }

    private void UpdateMoveSpeed()
    {
        MoveSpeedText.text = "속도 : " + player.MoveSpeed.ToString("0.00");
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
    }

    public void Restart()
    {
        GameOverUI.SetActive(false);
        SceneManager.LoadScene(0);
        SceneManager.sceneLoaded += (scene, mode) => { Time.timeScale = 1; };
    }
}
