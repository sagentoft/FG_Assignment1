using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar;


    private float currentHealth;

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    private MeshRenderer meshRenderer;
    private Color originalColor;
    private float flashTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
        healthBar.fillAmount = 1f;
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(DamageFlash());
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            transform.position = initialPosition;
            transform.eulerAngles = initialRotation;

            gameObject.SetActive(false);
        }
    }

    private IEnumerator DamageFlash()
    {
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        meshRenderer.material.color = originalColor;
    }

}
