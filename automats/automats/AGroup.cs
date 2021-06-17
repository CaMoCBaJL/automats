using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automats
{
    class AGroup
    {
        public List<SigmaSet> AGroupContent { get; }

        public AGroupAndSigmaSetType AGroupType { get; private set; }


        public AGroup() => AGroupContent = new List<SigmaSet>();

        public AGroup(IEnumerable<SigmaSet> sigmaSets) => AGroupContent = sigmaSets.ToList();

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
    }
}
