using Entities;
using System.Windows.Forms;
using CommonConstants;
using System;
using System.Text;
using System.Drawing;

namespace PresentationLayer
{
    public partial class TestSettingsForm : Form
    {
        public TestSettingsForm()
        {
            InitializeComponent();
        }

        private void TestSettingsForm_Load(object sender, System.EventArgs e)
        {
            SetChoosenModeLabelText();

            AddToolTips();
        }

        void AddToolTips()
        {
            new ToolTip().SetToolTip(restrictionMode1, ShowModeDetails(1));

            new ToolTip().SetToolTip(restrictionMode2, ShowModeDetails(2));

            new ToolTip().SetToolTip(restrictionMode3, ShowModeDetails(3));

            new ToolTip().SetToolTip(restrictionMode4, ShowModeDetails(4));

            new ToolTip().SetToolTip(restrictionMode5, ShowModeDetails(5));

        }

        void SetChoosenModeLabelText()
        {
            choosenModeLabel.Text =
                new StringBuilder(StringIndicators.commonPart + Enum.GetNames(typeof(TestRestrictionMode))[FindChosenMode]
                + Environment.NewLine + ShowModeDetails(FindChosenMode)).ToString();
        }

        int FindChosenMode
        {
            get
            {
                if (restrictionMode1.Checked)
                    return 1;
                else if (restrictionMode2.Checked)
                    return 2;
                else if (restrictionMode3.Checked)
                    return 3;
                else if (restrictionMode4.Checked)
                    return 4;
                else if (restrictionMode5.Checked)
                    return 5;

                return 0;
            }
        }

        string ShowModeDetails(int value)
        {
            switch (value)
            {
                case 1:
                    return StringIndicators.mininalRestrictions;
                case 2:
                    return StringIndicators.weakRestrictions;
                case 3:
                    return StringIndicators.averageRestrictions;
                case 4:
                    return StringIndicators.strongRestrictions;
                case 5:
                    return StringIndicators.maximumRestrictions;
                default:
                    return StringIndicators.errorMessage;
            }
        }

        private void radioButton_ValueChanged(object sender, EventArgs e)
        => SetChoosenModeLabelText();

    }
}
