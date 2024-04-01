using MathQuestAPI.Repository;
using MathQuestCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MathQuestAPI.Controllers
{
    [Route("utilisateurs")]
    [ApiController] // Ajoutez cet attribut
    public class UtilisateurController : ControllerBase
    {
        private readonly IRepository<Utilisateur> _utilisateurRepository;
        private readonly IRepository<Lecon> _leconRepository;


        public UtilisateurController(IRepository<Utilisateur> utilisateurRepository, IRepository<Lecon> leconRepository)
        {
            _utilisateurRepository = utilisateurRepository;
            _leconRepository = leconRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ToutLesUtilisateurs()
        {
            var utilisateurs = await _utilisateurRepository.GetAll();

            return Ok(utilisateurs);
        }



        [HttpGet("{utilisateurId}")]
        public async Task<IActionResult> ChercherUnUtilisateur(int utilisateurId)
        {
            var utilisateur = await _utilisateurRepository.GetById(utilisateurId);

            if (utilisateur != null)
            {
                return Ok(utilisateur);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> AjoutUtilisateur([FromBody] Utilisateur utilisateur)
        {
            var dejaUtilisateur = await _utilisateurRepository.Get(u => u.Pseudo == utilisateur.Pseudo);
            if (dejaUtilisateur != null)
            {
                return BadRequest("Un utilisateur avec ce Pseudo existe déjà.");
            }


            var utilisateurId = await _utilisateurRepository.Add(utilisateur);


            if (utilisateurId > 0)
                return CreatedAtAction(nameof(ToutLesUtilisateurs), "Utilisateur ajouter");

            return BadRequest("Oh oh ... des problèmes");
        }



        [HttpPut("{utilisateurId}")]
        public async Task<IActionResult> UpdateUtilisateur(int utilisateurId, [FromBody] Utilisateur utilisateur)
        {
            var util = await _utilisateurRepository.GetById(utilisateurId);
            if (util == null)
                return BadRequest("Utilisateur introuvable");

            utilisateur.UtilisateurId = utilisateurId;
            if (await _utilisateurRepository.Update(utilisateur))
                return Ok("Utilisateur mis à jours");

            return BadRequest("Oh oh ... des problèmes");
        }



        [HttpDelete("{utilisateurId}")]
        public async Task<IActionResult> RetraitUtilisateur(int utilisateurId)
        {
            var util = await _utilisateurRepository.GetById(utilisateurId);
            if (util == null)
                return BadRequest("Utilisateur introuvable");

            if (await _utilisateurRepository.Delete(utilisateurId))
                return Ok("Utilisateur retirer");

            return BadRequest("Oh oh ... des problèmes");
        }


    }
}
