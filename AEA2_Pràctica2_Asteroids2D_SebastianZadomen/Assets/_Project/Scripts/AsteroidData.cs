using UnityEngine;
using UnityEngine.UIElements;
// TODO: crea el ScriptableObject [CreateAssetsMenu...] recorda que no ha d'heretar de MonoBehaviour
[CreateAssetMenu(fileName = "NewAsteroidData", menuName = "Asteroids/Asteroid Data")]
public class AsteroidData : ScriptableObject
{
    public int maxHealth;
    public Color color;
    public float scale;
    public float minSpeed;
    public float maxSpeed;  
}
