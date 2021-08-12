using System.Collections.Generic;
using System.Linq;


namespace Entities
{
    public class SigmaSet
    {
        public Dictionary<string, List<int>> SetContent { get; private set; }

        public AGroupAndSigmaSetType SetType { get; private set; }

        public int Count {
            get
            {
                int result = 0;

                foreach (var objects in SetContent.Values)
                    result += objects.Count;

                return result;
            }
        }


        public SigmaSet()
        {
            SetContent = new Dictionary<string, List<int>>();

            SetType = AGroupAndSigmaSetType.None;
        }

        public SigmaSet(IEnumerable<int> conditions, string signal)
        {
            SetContent = new Dictionary<string, List<int>>();

            Add(signal, conditions);

            DefineSigmaSetType();
        }

        public SigmaSet(KeyValuePair<string, List<int>> keyValuePair)
        {
            Add(keyValuePair.Key, keyValuePair.Value);
        }

        void DefineSigmaSetType()
        {
            if (SetContent.Values.Last().Count == 1)
            {
                SetType = AGroupAndSigmaSetType.Prime;

                return;
            }
            else
            {
                foreach (var pair in SetContent)
                {
                    foreach (var elem in pair.Value)
                    {
                        int elemCount = pair.Value.Count<int>((item) => { return item == elem; });

                        if (elemCount > 1)
                        {
                            if (elemCount == SetContent.Count)
                                SetType = AGroupAndSigmaSetType.Homogenous;
                            else
                                SetType = AGroupAndSigmaSetType.Multiple;

                            return;
                        }
                    }
                }
            }

            SetType = AGroupAndSigmaSetType.None;
        }

        public void Add(string signal, IEnumerable<int> condtions)
        {
            if (SetContent == null)
                SetContent = new Dictionary<string, List<int>>();

            foreach (var item in condtions)
                Add(signal, item);
        }

        public void Add(string signal, int condition)
        {
            if (SetContent.Keys.Contains(signal))
                SetContent[signal].Add(condition);

            else
                SetContent[signal] = new List<int>(new int[] { condition });

            DefineSigmaSetType();
        }

        public void Clear() => SetContent = new Dictionary<string, List<int>>();
    }
}
