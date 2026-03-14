using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //State Machine
    public enum GameState
    {
        Playing,
        Paused,
        Won,
        Lost
    }

    public GameState currentState;

    private void Awake()
    {
        Instance = this;
        currentState = GameState.Playing;
    }

    public void Playing()
    {
        Time.timeScale = 1f;
    }

    public void Win()
    {
        currentState = GameState.Won;
        Time.timeScale = 0f;
        UIController.Instance.ShowWin();
    }
}
