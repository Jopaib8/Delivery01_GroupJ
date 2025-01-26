using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float points;
    private TextMeshProUGUI textMesh;


    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = points.ToString("Score: 0");
    }

    public void SumaPunts (float puntsEntrada) { points += puntsEntrada;}
}
