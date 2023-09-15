using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavmaxiaGame
{
    public class Battlefield
    {
        public Point initializationPoint { get; }
        public Boolean isEnemyBatt { get; }
        public ButtonPoint[,] battlefieldPoints = new ButtonPoint[10, 10];
        
        public List<Warship> remainingShips =new List<Warship>();
        public GameForm upperForm;
        public int rowSize { get; }
        public int colSize { get; }
        public Battlefield(Boolean isEnemyBattlefield,int rowSizeParameter,int colSizeParameter)
        {
            isEnemyBatt = isEnemyBattlefield;
            rowSize = rowSizeParameter;
            colSize = colSizeParameter;
        }

        public void AttemptRemoval(Warship removedWarship)
        {
            if (remainingShips.Any())   //Maybe can be skipped
            {
                remainingShips.Remove(removedWarship);
            }

            if(!remainingShips.Any())   //If-else is not used because when we remove the last ship of remainingShips , we then have to end the game.
            {
                upperForm.GameEnd(this.isEnemyBatt);    //We get here only if all of a battlefield's ships have been sunk
            }   
        }

        public void setWarship(int size)    //Warship is set to a random horizontal or vertical list of neighboring buttonpoints with the given size
        {
            Random rand = upperForm.rand;
            int initPositionRow;
            int initPositionCol;
            int isHorizontal = rand.Next(2);
            int[] prices = new int[2];
            Boolean positionTaken = true;
            ButtonPoint tempButtonPoint = new ButtonPoint();
            prices = positionSetter(size,isHorizontal);
            initPositionRow = prices[0];
            initPositionCol = prices[1];
            while (positionTaken)
            {
                positionTaken = false;
                if (isHorizontal == 1)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (this.battlefieldPoints[initPositionRow + i, initPositionCol].isTaken)   //If there is already a ship point in the corresponding position
                        {
                            prices = positionSetter(size,isHorizontal);
                            initPositionRow = prices[0];
                            initPositionCol = prices[1];
                            positionTaken = true;
                            break;

                        }
                    }
                }
                else
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (this.battlefieldPoints[initPositionRow, initPositionCol + i].isTaken)   //If there is already a ship point in the corresponding position
                        {
                            prices = positionSetter(size,isHorizontal);
                            initPositionRow = prices[0];
                            initPositionCol = prices[1];
                            positionTaken = true;
                            break;
                        }
                    }
                }
            }
            List<ButtonPoint> tempButtonPointList = new List<ButtonPoint>();

            if (isHorizontal == 1)
            {
                for (int i = 0; i < size; i++)
                {
                    tempButtonPoint = this.battlefieldPoints[initPositionRow + i, initPositionCol];
                    tempButtonPoint.isTaken = true;
                    if (this.isEnemyBatt)
                    {
                        tempButtonPointList.Add(tempButtonPoint);   //Enemy battlefield's ships must not be visible
                        continue;
                    }
                    tempButtonPoint.BackColor = Color.Yellow;
                    tempButtonPointList.Add(tempButtonPoint);
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    tempButtonPoint = this.battlefieldPoints[initPositionRow, initPositionCol + i];
                    tempButtonPoint.isTaken = true;
                    if (this.isEnemyBatt)
                    {
                        tempButtonPointList.Add(tempButtonPoint);   //Enemy battlefield's ships must not be visible
                        continue;
                    }
                    tempButtonPoint.BackColor = Color.Yellow;
                    tempButtonPointList.Add(tempButtonPoint);
                }
            }

            this.remainingShips.Add(new Warship(tempButtonPointList, this, size));

        }

        public int[] positionSetter(int size,int isHorizontal)  //Calculates 2 integers that correspond to a position in the battlefield
        {                                                       //The integers are calculated with respect to a ship's size and direction (horizontal,vertical),
            Random rand = upperForm.rand;                       //Because a ship's points must not surpass the boundaries of the battlefieldPoints array
            int[] array = new int[2];
            if (isHorizontal==1)
            {
                array[0] = rand.Next(rowSize - size);
                array[1] = rand.Next(colSize);
                return array;
            }
            else
            {
                array[0] = rand.Next(rowSize);
                array[1] = rand.Next(colSize-size);
                return array;
            }
        }

    }
}
