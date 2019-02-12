using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScript : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Rigidbody>().useGravity == false)
        {
            player.transform.Translate(new Vector3(0,-0.01f,0) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
