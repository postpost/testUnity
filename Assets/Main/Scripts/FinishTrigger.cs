using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject m_finishCanvas;

    [SerializeField] private Button m_restartBtn;
    [SerializeField] private Button m_exitBtn;

    private void Start()
    {
        m_finishCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_finishCanvas.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void OnRestartBtnClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void OnExitBtnClicked()
    {
        #if UNITY_EDITOR
        // Application.Quit() works in "run" mode
        // UnityEditor.EditorApplication.isPlaying is set to false to finish the game
            ResetEditorGame();
        #else
        Application.Quit();
        #endif
    }

    private void ResetEditorGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        m_finishCanvas.SetActive(false);
    }
}
