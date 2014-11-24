using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    GameObject player;
    public GameObject cameraTarget;

    float smoothTime = .1f;
    float cameraHeight = 2.5f;
    public bool cameraFollowX { get; private set; }
    public bool cameraFollowY { get; private set; }
    public bool cameraFollowHeight { get; private set; }

    Vector2 velocity;
    Transform cameraTransform;

    void Start()
    {
        
        cameraFollowX = true;
        cameraFollowY = true;
        cameraFollowHeight = false;
        
        cameraTransform = transform;
        
    }

    void Update()
    {
        if(cameraFollowX)
        {
            float newPosition = Mathf.SmoothDamp(cameraTransform.position.x, cameraTarget.transform.position.x, ref velocity.x, smoothTime);
            cameraTransform.position = new Vector3(newPosition, cameraTransform.position.y, -10);
        }
        if(cameraFollowY)
        {
            float newPosition = Mathf.SmoothDamp(cameraTransform.position.y, cameraTarget.transform.position.y, ref velocity.y, smoothTime);
            cameraTransform.position = new Vector3(cameraTransform.position.x, newPosition, -10);
        }
        if(!cameraFollowY && cameraFollowHeight)
        {

        }
    }


}
