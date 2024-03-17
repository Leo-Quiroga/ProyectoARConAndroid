using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    [SerializeField] private float retraso; // Cambia esto al valor deseado en segundos
    [SerializeField] private int escenaObjetivo;

    public void CambiarEscenaConRetraso()
    {
        // Invocar la funci�n para cambiar de escena despu�s del retraso
        Invoke("CambiarEscena", retraso);
    }

    private void CambiarEscena()
    {
        SceneManager.LoadScene(escenaObjetivo);
    }
}
