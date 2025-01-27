using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

        void Update()
        {
            Vector3 newPos = new Vector3(player.position.x, player.position.y + offset.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
        }
    
}
