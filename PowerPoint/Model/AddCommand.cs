﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class AddCommand : ICommand
    {
        Shape _shape;
        Model _model;

        public AddCommand(Model model, string shapeType)
        {
            _model = model;
            _shape = Factory.CreateShape(shapeType);
        }
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        public void ReverseExecute()
        {
            _model.DeleteShape(_shape);
        }
    }
}