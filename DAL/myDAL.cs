using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class myDAL : IDAL
    {
        public bool addTrainee(Trainee trainee)
        {
            foreach (var item in DataSource.Trainees)
            {
                if (item.ID == trainee.ID)
                    return false;
            }
            DataSource.Trainees.Add(trainee.Clone());
            return true;
        }

        public List<Trainee> getAllTrainees()
        {
            List<Trainee> result = new List<Trainee>();
            foreach (var item in DataSource.Trainees)
            {
                result.Add(item.Clone());
            }
            return result;
        }

        public bool removeTrainee(Trainee trainee)
        {
            foreach (var item in DataSource.Trainees)
            {
                if (item.ID == trainee.ID)
                    return DataSource.Trainees.Remove(item);
            }
            return false;
        }
    }
}
