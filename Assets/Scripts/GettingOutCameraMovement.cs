using UnityEngine;

public class GettingOutCameraMovement : MonoBehaviour
{
    // player transform
    private Transform playerTransform;
    private Transform cameraTransform;  

    // the velocity of the camera 
    [SerializeField] private float cameraVelocity = 30;
    // the limit of the camera's position
    [SerializeField] private float maxDistanceFromPlayer = 4.0f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerTransform = (GameObject.FindWithTag("Player")).GetComponent<Transform>();
       cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
	float directionVelocity = Input.GetAxis("Horizontal") * cameraVelocity;
	/*cameraTransform.position = new Vector3(cameraTransform.position.x + (Time.deltaTime * directionVelocity), cameraTransform.position.y, cameraTransform.position.z);
	// adjust to camera Transform
	if (cameraTransform.position.x > playerTransform.position.x + maxDistanceFromPlayer)
	{
		cameraTransform.position = new Vector3(playerTransform.position.x + maxDistanceFromPlayer, cameraTransform.position.y, cameraTransform.position.z);	
	}
	if (cameraTransform.position.x < playerTransform.position.x - maxDistanceFromPlayer)
	{
		cameraTransform.position = new Vector3(playerTransform.position.x - maxDistanceFromPlayer, cameraTransform.position.y, cameraTransform.position.z);
	}*/

	cameraTransform.position = new Vector3(playerTransform.position.x + maxDistanceFromPlayer, cameraTransform.position.y, cameraTransform.position.z);	
    }
}
