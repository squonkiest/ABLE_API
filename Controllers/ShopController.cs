using ABLE_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABLE_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly AbleContext _ableContext;
        private readonly DbSet<ExperimentData> _experimentDataSet;

        public ShopController(AbleContext ableContext)
        {
            _ableContext = ableContext;
            _experimentDataSet = _ableContext.Set<ExperimentData>();
        }

        [HttpPost("buy-now")]
        public async Task<ActionResult> BuyNow()
        {
            if (Request.Cookies.TryGetValue("button_variant", out var variant)
                && Request.Cookies.TryGetValue("user_id", out var userId))
            {
                await SaveExperiment(userId, "button_variant", variant, ExperimentStatus.Clicked);
            }
            else
            {
                return BadRequest("Cookies is not present");
            }
            return Ok();
        }

        [HttpPost("buy-now-assigned")]
        public async Task<ActionResult> BuyNowAssigned()
        {
            if (Request.Cookies.TryGetValue("button_variant", out var variant)
                && Request.Cookies.TryGetValue("user_id", out var userId))
            {
                await SaveExperiment(userId, "button_variant", variant, ExperimentStatus.Assigned);
            }
            else
            {
                return BadRequest("Cookies is not present");
            }
            return Ok();
        }

        [HttpPost("buy-now-exposed")]
        public async Task<ActionResult> BuyNowExposed()
        {
            if (Request.Cookies.TryGetValue("button_variant", out var variant)
                && Request.Cookies.TryGetValue("user_id", out var userId))
            {
                await SaveExperiment(userId, "button_variant", variant, ExperimentStatus.Exposed);
            }
            else
            {
                return BadRequest("Cookies is not present");
            }
            return Ok();
        }

        private async Task SaveExperiment(string userId, string experiment, string variant, ExperimentStatus status)
        {
            _experimentDataSet.Add(new ExperimentData
            {
                UserId = Guid.Parse(userId),
                ExperimentName = experiment,
                Status = status,
                Variant = variant

            });
            if (await _ableContext.SaveChangesAsync() == 0)
            {
                throw new Exception("0 rows was changed.");
            }
        }
    }
}
