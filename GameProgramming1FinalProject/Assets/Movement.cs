using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 2f;
    private Vector3 startPosition;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Vector3.Distance(startPosition, transform.position) >= distance)
        {
            movingRight = !movingRight;
        }
    }

}
