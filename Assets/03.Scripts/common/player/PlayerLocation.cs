using System;
using UnityEngine;

public class PlayerLocation : MonoBehaviour {
    [SerializeField] private Transform parrentPivot;
    [SerializeField] private Transform[] roomTransforms;

    private void Awake() {
        roomTransforms = Array.FindAll(parrentPivot.GetComponentsInChildren<Transform>(), t => t != parrentPivot);
    }

    private void Start() {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager.IsInLobby) {
            this.PlacePlayerLocation();
            gameManager.IsInLobby = false;
        }
    }

    private void PlacePlayerLocation() {
        int playerLobbyStateNum = FindObjectOfType<GameManager>().PlayerLobbyState;
        int roomIndex = Mathf.Clamp(playerLobbyStateNum, 0, roomTransforms.Length);
        var roomTransform = roomTransforms[roomIndex];
        transform.position = roomTransform.position;
        transform.rotation = roomTransform.rotation;
    }
}