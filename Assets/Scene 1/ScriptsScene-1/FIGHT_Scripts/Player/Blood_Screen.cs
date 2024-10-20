using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Blood_Screen : MonoBehaviour
{
    public Image HealBar;
    public GameObject Effects;

    private float previousHealth;
    private float currentHealth;

    void Start()
    {
        currentHealth = HealBar.fillAmount * 100f;
        previousHealth = currentHealth;
    }

    void Update()
    {
        currentHealth = HealBar.fillAmount * 100f;

        if (currentHealth < previousHealth)
        {
            StartCoroutine(ShowDamageEffect());
        }

        previousHealth = currentHealth;
    }

    private IEnumerator ShowDamageEffect()
    {
        Effects.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Effects.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss_Attack"))
        {
            HealBar.fillAmount -= 0.15f;
        }
    }
}
