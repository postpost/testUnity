using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private TMP_Text m_text;
    [SerializeField, Range(0, 100)] private int m_maxHealth;

    private void Awake()
    {
        m_text = GetComponent<TMP_Text>();
    }

    public void TakeDamage(int damage)
    {
        m_maxHealth -= damage;
    }

    private void Update()
    {
        m_text.text = m_maxHealth.ToString();
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(m_maxHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
