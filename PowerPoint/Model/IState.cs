using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IState
    {
        void MouseDown(double pointX, double pointY);
        void MouseMove(double pointX, double pointY);
        void MouseRelease(double pointX, double pointY);
    }
}
