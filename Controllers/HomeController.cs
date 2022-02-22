using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moment32.Data;
using moment32.Models;

namespace moment32.Controllers;

public class HomeController : Controller
{
    private readonly RecordContext _context;

        public HomeController(RecordContext context)
        {
            _context = context;
        }

    // View for all albums
    public async Task<IActionResult> Index()
    {
        List<Artist>? Artists = await _context.Artist.ToListAsync();
        List<Record>? Records = await _context.Record.ToListAsync();
        List<Renting>? Renting = await _context.Renting.ToListAsync();
        List<Song>? Song = await _context.Song.ToListAsync();
        List<User>? User = await _context.User.ToListAsync();

        ViewBag.Artists = Artists;
        ViewBag.Records = Records;
        ViewBag.Renting = Renting;
        ViewBag.Songs = Song;
        ViewBag.Users = User;
        
        return View();
    }

    // View for posted search
    [HttpPost]
     public async Task<IActionResult> Search(string Search){

        string search = Search.ToLower();
        var artists = from a in _context.Artist select a;
        var records = from r in _context.Record select r;

        if (!String.IsNullOrEmpty(Search)){
            artists = artists.Where(s => s.ArtistName!.ToLower().Contains(Search));
            records = records.Where(s => s.RecordName!.ToLower().Contains(Search));
        }
        ViewBag.Artists = await artists.ToListAsync();
        ViewBag.Records = await records.ToListAsync();
        ViewBag.Search = Search;
        
        return View();
    }


}
