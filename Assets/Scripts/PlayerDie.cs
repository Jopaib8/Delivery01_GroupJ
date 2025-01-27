using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public Animator _animator;
    private PlayerMove playerMove;
    private PlayerJump playerJump;

    void Start() {
        _animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
    }

    public void PlayerDeath () {
        _animator.SetTrigger("Die");
        playerMove.BlockOnDie();
        playerJump.BlockOnDie();
        Debug.Log("Player animation died");
    }
}