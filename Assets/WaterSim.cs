using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Water : MonoBehaviour
{
    public float waveFrequency = 1f;
    public float waveAmplitude = 0.5f;
    public float waveSpeed = 1f;
     
    MeshFilter meshFilter;
    Vector3[] originalVertices;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalVertices = meshFilter.mesh.vertices;
    }

    void Update()
    {
        GenerateWaves();
    }

    void GenerateWaves()
    {
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = originalVertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = originalVertices[i];
            float x = vertex.x;
            float z = vertex.z;

            float y = CalculateWaterHeight(x, z);

            vertices[i] = new Vector3(x, y, z);
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();

    }

    public float GetHeightAtPosition(Vector3 pos) {
        return CalculateWaterHeight(pos.x, pos.z);

    }
    public Vector3 GetNormalAtPosition(Vector3 pos) {

        float original_height = CalculateWaterHeight(pos.x, pos.z);
        float x_height = CalculateWaterHeight(pos.x +.5f, pos.z);
        float z_height = CalculateWaterHeight(pos.x, pos.z + .5f);
        return Vector3.Cross(pos - new Vector3(pos.x +.5f, x_height, pos.z), pos - new Vector3 (pos.x, z_height, pos.z+0.5f)) * -1f;

    }

    private float CalculateWaterHeight(float x,float z) {
        return Mathf.Sin(x * waveFrequency + Time.time * waveSpeed) * waveAmplitude +
                      Mathf.Sin(z * waveFrequency + Time.time * waveSpeed) * waveAmplitude;
    }
}
