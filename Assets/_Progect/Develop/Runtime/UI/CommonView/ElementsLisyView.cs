using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.CommonView
{
    public class ElementsLisyView<TElement> : MonoBehaviour,IView where TElement : MonoBehaviour, IView
    {
        [SerializeField] private Transform _parant;

        private List<TElement> _elements = new List<TElement>();

        public IReadOnlyList<TElement> Elements => _elements;

        public void Add(TElement element)
        {
            element.transform.SetParent(_parant);
            _elements.Add(element);
        }

        public void Remove(TElement element)
        {
            element.transform.SetParent(null);
            _elements.Remove(element);
        }
    }

}
