using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Renderer character;
    [SerializeField] float roationSpeed = 0.5f;
    [SerializeField] Texture secondFace;
    [SerializeField] Texture thirdFace;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject pukePrefab;
    bool fellBad = false;

    private void Start()
    {
        character = GetComponent<Renderer>();
    }
    void Update()
    {
        transform.Rotate(0, roationSpeed, 0);

        if (fellBad == true)
        {
            Instantiate(pukePrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void OnMouseDown()
    {
        if (roationSpeed < 2f) //решил добавить немного больше чем изменение цвета, при каждом клике персоонаж начинает крутится быстрее и меняет лицо
        {
            roationSpeed = roationSpeed * 2;
            character.material.SetTexture("_MainTex", secondFace);
            character.material.SetColor("_Color", Color.green);
        }
        if (roationSpeed > 2.5f) //если раскрутить персоонажа слишком сильно он начнёт блевать
        {
            roationSpeed = roationSpeed * 2;
            character.material.SetTexture("_MainTex", thirdFace);
            character.material.SetColor("_Color", Color.green);
            fellBad = true;
        }
    }
}
