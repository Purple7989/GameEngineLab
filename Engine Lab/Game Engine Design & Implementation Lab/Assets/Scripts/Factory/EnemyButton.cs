using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    private EnemyFactory factory;

    private EditorManager editor;

    TextMeshProUGUI btnText;

    // Start is called before the first frame update
    void Start()
    {
        factory = GameObject.Find("GameManager").GetComponent<EnemyFactory>();

        editor = EditorManager.instance;

        btnText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClickSpawn()
    {
        switch (btnText.text)
        {
            case "crab":
                editor.item = factory.GetEnemy("crab").Create(factory.prefab1);
                break;
            case "Bee":
                editor.item = factory.GetEnemy("Bee").Create(factory.prefab2);
                break;
            default:
                break;
        }

        editor.instantiated = true;
    }
}