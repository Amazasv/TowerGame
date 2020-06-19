using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class BtnInstantite : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab = null;
    [SerializeField]
    private Transform Parent = null;
    private void Awake()
    {
        if (Prefab)
        {
            GetComponent<Button>().onClick.AddListener(
                        delegate
                        {
                            if (Parent) Instantiate(Prefab, Parent);
                            else Instantiate(Prefab, transform);
                        });
        }
    }
}
