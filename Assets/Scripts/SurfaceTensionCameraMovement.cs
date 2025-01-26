using UnityEngine;

public class SurfaceTensionCameraMovement : MonoBehaviour
{
    // player transform
    private Transform playerTransform;
    private Transform cameraTransform;
    public float boundary = 0.2f;
    public float speed = 1f;
    public float lerpSpeed = 5f;
    Camera cam;
    [SerializeField] private Gradient backgroundGradient;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = (GameObject.FindWithTag("Player")).GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = new Vector3(cameraTransform.position.x, playerTransform.position.y + 1.5f, cameraTransform.position.z);
        cam.backgroundColor = backgroundGradient.Evaluate(playerTransform.position.y/100f);
        //Vector3 viewPos = cam.WorldToViewportPoint(playerTransform.position);

        //float newPos = cameraTransform.position.y;

        //if (viewPos.y >= 1 - boundary)
        //{
        //    newPos += speed * Time.deltaTime;
        //}
        //else if (viewPos.y <= boundary)
        //{
        //    newPos -= speed * Time.deltaTime;
        //}

        //Vector3 newPosition = new Vector3(cameraTransform.position.x, newPos, cameraTransform.position.z);
        ////Trans.position = Vector3.Lerp(Trans.position, _cam, CamMoveSpeed * Time.deltaTime);

        //cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPosition, lerpSpeed);
    }
}
