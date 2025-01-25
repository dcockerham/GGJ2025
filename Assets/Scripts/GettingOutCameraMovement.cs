using UnityEngine;

public class GettingOutCameraMovement : MonoBehaviour
{
    // player transform
    private Transform playerTransform;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerTransform = (GameObject.FindWithTag("Player")).GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }
}
