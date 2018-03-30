using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrianglePuzzle.Models
{
    public class GridBlock
    {
        public int Id { get; set; }
        public List<Coordinate> Coordinates { get; set; }
    }
}