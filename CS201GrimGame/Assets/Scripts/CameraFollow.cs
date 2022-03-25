using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;

    Vector3 cameraOffset;
    [SerializeField] float CameraSmooth = 75f;

    // Start is called before the first frame update
    void Start()
    {
        // needed to offset camera from being on top of camera
        cameraOffset = new Vector3(0.0f, 1.5f, -10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Player.position + cameraOffset;
        Vector3 SmoothedVector = Vector3.Lerp(transform.position, targetPosition, CameraSmooth * Time.fixedDeltaTime);
        transform.position = SmoothedVector;
    }
}
