using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSpawn : MonoBehaviour, IPointerDownHandler {
    private GameObject _objDragSpawning;

    //是否正在拖拽
    private bool _isDragSpawning = false;
    public Image image;//拖拽时显示的图标
    // Update is called once per frame
    public string nameInfo;//拖拽时生成的物体名称
	void Update () {
        if (_isDragSpawning) {
            //射线
            //刷新位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask aa = 1 << 8;
            if (_objDragSpawning == null) return;
            if (Physics.Raycast (ray,out hit ,100f,aa)) {
                _objDragSpawning.SetActive(true);
                _objDragSpawning.transform.position = hit.point;
                image.enabled = false;
            }
            else {
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
        GameObject prefab = Resources.Load<GameObject>(nameInfo);//根据名字在Resources文件夹内查找预制体生成
        if (prefab != null) {
            _objDragSpawning = Instantiate(prefab);
            _isDragSpawning = true;
        }
    }
}
