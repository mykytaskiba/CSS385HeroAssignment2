using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float fadeMultiplier = 0.75f;

    [SerializeField]
    Vector3 positionVariation = new Vector3(15,15,0);


    float health;
    public void onDamage(float damage)
    {
        health += -damage;

        if (health <= 0)
        {
            health = maxHealth;
            newWaypointPosition();
            return;
        }


        Color newColor = spriteRenderer.color;
        newColor.a *= fadeMultiplier;

        spriteRenderer.color = newColor;
    }

    void newWaypointPosition()
    {
        bool validLocation = false;

        while (!validLocation)
        {
            Vector3 topLeft = gameObject.transform.position - positionVariation;
            Vector3 added = Random.value * 2 * positionVariation;

            transform.position = topLeft + added;

            validLocation = WorldBounds.Get().WithinBounds(transform.position);
        }
        spriteRenderer.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        transform.position = WorldBounds.Get().GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
