using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class textCharacterShake : MonoBehaviour
{
    public float shakeAmount;

    TMP_Text text;
    
    void Start() => text = GetComponent<TMP_Text>();

    // Update is called once per frame
    void Update()
    {
        text.ForceMeshUpdate();
        Mesh textMesh = text.mesh;
        Vector3[] vertices = textMesh.vertices;

        for (int i = 0; i < text.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo character = text.textInfo.characterInfo[i];
            int index = character.vertexIndex;

            Vector3 offset = shake();
            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }

        textMesh.vertices = vertices;
        text.canvasRenderer.SetMesh(textMesh);
    }

    Vector2 shake() { return new Vector2(Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount)); }
}
