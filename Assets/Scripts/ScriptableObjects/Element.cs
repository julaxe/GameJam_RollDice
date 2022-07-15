using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Element")]
    public class Element : ScriptableObject
    {
        public string elementName;
        public List<Element> weakAgainst;
        public List<Element> strongAgainst;
    }
}