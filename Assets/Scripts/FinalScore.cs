using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    
    private Score points;
    private TextMeshProUGUI textMesh;


    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text =  $"Score: {points}";
    }

    
}
