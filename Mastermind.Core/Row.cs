using System;


namespace Mastermind.Core
{
    public class Row
    {
        
        public AttemptColor[] AttemptColors { get; set; }

        public int CorrectPositionColor { get; set; }

        public int CorrectColor { get; set; }

        public Row()
        {
            
        }

        // public void SetHint(int black, int white)
        // {
        //     int index = 0;
        //     for (int i = 0; i < black; i++)
        //     {
        //         ValidateColors[index] = ValidateColor.Black;
        //         index++;
        //     }
        //     for (int i = 0; i < white; i++)
        //     {
        //         ValidateColors[index] = ValidateColor.Black;
        //         index++;
        //     }
        // }
    }
}