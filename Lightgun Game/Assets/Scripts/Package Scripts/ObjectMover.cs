using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform _object;
    public Transform[] positions;
    public float speed = 1f;
    private int posIndex = 0;
    private IEnumerator coroutine;

    public void Move()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        posIndex++;
        if (posIndex == positions.Length)
            posIndex = 0;

        coroutine = MoveCoroutine(positions[posIndex]);
        StartCoroutine(coroutine);
    }

    IEnumerator MoveCoroutine(Transform destination)
    {
        while (true)
        {
            var direction = destination.position - _object.position;
            _object.position += direction.normalized * Time.deltaTime * speed;

            if (direction.magnitude < Time.deltaTime * speed)
            {
                _object.position = destination.position;
                break;
            }

            yield return null;
        }
        coroutine = null;
    }
}
