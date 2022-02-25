using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundPainterMenu : MonoBehaviour
{
    public Mesh model;

    public Material mNave;

    public int numNave = 2;

    int changeDistance = 0;
    float changeTimer = 0;

    public float rotacionN = 30;
    public float distanciaN = 5;
    public float separacionN = 0.05f;
    public float escalaN = 0.5f;

    public float velocidadRotacionN = 30.0f;


    public int numEstrellas = 200;

    public Material mEstrella;

    public float anchoCampoEstrellas = 300;
    public float altoCampoEstrellas = 200;
    public float distanciaCampoEstrellas = 100; //Sistema mundo


    Vector3[] posicionesEstrellas;
    Matrix4x4[] matricesEstrella;
    Matrix4x4[] matricesEstrellaEscaladas;
    float[] escalaEstrellas;

    float escalaEstrella = 0.5f;
    CommandBuffer commandsNave;
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
                UnityEngine.Random.Range (-anchoCampoEstrellas / 2, anchoCampoEstrellas/2),
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
        commandsNave = new CommandBuffer();
        Camera.main.AddCommandBuffer(CameraEvent.BeforeForwardAlpha, commandsNave);
    }

    // Update is called once per frame
    void Update()
    {
        commandsNave.Clear();
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
            distanciaN = distanciaN + 0.01f;
        }
        else
        {
            distanciaN = distanciaN - 0.01f;
        }

        for (int i = 0; i < numNave; i++)
        {
            Matrix4x4 MNave = MSol * Matrix4x4.Rotate(Quaternion.Euler(0, 0, rotacionN +
                i * (360.0f / numNave))) *
                Matrix4x4.Translate(new Vector3(distanciaN + i * separacionN, 0, 0)) *
                Matrix4x4.Scale(new Vector3(escalaN, escalaN, 1));

            commandsNave.DrawMesh(model, MNave, mNave, 0, -1, null);
        }

        rotacionN += velocidadRotacionN * Time.deltaTime;
        
    }

}