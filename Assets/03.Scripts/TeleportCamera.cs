using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCamera : MonoBehaviour {
    public Door mDoor;
    
    public void SetupDoor(Door door) {
        this.mDoor = door;
    }

    public void OpenDoor() {
        this.mDoor.OpenDoor();
    }

    public void CloseDoor() {
        this.mDoor.CloseDoor();
    }
}
