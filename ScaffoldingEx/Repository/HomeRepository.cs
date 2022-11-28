using ScaffoldingEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScaffoldingEx.Repository
{
    public interface IHomeRepository
    {
        void SeacrhAvenger();
        void SeacrhItem();
        IEnumerable<ModelAven> Results(string fName);
        string LinkResults();
        IEnumerable<ModelAven> SendAsJson(string name);
        IEnumerable<ModelAven> GetTable();
    }
    public class HomeRepository : IHomeRepository
    {

        private ModelAvenContext db;
        public ModelAvenContext dbEntities
        {
            get { return db; }
            set { db = value; }
        }
        public HomeRepository(ModelAvenContext dbcontext)
        {
            db = dbcontext;
        }
        public void SeacrhAvenger()
        {
            db.modelAvens.Select(x => x.HeroName).Distinct();
        }

        public void SeacrhItem()
        {
            db.modelAvens.Select(x => x.HeroName).Distinct();
        }

        public IEnumerable<ModelAven> Results(string fName)
        {
            return db.modelAvens.Where(x => x.Name.Contains(fName)).ToList();
        }

        public string LinkResults()
        {
            return db.modelAvens.Select(x => x.HeroName).Distinct().ToString();
        }

        public IEnumerable<ModelAven> SendAsJson(string name)
        {
            return db.modelAvens.Where(x => x.Name.Contains(name)).ToList();
        }


        public IEnumerable<ModelAven> GetTable()
        {
            return db.modelAvens.ToList();
        }

    }
}