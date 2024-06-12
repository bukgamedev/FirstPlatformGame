using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image TotalHealthBar;
    [SerializeField] Image CurrentHealthBar;
    private void Start()
    {
        TotalHealthBar.fillAmount = playerHealth.CurrentHealth / 10;
    }
    private void Update()
    {
        CurrentHealthBar.fillAmount = playerHealth.CurrentHealth / 10;
    }
}
