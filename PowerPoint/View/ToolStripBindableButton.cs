using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PowerPoint
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public class BindingToolStripButton : ToolStripButton, IBindableComponent
    {
        public BindingToolStripButton() : base() 
        {
        }
        public BindingToolStripButton(String text) : base(text) 
        { 
        }
        public BindingToolStripButton(System.Drawing.Image image) : base(image) 
        { 
        }
        public BindingToolStripButton(String text, System.Drawing.Image image) : base(text, image) 
        {
        }
        public BindingToolStripButton(String text, System.Drawing.Image image, EventHandler onClick) : base(text, image, onClick) 
        {
        }
        public BindingToolStripButton(String text, System.Drawing.Image image, EventHandler onClick, String name) : base(text, image, onClick, name) 
        {
        }

        #region IBindableComponent Members
        private BindingContext _bindingContext;
        private ControlBindingsCollection _dataBindings;

        [Browsable(false)]
        public BindingContext BindingContext
        {
            get
            {
                if (_bindingContext == null)
                {
                    _bindingContext = new BindingContext();
                }
                return _bindingContext;
            }
            set
            {
                _bindingContext = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (_dataBindings == null)
                {
                    _dataBindings = new ControlBindingsCollection(this);
                }
                return _dataBindings;
            }
        }
        #endregion
    }
}
