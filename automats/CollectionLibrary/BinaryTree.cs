using System.Collections.Generic;
using System.Linq;
using Entities;

namespace CommonCollections
{
    public class BinaryTree
    {
        List<ModellingStepData> _storage;


        public BinaryTree()
        {
            _storage = new List<ModellingStepData>();
        }

        public BinaryTree(IEnumerable<ModellingStepData> data)
        {
            _storage = data.ToList();
        }

        public bool Add(ModellingStepData stepData, out ModellingStepData cicleCondition)
        {
            int indx = BinarySearch(stepData.OutputSignals);

            if (indx >= 0)
            {
                _storage.Insert(indx, stepData);

                cicleCondition = new ModellingStepData();

                return true;
            }
            else
            {
                cicleCondition =  _storage[stepData.OutputSignals];

                _storage[stepData.OutputSignals] = stepData;

                return false;
            }
        }

        public IEnumerable<ModellingStepData> GetCycledSteps(int lastStep, int firstStep)
            => _storage.Skip(firstStep).Take(lastStep - firstStep);

        public bool Remove(ModellingStepData data)
        => _storage.Remove(data);

        int BinarySearch(int elementOutputSignals)
        {
            int n = _storage.Count - 1;

            int step = n / 2;

            n -= step;

            while (step != 1)
            {
                if (_storage.Count == 0)
                    return 0;

                step = step / 2 + step % 2;

                if (_storage[n].OutputSignals == elementOutputSignals)
                    return -n;

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
