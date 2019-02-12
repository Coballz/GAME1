using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;
    private Renderer renderer;
    private bool playerCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        handleColor(playerCollided);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            playerCollided = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Player" && playerController.getScore() != 3)
            playerCollided = false;
    }

    void handleColor(bool playerCollided)
    {
        if (playerCollided && playerController.getScore() == 3)
            renderer.material.color = Color.green;
        else if (playerController.getScore() == 3)
            renderer.material.color = Color.red;
        else renderer.material.color = Color.blue;
    }
}
