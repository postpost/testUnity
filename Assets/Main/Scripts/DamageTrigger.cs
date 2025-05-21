using TMPro;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private int m_damage;
    [SerializeField] private PlayerStats m_playerStats;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            m_playerStats.TakeDamage(m_damage);
        }
    }
}
