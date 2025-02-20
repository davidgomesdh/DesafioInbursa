using Application.DTOs;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesafioInbursa.Controllers
{
    [ApiController]
    [Route("api/loans")]
    [Produces("application/json")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        /// <summary>
        /// Simula um empréstimo com base na Tabela Price.
        /// </summary>
        /// <param name="loan">Dados da simulação do empréstimo.</param>
        /// <returns>Detalhamento das parcelas e valores totais.</returns>
        /// <response code="200">Retorna os detalhes do empréstimo simulado.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        [HttpPost("simulate")]
        [ProducesResponseType(typeof(LoanSimulationResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SimulateLoan([FromBody] LoanViewModel loan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var simulationResult = await _loanService.SimulateLoanAsync(loan);
            return Ok(simulationResult);
        }
    }
}
