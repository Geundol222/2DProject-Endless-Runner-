using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameSceneFlow : MonoBehaviour
{
    [SerializeField] private State curState;

    public UnityEvent OnReadyed;
    public UnityEvent OnPlayed;
    public UnityEvent OnGameOvered;

    private void Start()
    {
        Ready();
        GameManager.Data.CurScore = 0;
    }

    public void Ready()
    {
        curState = State.Ready;
        OnReadyed?.Invoke();
    }

    public void Play()
    {
        curState = State.Play;
        OnPlayed?.Invoke();
    }

    public void GameOver()
    {
        curState = State.GameOver;
        OnGameOvered?.Invoke();
    }

    public enum State
    {
        Ready,
        Play,
        GameOver
    }
}
