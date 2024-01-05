using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DialogPresentationModel
    {
        public bool IsValidNumber(string[] coordinate, int[] maxRange)
        {
            for (int i = 0; i < coordinate.Length; i++)
            {
                if (!int.TryParse(coordinate[i], out int number) || number < 0 || number > maxRange[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
