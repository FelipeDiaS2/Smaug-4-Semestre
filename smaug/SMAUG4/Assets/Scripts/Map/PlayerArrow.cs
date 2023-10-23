using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    public float movementDistance = 2.0f;
    public float movementSpeed = 2.0f;

    private Vector2 initialPosition;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveUpDown());
    }

    IEnumerator MoveUpDown()
    {
        while (true)
        {
            float targetY = movingUp ? initialPosition.y + movementDistance : initialPosition.y - movementDistance;
            Vector2 targetPosition = new Vector2(initialPosition.x, targetY);
            float distance = Vector2.Distance(transform.position, targetPosition);

            while (distance > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                distance = Vector2.Distance(transform.position, targetPosition);
                yield return null;
            }

            movingUp = !movingUp;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
