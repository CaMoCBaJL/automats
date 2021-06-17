using System;
using System.Collections.Generic;
using System.Linq;


namespace automats
{
    class SigmaSet
    {
        public List<int> SetContent { get;}

        public AGroupAndSigmaSetType SetType { get; private set; }


        public SigmaSet(IEnumerable<int> condtions) => SetContent = condtions.ToList();

        void DefineSigmaSetType()
        {
            if (SetContent.Count == 1)
            {
                SetType = AGroupAndSigmaSetType.Prime;

                return;
            }
            else
            {
                foreach (var elem in new SortedSet<int>(SetContent.Cast<int>()))
                {
                    int elemCount = SetContent.Count<int>((item) => { return item == elem; });

                    if (elemCount > 0)
                    {
                        if (elemCount == SetContent.Count)
                            SetType = AGroupAndSigmaSetType.Homogenous;
                        else
                            SetType = AGroupAndSigmaSetType.Multiple;

                        return;
                    }
                }
            }

            SetType = AGroupAndSigmaSetType.None;
        }
    }
}
