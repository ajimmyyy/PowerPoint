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
        Shapes _page;
        Model _model;

        public AddCommand(Model model, string shapeType, int[] coordinate, Shapes page)
        {
            _model = model;
            _shape = Factory.CreateShape(shapeType, coordinate);
            _page = page;
        }

        //執行命令
        public void Execute()
        {
            _model.AddShape(_shape, _page);
        }

        //執行復原命令
        public void ReverseExecute()
        {
            _model.DeleteShape(_shape, _page);
        }
    }
}
