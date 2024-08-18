using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midujisuan : MonoBehaviour
{
    public GameObject fama, fama1;
    public GameObject shuiwei;
    void Start()
    {
        fama .SetActive(true);
        fama1.SetActive(false );
    }
    public void newgame()
    {
        fama.SetActive(false);
        Invoke("jixu", 0.5f);
    }
    public void jixu()
    {
        fama1 .SetActive(true);
        Invoke(nameof(shuiweisuofang), 0.5f);
    }
    public void shuiweisuofang()
    {
        shuiwei.transform.localScale = new Vector3(shuiwei.transform.localScale.x, shuiwei.transform.localScale.y, shuiwei.transform.localScale.z + 0.1348f);
    }
}
