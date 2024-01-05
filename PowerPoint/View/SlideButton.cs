using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public class SlideButton : Button, ICloneable
    {
        private bool _isChecked = false;

        public SlideButton()
        {
            this.BackColor = System.Drawing.SystemColors.Window;
            this.FlatAppearance.BorderSize = 1;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.UseVisualStyleBackColor = false;
        }

        public object Clone()
        {
            SlideButton clonedButton = new SlideButton();
            clonedButton.Text = this.Text;
            clonedButton.Size = this.Size;
            clonedButton.BackColor = this.BackColor;
            clonedButton.FlatAppearance.BorderSize = this.FlatAppearance.BorderSize;
            clonedButton.FlatStyle = this.FlatStyle;
            clonedButton.UseVisualStyleBackColor = this.UseVisualStyleBackColor;
            clonedButton.FlatAppearance.BorderColor = System.Drawing.Color.White;

            return clonedButton;
        }

        private void UpdateAppearance()
        {
            if (_isChecked)
            {
                this.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            }
            else
            {
                this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            }
        }

        public bool Checked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                UpdateAppearance();
            }
        }
    }
}
