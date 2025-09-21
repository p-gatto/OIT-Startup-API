using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Richiede autenticazione per tutti gli endpoint
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, IAuthService authService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _authService = authService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            try
            {
                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "User", "Read");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per visualizzare gli utenti");
                }

                var users = await _userService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users");
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            try
            {
                // Verifica permessi
                var currentUserId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(currentUserId, "User", "Read");

                // Permetti agli utenti di vedere i propri dati
                if (!hasPermission && currentUserId != id)
                {
                    return Forbid("Permessi insufficienti per visualizzare questo utente");
                }

                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound(new { message = "Utente non trovato" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user {UserId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "User", "Create");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per creare utenti");
                }

                var user = await _userService.CreateUserAsync(dto);
                _logger.LogInformation("User {Username} created by user {CreatorId}", dto.Username, userId);

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Verifica permessi
                var currentUserId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(currentUserId, "User", "Update");

                // Permetti agli utenti di modificare i propri dati (limitatamente)
                if (!hasPermission && currentUserId != id)
                {
                    return Forbid("Permessi insufficienti per modificare questo utente");
                }

                // Se l'utente modifica se stesso, limita le modifiche possibili
                if (currentUserId == id && !hasPermission)
                {
                    // Rimuovi campi che solo gli admin possono modificare
                    dto.IsActive = null;
                    dto.EmailConfirmed = null;
                    dto.GroupIds = null;
                }

                var user = await _userService.UpdateUserAsync(id, dto);
                if (user == null)
                    return NotFound(new { message = "Utente non trovato" });

                _logger.LogInformation("User {UserId} updated by user {UpdaterId}", id, currentUserId);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user {UserId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "User", "Delete");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per eliminare utenti");
                }

                // Non permettere l'auto-eliminazione
                if (userId == id)
                {
                    return BadRequest(new { message = "Non puoi eliminare il tuo stesso account" });
                }

                var success = await _userService.DeleteUserAsync(id);
                if (!success)
                    return NotFound(new { message = "Utente non trovato" });

                _logger.LogInformation("User {UserId} deleted by user {DeleterId}", id, userId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user {UserId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpPost("{id}/reset-password")]
        public async Task<IActionResult> ResetPassword(int id, [FromBody] ResetPasswordDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "User", "Update");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per resettare password");
                }

                var success = await _userService.ResetPasswordAsync(id, dto.NewPassword);
                if (!success)
                    return NotFound(new { message = "Utente non trovato" });

                _logger.LogInformation("Password reset for user {UserId} by user {AdminId}", id, userId);
                return Ok(new { message = "Password resettata con successo" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error resetting password for user {UserId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpPut("{id}/security-groups")]
        public async Task<IActionResult> AssignSecurityGroups(int id, [FromBody] AssignSecurityGroupsDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "SecurityGroup", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per gestire gruppi di sicurezza");
                }

                var success = await _userService.AssignGroupsAsync(id, dto.SecurityGroupIds);
                if (!success)
                    return NotFound(new { message = "Utente non trovato" });

                _logger.LogInformation("Security groups assigned to user {UserId} by user {AdminId}", id, userId);
                return Ok(new { message = "Gruppi di sicurezza assegnati con successo" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning security groups to user {UserId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new UnauthorizedAccessException("Token non valido");
            }
            return userId;
        }
    }

    public class ResetPasswordDto
    {
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = string.Empty;
    }

    public class AssignSecurityGroupsDto
    {
        [Required]
        public List<int> SecurityGroupIds { get; set; } = new();
    }

}
