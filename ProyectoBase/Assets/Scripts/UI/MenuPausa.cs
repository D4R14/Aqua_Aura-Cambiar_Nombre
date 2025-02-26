using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [Header("Menu Pausa")]
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    //[SerializeField] private GameObject Juego;

    [Header("SkillTree")]
    private Vendedor vendedor;
    [SerializeField] private GameObject skillTree;
    [SerializeField] private GameObject botonSi;
    //[SerializeField] private GameObject botonNo;

    #region Pausa

    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
    #endregion

    #region skillTreeTienda
    public void MostrarSkillTree()
    {
        skillTree.SetActive(true);
        botonSi.SetActive(false);
        //botonNo.SetActive(false);
    }
    #endregion
}
