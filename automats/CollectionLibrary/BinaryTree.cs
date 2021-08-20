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
                cicleCondition = _storage[stepData.OutputSignals];

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
            int n = _storage.Count;

            int step = n / 2;

            n -= step;

            if (_storage.Count == 0)
                return 0;

            while (step > 0)
            {
                if (_storage[n].OutputSignals == elementOutputSignals)
                    return -n;

                if (_storage[n].OutputSignals > elementOutputSignals)
                    n -= step;
                else
                    n += step;

                step = step / 2;
            }

            return LastComparison(n, elementOutputSignals);
        }

        int LastComparison(int transitionalValue, int newValue)
        {

            if (transitionalValue == 0)
                return RightComparison(transitionalValue, newValue);

            else if (transitionalValue == _storage.Count)
                return LeftComparison(transitionalValue, newValue);

            else
            {
                if (RightComparison(transitionalValue, newValue) == transitionalValue)
                    return LeftComparison(transitionalValue, newValue);

                return RightComparison(transitionalValue, newValue);
            }
        }

        int LeftComparison(int n, int newValue)
        {
            if (_storage[n - 1].OutputSignals > newValue)
                return n - 1;

            return n;
        }

        int RightComparison(int n, int newValue)
        {
            if (_storage[n + 1].OutputSignals > newValue)
                return n;

            return n + 1;
        }
    }
}
