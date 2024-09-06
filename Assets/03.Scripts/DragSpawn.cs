using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSpawn : MonoBehaviour, IPointerDownHandler {
    private GameObject _objDragSpawning;
    private bool _isDragSpawning = false;
    public Image image;
    
    public string nameInfo;

	private void Update () {
        if (_isDragSpawning) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask aa = 1 << 8;
            if (_objDragSpawning == null) return;
            if (Physics.Raycast (ray,out hit ,100f,aa)) {
                _objDragSpawning.SetActive(true);
                _objDragSpawning.transform.position = hit.point;
                image.enabled = false;
            } else {
                image.enabled = true;
                _objDragSpawning.SetActive(false);
                image.transform.position = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0)) {
                _isDragSpawning = false;
                _objDragSpawning = null;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        GameObject prefab = Resources.Load<GameObject>(nameInfo);
        if (prefab != null) {
            _objDragSpawning = Instantiate(prefab);
            _isDragSpawning = true;
        }
    }
}
