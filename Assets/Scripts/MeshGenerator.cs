using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    Material[] sharedMaterials;
    public int xSize = 50;
    public int zSize = 50;

    MeshCollider collidermesh;

    Material mat = Resources.Load("Materials/Nasty_CelShading2.mat", typeof(Material)) as Material;

    void Start()
    {
        mesh = new Mesh();

        collidermesh = gameObject.AddComponent<MeshCollider>();
        GetComponent<MeshFilter>().mesh = mesh;

        collidermesh.sharedMesh = mesh;

        CreateShape();
        UpdateMesh();

        


    }

    // Update is called once per frame
 

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .6f) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize +1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize +1;
                triangles[tris + 5] = vert + xSize +2;

                vert++;
                tris += 6;

                
            }
            vert++;
        }

        uvs = new Vector2[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x/ xSize,(float) z /zSize);
                i++;
            }
        }
    }

    private void UpdateMesh()
    {

        
        mesh.Clear();
       
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mat.mainTexture.wrapMode = TextureWrapMode.Repeat;

        for (int i=0; i<= mesh.triangles.Length; i++)
        {
            sharedMaterials[i] = mat;
        }


        

        mesh.RecalculateNormals();
       
        mesh.RecalculateBounds();
        collidermesh.sharedMesh = mesh;
        // MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();


        /*   MeshRenderer rend = gameObject.GetComponent<MeshRenderer>();
           rend.material = mat;
           rend.materials = sharedMaterials;
           */


    }



}
