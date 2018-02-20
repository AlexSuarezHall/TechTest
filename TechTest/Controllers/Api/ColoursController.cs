using Services.cs.Interfaces;
using System.Web.Http;

namespace TechTest.Controllers.Api
{
    public class ColoursController : ApiController
    {
        private IColourService ColourService;

        public ColoursController(IColourService colourService)
        {
            ColourService = colourService;
        }

        public IHttpActionResult GetColour()
        {
            var colours = ColourService.GetColours();

            return Ok(colours);
        }
    }
}