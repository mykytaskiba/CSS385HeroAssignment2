using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField]
    float velocity = 45;
    [SerializeField]
    float targetDistance = 0.2f;

    [SerializeField]
    float rotationSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        NewTarget();
        VisualUI.Get().OnSpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaneManager.Get().useMovement)
        {
            Move();
            Rotate();
        }
    }

    int lastTarget = -1;
    Vector3 target;

    void Move()
    {


        float movementAmount = velocity * Time.deltaTime;

        transform.position = transform.position + transform.up * movementAmount;

        float distance = (target - transform.position).magnitude;
        if (distance < targetDistance)
        {
            NewTarget();
        }

    }

    float currentRotation;
    void Rotate()
    {
        Vector3 difference = target - transform.position;
        float targetAngle = Mathf.Rad2Deg*Mathf.Atan2(difference.y, difference.x)-90;
        currentRotation = Mathf.LerpAngle(currentRotation, targetAngle, rotationSpeed*Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
    void NewTarget()
    {
        target = WaypointManager.Get().GetNextTarget(ref lastTarget);
    }

    private void OnDestroy()
    {
    }
}
