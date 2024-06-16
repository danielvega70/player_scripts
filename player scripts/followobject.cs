using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] // Permite que Unity muestre esta variable en el Inspector
    private Transform target; // El objeto al que queremos seguir, se asignará desde el Inspector

    void Update()
    {
        if (target != null)
        {
            // Actualizamos la posición del objeto para que coincida con la posición del objeto seleccionado
            transform.position = target.position;
            transform.rotation = target.rotation;
            // Si necesitas que el objeto también mantenga la misma escala que el objeto seleccionado:
            // transform.localScale = target.localScale;
        }
    }
}
