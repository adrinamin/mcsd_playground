using System.Collections;
using DataStore.Model;
using MongoDB.Bson;

namespace DataStore.Repository
{
    public class BudgetRepository
    {
        public IEnumerable GetAllBudgets()
        {
            return new ArrayList();
        }

        public void AddBudget(Budget budget)
        {

        }

        public void UpdateBudgetAmount(int amount)
        {

        }

        public void UpdateBudgetName(string name)
        {

        }

        public void DeleteBudget(ObjectId id)
        {
            
        }
    }
}