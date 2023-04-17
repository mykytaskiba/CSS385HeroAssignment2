using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDamage : MonoBehaviour, IDamagable
{

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float fadeMultiplier = 0.8f;

    bool deathActivated = false;

    float health;
    public void onDamage(float damage)
    {
        health += -damage;

        if (health <= 0)
        {
            if (!deathActivated)
            {
                deathActivated = true;
                VisualUI.Get().OnDestroyEnemy();
                PlaneManager.Get().onPlaneDeath();
                GameObject.Destroy(gameObject);
            }
            return;
        }


        Color newColor = spriteRenderer.color;
        newColor.a *= fadeMultiplier;

        spriteRenderer.color = newColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
