using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance { get; private set; }

    [SerializeField] private Button quitButton;
    [SerializeField] private Button startButton;

    private void Awake()
    {
        Instance = this;
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
            Debug.Log("Quit");
        });
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
            Debug.Log("Start");
        });
    }
}
