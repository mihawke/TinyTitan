using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject WinPanel;

    private void Awake()
    {
        Instance = this;
        restartButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        });
        quitButton.onClick.AddListener(() =>
               {
                   SceneManager.LoadScene(0);
               });
        WinPanel.SetActive(false);
    }

    public void ShowWin()
    {
        WinPanel.SetActive(true);
    }
}
