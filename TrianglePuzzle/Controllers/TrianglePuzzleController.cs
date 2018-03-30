using System.Web.Http;
using TrianglePuzzle.Models;

namespace TrianglePuzzle.Controllers
{
    public class TrianglePuzzleController : ApiController
    {
        /// <summary>
        /// Returns a static region grid to display.
        /// </summary>
        [HttpGet]
        [Route("api/TrianglePuzzle/GetRegionGrid")]
        public RegionGrid GetRegionGrid()
        {
            var regionGrid = new RegionGrid();

            return regionGrid;
        }
    }
}
