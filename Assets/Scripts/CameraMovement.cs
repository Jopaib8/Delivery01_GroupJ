using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;       // Transform del jugador
    public Vector3 offset;         // Offset entre la c�mara y el jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento

    void Start()
    {
        // Encuentra al jugador autom�ticamente si no est� asignado en el Inspector
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Calcula el offset inicial en relaci�n con la posici�n inicial del jugador
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posici�n deseada de la c�mara
            Vector3 targetPosition = player.position + offset;

            // Suaviza el movimiento de la c�mara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Asigna la nueva posici�n a la c�mara
            transform.position = smoothedPosition;
        }
    }
}
