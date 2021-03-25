using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HealthBar : MonoBehaviour
{
    [Range(0, 100)]
    public int currentHealth = 0;

    [Range(1, 100)]
    public int maximumHealth = 1;

    public Slider healthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthBarSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void Reset()
    {
        healthBarSlider.value = maximumHealth;
        currentHealth = maximumHealth;
    }

    public void TakeDamage(int damage)
    {
        healthBarSlider.value -= damage;
        currentHealth -= damage;
    }

    public void SetHealth(int healthValue)
    {
        healthBarSlider.value = healthValue;
        currentHealth = healthValue;
    }
}
