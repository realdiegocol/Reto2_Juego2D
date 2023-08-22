using UnityEngine;
using UnityEngine.Events;

public class SistemaRecoleccion : MonoBehaviour
{
    public int cantidadBombillos;
    public int bombillosRecolectados = 0;

    public UnityEvent recoleccionCompleta;

    // Reference to the UIManager script
    public UIManager uiManager;

    void Start()
    {
        cantidadBombillos = GameObject.FindGameObjectsWithTag("Bombillo").Length;
    }

    public void EvaluarRecoleccion()
    {

        bombillosRecolectados++;
        int remainingBombillos = cantidadBombillos - bombillosRecolectados;

        // Update the UI Text elements with the new counts
        uiManager.UpdateUI(bombillosRecolectados, remainingBombillos);

        if (bombillosRecolectados == cantidadBombillos)
            recoleccionCompleta.Invoke();
    }
}
