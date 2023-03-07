using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRb;

    [SerializeField] private AudioSource deathSoundEffect;
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    private void Start()
    {
        // "GetComponent<>();" permet de récupérer un composant auquel l'objet est attaché et permet de l'utiliser en le stockant dans une variable du même type
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Cette fonction est seulement appelé lors ce que le joueur rentre en collition avec un objet ayant en paramètre un "RigidBody 2D" ou un "Collider 2D"
    // Ici je parle du joueur car c'est sur lui que je vais utiliser mais ça peut être un autre objet tant qu'il a un "RigidBody 2D" ou un "Collider 2D"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On utilise les tags et non pas les noms des objets du fait que si nous mettons plein de fois le même objet, les noms des objets seront
        // différents et nous devrons à chaque fois 
        if(collision.gameObject.CompareTag("Trap"))
        {
            //Bloque le joueur pour pas qu'il puisse bouger le temps de son respawn
            deathSoundEffect.Play();
            playerRb.bodyType = RigidbodyType2D.Static;
            playerAnimator.SetTrigger("isDead");
        }
    }
}