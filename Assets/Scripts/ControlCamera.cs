using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    [SerializeField] private Transform targetPokemon;
    [SerializeField] private float speedMoveCam = 5;
    
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            RotateCameraAroundTarget();
        }
        
        ApproachingTheTarget();
    }

    private void RotateCameraAroundTarget()
    {
        float rotationX = Input.GetAxis("Mouse X");

        if (rotationX != 0)
        {
            transform.RotateAround(targetPokemon.position, transform.up, -rotationX * speedMoveCam);
        }
    }

    private void ApproachingTheTarget()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        float distance = Vector3.Distance(transform.position, targetPokemon.position);

        if (zoom != 0)
        {
            if (distance > 3)
            {
                zoom = zoom * speedMoveCam * Time.deltaTime;
                Vector3 directionMoveCam = Vector3.forward * zoom;
                transform.Translate(directionMoveCam);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.0015f);
            }
        }
    }
}
