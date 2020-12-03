
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] PlayerCharacter target;

    float speed = 4f;
    float followDistance = 2f;

    // Update is called once per frame
    void Update()
    {
        float distFromX = this.transform.position.x - target.transform.position.x;
        float distFromY = this.transform.position.y - target.transform.position.y;

        if (distFromX > followDistance)
        {
            this.transform.position -= new Vector3(speed, 0f, 0f) * Time.deltaTime;
        }

        else if (distFromX < -followDistance)
        {
            this.transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
        }

        if (distFromY > 2)
        {
            this.transform.position -= new Vector3(0f, speed, 0f) * Time.deltaTime;
        }
        else if (distFromY < -followDistance)
        {
            this.transform.position += new Vector3(0f, speed, 0f) * Time.deltaTime;
        }
    }
}