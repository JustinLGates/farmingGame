using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerCharacter player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting controller..");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > .5f || Input.GetAxisRaw("Horizontal") < -.5f)
        {
            player.transform.position += new Vector3(player.speed, 0f, 0f) * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") > .5f || Input.GetAxisRaw("Vertical") < -.5f)
        {
            player.transform.position += new Vector3(0f, player.speed, 0f) * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) { Debug.Log("Fire in the hole"); }
    }
}