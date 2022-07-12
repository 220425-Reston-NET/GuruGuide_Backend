using GuruGuideDL;
using GuruGuideModles;

namespace GuruGuideBL
{
    public class CoachesBL : ICoachesBL
    {
        private IRepository<Coaches> _CoachesRepo;

        public CoachesBL(IRepository<Coaches> c_CoachesRepo)
        {
            _CoachesRepo = c_CoachesRepo;
        }

   public async void AddCoaches (Coaches c_Coaches)
        {
            Coaches foundedCoaches = SearchCoachesByUserName(c_Coaches.CUserName, c_Coaches.CPassword);
            if (foundedCoaches == null)    
            {
                _CoachesRepo.Add(c_Coaches);
            }
            else
            {
                throw new Exception("Coache UserName already exist!!");
            }
        }
        public List<Coaches> GetCoaches()
        {
            return _CoachesRepo.GetAll();
        }

        public Coaches SearchCoachesByAddress(string c_CoachesCAddress)
        {
            List<Coaches> currentListOfCoaches = _CoachesRepo.GetAll();
           
           foreach (Coaches custobj in currentListOfCoaches)
           {
               if (custobj.CAddress == c_CoachesCAddress)
               {
                   return custobj;
               }
           }
           
                return null;
        }

        public Coaches SearchCoachesBySpecialization(string c_CoachesAreaOfSpecialization)
        {
           List<Coaches> currentListOfCoaches = _CoachesRepo.GetAll();
           
           foreach (Coaches custobj in currentListOfCoaches)
           {
               if (custobj.AreaOfSpecialization == c_CoachesAreaOfSpecialization)
               {
                   return custobj;
               }
           }
           
                return null;
        }

        public Coaches SearchCoachesByState(string c_CoachesState)
        {
              List<Coaches> currentListOfCoaches = _CoachesRepo.GetAll();
           
           foreach (Coaches custobj in currentListOfCoaches)
           {
               if (custobj.CState == c_CoachesState)
               {
                   return custobj;
               }
           }
           
                return null;
        }

        public Coaches SearchCoachesByUserName(string c_CoachesUserName, string c_password)
        {
           List<Coaches> currentListOfCoaches = _CoachesRepo.GetAll();
           
           foreach (Coaches custobj in currentListOfCoaches)
           {
               if (custobj.CUserName == c_CoachesUserName && custobj.CPassword == c_password)
               {
                   return custobj;
               }
           
            }
                return null;
        }
    }
}