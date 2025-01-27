using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{

        private TextMeshProUGUI textMesh;


        private void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            textMesh.text = ($"Score: {Score.totalPoints}");
        }

}