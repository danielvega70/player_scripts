using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] // Permite que Unity muestre esta variable en el Inspector
    private Transform target; // El objeto al que queremos seguir, se asignar� desde el Inspector

    void Update()
    {
        if (target != null)
        {
            // Actualizamos la posici�n del objeto para que coincida con la posici�n del objeto seleccionado
            transform.position = target.position;
            transform.rotation = target.rotation;
            // Si necesitas que el objeto tambi�n mantenga la misma escala que el objeto seleccionado:
            // transform.localScale = target.localScale;
        }
    }
}
