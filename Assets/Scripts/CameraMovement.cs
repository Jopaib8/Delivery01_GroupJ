using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

        void Update()
        {
            Vector3 newPos = new Vector3(player.position.x, player.position.y + offset.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
        }
    
}
