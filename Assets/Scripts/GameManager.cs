using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject columna;
    public Renderer fondo;
    public List<GameObject> columnas;
    public List<GameObject> piedras;
    public List<GameObject> trampas;
    public float velocidad = 2;
    public GameObject piedra1;
    public GameObject piedra2;
    public GameObject trampa;
    public GameObject MenuStart;
    public GameObject MenuGameOver;
    public bool gameOver = false;
    public bool startGame = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 40; i = i + 2)
        {
            columnas.Add(Instantiate(columna, new Vector2(-10 + i, -3), Quaternion.identity));
        }
        piedras.Add(Instantiate(piedra1, new Vector2(7, -5), Quaternion.identity));
        piedras.Add(Instantiate(piedra2, new Vector2(14, -5), Quaternion.identity));
        trampas.Add(Instantiate(trampa, new Vector2(10, -5), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                startGame= true;
            }
        }

        if (startGame == true && gameOver == true)
        {
            MenuGameOver.SetActive(true);
            if(Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (startGame == true && gameOver== false)
        {
            MenuStart.SetActive(false);
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;

            for (int i = 0; i < columnas.Count; i=i+1)
            {
                if (columnas[i].transform.position.x <= -10)
                {
                    columnas[i].transform.position = new Vector3(30, -3, 0);
                }
                columnas[i].transform.position = columnas[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
            for (int i = 0; i < piedras.Count; i++)
            {
                if (piedras[i].transform.position.x <= -10)
                {
                    float ran = Random.Range(7, 32);
                    piedras[i].transform.position = new Vector3(ran, -5, 0);
                }
                piedras[i].transform.position = piedras[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
            for (int i = 0; i < trampas.Count; i++)
            {
                if (trampas[i].transform.position.x <= -10)
                {
                    float ran = Random.Range(7, 32);
                    trampas[i].transform.position = new Vector3(ran, -5, 0);
                }
                trampas[i].transform.position = trampas[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

        }
    }
}
