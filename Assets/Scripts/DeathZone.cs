using UnityEngine;

public class DeathZoneRespawn : MonoBehaviour
{
    [SerializeField] private Vector2 RespawnPoint;

    public void Start () 
    {
        // Guardamos la posici�n de respawn
        RespawnPoint = transform.position;
    }

    public void OnTriggerEnter2D (Collider2D collisions) 
    {
        // Si el jugador colisiona con la zona de muerte activa la funci�n de Respawn
        if (collisions.CompareTag("DeathZone")) {
            Respawn();
        }
    }
   // Transforma al jugador a la posici�n de respawn
    public void Respawn () {
        transform.position = RespawnPoint;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        
    }
}