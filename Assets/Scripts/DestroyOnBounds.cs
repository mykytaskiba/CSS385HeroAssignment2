using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!WorldBounds.Get().WithinBounds(transform.position))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
