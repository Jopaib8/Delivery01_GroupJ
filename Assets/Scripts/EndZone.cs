using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public void OnTriggerEnter2D (Collider2D collisions) // Si el jugador colisiona con la zona de muerte activa la funci�n de DeathScreen    
    {    
        DeathScreen();       
    }
    public void DeathScreen()
    {
        SceneManager.LoadSceneAsync(2);
    }


}