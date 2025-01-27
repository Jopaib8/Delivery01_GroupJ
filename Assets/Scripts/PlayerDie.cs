using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public Animator _animator;

    void Start() {
        _animator = GetComponent<Animator>();
    }

    public void PlayerDeath () {
        _animator.SetTrigger("Die");
        Debug.Log("Player animation died");
    }
}