using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private PlayerDie playerDie;

    public void Start () 
    {       
        playerDie = GameObject.FindWithTag("Player").GetComponent<PlayerDie>();
    }

    public void OnTriggerEnter2D (Collider2D collisions) // Si el jugador colisiona con la zona de muerte activa la funci�n de DeathScreen    
    {    
        StartCoroutine(DeathScreen());   
        Debug.Log("Player has died");        
    }
    public IEnumerator DeathScreen()
    {
        playerDie.PlayerDeath();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadSceneAsync(2);
    }


}