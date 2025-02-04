using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    float FollowSpeed = 2f;
    [SerializeField]
    Transform target;
    [SerializeField]
    GameObject ground;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, Mathf.Clamp(target.position.y + 5,-100, ground.transform.position.y + 10), -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
