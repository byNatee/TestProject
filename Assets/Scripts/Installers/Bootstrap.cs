using Services;
using UnityEngine;

namespace Installers
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            BindIUpdate();
        }

        private void BindIUpdate()
        {
            var go = new GameObject();
            go.name = "Updater";
            go.AddComponent<Updater>();
        }
    }
}