using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public static List<Company> companies = new List<Company>
        {
            new Company
            {
                CompanyId = 1,
                CompanyName = "Data Grid Ltd.",
                Phone = "01726358382",
                Email = "datagrid@gmail.com",
                Location = "Uttara, Dhaka"
            },
            new Company
            {
                CompanyId = 2,
                CompanyName = "New Data ltd.",
                Phone = "01754231467",
                Email = "newdata@gmail.com",
                Location = "sector 11, uttara, Dhaka"
            }
        };
        private readonly DataContext context;

        public CompanyController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            return Ok(await this.context.Companies.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var company = await this.context.Companies.FindAsync(id);
            if(company == null)
            {
                return BadRequest("Company Not Found.");
            }
            else
            {
                return Ok(company);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Company>>> AddCompany(Company company)
        {
            this.context.Companies.Add(company);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Companies.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Company>>> UpdateCompany(Company request)
        {
            var company = await this.context.Companies.FindAsync(request.CompanyId);
            if(company == null)
            {
                return BadRequest("Company Not Found.");
            }
            else
            {
                company.CompanyName = request.CompanyName;
                company.Phone = request.Phone;
                company.Email = request.Email;
                company.Location = request.Location;
                await this.context.SaveChangesAsync();

                return Ok(await this.context.Companies.ToListAsync());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Company>>> DeleteCompany(int id)
        {
            var company = await this.context.Companies.FindAsync(id);
            if(company == null)
            {
                return BadRequest("Company Not Found.");
            }
            else
            {
                this.context.Companies.Remove(company);
                await this.context.SaveChangesAsync();
                return Ok(await this.context.Companies.ToListAsync());
            }
        }
    }
}
