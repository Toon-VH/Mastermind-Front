using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Core
{
    public class Mastermind
    {
        public int RowLength { get; set; }
        public int GameLenght { get; set; }
        public int ColorsAmount { get; set; }
        public AttemptColor[] Code { get; set; }
        public List<Row> Attempts { get; set; }

        public Mastermind(int rowLength = 4, int lenghtGame = 9, int colorsAmount = 6)
        {
            RowLength = rowLength;
            GameLenght = lenghtGame;
            ColorsAmount = colorsAmount;

            Attempts = new List<Row>();

            Code = Random();
        }

        public bool Validate()
        {
            bool result = true;

            for (var i = 0; i < RowLength; i++)
            {
                if (Attempts.Last().AttemptColors[i] != Code[i])
                {
                    result = false;
                }
            }

            return result;
        }

        public void CalculateHints()
        {
            var indexes = new List<int>();

            for (int i = 0; i < RowLength; i++)
            {
                if (Code[i] == Attempts.Last().AttemptColors[i])
                {
                    indexes.Add(i);
                    Attempts.Last().CorrectPositionColor++;
                }
            }

            for (int i = 0; i < RowLength; i++)
            {
                if (indexes.Contains(i)) continue;
                for (int j = 0; j < RowLength; j++)
                {
                    if (indexes.Contains(j)) continue;
                    //var color = Attempts.Last().AttemptColors[j];

                    if (Code[i] == Attempts.Last().AttemptColors[j])
                    {
                        Attempts.Last().CorrectColor++;
                        break;
                    }
                }
            }
        }


        public void SaveAttempt(AttemptColor[] colors)
        {
            Attempts.Add(new Row
            {
                AttemptColors = colors
            });
        }

        // private AttemptColor StringToColor(string color)
        // {
        //     AttemptColor result;
        //     switch (color)
        //     {
        //         case "Red":
        //             result = AttemptColor.Red;
        //             break;
        //         case "Green":
        //             result = AttemptColor.Green;
        //             break;
        //         case "Yellow":
        //             result = AttemptColor.Yellow;
        //             break;
        //         case "Blue":
        //             result = AttemptColor.Blue;
        //             break;
        //         case "Purple":
        //             result = AttemptColor.Purple;
        //             break;
        //         case "Orange":
        //             result = AttemptColor.Orange;
        //             break;
        //
        //         default:
        //             result = AttemptColor.Red;
        //             break;
        //     }
        //
        //     return result;
        // }

        private AttemptColor[] Random()
        {
            AttemptColor[] array = new AttemptColor[RowLength];
            for (int i = 0;
                i < RowLength;
                i++)
            {
                array[i] = RandomColorPicker();
            }

            return array;
        }

        private AttemptColor RandomColorPicker()
        {
            var rand = new Random();
            var rdm = rand.Next(1, ColorsAmount - 1);
            return (AttemptColor) rdm;
        }
    }
}