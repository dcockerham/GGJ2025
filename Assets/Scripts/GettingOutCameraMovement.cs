using UnityEngine;

public class GettingOutCameraMovement : MonoBehaviour
{
    // player transform
    private Transform playerTransform;
    private Transform cameraTransform;  
	// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerTransform = (GameObject.FindWithTag("Player")).GetComponent<Transform>();
       cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
	cameraTransform.position = new Vector3(playerTransform.position.x + 4.0f, cameraTransform.position.y, cameraTransform.position.z);	
    }
}
