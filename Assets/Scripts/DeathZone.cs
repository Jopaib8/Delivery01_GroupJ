using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    

    public void Start () 
    {       
        
    }

    public void OnTriggerEnter2D (Collider2D collisions) // Si el jugador colisiona con la zona de muerte activa la funci�n de DeathScreen    
    {            
            DeathScreen();     
            Debug.Log("Player has died");        
    }
    public void DeathScreen()
    {
        SceneManager.LoadSceneAsync(2);
    }


}