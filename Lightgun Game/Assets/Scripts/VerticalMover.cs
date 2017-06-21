using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// </summary>
public class VerticalMover : MonoBehaviour {

    private bool moving;
    private float speed = 1f;
    private float movementTarget;
    public float targetHeight;
    private float startHeight = 0f;
    private float movementDistance, maxMovementDistance;
    public Vector2 randomTargetOffset;
    public Vector2 randomMovementDelay;
    public AnimationCurve movementSpeed;

	void Start () {
        startHeight = transform.position.y;
        targetHeight += Random.Range(randomTargetOffset.x, randomTargetOffset.y);
	}
    public void MoveToTargetPos()
    {
        StartCoroutine(MoveCoroutine(targetHeight));
    }
    public void MoveToStartPos()
    {
        StartCoroutine(MoveCoroutine(startHeight));
    }

    private IEnumerator MoveCoroutine(float target)
    {
        yield return new WaitForSeconds(Random.Range(randomMovementDelay.x, randomMovementDelay.y));

        moving = true;
        movementTarget = target;
        movementDistance = Mathf.Abs(transform.position.y - movementTarget);
        maxMovementDistance = movementDistance;
    }

    void Update()
    {
        if (moving)
        {
            float direction = Mathf.Sign(movementTarget - transform.position.y);
            speed = movementSpeed.Evaluate(1 - movementDistance / maxMovementDistance);
            speed = Mathf.Max(speed, 0.01f);
            transform.position += Vector3.up * Time.deltaTime * direction * speed;
            movementDistance -= Time.deltaTime * speed;

            if (movementDistance <= 0)
            {
                moving = false;
                transform.position = new Vector3(transform.position.x, movementTarget, transform.position.z);
            }
        }
    }
}
