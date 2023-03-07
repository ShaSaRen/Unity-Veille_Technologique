using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public GameObject player;   // cr�ation de l'objet Player qui repr�sente le joueur dans le jeu
    public float timeOffSet;
    public Vector3 posOffSet;

    private Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSet, ref velocity, timeOffSet);
    }
}
