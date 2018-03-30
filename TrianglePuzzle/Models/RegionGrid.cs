using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrianglePuzzle.Models
{
    public class RegionGrid
    {
        const int _gridItemSize = 10, _horizontalGridLength = 60, _verticalGridLength = 60;
        int[] _sectorColumns = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        string[] _sectorRows = { "A", "B", "C", "D", "E", "F" };

        public CoordinateGrid CoordinateGrid { get; private set; }

        public List<List<GridBlock>> GridBlocks { get; private set; } = new List<List<GridBlock>>();

        public Dictionary<string, RightTriangle> TriangleDictionary { get; private set; } = new Dictionary<string, RightTriangle>();

        public string[] Keys { get; private set; }

        public RegionGrid()
        {
            CoordinateGrid = new CoordinateGrid(_gridItemSize, _horizontalGridLength, _verticalGridLength);
            InitializeKeys();
            CreateGridBlocks();
            CreateTriangleDictionary();
        }

        private void AddTriangle(string key, RightTriangle rt)
        {
            TriangleDictionary.Add(key, rt);
        }

        private void InitializeKeys()
        {
            int count = 0;

            Keys = new string[_sectorColumns.Length * _sectorRows.Length];

            foreach (var row in _sectorRows)
            {
                foreach (var col in _sectorColumns)
                {
                    Keys[count] = row + col;
                    count++;
                }
            }
        }

        private void CreateGridBlocks()
        {
            int numberOfBlocksPerRow = (_horizontalGridLength / _gridItemSize);

            for (int lineIndex = 0; lineIndex < CoordinateGrid.Lines.Count - 1; lineIndex++)
            {
                int gridBlockId = 0, startIndex = 0, endIndex = 1;
                GridBlock gridBlock = null;
                var gridBlockRow = new List<GridBlock>();

                while (gridBlockId < numberOfBlocksPerRow)
                {
                    gridBlock = new GridBlock
                    {
                        Id = gridBlockId,
                        Coordinates = new List<Coordinate>()
                    };

                    AddLineCoordinates(startIndex, endIndex, CoordinateGrid.Lines[lineIndex], ref gridBlock); // top line
                    AddLineCoordinates(startIndex, endIndex, CoordinateGrid.Lines[lineIndex + 1], ref gridBlock); // bottom line

                    startIndex++;
                    endIndex++;
                    gridBlockId++;

                    gridBlockRow.Add(gridBlock);
                }

                GridBlocks.Add(gridBlockRow);
            }
        }

        private void AddLineCoordinates(int startIndex, int endIndex, Coordinate[] lineCoordinate, ref GridBlock lq)
        {
            while (startIndex <= endIndex)
            {
                lq.Coordinates.Add(lineCoordinate[startIndex]); // add top coord's
                startIndex++;
            }
        }

        private void CreateTriangleDictionary()
        {
            int keyNumber = 0;

            foreach (var gridBlockRow in GridBlocks)
            {
                foreach (var block in gridBlockRow)
                {
                    var topLeftCoord = block.Coordinates[0];
                    var topRightCoord = block.Coordinates[1];
                    var lowerLeftCoord = block.Coordinates[2];
                    var lowerRightCoord = block.Coordinates[3];

                    RightTriangle lowerRT = new RightTriangle
                    {
                        Coordinates = new List<Coordinate> { topLeftCoord, lowerLeftCoord, lowerRightCoord }
                    };

                    RightTriangle upperRT = new RightTriangle
                    {
                        Coordinates = new List<Coordinate> { topLeftCoord, topRightCoord, lowerRightCoord }
                    };

                    AddTriangle(Keys[keyNumber], lowerRT);
                    AddTriangle(Keys[keyNumber + 1], upperRT);

                    keyNumber = keyNumber + 2;
                }
            }
        }
    }
}