using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float punts;
    private TextMeshProUGUI textMesh;


    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = punts.ToString("0");
    }

    public void SumaPunts (float puntsEntrada) { punts += puntsEntrada;}
}
