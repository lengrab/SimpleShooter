using UnityEngine;

public class CharacterVision : MonoBehaviour
{
        public bool TryGetTarget(out GameObject target)
        {
                //TODO написать реализацию получения цели
                target = gameObject;
                return true;
        }
}
