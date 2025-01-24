using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;       // Transform del jugador
    public Vector3 offset;         // Offset entre la cámara y el jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento

    void Start()
    {
        // Encuentra al jugador automáticamente si no está asignado en el Inspector
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Calcula el offset inicial en relación con la posición inicial del jugador
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posición deseada de la cámara
            Vector3 targetPosition = player.position + offset;

            // Suaviza el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Asigna la nueva posición a la cámara
            transform.position = smoothedPosition;
        }
    }
}
