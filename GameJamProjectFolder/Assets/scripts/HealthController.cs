using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthController : MonoBehaviour
{
    public GameObject Heart1, Heart2, Heart3, Heart4;

    public void ResetHealth()
    {
        UpdateHealth(1, 1);
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        float percentage = currentHealth / (float)maxHealth;
        if (percentage >= 1f)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
        }
        else if(percentage >= 0.75f)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(false);
        }
        else if (percentage >= 0.5f)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
        }
        else if (percentage >= 0.25f)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
        }
        else
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
        }
    }
}
