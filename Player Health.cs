using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool IsDead = false; // put this variable in the game manager script
    public float MaxHealth;
    public float CurrentHealth;
    public Slider HealthSlider;
    public Vector3 SpawnPoint;

    private void Start()
    {
        IsDead = false;
        GetComponent<Renderer>().enabled = true;
        CurrentHealth = MaxHealth;
        HealthSlider.maxValue = MaxHealth;
    }

    private void Update()
    {
        HealthSlider.value = CurrentHealth;

        if (CurrentHealth <= 0)
            StartCoroutine(Death());
    }

    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
    }

    IEnumerator Death()
    {
        IsDead = true;
        GetComponent<Renderer>().enabled = false;
        transform.position = SpawnPoint;
        yield return new WaitForSeconds(3);
        GetComponent<Renderer>().enabled = false;
        CurrentHealth = MaxHealth;
        IsDead = false;
    }
}
