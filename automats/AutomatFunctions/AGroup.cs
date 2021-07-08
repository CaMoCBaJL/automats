using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AGroup
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
                    (value) => value == group.AGroupContent[0].SetContent.Values.ElementAt(0)[0])) || group.AGroupType == AGroupAndSigmaSetType.Prime;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var sigmaSet in AGroupContent)
            {
                foreach (var key in sigmaSet.SetContent.Keys)
                {
                    result.Append('{');

                    for (int i = 0; i < sigmaSet.SetContent[key].Count; i++)
                    {
                        if (i > 0)
                            result.Append(", ");

                        result.Append(sigmaSet.SetContent[key][i]);
                    }

                    result.Append('}');
                }

                if (AGroupContent.IndexOf(sigmaSet) +1 < AGroupContent.Count)
                    result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

    }
}
