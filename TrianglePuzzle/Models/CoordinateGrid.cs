using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrianglePuzzle.Models
{
    public class CoordinateGrid
    {
        public List<Coordinate[]> Lines { get; set; } = new List<Coordinate[]>();

        public CoordinateGrid(int gridItemSize, int horizontalGridLength, int verticalGridLength)
        {
            int rowLength = (verticalGridLength / gridItemSize);
            int colLength = (horizontalGridLength / gridItemSize);

            for (int row = 0; row <= rowLength; row++)
            {
                Coordinate[] rowCoordinates = new Coordinate[(horizontalGridLength / gridItemSize) + 1];

                for (int col = 0; col <= colLength; col++)
                {
                    Coordinate newCoordinate = new Coordinate
                    {
                        XPoint = (col == 0 ? col : col * gridItemSize),
                        YPoint = (row == 0 ? row : row * gridItemSize)
                    };

                    rowCoordinates[col] = newCoordinate;
                }

                Lines.Add(rowCoordinates);
            }
        }
    }
}