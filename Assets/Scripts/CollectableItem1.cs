using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableItem : MonoBehaviour
{


    [SerializeField] private AudioClip colect1;
    [SerializeField] private float cantidadPunts;
    [SerializeField] private Score punts;
    [SerializeField] private AudioClip coin;
    [SerializeField] private bool isPotion;
    [SerializeField] private AudioClip potion;
    private PlayerJump playerJump;

    // Inicializa el objeto
    private void Awake()
    {
        playerJump = GameObject.FindWithTag("Player").GetComponent<PlayerJump>();
    }
    // Si el jugador colisiona con el objeto, se destruye y se agrega al inventario
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (!isPotion)
            {
               coin = collision.GetComponent<AudioClip>();
               punts.SumaPunts(cantidadPunts);

            }
            else
            {
                potion = collision.GetComponent<AudioClip>();
                playerJump.ActivatePowerUp();
            }
               Destroy(gameObject);

            if (SoundController.Instance != null)
            {
                SoundController.Instance.PlaySound(colect1);
            }
            else
            {
                Debug.LogError("SoundController instance is null");
            }
        }
    }
}
