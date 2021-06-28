using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Core
{
    public class MastermindEngine
    {
        public int RowLength { get; set; }
        public int GameLenght { get; set; }
        public int ColorsAmount { get; set; }
        public AttemptColor[] Code { get; set; }
        public List<Row> Attempts { get; set; }

        public MastermindEngine(int rowLength = 4, int lenghtGame = 9, int colorsAmount = 6)
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

            

        private AttemptColor[] Random()
        {
            AttemptColor[] array = new AttemptColor[RowLength];
            for (int i = 0; i < RowLength; i++)
            {
                array[i] = RandomColorPicker();
            }

            return array;
        }

        private AttemptColor RandomColorPicker()
        {
            var rand = new Random();
            var rdm = rand.Next(0, ColorsAmount);
            return (AttemptColor) rdm;
        }
    }
}