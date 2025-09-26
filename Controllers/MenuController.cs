using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OIT_Startup_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Richiede autenticazione per tutti gli endpoint
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MenuGroupDto>>> GetMenuStructure()
        {
            var menu = await _menuService.GetMenuStructureAsync();
            return Ok(menu);
        }

        [HttpGet("groups/{id}")]
        public async Task<ActionResult<MenuGroupDto>> GetMenuGroup(int id)
        {
            var group = await _menuService.GetMenuGroupAsync(id);
            if (group == null)
                return NotFound();

            return Ok(group);
        }

        [HttpGet("items/{id}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItem(int id)
        {
            var item = await _menuService.GetMenuItemAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost("groups")]
        public async Task<ActionResult<MenuGroupDto>> CreateMenuGroup(CreateMenuGroupDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var group = await _menuService.CreateMenuGroupAsync(dto);
            return CreatedAtAction(nameof(GetMenuGroup), new { id = group.Id }, group);
        }

        [HttpPost("items")]
        public async Task<ActionResult<MenuItemDto>> CreateMenuItem(CreateMenuItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _menuService.CreateMenuItemAsync(dto);
            return CreatedAtAction(nameof(GetMenuItem), new { id = item.Id }, item);
        }

        [HttpPut("groups/{id}")]
        public async Task<ActionResult<MenuGroupDto>> UpdateMenuGroup(int id, CreateMenuGroupDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var group = await _menuService.UpdateMenuGroupAsync(id, dto);
            if (group == null)
                return NotFound();

            return Ok(group);
        }

        [HttpPut("items/{id}")]
        public async Task<ActionResult<MenuItemDto>> UpdateMenuItem(int id, UpdateMenuItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _menuService.UpdateMenuItemAsync(id, dto);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpDelete("groups/{id}")]
        public async Task<IActionResult> DeleteMenuGroup(int id)
        {
            var result = await _menuService.DeleteMenuGroupAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("items/{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var result = await _menuService.DeleteMenuItemAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("groups/reorder")]
        public async Task<IActionResult> ReorderMenuGroups([FromBody] Dictionary<int, int> orderMap)
        {
            await _menuService.ReorderMenuGroupsAsync(orderMap);
            return Ok();
        }

        [HttpPut("items/reorder")]
        public async Task<IActionResult> ReorderMenuItems([FromBody] Dictionary<int, int> orderMap)
        {
            await _menuService.ReorderMenuItemsAsync(orderMap);
            return Ok();
        }
    }

}