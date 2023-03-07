using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // On met des GameObject dans un tableau du fait que nous voulons avoir la possibilité d'ajouter
    // beaucoup de point de passage pour la platforme en mouvement 
    [SerializeField] private GameObject[] positions;
    private int currentPosIndex = 0;

    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
    {
        // Le deuxième paramètre désigne le GameObject auquel le script est attaché 
        if (Vector2.Distance(positions[currentPosIndex].transform.position, transform.position) < .1f)
        {
            currentPosIndex++;
            if (currentPosIndex >= positions.Length)
            {
                currentPosIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, positions[currentPosIndex].transform.position, Time.deltaTime * speed);
    }
}
