using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject GameOverUI;
    public Text MoveSpeedText;

	// Use this for initialization
	void Start () {
        GameOverUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        MoveSpeedText.text = "속도 : " + player.GetComponent<Player>().moveSpeed.ToString("0.00");

        if (player.transform.position.y < 0.5f)
            GameOver();

        if (Input.GetKeyDown(KeyCode.R) && GameOverUI.activeSelf == true)
        {
            GameOverUI.SetActive(false);
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
	}

    void GameOver()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
    }
}
