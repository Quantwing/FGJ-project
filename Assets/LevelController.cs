﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState { Menu, GameStart, GamePlay, GameEnd }

public class LevelController : MonoBehaviour
{  
    public static GameState gameState;
    public static int killCount;

    public GameState gameStateDisplay;
    public float levelTimeStart;
    public float levelTimeCurrent;
    public Text winText;

    private bool gameOver = false;
    private float fade;
    private float fadeSpeed = 1f;

    void Start()
    {
        gameState = gameStateDisplay;
    }

    void Update()
    {
        MenuInput();

        if (gameState == GameState.GameStart)
        {
            levelTimeCurrent = levelTimeStart;
        }
        else if (gameState == GameState.GamePlay && levelTimeCurrent > 0f)
        {
            levelTimeCurrent -= Time.deltaTime;
            if (levelTimeCurrent <= 0f)
            {
                levelTimeCurrent = 0f;
                gameOver = true;
                StartCoroutine(PlayerWin());
            }
        }
        if (gameOver)
        {
            fade = Mathf.Clamp01(fade + fadeSpeed * Time.deltaTime);

            winText.color = new Color(winText.color.r, winText.color.b, winText.color.g, fade);
        }
        else
        {
            fade = Mathf.Clamp01(fade - fadeSpeed * Time.deltaTime);

            winText.color = new Color(winText.color.r, winText.color.b, winText.color.g, fade);
        }
    }

    IEnumerator PlayerWin()
    {
        yield return new WaitForSeconds(3f);
        gameOver = false;
        gameState = GameState.GameEnd;
    }

    void MenuInput()
    {
        /*switch (gameState)
        {
            case GameState.Menu:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameState = GameState.GameStart; 
                }
                break;

            case GameState.GamePlay:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameState = GameState.GameEnd;
                }
                break;

            default:
                break;
        }*/
    }
}
