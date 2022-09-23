using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public string str;
    public Text textElem;
    private GameObject sub;

    // Start is called before the first frame update
    void Start()
    {
        sub = this.transform.Find("submarineUPLOADABLE").gameObject;
        textElem.text = str;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
