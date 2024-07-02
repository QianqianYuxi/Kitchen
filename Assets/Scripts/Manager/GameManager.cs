using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get;private set; }//实例化
    [SerializeField] private Player player;
    [SerializeField] private float waitingTimer=3;
    [SerializeField] private float countDownTimer=3;
    [SerializeField] private float gamePlayingTimer=60;
    private float gamePlayingTimeTotal;
    private bool isGamePause = false;

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnPaused;

    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver
    }

    private State state;

    private void Awake()
    {
        Instance = this;
        gamePlayingTimeTotal = gamePlayingTimer;//总时长赋值
    }
    private void Start()
    {
        TurnToWaitingToStart();
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        ToggleGamePause();
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingTimer -= Time.deltaTime;
                if (waitingTimer < 0)
                {
                    TurnToCountDown();
                }
                break;
            case State.CountDownToStart:
                countDownTimer -= Time.deltaTime;
                if (countDownTimer < 0)
                {
                    TurnToGamePlaying();
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0)
                {
                    TurnToGameOver();
                }
                break;
            case State.GameOver:
                break;
            default:
                break;
        }
    }

    private void TurnToWaitingToStart()
    {
        state = State.WaitingToStart;//初始化
        DisablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void TurnToCountDown()
    {
        state = State.CountDownToStart;
        DisablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }
    private void TurnToGamePlaying()
    {
        state = State.GamePlaying;
        EnablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }
    private void TurnToGameOver()
    {
        state = State.GameOver;
        DisablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void DisablePlayer()
    {
        player.enabled = false;
    }
    private void EnablePlayer()
    {
        player.enabled = true;
    }
    public bool IsWaitingToStartState()
    {
        return state == State.WaitingToStart;
    }
    public bool IsCountDownState()
    {
        return state == State.CountDownToStart;
    }
    public bool IsGamePlayingState()
    {
        return state == State.GamePlaying;
    }
    public bool IsGameOverState()
    {
        return state == State.GameOver;
    }
    public float GetCountDownTimer()
    {
        return countDownTimer;
    }
    public void ToggleGamePause()
    {
        //先切换暂停/继续状态
        isGamePause = !isGamePause;
        //再判断操作
        if (isGamePause)
        {
            Time.timeScale = 0;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1;
            OnGameUnPaused?.Invoke(this, EventArgs.Empty);
        }
    }
    public float GetGamePlayingTimer()
    {
        return gamePlayingTimer;
    }
    public float GetGamePlayingTimerNormalized()
    {
        return gamePlayingTimer / gamePlayingTimeTotal;//当前剩余时长占总时长比例
    }
}
