using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllActions", menuName = "Scriptable Objects/AllActions")]
public class AllActions : ScriptableObject
{
    // todas las acciones posibles
        // lo que necesito ahora (esto no va aqui) es guardar cómo va el contador de cada accion y si ha llegado a su score to reach 
        // ¿¿podria hacer un diccionario 
    public List<ActionRes> allActions;
}
