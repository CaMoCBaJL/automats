using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatTest
{
    class AGroup
    {
        public List<SigmaSet> AGroupContent { get; }

        public AGroupAndSigmaSetType AGroupType { get; private set; }

        public AGroup AncestorAGroup { get; }


        public AGroup(AGroup previousAgroup)
        {
            AGroupContent = new List<SigmaSet>();

            AncestorAGroup = previousAgroup;

            AGroupType = AGroupAndSigmaSetType.None; 
        }

        public AGroup(IEnumerable<SigmaSet> sigmaSets, AGroup previousAgroup)
        {
            AGroupContent = sigmaSets.ToList();

            AncestorAGroup = previousAgroup;

            DefineAGroupType();
        }

        public void DefineAGroupType()
        {
            var previousSigmaSetType = AGroupContent[0].SetType;

            for (int i = 1; i < 4; i++)
            {
                bool res = true;

                AGroupContent.ForEach((set) => res = res && ((int)set.SetType == i));

                if (res)
                {
                    AGroupType = (AGroupAndSigmaSetType)Enum.Parse(typeof(AGroupAndSigmaSetType), i.ToString());

                    return;
                }
            }

            AGroupType = AGroupAndSigmaSetType.None;
        }

        public void AddElement(SigmaSet elem)
        {
            AGroupContent.Add(elem);

            DefineAGroupType();
        }

        public static bool IsGroupHomogenous(AGroup group) => group.AGroupContent.TrueForAll((sigmaSet)
                => sigmaSet.SetContent.Values.Last().TrueForAll(
                    (value) => value == group.AGroupContent[0].SetContent.Values.ElementAt(0)[0]));
            //return group.AGroupContent.TrueForAll((sigmaSet) => 
            //sigmaSet.SetType == AGroupAndSigmaSetType.Homogenous 
            //|| (sigmaSet.SetContent.Values.Count == 1 && sigmaSet.SetContent)
        
    }
}
