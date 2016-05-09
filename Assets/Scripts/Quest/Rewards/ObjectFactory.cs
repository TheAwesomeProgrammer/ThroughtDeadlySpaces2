using UnityEngine;

namespace Assets.Scripts.Quest.Rewards.Sword
{
    public abstract class ObjectFactory : MonoBehaviour
    {
        public GameObject[] Elements;

        public GameObject GetElement(int elementId)
        {
            return Elements[elementId - 1];
            // Minus one because in array first element is zero and the elementId, starts at 1.
            // Therefor we need to minus by one, to make the first elementId equals the first array element.
        }

        public GameObject GetRandomElement()
        {
            return Elements[Random.Range(0, Elements.Length)];
        }
    }
}