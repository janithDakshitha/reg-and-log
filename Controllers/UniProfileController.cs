using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    
    public class UniProfileController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment; //get the access of service environment
        private readonly UniProfileDbContext _context;//access the database

        public UniProfileController(UniProfileDbContext context, IWebHostEnvironment webHost) //supply dependency injection
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        [HttpGet]
        public IActionResult Create() //create uniProfileModel varable and pass variable to the view
        {
            UniProfileModel uniProfileModel = new UniProfileModel();
            return View(uniProfileModel);
        }

        [HttpPost]
        public ActionResult Create(UniProfileModel uniProfileModel) //recive the fillup uniprofilemodel from the submited form of the webbrowser and will be saved the database
        {
            string uniqueFileName = UploadedFile(uniProfileModel);
            uniProfileModel.ProfilPic_URL = uniqueFileName;

            _context.Attach(uniProfileModel);//attach the model to the Dbcontext and the change of the state of the model to entitystate.added.
            _context.Entry(uniProfileModel).State = EntityState.Added;
            _context.SaveChanges();//then call the context.SaveChanges() method to add the record to the database
            return RedirectToAction(nameof(Index));//then call the index action to list the image record 

        }
        private string UploadedFile(UniProfileModel uniProfileModel) //function for save the uploaded binary stream of the uniprofilemodel in th images folder inside the wwwroot folder. afer that method will return the unique file name of the  image to the function
        {
            string uniqueFileName = null;
            if (uniProfileModel.UploadedProfilePic != null)//check the usser has uploaded a file or not
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "profilepics");//if the user uploaded the file then we get the root path of the hosting directory this will return the path of the wwwroot folder. aftre that we add the image to the webrrot path since we want to store the file in the images folder
                uniqueFileName = Guid.NewGuid().ToString() + "_" + uniProfileModel.UploadedProfilePic.FileName;//gigvinga a nuique file name to save the file so we use Guid.NewGuid method to get a new guid(globally unique identifier)
                string filepath = Path.Combine(uploadsFolder, uniqueFileName);//use the path.combine method to combine the file name with the uploaded folder name
                using (var fileStream = new FileStream(filepath, FileMode.Create))//save the uploaded file to the images folder using copyto method of the iform file interface
                {
                    uniProfileModel.UploadedProfilePic.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult Index()
        {
            List<UniProfileModel> uniProfileModels;//create a list of type uniprofilemodel and set that list to _context.Uniprofiles.Tolist
            uniProfileModels = _context.UniProfiles.ToList();
            return View(uniProfileModels);//then pass the list to the view to display on the screen 
        }

        public IActionResult Degree()
        {
            IEnumerable<DegreeModel> DegreeList = _context.Degrees.ToList();
            return View(DegreeList);
        }
        public IActionResult DegreeCreate()
        {
            return View();


        }


        //degree create



        //POST action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DegreeCreate(DegreeModel obj)
        {

            _context.Degrees.Add(obj);
            _context.SaveChanges();

            return View(obj);
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            UniProfileModel uniProfileModel = _context.UniProfiles.Where(c => c.Uni_ID == Id).FirstOrDefault();
            
            return View(uniProfileModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(UniProfileModel uniProfileModel)
        {
            if (uniProfileModel.UploadedProfilePic != null)
            {
                string uniqueFileName = UploadedFile(uniProfileModel);
                uniProfileModel.ProfilPic_URL = uniqueFileName;
            }
            _context.Attach(uniProfileModel);
            _context.Entry(uniProfileModel).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            UniProfileModel uniProfileModel = _context.UniProfiles.Where(c => c.Uni_ID == Id).FirstOrDefault();
            return View(uniProfileModel);
        }



        public IActionResult Degree1(int Id)
        {
            IEnumerable<DegreeModel> DegreeList = _context.Degrees.Where(c => c.Uni_ID == Id).ToList()/*.FirstOrDefault()*/;
            return View(DegreeList);


        }

    }
}
