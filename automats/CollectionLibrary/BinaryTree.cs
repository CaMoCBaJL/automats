using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace CollectionLibrary
{
    public class BinaryTree
    {
        List<ModellingStepData> _storage;


        public BinaryTree()
        {
            _storage = new List<ModellingStepData>();
        }

        public BinaryTree (IEnumerable<ModellingStepData> data)
        {
            _storage = data.ToList();
        }

        public bool Add(ModellingStepData stepData)
        {
            return true;
        }

        public bool Remove(int index)
        {
            return true;
        }

        int BinarySearch(int elementOutputSignals)
        {
            int n = _storage.Count;

            int step = n / 2;

            n -= step;

            while (step != 1)
            {
                step = step / 2 + step % 2;

                if (_storage[n].OutputSignals == elementOutputSignals)
                    return n;

                if (_storage[n].OutputSignals > elementOutputSignals)
                    n -= step;
                else
                    n += step;
            }

            if (_storage[n].OutputSignals > elementOutputSignals)
                return n - 1;
            else
                return n + 1;
        }
    }
}
