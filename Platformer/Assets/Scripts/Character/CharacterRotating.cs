using ObjectBehaviour;
using UnityEngine;

namespace Character
{
    public class CharacterRotating : MonoBehaviour, IRotatable
    {
        public void ObjectRotate(float direction)
        {
            if (direction < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Поворот влево
            }
            else if (direction > 0.01f)
            {
                transform.localScale = new Vector3(1, 1, 1); // Поворот вправо
            }
        }
    }
}