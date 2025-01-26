using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ColletableItem : MonoBehaviour
{


    [SerializeField] private AudioClip colect1;
    [SerializeField] private float cantidadPunts;
    [SerializeField] private Score punts;
    [SerializeField] private AudioClip coin;




    // Inicializa el objeto
    private void Awake()
    {
    }
    // Si el jugador colisiona con el objeto, se destruye y se agrega al inventario
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coin = collision.GetComponent<AudioClip>();

            

            punts.SumaPunts(cantidadPunts);

            Debug.Log("Player collided with collectible");

            Destroy(gameObject);
            
            /*if (SoundController.Instance != null)
            {
                SoundController.Instance.EjecutarSonido(colect1);
            }
            else
            {
                Debug.LogError("SoundController instance is null");
            }*/
        }
    }
}
