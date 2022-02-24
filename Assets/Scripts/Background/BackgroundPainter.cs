using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundPainter : MonoBehaviour
{
    public Mesh model;

    public Material mTierra;

    public int numTierras = 2;

    int changeDistance = 0;
    float changeTimer = 0;

    public float rotacionT = 30;
    public float distanciaT = 5;
    public float separacionT = 0.05f;
    public float escalaT = 0.5f;

    public float velocidadRotacionT = 30.0f;


    public int numEstrellas = 200;

    public Material mEstrella;

    public float anchoCampoEstrellas = 300;
    public float altoCampoEstrellas = 200;
    public float distanciaCampoEstrellas = 100; //Sistema mundo

    public float velocidadEscalaEstrellas = 0.1f;


    Vector3[] posicionesEstrellas;
    Matrix4x4[] matricesEstrella;
    Matrix4x4[] matricesEstrellaEscaladas;
    float[] escalaEstrellas;

    float escalaEstrella = 0.5f;
    CommandBuffer commandsPlanetas;
    CommandBuffer commandsEstrellas;


    void Start()
    {
        posicionesEstrellas = new Vector3[numEstrellas];
        matricesEstrella = new Matrix4x4[numEstrellas];
        matricesEstrellaEscaladas = new Matrix4x4[numEstrellas];

        escalaEstrellas = new float[numEstrellas];

        for (int i = 0; i < numEstrellas; i++)
        {
            posicionesEstrellas[i] = new Vector3(
                UnityEngine.Random.Range(-anchoCampoEstrellas/2, anchoCampoEstrellas/2),
                UnityEngine.Random.Range(-altoCampoEstrellas / 2, altoCampoEstrellas / 2),
                distanciaCampoEstrellas);

            matricesEstrella[i] = Matrix4x4.Translate(posicionesEstrellas[i]);

            escalaEstrellas[i] = UnityEngine.Random.Range(1, 2.0f);
        }
        
        commandsEstrellas = new CommandBuffer();
        commandsEstrellas.Clear();

        for (int i = 0; i < numEstrellas; i++)
        {
            float s = escalaEstrellas[i] * escalaEstrella;
            matricesEstrellaEscaladas[i] = matricesEstrella[i] * Matrix4x4.Scale(new Vector3(s, s, 1));
        }

        commandsEstrellas.DrawMeshInstanced(model, 0, mEstrella, -1, matricesEstrellaEscaladas, numEstrellas);

        Camera.main.AddCommandBuffer(CameraEvent.BeforeForwardAlpha, commandsEstrellas);
        commandsPlanetas = new CommandBuffer();
        Camera.main.AddCommandBuffer(CameraEvent.BeforeForwardAlpha, commandsPlanetas);
    }

    // Update is called once per frame
    void Update()
    {
        commandsPlanetas.Clear();
        Matrix4x4 MSol = transform.localToWorldMatrix;

        if (changeTimer <= 0)
        {
            if (changeDistance == 0)
            {
                changeDistance = 1;
            }
            else
            {
                changeDistance = 0;
            }
            changeTimer = Random.Range(1,2);
        }
        changeTimer = changeTimer - Time.deltaTime;

        if (changeDistance == 1)
        {
            distanciaT = distanciaT + 0.01f;
        }
        else
        {
            distanciaT = distanciaT - 0.01f;
        }

        for (int i = 0; i < numTierras; i++)
        {
            Matrix4x4 MTierra = MSol * Matrix4x4.Rotate(Quaternion.Euler(0, 0, rotacionT +
                i * (360.0f / numTierras))) *
                Matrix4x4.Translate(new Vector3(distanciaT + i * separacionT, 0, 0)) *
                Matrix4x4.Scale(new Vector3(escalaT, escalaT, 1));

            commandsPlanetas.DrawMesh(model, MTierra, mTierra, 0, -1, null);
        }

        rotacionT += velocidadRotacionT * Time.deltaTime;
        
    }

    /*private void OnRenderObject()
    {
        Graphics.ExecuteCommandBuffer(commands);
    }*/
}