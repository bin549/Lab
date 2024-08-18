using System.Collections;
using UnityEngine;

public class 拖拽 : MonoBehaviour  {
    public shiyanjindu shiyanjindu;
    private Vector3 _vec3TargetScreenSpace;
    private Vector3 _vec3TargetWorldSpace;
    public  Transform _trans;
    private Vector3 _vec3MouseScreenSpace;
    private Vector3 _vec3Offset;

    private void Awake()  {
        _trans = transform;
    }
    
    private void Update() {
        _trans.position = new Vector3(Mathf.Clamp(_trans.transform.position.x, _trans.parent.position.x - 0.09f, _trans.parent.position.x + 0.04f), _trans.parent.position.y, _trans.parent.position.z);
        if (翻转.ins.开关 == true) {
            翻转.ins._v =1-( (_trans.position.x / 0.13f) - 50.7861523f);
            Rotate.ShowSpeed(_trans.position.x * 20, 45f, 360);
            Rotate1.ShowSpeed(_trans.position.x * 20, 45, 360);
            shiyanjindu.disanbu();
        }
    }
 
    IEnumerator OnMouseDown() {
        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);
        _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);
        _vec3Offset = _trans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);
        while (Input.GetMouseButton(0))
        {
            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);
            _vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;
            _trans.position = _vec3TargetWorldSpace;
            yield return new WaitForFixedUpdate();
        }
    }
}