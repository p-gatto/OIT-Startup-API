using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IAuthService _authService;
        private readonly ILogger<GroupsController> _logger;

        public GroupsController(
            IGroupService groupService,
            IAuthService authService,
            ILogger<GroupsController> logger)
        {
            _groupService = groupService;
            _authService = authService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupDto>>> GetGroups()
        {
            try
            {
                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "Group", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per visualizzare i gruppi di sicurezza");
                }

                var groups = await _groupService.GetGroupsAsync();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting security groups");
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetGroup(int id)
        {
            try
            {
                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "Group", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per visualizzare questo gruppo di sicurezza");
                }

                var group = await _groupService.GetGroupByIdAsync(id);
                if (group == null)
                    return NotFound(new { message = "Gruppo di sicurezza non trovato" });

                return Ok(group);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting security group {GroupId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<GroupDto>> CreateGroup([FromBody] CreateGroupDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "Group", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per creare gruppi di sicurezza");
                }

                var group = await _groupService.CreateGroupAsync(dto);
                _logger.LogInformation(" group {GroupName} created by user {UserId}", dto.Name, userId);

                return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, group);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating security group");
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroupDto>> UpdateGroup(int id, [FromBody] UpdateGroupDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "Group", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per modificare gruppi di sicurezza");
                }

                var group = await _groupService.UpdateGroupAsync(id, dto);
                if (group == null)
                    return NotFound(new { message = "Gruppo di sicurezza non trovato" });

                _logger.LogInformation("Securtiy group {GroupId} updated by user {UserId}", id, userId);
                return Ok(group);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating security group {GroupId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            try
            {
                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "Group", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per eliminare gruppi di sicurezza");
                }

                var success = await _groupService.DeleteGroupAsync(id);
                if (!success)
                    return NotFound(new { message = "Gruppo di sicurezza non trovato" });

                _logger.LogInformation("Security group {GroupId} deleted by user {UserId}", id, userId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting security group {GroupId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpGet("permissions")]
        public async Task<ActionResult<List<PermissionDto>>> GetPermissions()
        {
            try
            {
                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "Group", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per visualizzare i permessi");
                }

                var permissions = await _groupService.GetPermissionsAsync();
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting permissions");
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpPost("permissions")]
        public async Task<ActionResult<PermissionDto>> CreatePermission([FromBody] CreatePermissionDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Verifica permessi (solo admin di sistema)
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "System", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per creare permessi");
                }

                var permission = await _groupService.CreatePermissionAsync(dto);
                _logger.LogInformation("Permission {PermissionName} created by user {UserId}", dto.Name, userId);

                return CreatedAtAction(nameof(GetPermissions), permission);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating permission");
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpDelete("permissions/{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            try
            {
                // Verifica permessi (solo admin di sistema)
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "System", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per eliminare permessi");
                }

                var success = await _groupService.DeletePermissionAsync(id);
                if (!success)
                    return NotFound(new { message = "Permesso non trovato" });

                _logger.LogInformation("Permission {PermissionId} deleted by user {UserId}", id, userId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting permission {PermissionId}", id);
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

        [HttpPut("{id}/permissions")]
        public async Task<IActionResult> AssignPermissions(int id, [FromBody] AssignPermissionsDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Verifica permessi
                var userId = GetCurrentUserId();
                var hasPermission = await _authService.HasPermissionAsync(userId, "Group", "Manage");
                if (!hasPermission)
                {
                    return Forbid("Permessi insufficienti per assegnare permessi");
                }

                var success = await _groupService.AssignPermissionsToGroupAsync(id, dto.PermissionIds);
                if (!success)
                    return NotFound(new { message = "Gruppo di sicurezza non trovato" });

                _logger.LogInformation("Permissions assigned to security group {GroupId} by user {UserId}", id, userId);
                return Ok(new { message = "Permessi assegnati con successo" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning permissions to security group {GroupId}", id);
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

    public class AssignPermissionsDto
    {
        [Required]
        public List<int> PermissionIds { get; set; } = new();
    }

}
